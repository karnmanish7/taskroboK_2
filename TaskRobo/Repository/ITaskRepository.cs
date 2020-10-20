using System.Collections.Generic;
using System.Threading.Tasks;
using TaskRobo.Models;

namespace TaskRobo.Repository
{
    public interface ITaskRepository
    {
        Task<int> SaveTask(UserTask task);
        int DeleteTask(string email, int? taskId);
        IReadOnlyList<UserTask> GetAllTasks(string email);
        UserTask GetTaskById(string email, int? taskId);
        Task<int> UpdateTask(UserTask task);
    }
}
