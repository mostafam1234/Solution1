using App.DataAccess;
using App.Logic;
using App.services.ShoppingCartServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ShoppingCartServices.services
{
    public class ShoppingCartServe:IShoppingCartServices
    {
        private readonly ApplicationDbContext _Context;

        public ShoppingCartServe(ApplicationDbContext context)
        {
            _Context = context;
        }
        public void AddToCart(Pie pie,string cartid)
        {
            var item = _Context.items.FirstOrDefault
                (x => x.Pie.PieId == pie.PieId &&
                 x.ShoppingCartId == cartid);
            if (item == null)
            {
                item = ShoppingCartItem.Instance(pie, 1, cartid).Value;
                _Context.items.Add(item);
            }
            else
            {
                item.IncreaseQuantity();
            }
            _Context.SaveChanges();
        }


        public void RemoveFromCart(Pie pie,string cartid)
        {
            var item = _Context.items.FirstOrDefault
               (x => x.Pie.PieId == pie.PieId &&
                x.ShoppingCartId == cartid);
            if (item.Quantity > 1)
            {
                item.DecreaseQuantity();
            }
            else
            {
                _Context.items.Remove(item);
            }
            _Context.SaveChanges();
        }
        public List<ShoppingCartItem> GetCartItems(string CartId)
        {
            var items = _Context.items.Include(x => x.Pie).Where(x => x.ShoppingCartId == CartId).ToList();
            return items;
        }
        public void ClearCart(string CartId)
        {
            var items = _Context.items.Where(x => x.ShoppingCartId == CartId);
            _Context.items.RemoveRange(items);
            _Context.SaveChanges();
        }

    }
}
