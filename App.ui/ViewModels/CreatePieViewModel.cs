using App.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.ui.ViewModels
{
    public class CreatePieViewModel
    {
        public CreatePieViewModel()
        {
            categories = new List<Category>();
        }
        [Required(ErrorMessage ="The Name IS Required")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage ="Please Enter The Price")]
        public decimal Price { set; get; }

        [Required(ErrorMessage = "The Category is required")]
        public IEnumerable<Category> categories { set; get; } 
        public bool IsPieOfTheWeek { set; get; }
        public bool InStock { set; get; }
        public int CategorId { get; set; }
       
    }
}
