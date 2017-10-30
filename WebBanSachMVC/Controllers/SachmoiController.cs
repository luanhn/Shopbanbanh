using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanSachMVC.Models;

namespace WebBanSachMVC.Controllers
{
    public class SachmoiController : Controller
    {
        QuanLyWebBanBanhNgotEntities db = new QuanLyWebBanBanhNgotEntities();
        //
        // GET: /Sachmoi/
        public ActionResult SachmoiPartial()
        {
            return PartialView(db.DanhsachBanhs.Take(3).ToList());
        }
        public ViewResult xemchitiet(int manh=0) {
            DanhsachBanh nh = db.DanhsachBanhs.SingleOrDefault(n => n.MaSP == manh);
            if (nh == null) {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.TenTheLoai = db.LoaiBanhs.Single(n => n.MaLoai == nh.MaSP).TenLoai;
            return View(nh);
            
        }
	}
}