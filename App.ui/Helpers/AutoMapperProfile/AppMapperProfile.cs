using App.Logic;
using App.Logic.Domain;
using App.Logic.DTO;

using App.ui.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.ui.Helpers.AutoMapperProfile
{
    public class AppMapperProfile : Profile
    {
        public AppMapperProfile()
        {
            CreateMap<Pie, PieListViewModel>();
            CreateMap<Pie, PieDetailsViewModel>();  
            CreateMap<Pie,PieDto>();
            CreateMap<OrderViewModel, Order>();
            CreateMap<Category, CategoryEditViewModel>();
            CreateMap<Category, DeleteCategoryViewModel>();
            CreateMap<Category, CategoryListViewModel>();
            CreateMap<Pie, EditPieViewModel>();
            CreateMap<Pie, DeletePieViewModel>();
        }
    }
}
