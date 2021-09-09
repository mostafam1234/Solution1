using App.Logic;
using App.services.Category_services;
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
    
    public class CategoryController : Controller
    {
        private readonly ICategoryServices _CategoryServices;
        private readonly IMapper _Mapper;

        public CategoryController(ICategoryServices categoryServices, IMapper mapper)
        {
            _CategoryServices = categoryServices;
            _Mapper = mapper;
        }


        public IActionResult List()
        {
            var Allcategories = _CategoryServices.AllCategories();
            Allcategories.FirstOrDefault();
            var CategoryListViewModel = _Mapper.Map<List<CategoryListViewModel>>(Allcategories);
            return View(CategoryListViewModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var CreateCategoryViewModel = new CreateCategoryViewModel();
            return View(CreateCategoryViewModel);
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryViewModel createCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                _CategoryServices.AddCategory(createCategoryViewModel.CategoryName,createCategoryViewModel.Description);
                return RedirectToAction("list");
            }
            else
            {
                return View(createCategoryViewModel);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var CategoryToEdit = _CategoryServices.GetCategoryById(id);
            var CategoryEditViewModel = _Mapper.Map<CategoryEditViewModel>(CategoryToEdit);

            return View(CategoryEditViewModel);
        }
        [HttpPost]
        public IActionResult Edit(CategoryEditViewModel CategoryEditViewModel)
        {
            if (ModelState.IsValid)
            {
               var IsUpdated= _CategoryServices.EditCategory(CategoryEditViewModel.CategoryName,CategoryEditViewModel.Description, 
                    CategoryEditViewModel.CategoryId);
                return RedirectToAction("List");
            }
            else
            {
                return View(CategoryEditViewModel);
            }

        }
        [HttpGet]
        public IActionResult Delete (int id)
        {
            var CategoryToDelete = _CategoryServices.GetCategoryById(id);
            var DeleteCategoryViewModel = _Mapper.Map<DeleteCategoryViewModel>(CategoryToDelete);
            return View(DeleteCategoryViewModel);
        }
        [HttpPost]
        public IActionResult Delete(DeleteCategoryViewModel deleteCategoryViewModel)
        {
           var IsDeleted= _CategoryServices.DeleteCategory(deleteCategoryViewModel.CategoryId);
            return RedirectToAction("List");
        }
    }
}
