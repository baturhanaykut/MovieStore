using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using MovieStore_Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore_Domain.Entities
{
    public class AppUser : IdentityUser, IBaseEntity
    {

        public string ImagePath { get; set; }

        [NotMapped]
        public IFormFile UploadPath { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteTime { get; set; }

        public Status Status { get ; set ; }
    }
}
