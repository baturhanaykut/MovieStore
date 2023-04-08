using AutoMapper;
using MovieStore_Application.Models.DTOs.LanguageDTOS;
using MovieStore_Application.Models.VMs.LanguageVM;
using MovieStore_Domain.Entities;
using MovieStore_Domain.Enums;
using MovieStore_Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore_Application.Services.LanguageServices
{
    public class LanguageService : ILanguageService
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;

        public LanguageService(ILanguageRepository languageRepository, IMapper mapper)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
        }

        public async Task<bool> Create(CreateLanguageDTO model)
        {
            Language language = _mapper.Map<Language>(model);
            return await _languageRepository.Add(language);
        }

        public async Task<bool> Delete(int id)
        {
            Language deleteLanguage = await _languageRepository.GetDefault(x => x.Id == id);
            deleteLanguage.Status = Status.Deleted;
            return await _languageRepository.Delete(deleteLanguage);

        }

        public async Task<UpdateLanguageDTO> GetById(int id)
        {
            Language language = await _languageRepository.GetDefault(x => x.Id == id);
            return _mapper.Map<UpdateLanguageDTO>(language);
        }

        public async Task<List<LanguageVM>> GetLanguages()
        {
           var languages = await _languageRepository.GetFilteredList(
                select: x => new LanguageVM
                {
                    Id = x.Id,
                    Name = x.Name,
                },
                where: x => x.Status != Status.Passive && x.Status != Status.Deleted,
                orderBy: x => x.OrderBy(x => x.Name)
                );
            return languages;
        }

        public async Task<bool> Update(UpdateLanguageDTO model)
        {
            Language language = _mapper.Map<Language>(model);
            return await _languageRepository.Update(language);
        }
    }
}
