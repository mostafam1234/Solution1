using App.Logic.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.services.OrderServices
{
    public interface IOrderServices
    {
        void CreateOrder(Cart ShoppingCart, Order order);
    }
}
