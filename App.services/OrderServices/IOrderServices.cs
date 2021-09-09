using App.Logic.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.services.OrderServices
{
    public interface IOrderServices
    {
        public void CreateOrder(string CartId, string username, string address, string city, string country, string phonenumber);
    }
}
