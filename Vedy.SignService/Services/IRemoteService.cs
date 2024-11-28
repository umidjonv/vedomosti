using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vedy.Services
{
    public interface IRemoteService
    {
        Task Initialize();

        void Connect(string url);

        Task<bool> Send(string message); 
    }
}
