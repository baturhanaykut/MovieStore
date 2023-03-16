﻿using MovieStore.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MovieStore.Models.ViewModels
{
    public class StarringVM
    {
        public int? Id { get; set; }
        
       
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
        
        
        [Display(Name = "Birth Date")]
        public DateTime? BirthDate { get; set; }
        [Display(Name = "Perfomed Movies")]
        public List<Movie>? PerformedMovies { get; set; }
    }
}
