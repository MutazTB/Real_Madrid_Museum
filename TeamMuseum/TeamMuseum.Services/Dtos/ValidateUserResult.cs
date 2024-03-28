using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamMuseum.Services.Dtos
{
    public class ValidateUserResult
    {
        public bool IsValid { get; set; }
        public UserInfo UserInfo { get; set; }
    }
}
