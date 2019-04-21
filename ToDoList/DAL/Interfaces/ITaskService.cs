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

        void AddTaskUpdate(TaskUpdate taskUpdate);

        void DeleteTask(int taskId);

        void DeleteTaskUpdate(TaskUpdate taskUpdate);

        Task GetTask(int id);

        List<Task> GetTasksByUser(string userGuid);

        TaskUpdate GetTaskUpdate(int taskUpdateId);

        void UpdateTask(Task task);

        void UpdateTaskCompleteFlag(int taskId, bool isTaskComplete);

        void UpdateTaskUpdate(TaskUpdate taskUpdate);
    }
}