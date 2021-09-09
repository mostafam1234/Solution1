using App.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.services.Pie_services
{
    public interface IPieServices
    {
        IEnumerable<Pie> AllPies { get; }
        IEnumerable<Pie> PiesOfTheWeek { get; }
        Pie GetPieById(int pieId);
        public IEnumerable<Pie> GetpiesByCategoryName(string categoryname);
        public void CreatePie(string name, string description, decimal price, bool IsPieofthweek, bool instock, int Categoryid);
        public bool EditPie(int pieid, int categoryid, string name, string description, decimal price, bool ispieofthweek
           , bool instock);
        public bool DeletePie(int pieid);
        IEnumerable<Pie> SearchForPies(string serachTerm);

    }
}
