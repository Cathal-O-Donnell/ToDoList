﻿using System;
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

        List<Task> GetTasksByUser(string userGuid);

        Task GetTask(int id);

        TaskUpdate GetTaskUpdate(int taskUpdateId);

        void UpdateTask(Task task);

        void UpdateTaskUpdate(TaskUpdate taskUpdate);

        void UpdateTaskCompleteFlag(int taskId, bool isTaskComplete);
    }
}