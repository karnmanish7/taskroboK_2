using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using TaskRobo.Models;

namespace TaskRobo.Repository
{
    public class TaskRepository : ITaskRepository
    {
        readonly TaskDbContext context;
        public TaskRepository()
        {
            context = new TaskDbContext();
        }

        // This method should be used to delete task details from database based upon user's email & task id
        public int DeleteTask(string email, int? taskId)
        {
            int result = 0;
            try
            {
                var taskToDelete = context.UserTasks.FirstOrDefault(x => x.TaskId == taskId);
                if (taskToDelete != null)
                {
                    context.UserTasks.Remove(taskToDelete);
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

        // This method should be used to get all task details from database based upon user's email
        public IReadOnlyList<UserTask> GetAllTasks(string email)
        {
            var result = context.AppUsers.FirstOrDefault(x => x.Email == email);
            if (context != null)
            {
                var getAllTasks = context.UserTasks.Include(c => c.catogories).Where(x => x.UserID == result.UserID).ToList();

                return getAllTasks;
            }
            return null;
        }

        // This method should be used to get task details from database based upon user's email and task id
        public UserTask GetTaskById(string email, int? taskId)
        {
            if (context != null)
            {
                var result = context.UserTasks.Find(taskId);

                return result;
            }
            return null;
        }

        // This method should be used to save task details into database 
        public async Task<int> SaveTask(UserTask task)
        {
            if (context != null)
            {
                context.UserTasks.Add(task);
                await context.SaveChangesAsync();
                return task.TaskId;
            }
            return 0;
        }

        // This method should be used to update task details into database
        public async Task<int> UpdateTask(UserTask task)
        {
            if (context != null)
            {
                context.Entry(task).State = EntityState.Modified;
                await context.SaveChangesAsync();

                return task.TaskId;
            }
            return 0;
        }
    }
}