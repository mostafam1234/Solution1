using App.Logic;
using App.Logic.Domain;
using App.Logic.DTO;
using App.services.Pie_services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.services.CartServices
{
    public class ShoppingCartServices : ICartServices
    {
        private readonly IPieRepository _Pie;
        private readonly IMapper _Mapper;
        
        public ShoppingCartServices(IPieRepository pieRepository,IMapper mapper)
        {
            _Pie = pieRepository;
            _Mapper = mapper;
            
        }

        public Cart AddtoCart(int id,Cart shoppingCart)
        {
            var selectedpie = _Pie.GetPieById(id);
            var Pie = _Mapper.Map<PieDto>(selectedpie);

            if (shoppingCart == null)
            {
                shoppingCart = new Cart();
                var item = new ShoppingCartItem { Pie = Pie, Quantity = 1 };
                shoppingCart.Items.Add(item);
            }
            else
            {
                if (shoppingCart.IsExsist(id))
                {
                    var item = shoppingCart.FindItem(id);
                    item.Quantity++;
                }
                else
                {
                    var item = new ShoppingCartItem { Pie=Pie ,Quantity=1};
                    shoppingCart.Items.Add(item);
                }
            }
            return shoppingCart;

        }
       
        
    }

    
}
