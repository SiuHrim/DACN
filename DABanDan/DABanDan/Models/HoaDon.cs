namespace DABanDan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDon()
        {
            CTHoaDons = new HashSet<CTHoaDon>();
        }

        [Key]
        public int MaHD { get; set; }

        public int? MaND { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayLHD { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayGiao { get; set; }

        [Required]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(100)]
        public string VAT { get; set; }

        [Required]
        [StringLength(1)]
        public string TinhTrang { get; set; }

        public int TongTien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHoaDon> CTHoaDons { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }
    }
}
