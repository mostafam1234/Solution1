using System;
using System.Collections.Generic;
using System.Text;

namespace App.Logic.Domain
{
    public class OrderDetail
    {
        public int OrderDetailId { get;private set; }
        public int OrderId { get;private set; }
        public int PieId { get;private set; }
        public int Quantity { get;private set; }
        public decimal Price { get;private set; }
        public Pie Pie { get; set; }
        public Order Order { get; set; }

        public static OrderDetail Instance (int Quantity,Pie pie)
        {
            var orderDetail = new OrderDetail
            {
                PieId = pie.PieId,
                Quantity = Quantity,
                Price = pie.Price,
                Pie = pie
            };
            return orderDetail;
        }
    }
}
