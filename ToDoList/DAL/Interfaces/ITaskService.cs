using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoList.Models;

namespace ToDoList.DAL.Interfaces
{
    public interface ITaskService
    {
        void AddTask(Task task);

        List<Task> GetTasksByUser(int userId);

        Task GetTask(int id);

        void UpdateTask(Task task);

        void UpdateTaskCompleteFlag(int taskId, bool isTaskComplete);
    }
}