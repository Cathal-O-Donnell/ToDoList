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

        public ActionResult TaskDetail(int taskId)
        {
            Task task = DBContext.Tasks.SingleOrDefault(t => t.Id == taskId);

            return View(task);
        }
    }
}