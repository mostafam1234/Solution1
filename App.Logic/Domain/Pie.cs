using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpFunctionalExtensions;

namespace App.Logic
{
    public class Pie
    {
        public int PieId { get;private set; }
        public string Name { get;private set; }

        public string Description { get;private set; }
        public decimal Price { get;private set; }
        public string ImageUrl { get;private set; }
        public bool IsPieOfTheWeek { get;private set; }
        public bool InStock { get;private set; }
        public int CategoryId { get;private set; }
        public Category Category { get;private set; }

        private Pie()
        {

        }
        public static Result<Pie> Instance( string name, string description, decimal price, 
            bool ispieoftheweek, bool instock,int Categoryid)
        {
            if (string.IsNullOrEmpty(name))
            {
                return Result.Failure<Pie>("the name is required");
            }
            Pie pie = new Pie
            {
                
                Name = name,
                Description = description,
                Price = price,
                
                IsPieOfTheWeek = ispieoftheweek,
                InStock = instock,
                CategoryId = Categoryid,
            };
            return Result.Success(pie);
        }

        public void Update(string Name, string description, decimal price, bool IsPieOfTheWeek, bool inStock, int CategoryId)
        {
            this.Name = Name;
            this.Description = description;
            this.Price = price;
            this.IsPieOfTheWeek = IsPieOfTheWeek;
            this.InStock = inStock;
            this.CategoryId = CategoryId;

            //var ss = Category.Pies.FirstOrDefault();

            //Category.UpdatePies(ss);



        }

    }
    
}
