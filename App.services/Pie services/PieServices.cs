using App.DataAccess;
using App.Logic;
using App.services.Pie_services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.services.Pie_services
{
    public class PieServices : IPieServices
    {
        private readonly ApplicationDbContext _appDbContext;

        public PieServices(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Pie> AllPies
        {
            get
            {
                return _appDbContext.Pies.Include(c => c.Category);
            }
        }

        IEnumerable<Pie> IPieServices.PiesOfTheWeek => throw new NotImplementedException();

        public IEnumerable<Pie> PiesOfTheWeek(bool pieoftheweek)
        {

            var pies= _appDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek == pieoftheweek);
            return pies;
        }

        public Pie GetPieById(int pieId)
        {
            return _appDbContext.Pies.FirstOrDefault(p => p.PieId == pieId);
        }
        public IEnumerable<Pie> GetpiesByCategoryName(string categoryname)
        {
            IEnumerable<Pie> pies;
            if (categoryname == null)
            {
                pies= _appDbContext.Pies.Include(c => c.Category).ToList();
            }
            pies = _appDbContext.Pies.Include(c => c.Category).Where(p => p.Category.CategoryName == categoryname).ToList();
            return pies;
        }

        public void CreatePie (string name,string description,decimal price ,bool IsPieofthweek,bool instock,int Categoryid)
        {
            var PietoAdd = Pie.Instance(name, description, price, IsPieofthweek, instock, Categoryid).Value;
            _appDbContext.Pies.Add(PietoAdd);
            _appDbContext.SaveChanges();
        }

        public bool EditPie(int pieid,int categoryid,string name,string description,decimal price,bool ispieofthweek
            ,bool instock)
        {
            var PieToEdit = _appDbContext.Pies.FirstOrDefault(x => x.PieId == pieid);
            if (PieToEdit == null)
            {
                return false;
            }
            PieToEdit.Update(name, description, price, ispieofthweek, instock, categoryid);
            _appDbContext.Pies.Update(PieToEdit);
            _appDbContext.SaveChanges();
            return true;
              
        }
        public bool DeletePie(int pieid)
        {
           var pietodelete= _appDbContext.Pies.FirstOrDefault(x => x.PieId == pieid);
            if (pietodelete == null)
            {
                return false;
            }
            _appDbContext.Pies.Remove(pietodelete);
            _appDbContext.SaveChanges();
            return true;
        }

        public IEnumerable<Pie> SearchForPies(string serachTerm)
        {
            var Pies = _appDbContext.Pies.Where(p => p.Name.Contains(serachTerm)).ToList();
            return Pies;
        }
    }
}

