﻿using MovieStore_Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore_Application.Models.DTOs.StarringDTOS
{
    public class UpdateStarringDTO
    {
        public int? Id { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public Status Statu { get; set; }
    }
}
