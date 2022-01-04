using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WedBanLinhKienDienTu.Models.Dao;
using WedBanLinhKienMayTinh.Areas.Admin.Code;
using WedBanLinhKienMayTinh.Areas.Admin.Models;

namespace WedBanLinhKienMayTinh.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        [HttpGet ]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
            var result = new AccountDao().CheckLogin(model.UserName, model.PassWord);
            if(result && ModelState.IsValid )
            {
                SessionHelper.SetSession(new UserSession() { UserName = model.UserName });
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
            }
            return View(model);
        }
    }
}