using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CPE4_SoftDev3_2627_1stSem_Tolentino.Shared.Datas
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "The Name field is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Username field is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "The Email field is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The Password field is required")]
        public string Password { get; set; }
    }
}