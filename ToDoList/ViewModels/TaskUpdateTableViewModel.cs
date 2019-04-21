using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoList.Models;

namespace ToDoList.ViewModels
{
    public class TaskUpdateTableViewModel
    {
        public List<TaskUpdate> TaskUpdateList { get; set; }

        public int TaskId { get; set; }

        public bool IsTaskComplete { get; set; }

        public TaskUpdateTableViewModel()
        {
            TaskUpdateList = new List<TaskUpdate>();
        }
    }
}