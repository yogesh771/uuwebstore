using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UUWebstore.Models.viewModels
{
    public class viewModel
    {
    }
    public class LoginIdViewModel
    {
        [Required]      
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

    }
}