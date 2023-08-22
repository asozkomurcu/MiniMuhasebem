using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MiniMuhasebem.Application.Behaviors;
using MiniMuhasebem.Application.Exceptions;
using MiniMuhasebem.Application.Models.Dtos.CategoryDtos;
using MiniMuhasebem.Application.Models.RequestModels.CategoryRM;
using MiniMuhasebem.Application.Services.Abstraction;
using MiniMuhasebem.Application.Validators.CategoriesValidators;
using MiniMuhasebem.Application.Wrapper;
using MiniMuhasebem.Domain.Entities;
using MiniMuhasebem.Domain.UWork;

namespace MiniMuhasebem.Application.Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _uWork;
        public CategoryService(IMapper mapper, IUnitWork uWork)
        {
            _mapper = mapper;
            _uWork = uWork;
        }


        public async Task<Result<List<CategoryDto>>> GetAllCategories()
        {
            var result = new Result<List<CategoryDto>>();

            var categoryEntites = await _uWork.GetRepository<Category>().GetAllAsync();
            var categoryDtos = await categoryEntites.ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
            result.Data = categoryDtos;
            _uWork.Dispose();
            return result;
        }


        [ValidationBehavior(typeof(GetCategoryByIdValidator))]
        public async Task<Result<CategoryDto>> GetCategoryById(GetCategoryByIdVM getCategoryByIdVM)
        {
            var result = new Result<CategoryDto>();

            var categoryExists = await _uWork.GetRepository<Category>().AnyAsync(x => x.Id == getCategoryByIdVM.Id);
            if (!categoryExists)
            {
                throw new NotFoundException($"{getCategoryByIdVM.Id} numaralı kategori bulunamadı.");
            }

            var categoryEntity = await _uWork.GetRepository<Category>().GetById(getCategoryByIdVM.Id);

            var categoryDto = _mapper.Map<Category, CategoryDto>(categoryEntity);

            result.Data = categoryDto;
            _uWork.Dispose();
            return result;
        }


        [ValidationBehavior(typeof(CreateCategoryValidator))]
        public async Task<Result<int>> CreateCategory(CreateCategoryVM createCategoryVM)
        {
            var result = new Result<int>();

            var categoryEntity = _mapper.Map<CreateCategoryVM, Category>(createCategoryVM);

            _uWork.GetRepository<Category>().Add(categoryEntity);
            await _uWork.CommitAsync();

            result.Data = categoryEntity.Id;
            _uWork.Dispose();
            return result;
        }


        [ValidationBehavior(typeof(DeleteCategoryValidator))]
        public async Task<Result<int>> DeleteCategory(DeleteCategoryVM deleteCategoryVM)
        {
            var result = new Result<int>();

            var categoryExists = await _uWork.GetRepository<Category>().AnyAsync(x => x.Id == deleteCategoryVM.Id);
            if (!categoryExists)
            {
                throw new NotFoundException($"{deleteCategoryVM.Id} numaralı kategori bulunamadı.");
            }

            _uWork.GetRepository<Category>().Delete(deleteCategoryVM.Id);
            await _uWork.CommitAsync();

            result.Data = deleteCategoryVM.Id;
            _uWork.Dispose();
            return result;
        }


        [ValidationBehavior(typeof(UpdateCategoryValidator))]
        public async Task<Result<int>> UpdateCategory(UpdateCategoryVM updateCategoryVM)
        {
            var result = new Result<int>();

            var existsCategory = await _uWork.GetRepository<Category>().GetById(updateCategoryVM.Id);
            if (existsCategory is null)
            {
                throw new Exception($"{updateCategoryVM} numaralı kategori bulunamadı.");
            }


            var updatedCategory = _mapper.Map(updateCategoryVM, existsCategory);

            _uWork.GetRepository<Category>().Update(updatedCategory);
            await _uWork.CommitAsync();

            result.Data = updatedCategory.Id;
            _uWork.Dispose();
            return result;
        }

    }
}
