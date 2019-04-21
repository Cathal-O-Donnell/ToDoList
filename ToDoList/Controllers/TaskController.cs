using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList.Models;

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
            // Get list of tasks for the current user            

            return View();
        }
        
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(Task newTask)
        {
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            // Check that the current user is the owner of this task
            return View();
        }

        public ActionResult TaskDetail(int id)
        {
            // Check that the current user is the owner of this task

            Task task = DBContext.Tasks.SingleOrDefault(t => t.Id == id);

            return View(task);
        }
    }
}