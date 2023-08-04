using Nik.Api.Models;

namespace Nik.Api.Services.Interfaces
{
    public interface ICategoryImageRepository
    {
        Task<List<CategoryImage>> getAllCategoryImages();
        Task<CategoryImage> getByCategoryImage(int id);
        Task putCategoryImage(int id, CategoryImage categoryImage);
        Task<CategoryImage> postCategoryImage(CategoryImage categoryImage);
        Task deleteCategoryImage(int id);
    }
}
