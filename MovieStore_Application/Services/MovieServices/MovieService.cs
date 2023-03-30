using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore_Application.Models.DTOs.MovieDTOS;
using MovieStore_Application.Models.VMs.CategoryVM;
using MovieStore_Application.Models.VMs.DirectorVM;
using MovieStore_Application.Models.VMs.LanguageVM;
using MovieStore_Application.Models.VMs.MovieVM;
using MovieStore_Application.Models.VMs.StarringVM;
using MovieStore_Domain.Entities;
using MovieStore_Domain.Enums;
using MovieStore_Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore_Application.Services.MovieServices
{
    public class MovieService : IMovieService
    {
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IDirectorRepository _directorRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly IStarringRepository _starringRepository;

        public MovieService(IMovieRepository movieRepository, IMapper mapper, ICategoryRepository categoryRepository, IDirectorRepository directorRepository, ILanguageRepository languageRepository, IStarringRepository starringRepository)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
            _categoryRepository = categoryRepository;
            _directorRepository = directorRepository;
            _languageRepository = languageRepository;
            _starringRepository = starringRepository;
        }

        public async Task<bool> Create(CreateMovieDTO model)
        {
            Movie movie = _mapper.Map<Movie>(model);

            if (movie.UploadPath is not null)
            {
                using var image = Image.Load(model.UploadPath.OpenReadStream());

                image.Mutate(x => x.Resize(300, 300));
                Guid guid = Guid.NewGuid();

                image.Save($"wwwroot/images/{guid}.jpg");

                movie.ImagePath = $"/images/{guid}.jpg";

            }
            else
            {
                movie.ImagePath = $"/images/defaultmovie.jpg";
            }

            return await _movieRepository.Add(movie);
        }

        public async Task<CreateMovieDTO> CreateMovie()
        {
            CreateMovieDTO model = new CreateMovieDTO()
            {
                Categories = await _categoryRepository.GetFilteredList(
                    select: x => new CategoryVM()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Description = x.Description
                    },
                 where: x => x.Statu != Status.Passive && x.Statu != Status.Deleted,
                 orderBy: x => x.OrderBy(x => x.Name)
                 ),
                Directors = await _directorRepository.GetFilteredList(
                    select: x => new DirectorVM()
                    {
                        Id = x.Id,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        BirthDate = x.BirthDate
                    },
                    where: x => x.Statu != Status.Passive && x.Statu != Status.Deleted,
                 orderBy: x => x.OrderBy(x => x.FirstName)
                 ),
                Languages = await _languageRepository.GetFilteredList(
                    select: x => new LanguageVM()
                    {
                        Id = x.Id,
                        Name = x.Name,
                    },
                 where: x => x.Statu != Status.Passive && x.Statu != Status.Deleted,
                 orderBy: x => x.OrderBy(x => x.Name)
                    ),
                Starrings = await _starringRepository.GetFilteredList(
                    select: x => new StarringVM()
                    {
                        Id = x.Id,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        BirthDate = x.BirthDate
                    },
                 where: x => x.Statu != Status.Passive && x.Statu != Status.Deleted,
                 orderBy: x => x.OrderBy(x => x.FirstName)
                    ),


            };

            return model;
        }

        public async Task<bool> Delete(int id)
        {
            Movie movie = await _movieRepository.GetDefault(x => x.Id == id);
            movie.Statu = Status.Passive;
            return await _movieRepository.Delete(movie);
        }

        public async Task<UpdateMovieDTO> GetById(int id)
        {
            Movie movie = await _movieRepository.GetDefault(x => x.Id == id);

            var model = _mapper.Map<UpdateMovieDTO>(movie);

            model.Directors = await _directorRepository.GetFilteredList(
                select: x => new DirectorVM()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName
                },
                where: x => x.Statu != Status.Passive && x.Statu != Status.Deleted,
                orderBy: x => x.OrderBy(x => x.FirstName)
                );
            model.Starrings = await _starringRepository.GetFilteredList(
                select: x => new StarringVM()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName
                },
                where: x => x.Statu != Status.Passive && x.Statu != Status.Deleted,
                orderBy: x => x.OrderBy(x => x.FirstName)
                );
            model.Languages = await _languageRepository.GetFilteredList(
                 select: x => new LanguageVM()
                 {
                     Id = x.Id,
                     Name = x.Name


                 },
                where: x => x.Statu != Status.Passive && x.Statu != Status.Deleted,
                orderBy: x => x.OrderBy(x => x.Name)
                );
            model.Categories = await _categoryRepository.GetFilteredList(
                select: x => new CategoryVM()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                },
                where: x => x.Statu != Status.Passive && x.Statu != Status.Deleted,
                orderBy: x => x.OrderBy(x => x.Name)
                );
            return model;
        }

        public async Task<MovieDetailsVM> GetMovieDetails(int id)
        {
            MovieDetailsVM movie = await _movieRepository.GetFilteredFirstOrDefault(
                select: x => new MovieDetailsVM()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    ReleaseDate = x.ReleaseDate,
                    CategoryName = x.Category.Name,
                    DirectorName = x.Director.FullName,
                    Price = x.Price,
                    RunningTimeMin = x.RunningTimeMin,
                    LanguageName = x.Language.Name,
                    Stock = x.Stock,
                    IsActive = x.IsActive

                },
                where: x => x.Id == id,
                orderBy: null,
                include: x => x.Include(x => x.Category)
                             .Include(x => x.Director)
                             .Include(x => x.Language)
                );
            return movie;
        }

        public async Task<List<MovieVM>> GetMovies()
        {
            var movie = await _movieRepository.GetFilteredList(
                select: x=> new MovieVM()
                {
                    Id=x.Id,
                    Name=x.Name,
                    Description=x.Description,
                    ReleaseDate =x.ReleaseDate,
                    DirectorName = x.Director.FullName,
                    CategoryName = x.Category.Name,
                    Price=x.Price,
                    Stock=x.Stock
                },
                where: x => x.Statu != Status.Passive && x.Statu != Status.Deleted,
                orderBy: x=>x.OrderBy(x=>x.Name),
                include: x => x.Include(x => x.Category)
                             .Include(x => x.Director)
                            
                );

            return movie;
        }

        public async Task<bool> Update(UpdateMovieDTO model)
        {
            var movie = _mapper.Map<Movie>(model);

            if (movie.UploadPath != null)
            {
                using var image = Image.Load(model.UploadPath.OpenReadStream());

                image.Mutate(x => x.Resize(300, 300));
                Guid guid = Guid.NewGuid();

                image.Save($"wwwroot/images/{guid}.jpg");

                movie.ImagePath = $"/images/{guid}.jpg";
            }
            else
            {
                movie.ImagePath = $"/images/defaultmovie.jpg";
            }

           return await _movieRepository.Update(movie);
        }

       
    }


}

