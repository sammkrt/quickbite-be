using Microsoft.EntityFrameworkCore;
using QuickBiteBE.Models;
using QuickBiteBE.Services.Interfaces;

namespace QuickBiteBE.Services;

public class CategoryService : ICategoryService
{
    private readonly QuickBiteContext _context;

    public CategoryService(QuickBiteContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category> GetCategoryByIdAsync(int categoryId)
    {
        return await _context.Categories.FindAsync(categoryId);
    }

    public async Task<Category> CreateCategoryAsync(string category)
    {
        var newCategory = new Category { CategoryName = category };

        await _context.Categories.AddAsync(newCategory);
        await _context.SaveChangesAsync();

        return newCategory;
    }

    public async Task<Category> UpdateCategoryAsync(int categoryId, string category)
    {
        var existingCategory = await GetCategoryByIdAsync(categoryId);

        if (existingCategory == null)
        {
            throw new ArgumentException("Category not found.");
        }

        existingCategory.CategoryName = category;

        await _context.SaveChangesAsync();

        return existingCategory;
    }

    public async Task DeleteCategoryAsync(int categoryId)
    {
        var category = await GetCategoryByIdAsync(categoryId);

        if (category == null)
        {
            throw new ArgumentException("Category not found.");
        }

        _context.Categories.Remove(category);

        await _context.SaveChangesAsync();
    }
}