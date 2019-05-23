namespace DABanDan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            CTHoaDons = new HashSet<CTHoaDon>();
            CTPhieuNhaps = new HashSet<CTPhieuNhap>();
        }

        [Key]
        public int MaSP { get; set; }

        [Required]
        [StringLength(100)]
        public string TenSP { get; set; }

        public int DonGia { get; set; }

        public int SoLuong { get; set; }

        public string MoTa { get; set; }

        public int Lv { get; set; }

        [Required]
        [StringLength(20)]
        public string MauSac { get; set; }

        [Required]
        [StringLength(100)]
        public string IMG { get; set; }

        [StringLength(4)]
        public string MaLoai { get; set; }

        [StringLength(4)]
        public string MaHieu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHoaDon> CTHoaDons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPhieuNhap> CTPhieuNhaps { get; set; }

        public virtual HieuDan HieuDan { get; set; }

        public virtual LoaiDan LoaiDan { get; set; }
    }
}
