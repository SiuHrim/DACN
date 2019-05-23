using DABanDan.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using DABanDan.InputModels.Product;

namespace DABanDan.DAO
{
    public class ProductDao
    {
        Database db = new Database();
        public ProductDao()
        { 
            db = new Database();
        }

        //----------------------------------------Hiển thị sản phẩm theo  LV--------------------------------------------------------------
        public List<SanPham> ListLVSanPham()
        {
            return db.SanPhams.OrderByDescending(s => s.Lv).ToList();
        }
        //----------------------------------------Hiển thị sản phẩm theo DonGia------------------------------------------
        public List<SanPham> ListDonGiaSanPham()
        {
            return db.SanPhams.OrderBy(s => s.DonGia).ToList();
        }
        //----------------------------------------Hiển thị sản phẩm theo Loại------------------------------------------
        public List<SanPham> DSLoaiSP(string mloai, ref int totalRecord, int pageIndex = 1, int pageSize = 2 )
        {
            totalRecord = db.SanPhams.Where(s => s.MaLoai == mloai).Count();
            var model = db.SanPhams.Where(s => s.MaLoai == mloai).OrderBy(s => s.TenSP).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return model;
        }
        //----------------------------------------Hiển thị sản phẩm theo Hiệu------------------------------------------
        public List<SanPham> DSHieuSP(string mhieu, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            totalRecord = db.SanPhams.Where(s => s.MaHieu == mhieu).Count();
            var model = db.SanPhams.Where(s => s.MaHieu == mhieu).OrderBy(s => s.TenSP).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return model;
        }
        public List<SanPham> ListRelatedProducts(long idsp)
        {
            var product = db.SanPhams.Find(idsp);
            return db.SanPhams.Where(s => s.MaSP != idsp && s.MaLoai == product.MaLoai).ToList();
        }

        public SanPham ViewDetail(int id)
        {
            return db.SanPhams.Find(id);
        }
        //---------------------------Tìm Kiếm-------------------DS GỢI Ý------------
        public List<SanPham> DanhSachSP(string keyword)
        {
            return db.SanPhams.Where(s => s.TenSP.Contains(keyword)).ToList();
        }
    }
} 