using MovieStore_Application.Models.DTOs.CategoryDTOS;
using MovieStore_Application.Models.DTOs.MovieDTOS;
using MovieStore_Application.Models.VMs.MovieVM;
using MovieStore_Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore_Application.Services.MovieServices
{
    public interface IMovieService
    {


        Task<bool> Create(CreateMovieDTO model);
        Task<bool> Update(UpdateMovieDTO model);
        Task<bool> Delete(int id);
        Task<UpdateMovieDTO> GetById(int id);
        Task<List<MovieVM>> GetMovies();
        Task<MovieDetailsVM> GetMovieDetails(int id);
        Task<CreateMovieDTO> CreateMovie();





    }
}
