using System.Collections.Generic;
using System.Threading.Tasks;
using TaskRobo.Models;

namespace TaskRobo.Repository
{
    public interface ICategoryRepository
    {
        int DeleteCategory(int? categoryId);
        IReadOnlyList<Category> GetAllCategories(string email);
        Task<int> SaveCategory(Category category);
        Category GetCategoryById(int? categoryId);
    }
}