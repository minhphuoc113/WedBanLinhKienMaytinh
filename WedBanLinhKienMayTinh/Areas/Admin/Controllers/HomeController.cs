using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WedBanLinhKienDienTu.Models.EF;

namespace WedBanLinhKienMayTinh.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Hm
        public ActionResult Index()
        {
            return View();
        }
    }
}