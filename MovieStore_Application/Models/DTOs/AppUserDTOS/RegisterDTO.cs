using MovieStore_Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore_Application.Models.DTOs.AppUserDTOS
{
    public class RegisterDTO
    {
        //ToDo : DataAnnotations ekeleyeceğiz. 
        public string UserName { get; set; }

        public string Password { get; set; }

        public string ComfirmPassword { get; set; }

        public string Email { get; set; }

        public Status status => Status.Active;
    }
}
