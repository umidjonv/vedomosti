using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vedy.SignService.Models;

namespace Vedy.Services
{
    public interface IRemoteService
    {
        Task Initialize();

        void Connect(string url);

        Task<bool> Send(string message);

        void SetReceiver(Action<SignModel> recieverFunc);

        Task Receive(SignModel model);
    }
}
