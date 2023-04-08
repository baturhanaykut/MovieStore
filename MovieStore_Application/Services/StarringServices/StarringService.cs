using AutoMapper;
using MovieStore_Application.Models.DTOs.StarringDTOS;
using MovieStore_Application.Models.VMs.StarringVM;
using MovieStore_Domain.Entities;
using MovieStore_Domain.Enums;
using MovieStore_Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore_Application.Services.StarringServices
{
    public class StarringService : IStarringService
    {
        private readonly IStarringRepository _starringRepository;
        private readonly IMapper _mapper;
        public StarringService(IStarringRepository starringRepository, IMapper mapper)
        {
            _starringRepository = starringRepository;
            _mapper = mapper;
        }



        public async Task<bool> Create(CreateStarringDTO model)
        {
            Starring newStarring = _mapper.Map<Starring>(model);
            return await _starringRepository.Add(newStarring);
        }

        public async Task<bool> Delete(int id)
        {
            Starring deleteStarring = await _starringRepository.GetDefault(x => x.Id == id);
            deleteStarring.Status = Status.Deleted;
            return await _starringRepository.Delete(deleteStarring);
        }

        public async Task<UpdateStarringDTO> GetById(int id)
        {
            Starring starring = await _starringRepository.GetDefault(x=>x.Id == id);
            return _mapper.Map<UpdateStarringDTO>(starring);
        }

        public Task<List<StarringVM>> GetStarrings()
        {
            var starrings = _starringRepository.GetFilteredList(
                select: x => new StarringVM
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    BirthDate = x.BirthDate
                },
                where: x => x.Status != Status.Passive && x.Status != Status.Deleted,
                orderBy: x => x.OrderBy(x => x.FirstName)
                );

            return starrings;
        }


        public async Task<bool> Update(UpdateStarringDTO model)
        {
            Starring starring = _mapper.Map<Starring>(model);
            return await _starringRepository.Update(starring);
        }
    }
}
