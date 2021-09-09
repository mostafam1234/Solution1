using App.services.ShoppingCartServices;
using App.ui.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.ui.Components
{
    public class CartSummary :ViewComponent
    {
        private readonly IShoppingCartServices _ShoppingCartServices;

        public CartSummary(IShoppingCartServices shoppingCartServices)
        {
            _ShoppingCartServices = shoppingCartServices;
        }
        public IViewComponentResult Invoke()
        {
            var cartid = Request.Cookies["CartId"];
            var items = _ShoppingCartServices.GetCartItems(cartid);
            var CartViewModel = new ShoppingCartViewModel
            {
                Items = items,
                ShoppingCartTotal = 0
            };
            return View(CartViewModel);
        }
    }
}
