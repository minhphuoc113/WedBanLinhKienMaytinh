using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WedBanLinhKienDienTu.Models.Dao;

namespace WedBanLinhKienMayTinh.Areas.Admin.Controllers
{
    public class FeedbackController : Controller
    {
        // GET: Admin/Feedback
        public ActionResult Index()
        {
            FeedbackDao feedbackDao = new FeedbackDao();
            var feedbacks = feedbackDao.GetFeedbacks(0);
            return View(feedbacks);
        }

        // GET: Admin/Feedback/Details/5
        public ActionResult Details(int id)
        {
            FeedbackDao feedbackDao = new FeedbackDao( );
            var feedback = feedbackDao.GetFeedbackByID(id);
            return View(feedback);
        }

        // GET: Admin/Feedback/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Feedback/Create
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

        // GET: Admin/Feedback/Edit/5
        public ActionResult Edit(int id)
        {
            FeedbackDao feedbackDao = new FeedbackDao();
            var feedback = feedbackDao.GetFeedbackByID(id);
            return View();
        }

        // POST: Admin/Feedback/Edit/5
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

        // GET: Admin/Feedback/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Feedback/Delete/5
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
