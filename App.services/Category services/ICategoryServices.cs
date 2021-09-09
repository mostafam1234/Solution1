using App.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.services.Category_services
{
    public interface ICategoryServices
    {
        IEnumerable<Category> AllCategories();
        Category GetCategoryByname(string categoryname);
        Category GetCategoryById(int id);
        public void AddCategory(string Name, string Description);
        public bool EditCategory(string Name, string Description, int id);
        public bool DeleteCategory(int id);

    }
}
