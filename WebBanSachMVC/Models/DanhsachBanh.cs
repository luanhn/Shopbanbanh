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
    
    public partial class DanhsachBanh
    {
        public DanhsachBanh()
        {
            this.ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }
    
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public Nullable<decimal> DonGia { get; set; }
        public string DonViTinh { get; set; }
        public Nullable<int> MaLoai { get; set; }
        public string HinhAnh { get; set; }
        public string MoTa { get; set; }
    
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual LoaiBanh LoaiBanh { get; set; }
    }
}
