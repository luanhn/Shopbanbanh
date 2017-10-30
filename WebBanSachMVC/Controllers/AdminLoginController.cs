using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebBanSachMVC.Models;
namespace WebBanSachMVC.Controllers
{
    public class AdminLoginController : Controller
    {
        QuanLyWebBanBanhNgotEntities db = new QuanLyWebBanBanhNgotEntities();
        //
        // GET: /AdminLogin/

        [HttpGet]
        public ActionResult AdminDangNhap()
        {
            return View();

        }
        [HttpPost]
        public ActionResult AdminDangNhap(FormCollection f)
        {

            string tendn = f["txttaikhoan"].ToString();
            string mk = f["txtmatkhau"].ToString();
            Admin admin = db.Admins.SingleOrDefault(n => n.TenDN == tendn && n.MatKhau == mk);
            if (admin != null)
            {
                    ViewBag.ThongBao = "Đăng nhập thành công";
                    Session["logedUsers"] = admin.TenDN;
                    Session["logedUsersPW"] = admin.MatKhau;
                    Session["logedUsersID"] = admin.MaAdmin;
                    Session["TaiKhoan"] = admin;
                    return RedirectToAction("Index", "QuanLySanPham");
                  
            }
            ViewBag.ThongBao = "Đăng nhập thất bại";
            return View();
        }
        /////////
        [HttpGet]
        public ActionResult DoiMatKhauAdmin()
        { return View(); }
        [HttpPost]
        public ActionResult DoiMatKhauAdmin(FormCollection f, Admin model)
        {
            string mkcu = f["txtmkcu"].ToString();
            int UserId = Convert.ToInt32(Session["logedUsersID"]);
            int kq = db.DoiMatKhau(UserId, mkcu, model.MatKhau);
            if (kq == -1)
            {
                ViewBag.tbl = "Mật khẩu cũ không đúng !!!";
                return View();
            }
            else
            {
                db.SaveChanges();
                ViewBag.tbl = "Đổi mật khẩu thành công !!!";
                return RedirectToAction("Index","QuanLySanPham");
            }






        }
	}
}