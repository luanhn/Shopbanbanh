using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanSachMVC.Models;
namespace WebBanSachMVC.Controllers
{
    public class QuanLyKhuyenMaiController : Controller
    {
        QuanLyWebBanBanhNgotEntities db = new QuanLyWebBanBanhNgotEntities();
        //
        // GET: /QuanLyKhuyenMai/
        public ActionResult QLDSKhuyenMai()
        {
            return View(db.KhuyenMais.ToList());
        }
        //------------------------------

        [HttpGet]
        public ActionResult ThemMoi()
        {
            //dua du lieu vao drodownlist
           


            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoi(KhuyenMai nh, HttpPostedFileBase fileUpload)
        {
            //luu ten cua file

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
                db.KhuyenMais.Add(nh);
                db.SaveChanges();

            }
            return RedirectToAction("QLDSKhuyenMai");
        }
        [HttpGet]
        public ActionResult ChinhSua(int MaKM)
        {

            KhuyenMai nh = db.KhuyenMais.SingleOrDefault(n => n.MaKM == MaKM);
            if (nh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            

            return View(nh);
        }
        [HttpPost]
        [ValidateInput(false)]

        public ActionResult ChinhSua(KhuyenMai nh, FormCollection f, HttpPostedFileBase fileUp)
        {
            var oldpath = nh.HinhAnh;
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



           
            return RedirectToAction("QLDSKhuyenMai");
        }

        [HttpGet]
        public ActionResult Xoa(int MaKM)
        {
            KhuyenMai nh = db.KhuyenMais.SingleOrDefault(n => n.MaKM == MaKM);
            if (nh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
           
            return View(nh);
        }
        [HttpPost, ActionName("Xoa")]
        public ActionResult XacNhanXoa(int MaKM)
        {
            KhuyenMai nh = db.KhuyenMais.SingleOrDefault(n => n.MaKM == MaKM);
            if (nh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.KhuyenMais.Remove(nh);
            db.SaveChanges();
            return RedirectToAction("QLDSKhuyenMai");
        }




        //--------------------------------
	}
}