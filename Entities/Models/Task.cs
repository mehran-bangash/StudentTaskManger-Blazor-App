using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public int CourseId { get; set; }
        public int UserId { get; set; }

        // Navigation properties
        public Course? Course { get; set; }
        public User? User { get; set; }
    }
}
