using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MyApp.Models;

namespace MyApp.Controllers
{
    public class ToDoModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ToDoModels
        public ActionResult Index()
        {
            //get current logged in user's ID
            string CurrentUserID = User.Identity.GetUserId();
            ApplicationUser Current_User = db.Users.FirstOrDefault(x => x.Id == CurrentUserID);
           
            //only return data for currently logged in user
            return View(db.ToDoListItems.ToList().Where(x=>x.User == Current_User));
        }

        // GET: ToDoModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDoModel toDoModel = db.ToDoListItems.Find(id);
            if (toDoModel == null)
            {
                return HttpNotFound();
            }
            return View(toDoModel);
        }

        // GET: ToDoModels/Create
        public ActionResult Create()
        {
            
            {
                return View();
            }
        }

        // POST: ToDoModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Task_ID,Task_Description,Is_Task_Complete,Due_In")] ToDoModel toDoModel)
        {
            if (ModelState.IsValid)
            {
                //get current logged in user's ID
                string CurrentUserID = User.Identity.GetUserId();
                ApplicationUser Current_User = db.Users.FirstOrDefault(x => x.Id == CurrentUserID);

                //set model user to current user in order to save tasks specific to a user
                toDoModel.User = Current_User;
                db.ToDoListItems.Add(toDoModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(toDoModel);
        }

        // GET: ToDoModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDoModel toDoModel = db.ToDoListItems.Find(id);
            if (toDoModel == null)
            {
                return HttpNotFound();
            }
            return View(toDoModel);
        }

        // POST: ToDoModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Task_ID,Task_Description,Is_Task_Complete,Due_In")] ToDoModel toDoModel)
        {
            if (ModelState.IsValid)
            {
                //get current logged in user's ID
                string CurrentUserID = User.Identity.GetUserId();
                ApplicationUser Current_User = db.Users.FirstOrDefault(x => x.Id == CurrentUserID);

                //set model user to current user in order to save tasks specific to a user
                toDoModel.User = Current_User;
                toDoModel.Last_Updated = DateTime.Now;
                db.Entry(toDoModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(toDoModel);
        }

        // GET: ToDoModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDoModel toDoModel = db.ToDoListItems.Find(id);
            if (toDoModel == null)
            {
                return HttpNotFound();
            }
            return View(toDoModel);
        }

        // POST: ToDoModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ToDoModel toDoModel = db.ToDoListItems.Find(id);
            db.ToDoListItems.Remove(toDoModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
