using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToDoList.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(75)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(255)]
        public string Description { get; set; }

        public bool IsTaskComplete { get; set; }

        [Display(Name = "Last Updated")]
        public DateTime? LastUpdated { get; set; }

        [Display(Name = "Created")]
        public DateTime RecordCreated { get; set; }

        public List<TaskUpdate> TaskUpdateList { get; set; }

        public int UserId { get; set; }

        public Task()
        {
            IsTaskComplete = false;
            TaskUpdateList = new List<TaskUpdate>();
        }
    }
}