
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Logic
{
    public class ShoppingCartItem
    {
        
        public int Id { get;private set; }
        public  Pie Pie { get;private set; }
        public int Quantity { get;private set; }
        public string ShoppingCartId { get;private set; }
        private ShoppingCartItem()
        {

        }
        public static Result<ShoppingCartItem> Instance(Pie pie ,int Quantity,string ShoppingCartId)
        {
            if (Quantity <1)
            {
                Result.Failure<ShoppingCartItem>("Quantity can,t be less than one");
            }

            var CartItem = new ShoppingCartItem
            {
                Pie=pie,
                Quantity = Quantity,
                ShoppingCartId=ShoppingCartId
            };
            return Result.Success(CartItem);
        }
        public void DecreaseQuantity()
        {
            this.Quantity--;
        }
        public void IncreaseQuantity()
        {
            this.Quantity++;
        }

    }

}
