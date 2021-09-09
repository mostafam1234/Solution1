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
        public IActionResult Create (CreatePieViewModel VM)
        {
            

            if (ModelState.IsValid)
            {
                _PieServices.CreatePie(VM.Name,VM.Description,VM.Price,VM.IsPieOfTheWeek,VM.InStock,VM.CategorId);
                return RedirectToAction("List");
            }
            else
            {
                VM.categories = _CategoryServices.AllCategories();
                return View(VM);
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
            if (ModelState.IsValid)
            {
              var IsUpdated= _PieServices.EditPie(Vm.PieId,Vm.CategorId,Vm.Name,Vm.Description,Vm.Price,Vm.IsPieOfTheWeek
                    ,Vm.InStock);
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
            
          var IsDeleted= _PieServices.DeletePie(Vm.PieId);
            return RedirectToAction("list");
        }
        
    }
}
