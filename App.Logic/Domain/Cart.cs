using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Logic.Domain
{
    public class Cart
    {
        public string CarrtId { get; private set; }
        public List<ShoppingCartItem> Items { get; private set; } = new List<ShoppingCartItem>();
        public decimal CartTotal { get;private set; }
        private Cart()
        {
            
        }
        public static Result<Cart> Instance(string CartId,List<ShoppingCartItem>Cartitems)
        {
            var Cart = new Cart
            {
                CarrtId = CartId,
                Items = Cartitems,
            };
            Cart.CartTotal = CalCTotal(Cart);
            return Result.Success(Cart);
        }

        public bool IsExsist(int id)
        {
            return Items.Any(x => x.Pie.PieId==id);
        }


        public static decimal CalCTotal(Cart cart)
        {
            if (cart.Items == null)
            {
               cart. CartTotal = 0;
            }
            else
            {
              cart. CartTotal =cart.Items.Sum(x => x.Pie.Price * x.Quantity);
            }
           
            return cart.CartTotal;
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
                item.DecreaseQuantity();
            }
            else
            {
                Items.Remove(item);
            }
        }
        public void AddToCart(int id)
        {
            var item = Items.Find(x => x.Pie.PieId == id);
            if (IsExsist(id))
            {
                item.IncreaseQuantity();
            }
            else
            {
                Items.Add(item);
            }
            
        }

        public void ClearCart()
        {

            Items.Clear();
            
        }

    }
}
