using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Logic.Domain
{
    public class Cart
    {
        public string CarrtId { get;  set; }
        public List<ShoppingCartItem> Items { get;  set; } = new List<ShoppingCartItem>();
        public decimal CartTotal { get;private set; }

        public bool IsExsist(int id)
        {
            return Items.Any(x => x.Pie.PieId == id);
        }


        public decimal CalCTotal()
        {
            CartTotal = Items.Sum(x => x.Pie.Price * x.Quantity);
            return CartTotal;
        }
        public ShoppingCartItem FindItem(int id)
        {
            var item = Items.Find(x => x.Pie.PieId == id);
            return item;
        }
        public void RemoveFromCart( int id)
        {
            var item = Items.Find(x=>x.Pie.PieId==id);
            if (item.Quantity > 1)
            {
                item.Quantity--;
            }
            else
            {
                Items.Remove(item);
            }
            
        }

        public void ClearCart()
        {

            Items.Clear();
            
        }

    }
}
