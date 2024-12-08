using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vedy.SignService.Models
{
    public class RemoteModel
    { 
    }

    public class SignModel: RemoteModel
    {
        public int CustomerEntryId { get; set; }

        public string FullName { get; set; }
    }
    
    public class SignModelResponse: RemoteModel
    {
        public int CustomerEntryId { get; set; }

        public string FullName { get; set; }

        public string Image {  get; set; }
    }
}
