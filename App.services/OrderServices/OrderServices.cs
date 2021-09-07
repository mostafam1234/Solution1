using App.DataAccess;
using App.Logic.Domain;
using App.services.OrderServices;
using App.services.Pie_services;
using App.services.ShoppingCartServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.services.OrderServices
{
    public class OrderServices: IOrderServices
    {
        private ApplicationDbContext _Context;
        private IPieServices _PieServices;
        private readonly IShoppingCartServices _CartServices;

        public OrderServices(ApplicationDbContext context,IPieServices pieServices,IShoppingCartServices cartServices)
        {
            _Context = context;
            _PieServices = pieServices;
            _CartServices = cartServices;
        }
        public void CreateOrder(Cart ShoppingCart, Order order)
        {
            
            order.OrderPlaced = DateTime.Now;
            
            foreach(var item in ShoppingCart.Items)
            {
                var pie = _PieServices.GetPieById(item.Pie.PieId);
                var orderdetail = OrderDetail.Instance( item.Quantity, pie).Value;
                order.AddOrderDetails(orderdetail);
            }
            order.CalculateOrderTotal();
            _Context.orders.Add(order);
            _CartServices.ClearCart(ShoppingCart.CarrtId);
            _Context.SaveChanges();
        }
    }
}
