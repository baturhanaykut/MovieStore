using MovieStore_Domain.Entities;
using MovieStore_Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MovieStore_Application.Models.DTOs.StarringDTOS
{
    public class UpdateStarringDTO
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
        public Status Statu => Status.Modified;
    }
}
