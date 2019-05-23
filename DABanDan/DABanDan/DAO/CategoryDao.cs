using DABanDan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DABanDan.DAO
{
   
    public class CategoryDao
    {
        Database db = new Database();
        public CategoryDao()
        {
            db = new Database();
        }

        public LoaiDan ViewDetail(string id)
        {
            return db.LoaiDans.Find(id);
        }

        public HieuDan ViewHD(string id)
        {
            return db.HieuDans.Find(id);
        }

        public SanPham ViewSP(int id)
        {
            return db.SanPhams.Find(id);
        }
    }
}