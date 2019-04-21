using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ToDoList.ViewModels
{
    public class TaskIndexViewModel
    {
        public List<Models.Task> TaskList { get; set; }

        public TaskIndexViewModel()
        {
            TaskList = new List<Models.Task>();
        }
    }
}