using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanSachMVC.Models;
using System.ComponentModel.DataAnnotations;
namespace WebBanSachMVC.Controllers
{
    public class KhachHangController : Controller
    {
        QuanLyWebBanBanhNgotEntities db = new QuanLyWebBanBanhNgotEntities();
        //
        // GET: /KhachHang/
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Dangky() {
            return View();
        }
        [HttpPost]
        public ActionResult Dangky(KhachHang kh)
        {
            if (ModelState.IsValid) {
                db.KhachHangs.Add(kh);
                db.SaveChanges();
            }
            return View();
        }
        [HttpGet]
        public ActionResult Dangnhap() {
            return View();
        }
        [HttpPost]
        public ActionResult Dangnhap(FormCollection f) {
            string tk = f["txttaikhoan"].ToString();
            string mk = f["txtmatkhau"].ToString();
            KhachHang kh = db.KhachHangs.SingleOrDefault(n => n.TenDN == tk && n.MatKhau == mk);
            if (kh != null)
            {
                ViewBag.ThongBao = "Thanh cong";
                Session["TenDN"] = kh;
                return View();
            }
            
                ViewBag.ThongBao = "That bai";
            return View();
        }
        
	}
}