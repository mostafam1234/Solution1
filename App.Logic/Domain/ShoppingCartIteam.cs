using App.Logic.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Logic
{
    public class ShoppingCartItem
    {
        
        public int Id { get; set; }
        public PieDto Pie { get; set; }
        public int Quantity { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
