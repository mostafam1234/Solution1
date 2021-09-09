using App.Logic.Domain;
using App.services.Pie_services;
using App.services.ShoppingCartServices;
using App.ui.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.ui.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IPieServices _PieServices;
        private readonly IShoppingCartServices _ShoppingCartServices;

        public ShoppingCartController(IShoppingCartServices shoppingCartServices,IPieServices pieServices)
        {
            _PieServices = pieServices;
            _ShoppingCartServices = shoppingCartServices;
        }
        public IActionResult Index()
        {
            var CartId = Request.Cookies["CartId"];
            var items = _ShoppingCartServices.GetCartItems(CartId);
            var ShoppingCart = Cart.Instance(CartId, items).Value;
            var ViewModel = new ShoppingCartViewModel
            {
                Items = items,
                ShoppingCartTotal = ShoppingCart.CartTotal
            };
            return View(ViewModel);
        }

        public IActionResult AddToShoppingCart(int PieID)
        {
            var CartId = Request.Cookies["CartId"] ?? Guid.NewGuid().ToString();
            Response.Cookies.Append("CartId", CartId);
            var pie = _PieServices.GetPieById(PieID);
            _ShoppingCartServices.AddToCart(pie, CartId);
            return RedirectToAction("index","Home");
        }

        public IActionResult RemoveFromShoppingCart(int Pieid)
        {
            var CartId = Request.Cookies["CartId"];
            var pie = _PieServices.GetPieById(Pieid);
            _ShoppingCartServices.RemoveFromCart(pie, CartId);
            var items = _ShoppingCartServices.GetCartItems(CartId);
            if (items.Count < 1)
            {
                return RedirectToAction("index", "Home");
            }
            else
            {
                return RedirectToAction("index");

            }
        }
        public IActionResult ClearCart()
        {
            var CartId = Request.Cookies["CartId"];
            _ShoppingCartServices.ClearCart(CartId);
           return RedirectToAction("index","Home");
        }
    }
}
