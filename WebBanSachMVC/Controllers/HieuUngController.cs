using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanSachMVC.Models;
using PagedList;
namespace WebBanSachMVC.Controllers
{
    public class HieuUngController : Controller
    {
        QuanLyWebBanBanhNgotEntities db = new QuanLyWebBanBanhNgotEntities();
        //
        // GET: /HieuUng/
        public ActionResult SachHieuUng()
        {
          
            return View(db.DanhsachBanhs.Take(10).ToList());
        }
	}
}