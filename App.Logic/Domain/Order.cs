
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Logic.Domain
{
   
    
        public class Order
        {
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


        private Order()
        {

        }

        public static Result< Order> Instance(string name, string address,string city,string country,
            string phonenumber,string Email
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
                OrderTotal=0,
            };
            
            return Result.Success(order);
            
        }
        public void AddOrderDetails(OrderDetail orderDetail)
        {
            OrderDetails.Add(orderDetail);
        }

        public void CalculateOrderTotal()
        {
            if (OrderDetails == null)
            {
                OrderTotal = 0;
            }
            else
            {
                OrderTotal = OrderDetails.Sum(o => o.Pie.Price * o.Quantity);
            }
            
        }
        }

    }




