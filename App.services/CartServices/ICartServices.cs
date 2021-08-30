using App.Logic;
using App.Logic.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.services.CartServices
{
    public  interface ICartServices
    {
        Cart AddtoCart(int id, Cart shoppingCart);
        
    }
}
