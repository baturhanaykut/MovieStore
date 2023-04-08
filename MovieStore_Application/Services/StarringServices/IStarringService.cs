using MovieStore_Application.Models.DTOs.CategoryDTOS;
using MovieStore_Application.Models.DTOs.StarringDTOS;
using MovieStore_Application.Models.VMs.StarringVM;

namespace MovieStore_Application.Services.StarringServices
{
    public interface IStarringService
    {
        Task<bool> Create(CreateStarringDTO model);
        Task<bool> Update(UpdateStarringDTO model);
        Task<bool> Delete(int id);
        Task<List<StarringVM>> GetStarrings();

        Task<UpdateStarringDTO> GetById(int id);

    }
}