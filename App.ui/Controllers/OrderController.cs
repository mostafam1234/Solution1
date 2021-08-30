using App.Logic.Domain;
using App.services.OrderServices;
using App.ui.Helpers.session_helper;
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
   
    public class OrderController : Controller
    {
        private IOrderRepository _OrderRepository;
        private readonly IMapper _Maper;

        public OrderController(IOrderRepository orderRepository,IMapper mapper)
        {
            _OrderRepository = orderRepository;
            _Maper = mapper;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            var orderViewModel = new OrderViewModel();
            return View(orderViewModel);
        }
        [HttpPost]
        
        public IActionResult Checkout(OrderViewModel orderViewModel)
        {

            var order = _Maper.Map<Order>(orderViewModel);
            var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart");
            if (cart.Items.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty, add some pies first");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    _OrderRepository.CreateOrder(cart, order);
                    cart.ClearCart();
                    HttpContext.Session.SetObjectAsJson("Cart",cart);
                    return RedirectToAction("CheckoutComplete");
                }
            }
            return View(orderViewModel);

        }
        
        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order. You'll soon enjoy our delicious pies!";
            return View();
        }
    }
}
