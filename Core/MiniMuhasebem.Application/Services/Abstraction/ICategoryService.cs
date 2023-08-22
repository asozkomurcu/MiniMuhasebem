using MiniMuhasebem.Application.Models.Dtos.CategoryDtos;
using MiniMuhasebem.Application.Models.RequestModels.CategoryRM;
using MiniMuhasebem.Application.Wrapper;

namespace MiniMuhasebem.Application.Services.Abstraction
{
    public interface ICategoryService
    {
        Task<Result<List<CategoryDto>>> GetAllCategories();
        Task<Result<CategoryDto>> GetCategoryById(GetCategoryByIdVM getCategoryByIdVM);

        Task<Result<int>> CreateCategory(CreateCategoryVM createCategoryVM);
        Task<Result<int>> UpdateCategory(UpdateCategoryVM updateCategoryVM);
        Task<Result<int>> DeleteCategory(DeleteCategoryVM deleteCategoryVM);
    }
}
