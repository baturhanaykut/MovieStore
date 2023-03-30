using MovieStore_Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore_Application.Models.DTOs.LanguageDTOS
{
    public class UpdateLanguageDTO
    {
       

        public string? Name { get; set; }

        public Status Statu { get; set; }
    }
}
