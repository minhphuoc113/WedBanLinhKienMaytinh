using System.Collections.Generic;
using System.Web.Mvc;
using WedBanLinhKienDienTu.Models.Dao;
using WedBanLinhKienDienTu.Models.EF;
using WedBanLinhKienMayTinh.Library;

namespace WedBanLinhKienMayTinh.Areas.Admin.Controllers
{
    public class MenuController : Controller
    {
        CategoryDao categoryDao = new CategoryDao();
        AboutDao aboutDao = new AboutDao();
        ContentDao contentDao = new ContentDao();
        MenuDao menuDao = new MenuDao();
        // GET: Admin/Menu
        public ActionResult Index()
        {
            ViewBag.ListCategory = categoryDao.getList();
            List<Menu> menu = menuDao.getList();
            return View("Index", menu);
        }
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            if (!string.IsNullOrEmpty(form["ThemCategory"]))
            {
                if (!string.IsNullOrEmpty(form["itemcat"]))
                {
                    var listitem = form["itemcat"];
                    var listarr = listitem.Split(',');
                    foreach (var row in listarr)
                    {
                        int id = int.Parse(row);
                        Category category = categoryDao.getRow(id);
                        Menu menu = new Menu();
                        menu.Text = category.Name;

                    }
                }
                else
                {
                    TempData["message"] = new XMessage("danger", "Chưa chọn danh mục sản phẩm");
                }
            }

            return RedirectToAction("Index", "Menu");
        }
    }
}