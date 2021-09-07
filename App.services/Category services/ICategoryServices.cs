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
        void AddCategory(Category category);
         void EditCategory(Category category);
        void DeleteCategory(Category category);

    }
}
