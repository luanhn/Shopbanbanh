using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanSachMVC.Models;
using PagedList;
using PagedList.Mvc;
namespace WebBanSachMVC.Controllers
{
    public class HomeController : Controller
    {
        QuanLyWebBanBanhNgotEntities db = new QuanLyWebBanBanhNgotEntities();
        //
        // GET: /Home/
        public ActionResult Index(int? page)
        {
            //tao bien so san pham tren trang
            int pagesize = 12;
            //tao bien so trang
            int pagenumber=(page ?? 1);
            return View(db.DanhsachBanhs.ToList());
        }
	}
}