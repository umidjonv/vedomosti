using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vedy.Abstractions
{
    public class BaseForm : Form
    {
        public async Task ReceiveMessage<T>(T model, Func<T, Task> receiveMethod) where T : class 
        {
            await receiveMethod.Invoke(model);
        }
    }
}
