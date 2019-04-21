using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.DAL.Interfaces;
using ToDoList.Models;

namespace ToDoList.DAL.Services
{
    public class TaskService : ITaskService
    {

        private ApplicationDbContext DBContext;

        public TaskService(ApplicationDbContext DBContext)
        {
            this.DBContext = DBContext;
        }

        public void AddTask(Task task)
        {
            DBContext.Tasks.Add(task);
            DBContext.SaveChanges();
        }

        public Task GetTask(int id)
        {
            Task task = DBContext.Tasks.SingleOrDefault(t => t.Id == id);

            if (task != null)
                task.TaskUpdateList = DBContext.TaskUpdates.Where(t => t.TaskId == task.Id).ToList();

            return task;
        }

        public List<Task> GetTasksByUser(int userId)
        {
            return DBContext.Tasks.Where(t => t.UserId == userId).ToList();
        }

        public void UpdateTask(Task task)
        {
            Task taskInDb = DBContext.Tasks.Single(t => t.Id == task.Id);

            taskInDb.Title = task.Title;
            taskInDb.Description = task.Description;
            taskInDb.IsTaskComplete = task.IsTaskComplete;
            task.LastUpdated = DateTime.Now;

            DBContext.SaveChanges();
        }

        public void UpdateTaskCompleteFlag(int taskId, bool isTaskComplete)
        {
            Task task = GetTask(taskId);

            task.IsTaskComplete = isTaskComplete;

            UpdateTask(task);
        }
    }
}