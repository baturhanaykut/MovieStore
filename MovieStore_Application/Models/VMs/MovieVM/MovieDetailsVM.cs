using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore_Application.Models.VMs.MovieVM
{
    public class MovieDetailsVM
    {
        public int? Id{ get; set; }
        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }

        public int? DirectorId { get; set; }
        public string DirectorName { get; set; }

        public decimal? Price { get; set; }

        public int? RunningTimeMin { get; set; }

        public int? LanguageId { get; set; }

        public string LanguageName { get; set; }
        public bool? IsActive { get; set; }

        public int? Stock { get; set; }

        public string? ImagePath { get; set; }

    }
}
