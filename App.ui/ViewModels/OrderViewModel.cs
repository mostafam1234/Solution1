using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.ui.ViewModels
{
    public class OrderViewModel
    {
            [Required(ErrorMessage = "Please enter your address")]
            [StringLength(100)]
            [Display(Name = "Address ")]
            public string Address { get; set; }


            [Required(ErrorMessage = "Please enter your city")]
            [StringLength(50)]
            public string City { get; set; }


            
            

            [Required(ErrorMessage = "Please enter your country")]
            [StringLength(50)]
            public string Country { get; set; }

            [Required(ErrorMessage = "Please enter your phone number")]
            [StringLength(25)]
            [DataType(DataType.PhoneNumber)]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }        

    }







}
