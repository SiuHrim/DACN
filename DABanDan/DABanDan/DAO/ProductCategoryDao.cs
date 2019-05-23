using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DABanDan.Models;
namespace DABanDan.DAO
{
    
    public class ProductCategoryDao
    {
        Database db = new Database();
        public ProductCategoryDao()
        {
            db = new Database();
        }

        public List<LoaiDan> ListALL()
        {
            return db.LoaiDans.OrderBy(s => s.TenLoai).ToList();
        }

        public List<HieuDan> ListALLs()
        {
            return db.HieuDans.OrderBy(s => s.TenHieu).ToList();
        }
    }
}
