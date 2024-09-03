using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vedy.Extensions
{
    public static class TokenExtension
    {

        public static CancellationToken GetToken()
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            return tokenSource.Token;
        }
    }
}
