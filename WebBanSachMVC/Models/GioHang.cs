using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanSachMVC.Models;
namespace WebBanSachMVC.Models
{
    public class GioHang
    {
        QuanLyWebBanBanhNgotEntities db = new QuanLyWebBanBanhNgotEntities();
        public int iMaSP { get; set; }
        public string TenSP { get; set; }
        public string HinhAnh { get; set; }
        public double DonGia { get; set; }
        public int SoLuong { get; set; }
        public double ThanhTien
        {
            get { return SoLuong * DonGia; }
        }
        public GioHang(int MaSP) {
            DanhsachBanh nh=db.DanhsachBanhs.SingleOrDefault(n=>n.MaSP==MaSP);
            iMaSP = MaSP;
            TenSP = nh.TenSP;
            HinhAnh = nh.HinhAnh;
            SoLuong = 1;
            DonGia = double.Parse(nh.DonGia.ToString());
            
        }
    }
}