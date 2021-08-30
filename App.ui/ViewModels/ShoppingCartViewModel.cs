using App.Logic;
using App.ui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.ui.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();
        public decimal ShoppingCartTotal { get; set; }

    }

    

    
        
    
}
