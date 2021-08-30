using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.ui.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name ="ConfirmPassword")]
        [Compare("Password",ErrorMessage ="Password and ConfirmPassword Don,t Match")    ]
        public string ConfirmPassword { get; set; }
    }
}
