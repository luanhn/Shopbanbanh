using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanSachMVC.Models;
using PagedList;
// using thu vien de luu anh?
using System.IO;
using System.Data.Entity;
namespace WebBanSachMVC.Controllers
{
    public class QuanLySanPhamController : Controller
    {
        QuanLyWebBanBanhNgotEntities db = new QuanLyWebBanBanhNgotEntities();
        //
        // GET: /QuanLySanPham/
        public ActionResult Index()
        {
            
            return View();
        }
        //them moi san pham cua admin
        public ActionResult QLDSBanh() {

            return View(db.DanhsachBanhs.ToList());
        }
        public ActionResult LoaiBanh()
        {

            return View(db.LoaiBanhs.ToList());
        }
        //------------------------
        [HttpGet]
        public ActionResult ThemMoiLoaiBanh()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoiLoaiBanh(LoaiBanh tk)
        {
            if (ModelState.IsValid)
            {
                db.LoaiBanhs.Add(tk);
                db.SaveChanges();

            }
            return RedirectToAction("LoaiBanh", "QuanLySanPham");
        }
        [HttpGet]
        public ActionResult XoaLoaiBanh(int MaLoai)
        {
            LoaiBanh dvk = db.LoaiBanhs.SingleOrDefault(n => n.MaLoai == MaLoai);
            if (dvk == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(dvk);
        }
        [HttpPost, ActionName("XoaLoaiBanh")]
        public ActionResult XoaLB(int MaLoai)
        {
            LoaiBanh dvk = db.LoaiBanhs.SingleOrDefault(n => n.MaLoai == MaLoai);
            if (dvk == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.LoaiBanhs.Remove(dvk);
            db.SaveChanges();
            return RedirectToAction("LoaiBanh", "QuanLySanPham");
        }
        [HttpGet]
        public ActionResult SuaLoaiBanh(int MaLoai)
        {
            LoaiBanh hdt = db.LoaiBanhs.SingleOrDefault(n => n.MaLoai == MaLoai);
            if (hdt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(hdt);
        }
        [HttpPost, ActionName("SuaLoaiBanh")]
        [ValidateInput(false)]
        public ActionResult SuaLoaiBanh(LoaiBanh tk)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tk).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("LoaiBanh", "QuanLySanPham");
        }






        // -----------------------
        [HttpGet]
        public ActionResult ThemMoi() {
            //dua du lieu vao drodownlist
            ViewBag.MaLoai = new SelectList( db.LoaiBanhs.ToList(),"MaLoai","TenLoai");
           
          
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoi(DanhsachBanh nh,HttpPostedFileBase fileUpload) {
            //luu ten cua file
          
            ViewBag.MaLoai = new SelectList(db.LoaiBanhs.ToList(), "MaLoai", "TenLoai");
         
            //them vao csdl
            if (ModelState.IsValid) {
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
                db.DanhsachBanhs.Add(nh);
                    db.SaveChanges();

            }
            return RedirectToAction("QLDSBanh");
        }
        [HttpGet]
        public ActionResult ChinhSua(int MaSP) 
        {

            DanhsachBanh nh = db.DanhsachBanhs.SingleOrDefault(n => n.MaSP == MaSP);
            if (nh == null) {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.MaLoai = new SelectList(db.LoaiBanhs.ToList(), "MaLoai", "TenLoai",nh.MaLoai);
          
            return View(nh);
        }
        [HttpPost]
        [ValidateInput(false)]

        public ActionResult ChinhSua(DanhsachBanh nh, FormCollection f, HttpPostedFileBase fileUp)
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
           
           
              
                ViewBag.MaLoai = new SelectList(db.LoaiBanhs.ToList(), "MaLoai", "TenLoai", nh.MaLoai);
                return RedirectToAction("QLDSBanh");
        }
        
       
        //hien thi cua admin
        public ActionResult HienThi(int MaSP) {
            DanhsachBanh nh = db.DanhsachBanhs.SingleOrDefault(n => n.MaSP == MaSP);
            if(nh==null){
                Response.StatusCode = 404;
                return null;
            }
            return View(nh);
        
        }
        //xoa san pham admin
        [HttpGet]
        public ActionResult Xoa(int MaSP) {
            DanhsachBanh nh = db.DanhsachBanhs.SingleOrDefault(n => n.MaSP == MaSP);
            if (nh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.MaLoai = new SelectList(db.LoaiBanhs.ToList(), "MaLoai", "TenLoai", nh.MaLoai);
            return View(nh);
        }
        [HttpPost,ActionName("Xoa")]
        public ActionResult XacNhanXoa(int MaSP) 
        {
            DanhsachBanh nh = db.DanhsachBanhs.SingleOrDefault(n => n.MaSP == MaSP);
            if (nh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.DanhsachBanhs.Remove(nh);
            db.SaveChanges();
            return RedirectToAction("QLDSBanh");
        }
        //quan li khac hang
        public ActionResult QuanLyKhachHang() 
        {
            return View(db.KhachHangs.ToList()); 
        }
        [HttpGet]
        public ActionResult ChinhSuaKH(int MaKH)
        {
            KhachHang kh = db.KhachHangs.SingleOrDefault(n => n.MaKhachHang == MaKH);
            if (kh == null) {
                Response.StatusCode = 404;
                return null;
            }
            return View(kh);
        }
        [HttpPost]
        public ActionResult ChinhSuaKH(KhachHang kh)
        {
            if (ModelState.IsValid) {
                db.Entry(kh).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("QuanLyKhachHang");
        }
        //xoa khah hang
        [HttpGet]
        public ActionResult XoaKH(int MaKH) {
            KhachHang kh = db.KhachHangs.SingleOrDefault(n => n.MaKhachHang == MaKH);
            if (kh == null) 
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(kh);
        }
        [HttpPost,ActionName("XoaKH")]
        public ActionResult XacNhanXoaKH(int MaKH)
        {
            KhachHang kh = db.KhachHangs.SingleOrDefault(n => n.MaKhachHang == MaKH);
            if (kh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.KhachHangs.Remove(kh);
            db.SaveChanges();
            return RedirectToAction("QuanLyKhachHang");
        }
	}
}