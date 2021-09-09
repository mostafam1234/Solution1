using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Logic
{
    public class Category
    {
        private Category()
        {
            Pies = new List<Pie>();
        }
       
        public int CategoryId { get;private set; }
        public string CategoryName { get;private set; }
        public string Description { get; private set; }
        public List<Pie> Pies { get; private set; }
        public static Result<Category> Instance (string Name,string Description)
        {
            if (string.IsNullOrEmpty(Name))
            {
                return Result.Failure<Category>("The name is required");
            }
            
            Category category = new Category
            {
                CategoryName = Name,
                Description = Description
            };
            return Result.Success(category);
        }
       

        public void EditCategory(string Name,string CategoryDescription)
        {
            CategoryName = Name;
            Description = CategoryDescription;
            
        }

        public void Update (string Name,string description)
        {
            this.CategoryName = Name;
            this.Description = description;
        }
    }
}
