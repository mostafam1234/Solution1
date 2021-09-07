using App.Logic;
using App.services.Category_services;
using App.services.Pie_services;
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
    
    public class PieController : Controller
    {

        private readonly IPieServices _PieServices;
        private readonly ICategoryServices _CategoryServices;
        private readonly IMapper _Mapper;

        public PieController(IPieServices pieServices, ICategoryServices categoryServices,IMapper mapper)
        {
            _PieServices = pieServices;
            _CategoryServices = categoryServices;
            _Mapper = mapper;
        }
        public IActionResult List()
        {
            var pies = _PieServices.AllPies;
            var PieListViewModel = new PieListViewModel
            {
                pies = pies
            };
            return View(PieListViewModel);
        }


        [AllowAnonymous]
        public IActionResult Details (int id)
        {
            var pie = _PieServices.GetPieById(id);
            var piedetail = _Mapper.Map<PieDetailsViewModel>(pie);
            return View(piedetail);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var AllCategories = _CategoryServices.AllCategories();
            var CreatePieViewModel = new CreatePieViewModel
            {
                categories = AllCategories.ToList()
            };
            
            return View(CreatePieViewModel);
        }
        [HttpPost]
        public IActionResult Create (CreatePieViewModel createPieViewModel)
        {
            

            if (ModelState.IsValid)
            {
                var NewPie = Pie.Instance(createPieViewModel.Name, createPieViewModel.Description
                   , createPieViewModel.Price, createPieViewModel.IsPieOfTheWeek, createPieViewModel.InStock
                   , createPieViewModel.CategorId).Value;
                _PieServices.CreatePie(NewPie);
                return RedirectToAction("List");
            }
            else
            {
                createPieViewModel.categories = _CategoryServices.AllCategories();
                return View(createPieViewModel);
            }
           
        }
        [HttpGet]
        public IActionResult Edit (int id)
        {
            var PieToEdit = _PieServices.GetPieById(id);
            var EditPieViewModel = _Mapper.Map<EditPieViewModel>(PieToEdit);
            EditPieViewModel.categories = _CategoryServices.AllCategories();
            return View(EditPieViewModel);
        }
        
        public IActionResult Edit (EditPieViewModel Vm)
        {
            var pie = _PieServices.GetPieById(Vm.PieId);
            if (ModelState.IsValid)
            {
                pie.Update(Vm.Name, Vm.Description, Vm.Price, Vm.IsPieOfTheWeek, Vm.InStock, Vm.CategorId);
                _PieServices.EditPie(pie);
                return RedirectToAction("list");
            }
            else
            {
                var allCategories = _CategoryServices.AllCategories();
                Vm.categories = allCategories;
                return View(Vm);
            }
            
        }
        [HttpGet]
        public IActionResult Delete (int id)
        {
            var PieToDelete = _PieServices.GetPieById(id);
            var DeletePieViewModel = _Mapper.Map<DeletePieViewModel>(PieToDelete);
            DeletePieViewModel.CategoryName = _CategoryServices.GetCategoryById(PieToDelete.CategoryId).CategoryName;
            return View(DeletePieViewModel);
        }
        [HttpPost]
        public IActionResult Delete(DeletePieViewModel Vm)
        {
            var pie = _PieServices.GetPieById(Vm.PieId);
            _PieServices.DeletePie(pie);
            return RedirectToAction("list");
        }
        
    }
}
