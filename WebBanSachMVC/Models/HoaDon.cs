//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebBanSachMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class HoaDon
    {
        public HoaDon()
        {
            this.ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }
    
        public int MaHoaDon { get; set; }
        public string TongTien { get; set; }
        public Nullable<System.DateTime> NgayDatHang { get; set; }
        public Nullable<System.DateTime> NgayGiaoHang { get; set; }
        public Nullable<int> MaKH { get; set; }
        public Nullable<bool> TrangThai { get; set; }
    
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual KhachHang KhachHang { get; set; }
    }
}