﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BANNUOCHOAEntities : DbContext
    {
        public BANNUOCHOAEntities()
            : base("name=BANNUOCHOAEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ctdathang> ctdathangs { get; set; }
        public virtual DbSet<DONDATHANG> DONDATHANGs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<nhasanxuat> nhasanxuats { get; set; }
        public virtual DbSet<nuochoa> nuochoas { get; set; }
        public virtual DbSet<theloai> theloais { get; set; }
        public virtual DbSet<AD> ADs { get; set; }
    }
}