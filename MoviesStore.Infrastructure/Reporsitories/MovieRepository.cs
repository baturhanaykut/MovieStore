using MovieStore_Domain.Entities;
using MovieStore_Domain.Repository;
using MovieStore_Infrastructure.ApllicationDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore_Infrastructure.Reporsitories
{
    internal class MovieRepository:BaseRepository<Movie>,IMovieRepository
    {
        public MovieRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            
        }
    }
}
