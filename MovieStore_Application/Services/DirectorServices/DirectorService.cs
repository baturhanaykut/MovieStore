using AutoMapper;
using MovieStore_Application.Models.DTOs.DirectorDTOS;
using MovieStore_Application.Models.VMs.DirectorVM;
using MovieStore_Domain.Entities;
using MovieStore_Domain.Enums;
using MovieStore_Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore_Application.Services.DirectorServices
{
    public class DirectorService : IDirectorService
    {
        private readonly IDirectorRepository _directorRepository;
        private readonly IMapper _mapper;

        public DirectorService(IDirectorRepository directorRepository, IMapper mapper)
        {
            _directorRepository = directorRepository;
            _mapper = mapper;
        }

        public async Task<bool> Create(CreateDirectorDTO model)
        {
            Director director = _mapper.Map<Director>(model);
            return await _directorRepository.Add(director);
        }

        public async Task<bool> Delete(int id)
        {
            Director director = await _directorRepository.GetDefault(x => x.Id == id);
            director.Statu = Status.Deleted;
            return await _directorRepository.Delete(director);
        }

        public async Task<DirectorDetailsVM> GetDirectorDetails(int id)
        {
            //GetFitredList ile yazmamız gerekebilir.
            Director director = await _directorRepository.GetDefault(x => x.Id == id);
            return _mapper.Map<DirectorDetailsVM>(director);
        }

        public async Task<List<DirectorVM>> GetDirectors()
        {
            var directors = await _directorRepository.GetFilteredList(
                 select: x => new DirectorVM
                 {
                     Id = x.Id,
                     FirstName = x.FirstName,
                     LastName = x.LastName,
                     BirthDate = x.BirthDate,

                 },
                 where: x => x.Statu != Status.Passive && x.Statu != Status.Deleted,
                 orderBy: x => x.OrderBy(x => x.FirstName)
                 );
            return directors;

        }

        public async Task<bool> Update(UpdateDirectorDTO model)
        {
            Director director = _mapper.Map<Director>(model);
            return await _directorRepository.Update(director);
        }
    }
}
