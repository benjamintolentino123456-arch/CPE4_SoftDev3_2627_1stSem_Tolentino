using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CPE4_SoftDev3_2627_1stSem_Tolentino.Shared.Datas
{
    public class LoginModel
    {
        [Required(ErrorMessage = "The Username field is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "The Password field is required")]
        public string Password { get; set; }
        public object Email { get; set; }
    }
}
