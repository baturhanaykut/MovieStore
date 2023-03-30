using AutoMapper;
using MovieStore_Application.Models.DTOs.AppUserDTOS;
using MovieStore_Application.Models.DTOs.CategoryDTOS;
using MovieStore_Application.Models.DTOs.DirectorDTOS;
using MovieStore_Application.Models.DTOs.LanguageDTOS;
using MovieStore_Application.Models.DTOs.MovieDTOS;
using MovieStore_Application.Models.DTOs.StarringDTOS;
using MovieStore_Application.Models.VMs.CategoryVM;
using MovieStore_Application.Models.VMs.DirectorVM;
using MovieStore_Application.Models.VMs.LanguageVM;
using MovieStore_Application.Models.VMs.MovieVM;
using MovieStore_Application.Models.VMs.StarringVM;
using MovieStore_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore_Application.Mapping
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, RegisterDTO>().ReverseMap();
            
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();
            CreateMap<Category, CategoryVM>().ReverseMap();
           
            CreateMap<Director, CreateDirectorDTO>().ReverseMap();
            CreateMap<Director, UpdateDirectorDTO>().ReverseMap();
            CreateMap<Director, DirectorVM>().ReverseMap();
            CreateMap<Director, DirectorDetailsVM>().ReverseMap();


            CreateMap<Language, CreateLanguageDTO>().ReverseMap();
            CreateMap<Language, UpdateLanguageDTO>().ReverseMap();
            CreateMap<Language, LanguageVM>().ReverseMap();


            CreateMap<Starring, CreateStarringDTO>().ReverseMap();
            CreateMap<Starring, UpdateStarringDTO>().ReverseMap();
            CreateMap<Starring, StarringVM>().ReverseMap();

            CreateMap<Movie, CreateMovieDTO>().ReverseMap();
            CreateMap<Movie, UpdateMovieDTO>().ReverseMap();
            CreateMap<Movie, MovieDetailsVM>().ReverseMap();
            CreateMap<Movie, MovieVM>().ReverseMap();

        }
    }
}
