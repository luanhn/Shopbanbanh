using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanSachMVC.Models;
using PagedList;
namespace WebBanSachMVC.Controllers
{
    public class TimKiemController : Controller
    {
        QuanLyWebBanBanhNgotEntities db = new QuanLyWebBanBanhNgotEntities();
        //
        // GET: /TimKiem/
        [HttpPost]
        public ActionResult KetQuaTimKiem(int? page,FormCollection f)
        {
            string tukhoa = f["txttimkiem"].ToString();
            ViewBag.tukhoa = tukhoa;
            List<DanhsachBanh> lstKQTK = db.DanhsachBanhs.Where(n => n.TenSP.Contains(tukhoa)).ToList();
            if (lstKQTK.Count == 0) {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm nào";
            }
            
            //phan trang
            int pagesize = 3;
            int pagenumer = (page ?? 1);
            ViewBag.ThongBao = "Đã tìm thấy " + lstKQTK.Count + "sản phẩm";
            return View(lstKQTK.ToPagedList(pagenumer,pagesize));
        }
        [HttpGet]
        public ActionResult KetQuaTimKiem(int? page, string tukhoa)
        {
            ViewBag.tukhoa = tukhoa;
            List<DanhsachBanh> lstKQTK = db.DanhsachBanhs.Where(n => n.TenSP.Contains(tukhoa)).ToList();
            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm nào";
            }

            //phan trang
            int pagesize = 4;
            int pagenumer = (page ?? 1);
            ViewBag.ThongBao = "Đã tìm thấy " + lstKQTK.Count + "sản phẩm";
            return View(lstKQTK.ToPagedList(pagenumer, pagesize));
        }
	}
}