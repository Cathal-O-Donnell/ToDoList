using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToDoList.Models
{
    public class TaskUpdate
    {
        [Key]
        public int Id { get; set; }

        public int TaskId { get; set; }
       
        public string UpdateText { get; set; }

        public DateTime RecordCreated { get; set; }

        public TaskUpdate()
        {
            RecordCreated = DateTime.Now;
        }
    }
}