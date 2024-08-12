using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vedy.Common.BaseModels
{
    public class BaseResponse
    {
        public object? Data { get; set; }

        public bool IsSuccess { get; set; }

        public ErrorModel? Error { get; set; }


    }

    public class ErrorModel 
    {
        public string Message { get; set; }

        public int ErrorCode { get; set; }
    }
}
