namespace DABanDan.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Database : DbContext
    {
        public Database()
            : base("name=Database5")
        {
        }

        public virtual DbSet<CTHoaDon> CTHoaDons { get; set; }
        public virtual DbSet<CTPhieuNhap> CTPhieuNhaps { get; set; }
        public virtual DbSet<HieuDan> HieuDans { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<LoaiDan> LoaiDans { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public virtual DbSet<PhieuNhap> PhieuNhaps { get; set; }
        public virtual DbSet<QuyenHan> QuyenHans { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }

       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HieuDan>()
                .Property(e => e.MaHieu)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.VAT)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.TinhTrang)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.CTHoaDons)
                .WithRequired(e => e.HoaDon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiDan>()
                .Property(e => e.MaLoai)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.TenUser)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PhieuNhap>()
                .HasMany(e => e.CTPhieuNhaps)
                .WithRequired(e => e.PhieuNhap)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.MaLoai)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.MaHieu)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.CTHoaDons)
                .WithRequired(e => e.SanPham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.CTPhieuNhaps)
                .WithRequired(e => e.SanPham)
                .WillCascadeOnDelete(false);
        }

        public System.Data.Entity.DbSet<DABanDan.InputModels.DangKy.DangKyModel> DangKyModels { get; set; }

        public System.Data.Entity.DbSet<DABanDan.InputModels.DangNhap.DangNhapModel> DangNhapModels { get; set; }
    }
}
