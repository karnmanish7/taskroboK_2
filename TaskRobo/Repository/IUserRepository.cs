using System.Collections.Generic;
using TaskRobo.Models;

namespace TaskRobo.Repository
{
    public interface IUserRepository
    {
        int CreateUser(AppUser user);
        bool IsAuthenticated(AppUser user);

        string GetUserIdByEmail(string Email);

        List<Category> GetCategoriesForUser(string Email);
    }
}