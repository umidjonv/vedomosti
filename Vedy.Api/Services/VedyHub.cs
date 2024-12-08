using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Vedy.Common.DTOs.Sign;
namespace Vedy.Infrastructure.Services
{
    public class VedyHub : Hub
    {
        public async Task StartSign(SignModel model)
        => await Clients.All.SendAsync("SignStarting", model);

        public async Task SignComplete(SignModelResponse model)
        => await Clients.All.SendAsync("SignComplete", model);

        public async Task CloseSignWindow()
            => await Clients.All.SendAsync("CloseWindow");

    }
}
