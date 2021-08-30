using App.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.ui.ViewModels
{
    public class PieListViewModel
    {
        public IEnumerable<Pie> pies { set; get; } = new List<Pie>();
        public string CurrentCategory { get; set; }
    }
}
