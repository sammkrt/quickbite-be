using QuickBiteBE.Models;

namespace QuickBiteBE.Services.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<Category>> GetAllCategoriesAsync();
    Task<Category> GetCategoryByIdAsync(int categoryId);
    Task<Category> CreateCategoryAsync(string category);
    Task<Category> UpdateCategoryAsync(int categoryId, string category);
    Task DeleteCategoryAsync(int categoryId);


}