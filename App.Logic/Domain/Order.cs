
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Logic.Domain
{
   
    
        public class Order
        {

        private Order()
        {
            OrderDetails = new List<OrderDetail>();
        }
        public int OrderId { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
            public string Name { get;private set; }
            public string Address { get;private set; }
            public string City { get;private set; }
            public string Country { get;private set; }
            public string PhoneNumber { get;private set; }
            public string Email { get;private set; }
            public decimal OrderTotal { get;private set; }
            public DateTime OrderPlaced { get; set; }

        public static Result< Order> Instance(string name, string address,string city,string country,
            string phonenumber,string Email,List<OrderDetail> orderDetails
            )
        {
            if (string.IsNullOrEmpty(name))
            {
                return Result.Failure<Order>("The Name of Customer must be provided");
            }
            var order = new Order
            {
                Name = name,
                Address = address,
                City = city,
                Country = country,
                PhoneNumber = phonenumber,
                Email = Email,
                OrderPlaced = DateTime.Now,
                OrderDetails = orderDetails
            };
            order.OrderTotal = CalculateOrderTotal(order);
            return Result.Success(order);
            
        }
        public void AddOrderDetails(OrderDetail orderDetail)
        {
            OrderDetails.Add(orderDetail);
        }

        public static decimal CalculateOrderTotal(Order order)
        {
            if (order.OrderDetails == null)
            {
              order.OrderTotal = 0;
            }
            else
            {
               order. OrderTotal = order. OrderDetails.Sum(o => o.Pie.Price * o.Quantity);
            }
            return order.OrderTotal;
            
        }
        }

    }




