using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList.DAL.Interfaces;
using ToDoList.DAL.Services;
using ToDoList.Models;
using ToDoList.ViewModels;
using Microsoft.AspNet.Identity;

namespace ToDoList.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private ApplicationDbContext DBContext;

        private ITaskService taskService;

        public TaskController()
        {
            DBContext = new ApplicationDbContext();
            taskService = new TaskService(new ApplicationDbContext());
        }

        protected override void Dispose(bool disposing)
        {
            DBContext.Dispose();
        }

        public string UserGuid
        {
            get
            {
                string userGuid = User.Identity.GetUserId();

                if (!String.IsNullOrEmpty(userGuid))
                    return userGuid;
                else
                    return "";
            }
        }

        public ActionResult Index()
        {
            List<Task> taskList = taskService.GetTasksByUser(UserGuid);

            // Get list of tasks for the current user            
            TaskIndexViewModel viewModel = new TaskIndexViewModel()
            {
                TaskList = taskList
            };

            return View(viewModel);
        }

        public ActionResult NewUpdate(int taskId)
        {           
            TaskUpdate newTaskUpdate = new TaskUpdate()
            {
                TaskId = taskId
            };

            return View(newTaskUpdate);
        }

        [HttpPost]
        public ActionResult NewUpdate(TaskUpdate taskUpdate)
        {
            // Validate model states
            if (!ModelState.IsValid)
                return View("NewUpdate", taskUpdate);

            taskService.AddTaskUpdate(taskUpdate);

            // Redirect to the Detail view
            return RedirectToAction("Detail", new { Id = taskUpdate.TaskId });
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(Task newTask)
        {
            // Validate model states
            if (!ModelState.IsValid)            
                return View("New", newTask);            

            newTask.UserGuid = UserGuid;

            taskService.AddTask(newTask);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Task task = taskService.GetTask(id);

            return View(task);
        }

        [HttpPost]
        public ActionResult Edit(Task task)
        {
            taskService.UpdateTask(task);

            return RedirectToAction("Index");
        }

        public ActionResult Detail(int id)
        {
            Task task = taskService.GetTask(id);

            return View(task);
        }

        [HttpPost]
        public void UpdateTaskCompleteFlag(int taskId, bool isTaskComplete)
        {
            taskService.UpdateTaskCompleteFlag(taskId, isTaskComplete);
        }

        [HttpPost]
        public void DeleteTask(int taskId)
        {
            taskService.DeleteTask(taskId);
        }

        [HttpPost]
        public void DeleteTaskUpdate(int taskUpdateId)
        {
            TaskUpdate taskUpdateToDelete = taskService.GetTaskUpdate(taskUpdateId);

            taskService.DeleteTaskUpdate(taskUpdateToDelete);
        }
    }
}