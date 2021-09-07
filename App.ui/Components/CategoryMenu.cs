using App.services.Category_services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.ui.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly ICategoryServices _categoryRepository;
        public CategoryMenu(ICategoryServices categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryRepository.AllCategories().OrderBy(c => c.CategoryName);
            return View(categories);
        }
    }
}
