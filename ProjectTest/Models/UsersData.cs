using System.ComponentModel.DataAnnotations;

namespace ProjectTest.Models
{
    public class UsersData
    {
        public enum TaskStatus
        {
            Pending,
            Completed
        }
        public class taskDetails
        {
            [Key]
            public Guid Id { get; set; }
            [Required]
            public string Title { get; set; }
            [Required]
            public string Description { get; set; }
            [EnumDataType(typeof(TaskStatus))]
            public TaskStatus Status { get; set; }
        }
    }
}
