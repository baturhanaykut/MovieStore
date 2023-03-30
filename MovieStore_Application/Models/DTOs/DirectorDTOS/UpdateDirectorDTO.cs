using MovieStore_Application.Models.VMs.MovieVM;
using MovieStore_Domain.Entities;
using MovieStore_Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore_Application.Models.DTOs.DirectorDTOS
{
    public class UpdateDirectorDTO
    {
        public int? Id { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public Status Statu { get; set; }
        
        //Navigation Property

        public List<MovieVM>? DirectedMovies { get; set; }
    }
}
