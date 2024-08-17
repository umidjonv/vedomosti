using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vedy.Models
{
    public class PaginationModel<T>
    {
        public List<T> Items { get; set; }

        public int PageIndex { get; set; } 
        public int PageSize { get; set; } = 100;
        public int PageCount { get; set; }
    }
}
