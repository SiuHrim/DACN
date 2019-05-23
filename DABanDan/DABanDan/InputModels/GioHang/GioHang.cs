using DABanDan.Models;
using System;
namespace DABanDan.InputModels.GioHang
{
    [Serializable]
    public  class GioHang
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public string HinhAnh { get; set; }
        public int SoLuong { get; set; }
        public int DonGia { get; set; }
        public int TongTien
        {
            get
            {
                return SoLuong * DonGia;
            }
        }
    }
}