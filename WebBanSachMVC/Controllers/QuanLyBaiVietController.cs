using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanSachMVC.Models;
namespace WebBanSachMVC.Controllers
{
    public class QuanLyBaiVietController : Controller
    {
        QuanLyWebBanBanhNgotEntities db = new QuanLyWebBanBanhNgotEntities();
        //
        // GET: /QuanLyBaiViet/
        public ActionResult QLDSBaiViet()
        {
            return View(db.LoaiBaiViets.ToList());
        }
        public ActionResult QLDSCacBaiViet()
        {
            return View(db.BaiViets.ToList());
        }
        //chuc nang quan li loai bai viet
        [HttpGet]
        public ActionResult ThemMoiLoaiBaiViet()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemMoiLoaiBaiViet(LoaiBaiViet tk)
        {
            if (ModelState.IsValid)
            {
                db.LoaiBaiViets.Add(tk);
                db.SaveChanges();

            }
            return RedirectToAction("QLDSBaiViet", "QuanLyBaiViet");
        }
        [HttpGet]
        public ActionResult XoaLoaiBV(int MaLoaiBV)
        {
            LoaiBaiViet dvk = db.LoaiBaiViets.SingleOrDefault(n => n.MaLoaiBV == MaLoaiBV);
            if (dvk == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(dvk);
        }
        [HttpPost, ActionName("XoaLoaiBV")]
        public ActionResult XoaLoaiBaiViet(int MaLoaiBV)
        {
            LoaiBaiViet dvk = db.LoaiBaiViets.SingleOrDefault(n => n.MaLoaiBV == MaLoaiBV);
            if (dvk == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.LoaiBaiViets.Remove(dvk);
            db.SaveChanges();
            return RedirectToAction("QLDSBaiViet", "QuanLyBaiViet");
        }
        [HttpGet]
        public ActionResult SuaLoaiBV(int MaLoaiBV)
        {
            LoaiBaiViet hdt = db.LoaiBaiViets.SingleOrDefault(n => n.MaLoaiBV == MaLoaiBV);
            if (hdt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(hdt);
        }
        [HttpPost, ActionName("SuaLoaiBV")]
        public ActionResult SuaLoaiBV(LoaiBaiViet tk)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tk).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("QLDSBaiViet", "QuanLyBaiViet");
        }
        //------------------------------

        ////////////////////////////////////////////////////quan li bai viet

        [HttpGet]
        public ActionResult ThemMoiBaiViet()
        {
            //dua du lieu vao drodownlist
            ViewBag.LoaiBaiViet = new SelectList(db.LoaiBaiViets.ToList(), "MaLoaiBV", "TenLoaiBV");


            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoiBaiViet(BaiViet nh, HttpPostedFileBase fileUpload)
        {
            //luu ten cua file

            ViewBag.LoaiBaiViet = new SelectList(db.LoaiBaiViets.ToList(), "MaLoaiBV", "TenLoaiBV");

            //them vao csdl
            if (ModelState.IsValid)
            {
                var fileName = Path.GetFileName(fileUpload.FileName);
                //luu duong dan cua file
                var path = Path.Combine(Server.MapPath("~/Hinhsanpham"), fileName);
                if (System.IO.File.Exists(path))
                {
                    ViewBag.ThongBao = "Hình ảnh đã tồn tại";

                }
                else
                {
                    fileUpload.SaveAs(path);
                }
                //luu ten hinh vo csdl
                ViewBag.ThongbaoOK = "Thêm thành công";
                nh.HinhAnh = fileUpload.FileName;
                db.BaiViets.Add(nh);
                db.SaveChanges();

            }
            return RedirectToAction("QLDSCacBaiViet");
        }
        [HttpGet]
        public ActionResult ChinhSua(int MaBV)
        {

            BaiViet nh = db.BaiViets.SingleOrDefault(n => n.MaBaiViet == MaBV);
            if (nh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.LoaiBaiViet = new SelectList(db.LoaiBaiViets.ToList(), "MaLoaiBV", "TenLoaiBV");

            return View(nh);
        }
        [HttpPost]
        [ValidateInput(false)]

        public ActionResult ChinhSua(BaiViet nh, FormCollection f, HttpPostedFileBase fileUp)
        {
           
            var fileName = Path.GetFileName(fileUp.FileName);
            //luu duong dan cua file
            var path = Path.Combine(Server.MapPath("~/Hinhsanpham"), fileName);
            if (System.IO.File.Exists(path))
            {
                ViewBag.ThongBao = "Hình ảnh đã tồn tại";

            }
            else
            {
                fileUp.SaveAs(path);

            }
            nh.HinhAnh = fileUp.FileName;
            if (ModelState.IsValid)
            {


                db.Entry(nh).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }

            ViewBag.LoaiBaiViet = new SelectList(db.LoaiBaiViets.ToList(), "MaLoaiBV", "TenLoaiBV");
            return RedirectToAction("QLDSCacBaiViet");
        }

        [HttpGet]
        public ActionResult Xoa(int MaBV)
        {
            BaiViet nh = db.BaiViets.SingleOrDefault(n => n.MaBaiViet == MaBV);
            if (nh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.LoaiBaiViet = new SelectList(db.LoaiBaiViets.ToList(), "MaLoaiBV", "TenLoaiBV");
            return View(nh);
        }
        [HttpPost, ActionName("Xoa")]
        public ActionResult XacNhanXoa(int MaBV)
        {
            BaiViet nh = db.BaiViets.SingleOrDefault(n => n.MaBaiViet == MaBV);
            if (nh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.BaiViets.Remove(nh);
            db.SaveChanges();
            return RedirectToAction("QLDSCacBaiViet");
        }

        //-------------------------------
	}
}