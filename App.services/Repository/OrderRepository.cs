using App.DataAccess;
using App.Logic.Domain;
using App.services.OrderServices;
using App.services.Pie_services;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.services.Repository
{
    public class OrderRepository: IOrderRepository
    {
        private ApplicationDbContext _Context;
        private IPieRepository _PieRepository;

        public OrderRepository(ApplicationDbContext context,IPieRepository pieRepository)
        {
            _Context = context;
            _PieRepository = pieRepository;
            
        }
        public void CreateOrder(Cart ShoppingCart, Order order)
        {
            order.OrderPlaced = DateTime.Now;
            
            foreach(var item in ShoppingCart.Items)
            {
                var pie = _PieRepository.GetPieById(item.Pie.PieId);
                var orderdetail = OrderDetail.Instance( item.Quantity, pie);
                order.AddOrderDetails(orderdetail);
            }
            order.CalculateOrderTotal();
            _Context.orders.Add(order);
            _Context.SaveChanges();
        }
    }
}
