using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList.Models;
using ToDoList.ViewModels;

namespace ToDoList.Controllers
{
    public class TaskController : Controller
    {
        private ApplicationDbContext DBContext;

        public TaskController()
        {
            DBContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            DBContext.Dispose();
        }

        // GET: Task
        public ActionResult Index()
        {
            List<Task> taskList = new List<Task>();

            taskList = DBContext.Tasks.ToList();

            // Get TaskUpdates
            foreach (var task in taskList)
            {
                task.TaskUpdateList = DBContext.TaskUpdates.Where(t => t.TaskId == task.Id).ToList();
            }

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
            taskUpdate.RecordCreated = DateTime.Now;

            // Add new task to the Db
            DBContext.TaskUpdates.Add(taskUpdate);
            DBContext.SaveChanges();

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
            newTask.UserId = -1;

            DBContext.Tasks.Add(newTask);
            DBContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            // Check that the current user is the owner of this task
            Task task = DBContext.Tasks.SingleOrDefault(t => t.Id == id);

            return View(task);
        }

        [HttpPost]
        public ActionResult Edit(Task task)
        {
            // Get existing record
            Task taskDb = DBContext.Tasks.Single(t => t.Id == task.Id);

            // Update properties
            taskDb.Title = task.Title;
            taskDb.Description = task.Description;
            taskDb.LastUpdated = DateTime.Now;

            // Save changes
            DBContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Detail(int id)
        {
            // Check that the current user is the owner of this task

            Task task = DBContext.Tasks.SingleOrDefault(t => t.Id == id);
            task.TaskUpdateList = DBContext.TaskUpdates.Where(t => t.TaskId == task.Id).ToList();

            return View(task);
        }

        [HttpPost]
        public void UpdateTaskCompleteFlag(int taskId, bool isTaskComplete)
        {
            Task task = DBContext.Tasks.SingleOrDefault(t => t.Id == taskId);

            task.IsTaskComplete = isTaskComplete;
            task.LastUpdated = DateTime.Now;

            // Save changes
            DBContext.SaveChanges();
        }
    }
}