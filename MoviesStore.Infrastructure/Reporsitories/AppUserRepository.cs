﻿using MovieStore_Domain.Entities;
using MovieStore_Domain.Repository;
using MovieStore_Infrastructure.ApllicationDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore_Infrastructure.Reporsitories
{
    internal class AppUserRepository:BaseRepository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            
        }
    }
}
