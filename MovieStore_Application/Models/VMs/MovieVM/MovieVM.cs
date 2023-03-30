using MovieStore_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore_Application.Models.VMs.MovieVM
{
    public class MovieVM
    {
        public int? Id { get; set; }
        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime? ReleaseDate { get; set; }

       
        public string CategoryName { get; set; }

        
        public string DirectorName { get; set; }

        public decimal? Price { get; set; }

       
        public int? Stock { get; set; }

        public Category? Category { get; set; }

        public Director? Director { get; set; }


    }
}
