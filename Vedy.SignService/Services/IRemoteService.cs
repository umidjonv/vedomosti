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

        Task<bool> Send(SignModelResponse message);

        void SetReceiver(Action<SignModel> recieverFunc);
        void SetCloser(Action closerFunc);

        Task Receive(SignModel model);
    }
}
