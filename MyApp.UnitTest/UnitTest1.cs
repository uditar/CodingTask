using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyApp;
using Moq;
using System.Web.Mvc;
using System.Net;

namespace MyApp.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Controllers.ToDoModelsController controller = new Controllers.ToDoModelsController();
            //change the Id to any existing task ID eg. 3/4/6
            ActionResult result = controller.DeleteConfirmed(3);
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));

            RedirectToRouteResult routeResult = result as RedirectToRouteResult;
            Assert.AreEqual(routeResult.RouteValues["action"], "Index");

        }
    }
}
