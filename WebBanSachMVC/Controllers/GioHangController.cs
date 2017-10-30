using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanSachMVC.Models;
namespace WebBanSachMVC.Controllers
{
    public class GioHangController : Controller
    {
        QuanLyWebBanBanhNgotEntities db = new QuanLyWebBanBanhNgotEntities();
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang == null)
            {
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }
        public ActionResult ThemGioHang(int iMaSP,string strURL) {
            DanhsachBanh nh = db.DanhsachBanhs.SingleOrDefault(n => n.MaSP == iMaSP);
            if (nh == null) {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> lstGioHang = LayGioHang();
            GioHang gh = lstGioHang.Find(n => n.iMaSP == iMaSP);
            if (gh == null)
            {
                gh = new GioHang(iMaSP);
                lstGioHang.Add(gh);
                return Redirect(strURL);
            }
            else
            {
                gh.SoLuong++;
                return Redirect(strURL);
            }
        }
        public ActionResult CapNhatGioHang(int iMaSP, FormCollection f)
        {
            //kiem tra masp neu get sai thi tra ve trag loi 404
            DanhsachBanh nh = db.DanhsachBanhs.SingleOrDefault(n => n.MaSP == iMaSP);
            if (nh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //lay gio hang ra tu session
            List<GioHang> lstGioHang = LayGioHang();
            //ktra sp co ton tai trong session["GioHang"]
            GioHang gh = lstGioHang.SingleOrDefault(n => n.iMaSP == iMaSP);
            if (gh.SoLuong != null)
            {
                gh.SoLuong = int.Parse(f["txtSoLuong"].ToString());

            }
            return RedirectToAction("GioHang");
        }
        public ActionResult XoaGioHang(int iMaSP)
        {
            DanhsachBanh nh = db.DanhsachBanhs.SingleOrDefault(n => n.MaSP == iMaSP);
            if (nh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> lstGioHang = LayGioHang();
            GioHang gh = lstGioHang.SingleOrDefault(n => n.iMaSP == iMaSP);
            if (gh.SoLuong != null)
            {
                lstGioHang.RemoveAll(n => n.iMaSP == iMaSP);

            }
            if (lstGioHang.Count == 0)
            {
                return RedirectToAction("index", "Home");
            }
            return RedirectToAction("GioHang");
        }
        //xay dung trang gio hang
        public ActionResult GioHang() {
            if (Session["GioHang"] == null) {
                return RedirectToAction("index", "Home");
            }
            List<GioHang> lstGioHang = LayGioHang();
            return View(lstGioHang);
        }


        private double TongSoLuong() {
            int tongsl = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null) {
                tongsl = lstGioHang.Sum(n => n.SoLuong);

            }
            return tongsl;
        }
        private double TongTien() {
            double tongtt = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null) {
                tongtt = lstGioHang.Sum(n => n.ThanhTien);
            }
            return tongtt;
        }
        public ActionResult GioHangpartial() {
            ViewBag.ThongBao = TongSoLuong();
            return PartialView();
        }
        //xay dung trang sua gio hang
        public ActionResult SuaGioHang() {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("index", "Home");
            }
            List<GioHang> lstGioHang = LayGioHang();
            return View(lstGioHang);
           
        }
	}
}