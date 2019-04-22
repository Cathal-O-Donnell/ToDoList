using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using ToDoList;
using ToDoList.Controllers;
using ToDoList.Models;
using ToDoList.ViewModels;
using ToDoList.DAL.Services;
using ToDoList.DAL.Interfaces;

namespace ToDoListTests
{
    [TestClass]
    public class TaskControllerTest
    {
        [TestMethod]
        public void Index()
        {
            TaskController taskController = new TaskController();

            ActionResult result = taskController.Index() as ActionResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Detail()
        {
            TaskController taskController = new TaskController();

            ActionResult result = taskController.Detail(5) as ActionResult;

            Assert.IsNotNull(result);
        }
    }
}
