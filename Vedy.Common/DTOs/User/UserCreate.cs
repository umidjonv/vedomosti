using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vedy.Common.Enums;

namespace Vedy.Common.DTOs.User
{
    public class UserCreate
    {
        public string FullName { get; set; }

        public UserRole Role { get; set; }
    }
}
