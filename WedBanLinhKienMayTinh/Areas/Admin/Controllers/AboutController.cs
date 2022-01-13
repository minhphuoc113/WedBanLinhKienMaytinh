using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WedBanLinhKienDienTu.Models.Dao;
using WedBanLinhKienDienTu.Models.EF;
using WedBanLinhKienMayTinh.Library;

namespace WedBanLinhKienMayTinh.Areas.Admin.Controllers
{
    public class AboutController : Controller
    {
        AboutDao aboutDao = new AboutDao();
        private WebBanLinhKienMayTinhDbContext db = new WebBanLinhKienMayTinhDbContext();

        // GET: Admin/Categories
        public ActionResult Index()
        {
            var list = db.Abouts.Where(m => m.Status != null).OrderByDescending(m => m.CreatedBy).ToList();
            return View(aboutDao.getList("Index"));
        }

        // GET: Admin/Categories/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About about = aboutDao.getRow(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            return View(about);
        }

        // GET: Admin/About/Create
        public ActionResult Create()
        {
            ViewBag.ListCat = new SelectList(aboutDao.getList("Index"), "ID", "Name");

            return View();
        }

        // POST: Admin/Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,MetaTitle,ParentID,DisplayOrder,SeoTitle,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,MetaKeywords,MetaDescriptions,Status,ShowOnHome,Language")] About about)
        {
            if (ModelState.IsValid)
            {
                aboutDao.Insert(about);
                TempData["message"] = new XMessage("success", "Thêm thành công");
                return RedirectToAction("Index");
            }

            return View(about);
        }

        // GET: Admin/Categories/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About about = aboutDao.getRow(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            return View(about);
        }

        // POST: Admin/Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,MetaTitle,ParentID,DisplayOrder,SeoTitle,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,MetaKeywords,MetaDescriptions,Status,ShowOnHome,Language")] About about)
        {
            if (ModelState.IsValid)
            {
                aboutDao.Update(about);
                return RedirectToAction("Index");
            }
            return View(about);
        }

        // GET: Admin/Categories/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About about = aboutDao.getRow(id);
            TempData["message"] = new XMessage("success", "Xóa thành công");
            if (about == null)
            {
                return HttpNotFound();
            }
            return View(about);
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            About about = aboutDao.getRow(id);
            aboutDao.Delete(about);
            return RedirectToAction("Index");
        }

        public ActionResult Status(bool? id)
        {
            About about = db.Abouts.Find(id);
            bool? status = (about.Status == true);
            about.Status = status;
            about.CreatedBy = null;
            about.CreatedDate = DateTime.Now;
            db.Entry(about).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}