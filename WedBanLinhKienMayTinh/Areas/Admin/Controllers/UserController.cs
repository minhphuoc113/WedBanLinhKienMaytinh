using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WedBanLinhKienDienTu.Models.Dao;

namespace WedBanLinhKienMayTinh.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        public ActionResult Index()
        {
            UserDao userDao = new UserDao();
            var users = userDao.GetUsers(0);
            return View(users);
        }

        // GET: Admin/User/Details/5
        public ActionResult Details(int id)
        {
            UserDao userDao = new UserDao();
            var user = userDao.GetUserById(id);
            return View(user);
        }

        // GET: Admin/User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/User/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/User/Edit/5
        public ActionResult Edit(int id)
        {
            UserDao userDao = new UserDao();
            var user = userDao.GetUserById(id);
            return View(user);

        }

        // POST: Admin/User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/User/Delete/5
        public ActionResult Delete(int id)
        {
            UserDao userDao = new UserDao();
            var user = userDao.GetUserById(id);
            return View();
        }

        // POST: Admin/User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
