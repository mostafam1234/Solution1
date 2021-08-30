using App.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.ui.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Pie> pies { set; get; } = new List<Pie>();
        public string Title { get; set; }
    }
}
