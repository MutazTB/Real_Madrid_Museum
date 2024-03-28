using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TeamMuseum.Services.Enums.Enums;

namespace TeamMuseum.Services.Dtos
{
    public class ReturnResult
    {
        public bool IsSuccess { get; set; }
        public ResultStatus Status { get; set; }
        public string ErrorMessage { get; set; }
        public object Data { get; set; }
    }
}
