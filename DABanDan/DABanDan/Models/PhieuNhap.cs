namespace DABanDan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuNhap")]
    public partial class PhieuNhap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuNhap()
        {
            CTPhieuNhaps = new HashSet<CTPhieuNhap>();
        }

        [Key]
        public int MaPN { get; set; }

        public int? MaNCC { get; set; }

        public int? MaND { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayNhap { get; set; }

        public int TongTien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPhieuNhap> CTPhieuNhaps { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }

        public virtual NhaCungCap NhaCungCap { get; set; }
    }
}
