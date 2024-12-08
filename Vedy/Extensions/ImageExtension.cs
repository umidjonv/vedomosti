using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Vedy.Extensions
{
    public static class ImageExtension
    {
        public static Image ConvertToImage(this byte[] bytes)
        {
            using (MemoryStream ms = new MemoryStream(bytes)) 
            {
                return Image.FromStream(ms);
            }
        }
    }
}
