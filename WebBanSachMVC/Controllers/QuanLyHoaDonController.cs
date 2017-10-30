using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanSachMVC.Models;
namespace WebBanSachMVC.Controllers
{
    public class QuanLyHoaDonController : Controller
    {
        QuanLyWebBanBanhNgotEntities db = new QuanLyWebBanBanhNgotEntities();
        //
        // GET: /QuanLyHoaDon/
        public ActionResult QLDSHoaDon()
        {
            return View(db.HoaDons.ToList());
        }
        public ActionResult XemChiTietHoaDon(int MaHD = 0)
        {
            HoaDon nxb = db.HoaDons.SingleOrDefault(n => n.MaHoaDon == MaHD);
            if (nxb == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<ChiTietHoaDon> nh = db.ChiTietHoaDons.Where(n => n.MaHoaDon == MaHD).ToList();
            if (nh.Count == 0)
            {
                ViewBag.nuochoa = "";
            }
          
            return View(nh.ToList());
        }
	}
}