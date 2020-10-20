using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using TaskRobo.Models;

namespace TaskRobo.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        readonly TaskDbContext context;
        public CategoryRepository()
        {
            context = new TaskDbContext();
        }

        // This method should be used to delete category details from database based upon category id
        public int DeleteCategory(int? categoryId)
        {
            int result = 0;
            try
            {
                var categoryToDelete = context.Categories.FirstOrDefault(x => x.CategoryID == categoryId);
                if (categoryToDelete != null)
                {
                    context.Categories.Remove(categoryToDelete);
                    result = context.SaveChanges();
                    return result;
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        // This method should be used to get all categories from database based upon user's email
        public IReadOnlyList<Category> GetAllCategories(string email)
        {
            var result = context.AppUsers.FirstOrDefault(x => x.Email == email);

            if (context != null)
            {
                //var getAllCategories = context.Categories.ToList();
                var getAllCategories = context.Categories.Where(x => x.UserID == result.UserID).ToList();

                return getAllCategories;
            }
            return null;

        }

        // This method should be used to get category details based upon category id
        public Category GetCategoryById(int? categoryId)
        {
            if (context != null)
            {
                var result = context.Categories.Find(categoryId);

                return result;
            }
            return null;
        }

        // This method should be used to save category details into database
        public async Task<int> SaveCategory(Category category)
        {
            if (context != null)
            {
                context.Categories.Add(category);
                await context.SaveChangesAsync();
                return category.CategoryID;
            }
            return 0;
        }
    }
}