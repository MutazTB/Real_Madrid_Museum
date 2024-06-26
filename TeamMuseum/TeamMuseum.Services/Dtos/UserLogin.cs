﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamMuseum.Services.Dtos
{
    public class UserLogin
    {
        [Required(ErrorMessage = "Username is required!")]
        [Display(Name = "User Name")]
        [MinLength(3)]
        public string UserName { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
