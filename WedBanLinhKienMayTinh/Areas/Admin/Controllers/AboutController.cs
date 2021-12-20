﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WedBanLinhKienDienTu.Models.Dao;

namespace WedBanLinhKienMayTinh.Areas.Admin.Controllers
{
    public class AboutController : Controller
    {
        // GET: Admin/About
        public ActionResult Index()
        {
            AboutDao aboutDao = new AboutDao();
            var abouts = aboutDao.GetAbouts(0);
            return View(abouts);
        }

        // GET: Admin/About/Details/5
        public ActionResult Details(int id)
        {
            AboutDao aboutDao = new AboutDao();
            var about = aboutDao.GetAboutByID(id);
            return View(about);
        }

        // GET: Admin/About/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/About/Create
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

        // GET: Admin/About/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/About/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/About/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/About/Delete/5
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
