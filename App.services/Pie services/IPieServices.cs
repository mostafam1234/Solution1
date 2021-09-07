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
        void CreatePie(Pie pie);
        void EditPie(Pie pie);
        void DeletePie(Pie pie);
        IEnumerable<Pie> SearchForPies(string serachTerm);

    }
}
