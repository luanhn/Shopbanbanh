using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanSachMVC.Models;
namespace WebBanSachMVC.Controllers
{
    public class QuanLyTaiKhoanController : Controller
    {
        QuanLyWebBanBanhNgotEntities db = new QuanLyWebBanBanhNgotEntities();
        //
        // GET: /QuanLyTaiKhoan/
        public ActionResult QLDSTaiKhoanAdmin()
        {

            return View(db.Admins.ToList());
        }

         [HttpGet]
        public ActionResult ThemMoiTaiKhoan()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemMoiTaiKhoan(Admin tk)
        {
            if (ModelState.IsValid)
            {
                db.Admins.Add(tk);
                db.SaveChanges();

            }
            return RedirectToAction("QLDSTaiKhoanAdmin", "QuanLyTaiKhoan");
        }
        [HttpGet]
        public ActionResult Xoa(int MaTK)
        {
            Admin dvk = db.Admins.SingleOrDefault(n => n.MaAdmin == MaTK);
            if (dvk == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(dvk);
        }
        [HttpPost, ActionName("Xoa")]
        public ActionResult XacNhanXoa(int MaTK)
        {
            Admin dvk = db.Admins.SingleOrDefault(n => n.MaAdmin == MaTK);
            if (dvk == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.Admins.Remove(dvk);
            db.SaveChanges();
             return RedirectToAction("QLDSTaiKhoanAdmin", "QuanLyTaiKhoan");
        }
        [HttpGet]
        public ActionResult Sua(int MaTK)
        {
            Admin hdt = db.Admins.SingleOrDefault(n => n.MaAdmin == MaTK);
            if (hdt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(hdt);
        }
        [HttpPost, ActionName("Sua")]
        public ActionResult XacNhanSua(Admin tk)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tk).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("QLDSTaiKhoanAdmin", "QuanLyTaiKhoan");
        }
	






        // Quan ly tk khach hang
        public ActionResult QLDSTaiKhoanKH() { return View(db.KhachHangs.ToList()); }
        


	}
}