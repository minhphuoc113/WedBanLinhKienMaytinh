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
            ViewBag.ListAbout = aboutDao.getList();
            ViewBag.ListContent = contentDao.getList();
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
                        menuDao.Insert(menu);

                    }
                }
                else
                {
                    TempData["message"] = new XMessage("danger", "Chưa chọn danh mục sản phẩm");
                }
            }
            if (!string.IsNullOrEmpty(form["ThemAbout"]))
            {
                if (!string.IsNullOrEmpty(form["itemabout"]))
                {
                    var listitem = form["itemabout"];
                    var listarr = listitem.Split(',');
                    foreach (var row in listarr)
                    {
                        int id = int.Parse(row);
                        About about = aboutDao.getRow(id);
                        Menu menu = new Menu();
                        menu.Text = about.Name;
                        menuDao.Insert(menu);

                    }
                }
                else
                {
                    TempData["message"] = new XMessage("danger", "Chưa chọn danh mục sản phẩm");
                }
            }
            if (!string.IsNullOrEmpty(form["ThemContent"]))
            {
                if (!string.IsNullOrEmpty(form["itemcontent"]))
                {
                    var listitem = form["itemcontent"];
                    var listarr = listitem.Split(',');
                    foreach (var row in listarr)
                    {
                        int id = int.Parse(row);
                        Content content = contentDao.getRow(id);
                        Menu menu = new Menu();
                        menu.Text = content.Name;
                        menuDao.Insert(menu);

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