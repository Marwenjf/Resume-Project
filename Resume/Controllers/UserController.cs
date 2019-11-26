using Resume.Context;
using Resume.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Resume.Controllers
{
    public class UserController : Controller
    {
        OntomagContext db = new OntomagContext();
        // GET: User
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            User user = db.Users.Find(id);
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            User user = new User();
            return View(user);
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(user);
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
            {
                return View(user);
            }
            return RedirectToAction("Index");
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(user);

            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            User user = db.Users.Find(id);
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, User user)
        {
            try
            {
                User deletedUser = db.Users.Find(id);
                if (deletedUser != null)
                {
                    db.Users.Remove(deletedUser);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(id);
            }
            catch
            {
                return View();
            }
        }
    }
}