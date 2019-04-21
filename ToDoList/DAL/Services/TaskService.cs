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
            task.RecordCreated = DateTime.Now;

            DBContext.Tasks.Add(task);
            DBContext.SaveChanges();
        }

        public void AddTaskUpdate(TaskUpdate taskUpdate)
        {
            taskUpdate.RecordCreated = DateTime.Now;

            DBContext.TaskUpdates.Add(taskUpdate);
            DBContext.SaveChanges();
        }

        public void DeleteTask(int taskId)
        {
            Task taskToDelete = GetTask(taskId);

            // Delete all task updates for this task
            for (int i = 0; i < taskToDelete.TaskUpdateList.Count; i++)
            {
                DeleteTaskUpdate(taskToDelete.TaskUpdateList.ElementAt(i));
            }

            DBContext.Tasks.Remove(taskToDelete);
            DBContext.SaveChanges();
        }

        public void DeleteTaskUpdate(TaskUpdate taskUpdate)
        {
            DBContext.TaskUpdates.Remove(taskUpdate);
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
            List<Task> taskList = DBContext.Tasks.Where(t => t.UserId == userId).ToList();

            foreach (var task in taskList)
            {
                task.TaskUpdateList = DBContext.TaskUpdates.Where(tu => tu.TaskId == task.Id).ToList();
            }
            return taskList;
        }

        public TaskUpdate GetTaskUpdate(int taskUpdateId)
        {
            return DBContext.TaskUpdates.Single(t => t.Id == taskUpdateId);
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