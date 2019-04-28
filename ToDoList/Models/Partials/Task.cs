using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoList.Models
{
    public partial class Task
    {
        public bool DeadlineDatePassed
        {
            get
            {
                if (DeadlineDate.HasValue && !IsTaskComplete)
                {
                    if (DeadlineDate.Value.Date < DateTime.Now.Date)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
        }
    }
}