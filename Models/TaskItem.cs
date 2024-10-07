using System.ComponentModel.DataAnnotations;

namespace WebToDoApp.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Task name is required.")]
        public required string Name { get; set; }
        public bool IsComplete { get; set; }

        [Required(ErrorMessage = "Due date is required.")]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        public string? Description { get; set; }
    }
}