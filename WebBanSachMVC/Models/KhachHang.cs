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
    
    public partial class KhachHang
    {
        public KhachHang()
        {
            this.HoaDons = new HashSet<HoaDon>();
        }
    
        public int MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public string TenDN { get; set; }
        public string MatKhau { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
    
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}