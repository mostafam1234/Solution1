using App.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.services.ShoppingCartServices
{
    public interface IShoppingCartServices
    {
        void AddToCart(Pie pie, string cartid);
        public void RemoveFromCart(Pie pie, string cartid);
        List<ShoppingCartItem> GetCartItems(string CartId);
        void ClearCart(string CartId);
    }
}
