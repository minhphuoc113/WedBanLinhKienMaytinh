﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WedBanLinhKienDienTu.Models.Dao;

namespace WedBanLinhKienMayTinh.Areas.Admin.Controllers
{
    public class ContentController : Controller
    {
        // GET: Admin/Content
        public ActionResult Index()
        {
            ContentDao contentDao = new ContentDao();
            var contentes = contentDao.GetContents(0);
            return View(contentes);
        }

        // GET: Admin/Content/Details/5
        public ActionResult Details(int id)
        {
            ContentDao contentDao = new ContentDao();
            var content = contentDao.GetContentByID(id);
            return View(content);
        }

        // GET: Admin/Content/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Content/Create
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

        // GET: Admin/Content/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Content/Edit/5
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

        // GET: Admin/Content/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Content/Delete/5
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
