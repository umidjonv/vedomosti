using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Vedy.Abstractions;
using Vedy.Common.DTOs.Sign;
using Vedy.Consts;

namespace Vedy.Services
{
    public class SignService
    {
        HubConnection connection;
        public SignService() 
        {
            connection = new HubConnectionBuilder()
                .WithUrl($"{AppConsts.API_URL}vedy")
                .Build();

            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };

            

        }

        public async Task Connect<T>(T form, Func<SignModelResponse, Task> signedMethod) where T : BaseForm
        {
            connection.On<SignModelResponse>("CompleteSign", async (signModel) =>
            {
                await form.ReceiveMessage<SignModelResponse>(signModel, signedMethod);
            });

            connection.On<SignModel>("StartSign", (signModel) =>
            {
                MessageBox.Show("CALABUNGA!");
            });

            //connection.On<SignModel>("SignStarting", (signModel) =>
            //{
            //    MessageBox.Show("CALABUNGA!");
            //});

            try
            {
                await connection.StartAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public async Task StartSign(SignModel model)
        {
            try
            {
                

                await connection.InvokeAsync("StartSign", model);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
