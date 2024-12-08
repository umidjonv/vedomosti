
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Vedy.SignService.Models;


namespace Vedy.Services
{
    internal class RemoteService :IRemoteService
    {
        private HubConnection hubConnection;
        private Action<SignModel> _receiverFunc;
        private Action _closeFunc;

        public void Connect(string url)
        {
            hubConnection = new HubConnectionBuilder()
                .WithUrl($"{url}vedy")
                .Build();
            hubConnection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await hubConnection.StartAsync();
            };
        }

        

        public async Task Initialize()
        {
            hubConnection.On<SignModel>("SignStarting", async message =>
            {
                await Receive(message);

            });

            hubConnection.On("CloseWindow", async () =>
            {
                _closeFunc();

            });


            try
            {
                // Start the connection
                await hubConnection.StartAsync();
                //MessageBox.Show("Connected to SignalR Hub!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not connect to SignalR Hub: " + ex.Message);
            }
        }

        public void SetReceiver(Action<SignModel> receiverFunc)
        {
            _receiverFunc = receiverFunc;
        }

        public void SetCloser(Action closeFunc)
        {
            _closeFunc = closeFunc;
        }

        public async Task Receive(SignModel model)
        {
            _receiverFunc(model);
        }

        public async Task<bool> Send(SignModelResponse message)
        {
            try
            {
                await hubConnection.InvokeAsync("SignComplete", message); // "SendMessage" is the method name on the server
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending message: " + ex.Message);
                return false;
            }
        }

    }
}
