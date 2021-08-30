using App.DataAccess;
using App.Logic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.services.Pie_services
{
    public class PieRepository : IPieRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public PieRepository(ApplicationDbContext appDbContext)
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

        IEnumerable<Pie> IPieRepository.PiesOfTheWeek => throw new NotImplementedException();

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

        public void CreatePie (Pie pie)
        {
            _appDbContext.Pies.Add(pie);
            _appDbContext.SaveChanges();
        }

        public void EditPie(Pie pie)
        {
            _appDbContext.Pies.Update(pie);
            _appDbContext.SaveChanges();
              
        }
        public void DeletePie(Pie pie)
        {
            _appDbContext.Pies.Remove(pie);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<Pie> SearchForPies(string serachTerm)
        {
            var Pies = _appDbContext.Pies.Where(p => p.Name.Contains(serachTerm)).ToList();
            return Pies;
        }
    }
}

