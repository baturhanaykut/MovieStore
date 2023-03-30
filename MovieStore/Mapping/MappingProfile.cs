using AutoMapper;
using MovieStore.Models.ViewModels;
using MovieStore_Domain.Entities;

namespace MovieStore.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Director, DirectorVM>().ReverseMap();
            CreateMap<Starring, StarringVM>().ReverseMap();
            CreateMap<Category, CategoryVM>().ReverseMap();
            CreateMap<Language, LanguageVM>().ReverseMap();
            CreateMap<Movie, MovieVM>().ReverseMap();

        }
    }
}
