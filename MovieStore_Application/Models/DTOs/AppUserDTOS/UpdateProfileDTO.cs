using MovieStore_Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore_Application.Models.DTOs.AppUserDTOS
{
    public class UpdateProfileDTO
    {
        //ToDo : DataAnnotations ekeleyeceğiz.
        public string Id { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }

        public string ConfirmedPassword { get; set; }

        public string Email { get; set; }

        public Status Status { get; set; }

       
    }
}
