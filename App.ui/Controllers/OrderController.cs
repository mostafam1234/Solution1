using App.Logic.Domain;
using App.services.OrderServices;
using App.services.ShoppingCartServices;
using App.ui.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.ui.Controllers
{
   [Authorize]
    public class OrderController : Controller
    {
        private IOrderServices _OrderServices;
        private readonly IShoppingCartServices _CartServices;
        public OrderController(IOrderServices orderServices,IShoppingCartServices shoppingCartServices)
        {
            _OrderServices = orderServices;
            _CartServices = shoppingCartServices;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            var orderViewModel = new OrderViewModel();
            return View(orderViewModel);
        }
        [HttpPost]
        
        public IActionResult Checkout(OrderViewModel VM)
        {
            var username = User.Identity.Name;
            var order = Order.Instance(username, VM.Address, VM.City, VM.Country, VM.PhoneNumber, VM.Email).Value;
            var CartId = Request.Cookies["CartId"];
            var CartItems = _CartServices.GetCartItems(CartId);
            var ShoppingCart = Cart.Instance(CartId, CartItems).Value;
            if (ShoppingCart.Items.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty, add some pies first");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    _OrderServices.CreateOrder(ShoppingCart, order);
                    return RedirectToAction("CheckoutComplete");
                }
            }
            return View(VM);

        }
        
        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order. You'll soon enjoy our delicious pies!";
            return View();
        }
    }
}
