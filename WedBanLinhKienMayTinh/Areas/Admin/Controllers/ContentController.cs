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
    public class ContentController : Controller
    {
        ContentDao contentDao = new ContentDao();
        private WebBanLinhKienMayTinhDbContext db = new WebBanLinhKienMayTinhDbContext();

        // GET: Admin/Contents
        public ActionResult Index()
        {
            var list = db.Contents.Where(m => m.Status == false).OrderByDescending(m => m.CreatedBy).ToList();
            return View(contentDao.getList("Index"));
        }

        // GET: Admin/Categories/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Content content = contentDao.getRow(id);
            if (content == null)
            {
                return HttpNotFound();
            }
            return View(content);
        }

        // GET: Admin/Categories/Create
        public ActionResult Create()
        {
            ViewBag.ListCat = new SelectList(contentDao.getList("Index"), "ID", "Name");

            return View();
        }

        // POST: Admin/Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,MetaTitle,ParentID,DisplayOrder,SeoTitle,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,MetaKeywords,MetaDescriptions,Status,ShowOnHome,Language")] Content content)
        {
            if (ModelState.IsValid)
            {
                contentDao.Insert(content);
                TempData["message"] = new XMessage("success", "Thêm thành công");
                return RedirectToAction("Index");
            }

            return View(content);
        }

        // GET: Admin/Categories/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Content content = contentDao.getRow(id);
            if (content == null)
            {
                return HttpNotFound();
            }
            return View(content);
        }

        // POST: Admin/Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,MetaTitle,ParentID,DisplayOrder,SeoTitle,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,MetaKeywords,MetaDescriptions,Status,ShowOnHome,Language")] Content content)
        {
            if (ModelState.IsValid)
            {
                contentDao.Update(content);
                return RedirectToAction("Index");
            }
            return View(content);
        }

        // GET: Admin/Categories/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Content content = contentDao.getRow(id);
            TempData["message"] = new XMessage("success", "Xóa thành công");
            if (content == null)
            {
                return HttpNotFound();
            }
            return View(content);
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Content content = contentDao.getRow(id);
            contentDao.Delete(content);
            return RedirectToAction("Index");
        }

        public ActionResult Status(bool? id)
        {
            Content content = db.Contents.Find(id);
            bool status = (content.Status == true);
            content.Status = status;
            content.CreatedBy = null;
            content.CreatedDate = DateTime.Now;
            db.Entry(content).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}