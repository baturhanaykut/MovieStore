﻿using MovieStore.Models.DataAccess;
using MovieStore.Models.Entities;
using MovieStore.Repository.Abstract;
using System.Linq.Expressions;

namespace MovieStore.Repository.Concerete
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IMovieDbContext _context;

        public MovieRepository(MovieDbContext context)
        {
            _context = context;
        }

        public bool Add(Movie entity)
        {
            _context.Movies.Add(entity);
            return Save() > 0;
        }

        public bool Delete(int Id)
        {
            _context.Movies.Remove(GetById(Id));
            return Save() > 0;
        }

        public List<Movie> GetAll()
        {
           return _context.Movies.ToList();
        }

        public Movie GetById(int id)
        {
            return _context.Movies.Find(id);
        }

        public List<Movie> GetDefault(Expression<Func<Movie, bool>> exp)
        {
            return _context.Movies.Where(exp).ToList();
        }


        public bool Update(Movie entity)
        {
            _context.Movies.Update(entity);
            return Save() > 0;
        }
        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
