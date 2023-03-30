using MovieStore_Application.Models.DTOs.CategoryDTOS;
using MovieStore_Application.Models.VMs.CategoryVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore_Application.Services.CategoryServices
{
    public interface ICategoryService
    {

        Task<bool> Create(CreateCategoryDTO model);

        Task<bool> Delete(int id);

        Task<bool> Update(UpdateCategoryDTO model);

        Task<UpdateCategoryDTO> GetById(int id);

        Task<List<CategoryVM>> GetCategories();

        Task<CategoryVM> GetCategoryDetails(int id);


    }
}
