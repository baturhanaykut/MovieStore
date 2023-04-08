using MovieStore_Application.Models.DTOs.DirectorDTOS;
using MovieStore_Application.Models.VMs.DirectorVM;

namespace MovieStore_Application.Services.DirectorServices
{
    public interface IDirectorService
    {
        Task<bool> Create(CreateDirectorDTO model);
        Task<bool> Update(UpdateDirectorDTO model);
        Task<bool> Delete(int id);
        Task<List<DirectorVM>> GetDirectors();

        Task<DirectorDetailsVM> GetDirectorDetails(int id);

        
    }
}