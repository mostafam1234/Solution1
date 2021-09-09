using App.DataAccess;
using App.Logic.Domain;
using App.services.OrderServices;
using App.services.Pie_services;
using App.services.ShoppingCartServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.services.OrderServices
{
    public class OrderServices: IOrderServices
    {
        private ApplicationDbContext _Context;
        private IPieServices _PieServices;
        private readonly IShoppingCartServices _CartServices;

        public OrderServices(ApplicationDbContext context)
        {
            _Context = context;  
        }
        public void CreateOrder(string CartId, string username,string address,string city,string country ,string phonenumber)
        {

            var items = _Context.items.Where(x => x.ShoppingCartId == CartId).ToList();
            var ShoppingCart = Cart.Instance(CartId, items).Value;
            var OrderDetails = new List<OrderDetail>();
            
            foreach(var item in ShoppingCart.Items)
            {
                var pie = _Context.Pies.FirstOrDefault(x=>x.PieId==item.Pie.PieId);
                var orderdetail = OrderDetail.Instance( item.Quantity, pie).Value;
                OrderDetails.Add(orderdetail);
            }
            var order = Order.Instance(username, address, city, country, phonenumber, username, OrderDetails).Value;
            _Context.orders.Add(order);
            _CartServices.ClearCart(CartId);
            _Context.SaveChanges();
        }
    }
}
