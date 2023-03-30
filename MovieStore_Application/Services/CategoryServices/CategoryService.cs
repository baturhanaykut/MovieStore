using AutoMapper;
using MovieStore_Application.Models.DTOs.CategoryDTOS;
using MovieStore_Application.Models.VMs.CategoryVM;
using MovieStore_Domain.Entities;
using MovieStore_Domain.Enums;
using MovieStore_Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore_Application.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<bool> Create(CreateCategoryDTO model)
        {
            Category newCategory = _mapper.Map<Category>(model);
            return await _categoryRepository.Add(newCategory);

        }

        public async Task<bool> Delete(int id)
        {
            Category deleteCategory = await _categoryRepository.GetDefault(x => x.Id == id);
            deleteCategory.Statu = Status.Deleted;
            return await _categoryRepository.Delete(deleteCategory);

        }

        public async Task<UpdateCategoryDTO> GetById(int id)
        {
            Category category = await _categoryRepository.GetDefault(x => x.Id == id);
            return _mapper.Map<UpdateCategoryDTO>(category);
        }

        public async Task<List<CategoryVM>> GetCategories()
        {         

            var categoriess = await _categoryRepository.GetFilteredList(
                select: x => new CategoryVM
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                },
                where: x => x.Statu != Status.Passive && x.Statu != Status.Deleted,
                orderBy : x=>x.OrderBy(x=>x.Name)
                );
            return categoriess;
        }

        public async Task<CategoryVM> GetCategoryDetails(int id)
        {
            Category category = await _categoryRepository.GetDefault(x => x.Id ==id);

            return _mapper.Map<CategoryVM>(category);
        }

        public async Task<bool> Update(UpdateCategoryDTO model)
        {
            Category category = _mapper.Map<Category>(model);

            return await _categoryRepository.Update(category);
        }
    }
}
