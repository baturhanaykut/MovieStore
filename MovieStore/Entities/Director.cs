﻿namespace MovieStore.Entities
{
    public class Director
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        //Navigation Property

        public List<Movie> DirectedMovies { get; set; }
    }
}