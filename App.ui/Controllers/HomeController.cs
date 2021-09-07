using App.services.Category_services;
using App.services.Pie_services;
using App.ui.Models;
using App.ui.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace App.ui.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPieServices _PieServices;
        private readonly ICategoryServices _CategoryServices;
        private readonly IMapper _Mapper;

        public HomeController(ILogger<HomeController> logger,IPieServices pieServices,ICategoryServices categoryServices,IMapper mapper)
        {
            _logger = logger;
            _PieServices = pieServices;
            _CategoryServices = categoryServices;
            _Mapper = mapper;
        }

        public IActionResult Index()
        {
            var pies = _PieServices.AllPies;
            var HomeIndexViewModel = new HomeIndexViewModel
            {
                pies = pies,
                Title = "Welcome to Shop"
            };
            return View(HomeIndexViewModel);
        }

        public IActionResult PieList (int id)
        {
            var pielistviewmodel = new PieListViewModel();
            var Category = _CategoryServices.GetCategoryById(id);
            if (Category == null)
            {
                pielistviewmodel.pies = _PieServices.AllPies;
                pielistviewmodel.CurrentCategory = "Allpies";
            }
            else
            {
                pielistviewmodel.pies = Category.Pies;
                pielistviewmodel.CurrentCategory = Category.CategoryName;
            }
            return View(pielistviewmodel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
