using App.Logic.Domain;
using App.Logic.DTO;
using App.services.CartServices;
using App.services.Pie_services;

using App.ui.Helpers.session_helper;
using App.ui.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App.ui.Controllers
{
    
    public class CartController : Controller
    {
        public IPieRepository _Pie { get; }

        private readonly IMapper _Mapper;
        private readonly ICartServices _CartServices;

        public CartController(IPieRepository pierepository, IMapper mapper,ICartServices cartservices)
        {
            _Pie = pierepository;
            _Mapper = mapper;
            _CartServices = cartservices;

        }

        public IActionResult index()
        {
            var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart");
            var CartViewModel = new ShoppingCartViewModel();
            if (cart == null)
            {
                CartViewModel.ShoppingCartTotal = 0;
            }
            else 
            {
                CartViewModel.Items = cart.Items;
                CartViewModel.ShoppingCartTotal = cart.CalCTotal();
            }
            
            return View(CartViewModel);
        }

        public IActionResult AddToCart(int PieId)
        {
            var ShoppingCart = HttpContext.Session.GetObjectFromJson<Cart>("Cart");
            ShoppingCart = _CartServices.AddtoCart(PieId, ShoppingCart);
            HttpContext.Session.SetObjectAsJson("Cart", ShoppingCart);
            return RedirectToAction("index");
        }

        public IActionResult RemoveFromCart(int PieId)
        {
            var ShoppingCart = HttpContext.Session.GetObjectFromJson<Cart>("Cart");
            ShoppingCart.RemoveFromCart(PieId);
            HttpContext.Session.SetObjectAsJson("Cart", ShoppingCart);
            return RedirectToAction("index");
        }

        public IActionResult ClearCart()
        {
            var ShoppingCart = HttpContext.Session.GetObjectFromJson<Cart>("Cart");
            ShoppingCart.ClearCart();
            HttpContext.Session.SetObjectAsJson("Cart", ShoppingCart);
            return RedirectToAction("index");
        }
    }
}
