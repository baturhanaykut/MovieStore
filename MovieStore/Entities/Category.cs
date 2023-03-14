﻿namespace MovieStore.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        //Navigation Property

        public List<Movie> Movies { get; set; }

    }
}