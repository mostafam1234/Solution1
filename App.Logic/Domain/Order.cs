using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace App.Logic.Domain
{
   
    
        public class Order
        {
            public int OrderId { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string AddressLine1 { get; set; }
            public string AddressLine2 { get; set; }
            public string ZipCode { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Country { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            public decimal OrderTotal { get;private set; }
            public DateTime OrderPlaced { get; set; } 
              
        public void AddOrderDetails(OrderDetail orderDetail)
        {
            OrderDetails.Add(orderDetail);
        }

        public void CalculateOrderTotal()
        {
            OrderTotal = OrderDetails.Sum(o => o.Pie.Price * o.Quantity);
        }
        }

    }




