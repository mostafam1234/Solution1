using App.DataAccess;
using App.Logic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.services.Category_services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ApplicationDbContext _appDbContext;

        public CategoryServices(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Category> AllCategories()
        {
            return _appDbContext.Categories.Include(c => c.Pies);
        }

        public Category GetCategoryById(int id)
        {
            var category = _appDbContext.Categories.Include(p=>p.Pies).FirstOrDefault(c => c.CategoryId == id);
            return category;
        }

        public Category GetCategoryByname (string categoryname)
        {
            var category = _appDbContext.Categories.FirstOrDefault(c => c.CategoryName == categoryname);
            return category;
        }

        public void AddCategory(string Name,string Description)
        {
            var CategoryToAdd = Category.Instance(Name, Description).Value;
            _appDbContext.Categories.Add(CategoryToAdd);
            _appDbContext.SaveChanges();
        }
        public bool EditCategory(string Name,string Description,int id)
        {
            var category = _appDbContext.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (category == null)
            {
                return false;
            }
            category.Update(Name, Description);
            _appDbContext.Categories.Update(category);
            _appDbContext.SaveChanges();
            return true;
        }

        public bool DeleteCategory (int id)
        {
            var category = _appDbContext.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (category == null)
            {
                return false;
            }
            _appDbContext.Categories.Remove(category);
            _appDbContext.SaveChanges();
            return true;
        }
    }
}
