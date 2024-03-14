using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectTest.Data;
using ProjectTest.Models;
using static ProjectTest.Models.UsersData;

namespace ProjectTest.Services
{
    public class UserService : IUserService
    {
        private readonly DbContextClass _contextClass;

        public UserService(DbContextClass contextClass)
        {
            _contextClass = contextClass;
        }
        public async Task<taskDetails> CreateTaskAsync(taskDetails tasks)
        {
            try
            {
                var result = await _contextClass.Tasks.AddAsync(tasks);
                _contextClass.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex) 
            {
                throw new Exception("Error occurred while creating task.", ex);
            }              
        }

        public async Task<IEnumerable<taskDetails>> GetAllTasksAsync()
        {
            try
            {
                var users = await _contextClass.Tasks.ToListAsync();
                return users;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while getting all tasks.", ex);
            }

        }

        public async Task<taskDetails> GetTaskByIdAsync(Guid taskId)
        {
            try
            {
                return await _contextClass.Tasks.Where(x => x.Id == taskId).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while getting task with ID {taskId}.", ex);
            }
           
        }

        public async Task<taskDetails> UpdateTaskAsync(taskDetails task)
        {
            try
            {
                var result = _contextClass.Tasks.Update(task);
                await _contextClass.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while updating task.", ex);
            }
            
        }
        public async Task<taskDetails> DeleteTaskAsync(Guid id)
        {
            try
            {
                var result = await _contextClass.Tasks.Where(x => x.Id == id).FirstOrDefaultAsync();
                var res = _contextClass.Tasks.Remove(result);
                await _contextClass.SaveChangesAsync();
                return res.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while deleting task with ID {id}.", ex);
            }

        }

    }
}
