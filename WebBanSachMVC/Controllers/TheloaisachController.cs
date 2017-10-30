using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanSachMVC.Models;
using PagedList;
using PagedList.Mvc;
namespace WebBanSachMVC.Controllers
{
    public class TheloaisachController : Controller
    {
        QuanLyWebBanBanhNgotEntities db = new QuanLyWebBanBanhNgotEntities();
        //
        // GET: /Theloaisach/
        public ActionResult theloaipartial()
        {
            return PartialView(db.LoaiBanhs.Take(3).ToList());
        }
        public ViewResult sachtheotheloai(int? page ,int matheloai = 0)
        {
            ViewBag.MaTheLoai = matheloai;
            //tao bien so san pham tren trang
            int pagesize = 4;
            //tao bien so trang
            int pagenumber = (page ?? 1);
            LoaiBanh tl = db.LoaiBanhs.SingleOrDefault(n => n.MaLoai == matheloai);
            if (tl == null) {
                ViewBag.ThongBao = "Khong co sach nao thuoc chu de nay";
                //Response.StatusCode = 404;
               // return null;
            }
            List<DanhsachBanh> listnh = db.DanhsachBanhs.Where(n => n.MaLoai == matheloai).ToList();
            if (listnh.Count==0)
            {
                ViewBag.ThongBao = "Khong co sach nao thuoc chu de nay";
            }
           
            return View(listnh.ToPagedList(pagenumber, pagesize));
        }
        public ViewResult Danhmuctheloai() {
            return View(db.LoaiBanhs.ToList());
        }
	}
}