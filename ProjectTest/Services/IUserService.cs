using ProjectTest.Models;
using static ProjectTest.Models.UsersData;

namespace ProjectTest.Services
{
    public interface IUserService
    {
        public Task<taskDetails> CreateTaskAsync(taskDetails tasks);

        public Task<IEnumerable<taskDetails>> GetAllTasksAsync();

        public Task<taskDetails> GetTaskByIdAsync(Guid taskId);

        public Task<taskDetails> UpdateTaskAsync(taskDetails task);

        public Task<taskDetails> DeleteTaskAsync(Guid id);
    }
}
