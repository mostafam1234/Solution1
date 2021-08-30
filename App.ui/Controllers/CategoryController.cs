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
    [Authorize(Roles =("Admin"))]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _CategoryRepository;
        private readonly IMapper _Mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _CategoryRepository = categoryRepository;
            _Mapper = mapper;
        }


        public IActionResult List()
        {
            var Allcategories = _CategoryRepository.AllCategories();
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
                var CategoryToadd = Category.Instance(createCategoryViewModel.CategoryName, createCategoryViewModel.Description);
                _CategoryRepository.AddCategory(CategoryToadd);
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
            var CategoryToEdit = _CategoryRepository.GetCategoryById(id);
            var CategoryEditViewModel = _Mapper.Map<CategoryEditViewModel>(CategoryToEdit);

            return View(CategoryEditViewModel);
        }
        [HttpPost]
        public IActionResult Edit(CategoryEditViewModel CategoryEditViewModel)
        {
            var Category = _CategoryRepository.GetCategoryById(CategoryEditViewModel.CategoryId);
            if (ModelState.IsValid)
            {
                Category.Update(CategoryEditViewModel.CategoryName, CategoryEditViewModel.Description);
                _CategoryRepository.EditCategory(Category);
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
            var CategoryToDelete = _CategoryRepository.GetCategoryById(id);
            var DeleteCategoryViewModel = _Mapper.Map<DeleteCategoryViewModel>(CategoryToDelete);
            return View(DeleteCategoryViewModel);
        }
        [HttpPost]
        public IActionResult Delete(DeleteCategoryViewModel deleteCategoryViewModel)
        {
            var Category = _CategoryRepository.GetCategoryById(deleteCategoryViewModel.CategoryId);
            _CategoryRepository.DeleteCategory(Category);
            return RedirectToAction("List");
        }
    }
}
