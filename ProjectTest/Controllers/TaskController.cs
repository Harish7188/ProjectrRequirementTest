using Microsoft.AspNetCore.Mvc;
using ProjectTest.Services;
using ProjectTest.Models;
using static ProjectTest.Models.UsersData;

namespace ProjectTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private IUserService _userService {  get; set; }

        public TaskController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("api/Create task")] // Route for CreateTask
        public async Task<taskDetails> CreateTask(taskDetails user)
        {
            return await _userService.CreateTaskAsync(user);
        }

        [HttpGet("api/Get all tasks")]
        public async Task<IEnumerable<taskDetails>> GetAllTasks()
        {
            var users = await _userService.GetAllTasksAsync();
            return users;
        }


        [HttpGet("api/Get single task/{id}")]
        public async Task<taskDetails> GetTaskById(Guid id)
        {
            var uId = await _userService.GetTaskByIdAsync(id);
            return uId;
        }

        [HttpPut("api/Update a task/{id}")] // Route for UpdateTask
        public async Task<taskDetails> UpdateTask(Guid id, UsersData.taskDetails user)
        {
            // Check if the ID matches the provided task details ID
            var existingUser = await _userService.GetTaskByIdAsync(id);
            if (existingUser == null)
            {
                return null;
            }
            existingUser.Title = user.Title;
            existingUser.Description = user.Description;
            existingUser.Status = user.Status;
            return await _userService.UpdateTaskAsync(existingUser);

        }

        [HttpDelete("api/delete a task/{id}")]
        public async Task<taskDetails> DeleteTask(Guid id)
        {
            var dId = await _userService.DeleteTaskAsync(id);
            return dId;
        }


    }
}