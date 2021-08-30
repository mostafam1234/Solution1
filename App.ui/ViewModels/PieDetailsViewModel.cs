using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.ui.ViewModels
{
    public class PieDetailsViewModel
    {
        public int PieId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal  Price { set; get; }
        public string ImageUrl { get; set; }
    }
}
