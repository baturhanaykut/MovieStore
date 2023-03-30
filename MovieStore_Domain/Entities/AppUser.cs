using Microsoft.AspNetCore.Identity;
using MovieStore_Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore_Domain.Entities
{
    public class AppUser : IdentityUser, IBaseEntity
    {
        public Status Statu { get ; set ; }
    }
}
