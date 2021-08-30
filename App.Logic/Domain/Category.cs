using System;
using System.Collections.Generic;
using System.Text;

namespace App.Logic
{
    public class Category
    {
        public int CategoryId { get;private set; }
        public string CategoryName { get;private set; }
        public string Description { get; private set; }
        public List<Pie> Pies { get; private set; } = new List<Pie>();


        public static Category Instance (string Name,string Description)
        {
            
            Category category = new Category
            {
                CategoryName = Name,
                Description = Description
            };
            return category;
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
