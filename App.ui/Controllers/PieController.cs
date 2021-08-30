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

        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _Mapper;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository,IMapper mapper)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
            _Mapper = mapper;
        }
        public IActionResult List()
        {
            var pies = _pieRepository.AllPies;
            var PieListViewModel = new PieListViewModel
            {
                pies = pies
            };
            return View(PieListViewModel);
        }


        [AllowAnonymous]
        public IActionResult Details (int id)
        {
            var pie = _pieRepository.GetPieById(id);
            var piedetail = _Mapper.Map<PieDetailsViewModel>(pie);
            return View(piedetail);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var AllCategories = _categoryRepository.AllCategories();
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
                   , createPieViewModel.CategorId);
                _pieRepository.CreatePie(NewPie);
                return RedirectToAction("List");
            }
            else
            {
                createPieViewModel.categories = _categoryRepository.AllCategories();
                return View(createPieViewModel);
            }
           
        }
        [HttpGet]
        public IActionResult Edit (int id)
        {
            var PieToEdit = _pieRepository.GetPieById(id);
            var EditPieViewModel = _Mapper.Map<EditPieViewModel>(PieToEdit);
            EditPieViewModel.categories = _categoryRepository.AllCategories();
            return View(EditPieViewModel);
        }
        
        public IActionResult Edit (EditPieViewModel Vm)
        {
            var pie = _pieRepository.GetPieById(Vm.PieId);
            if (ModelState.IsValid)
            {
                pie.Update(Vm.Name, Vm.Description, Vm.Price, Vm.IsPieOfTheWeek, Vm.InStock, Vm.CategorId);
                _pieRepository.EditPie(pie);
                return RedirectToAction("list");
            }
            else
            {
                var allCategories = _categoryRepository.AllCategories();
                Vm.categories = allCategories;
                return View(Vm);
            }
            
        }
        [HttpGet]
        public IActionResult Delete (int id)
        {
            var PieToDelete = _pieRepository.GetPieById(id);
            var DeletePieViewModel = _Mapper.Map<DeletePieViewModel>(PieToDelete);
            DeletePieViewModel.CategoryName = _categoryRepository.GetCategoryById(PieToDelete.CategoryId).CategoryName;
            return View(DeletePieViewModel);
        }
        [HttpPost]
        public IActionResult Delete(DeletePieViewModel Vm)
        {
            var pie = _pieRepository.GetPieById(Vm.PieId);
            _pieRepository.DeletePie(pie);
            return RedirectToAction("list");
        }
        
    }
}
