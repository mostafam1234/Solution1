using CSharpFunctionalExtensions;
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
        public Pie Pie { get;private set; }
        public Order Order { get;private set; }


        private OrderDetail()
        {

        }
        public static Result< OrderDetail> Instance (int Quantity,Pie pie)
        {
            if (Quantity<1)
            {
                return Result.Failure<OrderDetail>("Quantity can,t be less than 1");
            }
            else
            {
                var orderDetail = new OrderDetail
                {
                    PieId = pie.PieId,
                    Quantity = Quantity,
                    Price = pie.Price,
                    Pie = pie
                };
                return Result.Success(orderDetail);
            }
        } 
    }
}
