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
    
    public partial class BaiViet
    {
        public int MaBaiViet { get; set; }
        public string TieuDe { get; set; }
        public string HinhAnh { get; set; }
        public string NoiDung { get; set; }
        public Nullable<int> LoaiBaiViet { get; set; }
    
        public virtual LoaiBaiViet LoaiBaiViet1 { get; set; }
    }
}