using MovieStore_Application.Models.DTOs.CategoryDTOS;
using MovieStore_Application.Models.DTOs.LanguageDTOS;
using MovieStore_Application.Models.VMs.LanguageVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore_Application.Services.LanguageServices
{
    public interface ILanguageService
    {
        Task<bool> Create(CreateLanguageDTO model);
        Task<bool> Delete(int id);
        Task<bool> Update(UpdateLanguageDTO model);
        Task<UpdateLanguageDTO> GetById(int id);
        Task<List<LanguageVM>> GetLanguages();


    }
}
