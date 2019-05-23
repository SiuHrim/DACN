using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DABanDan.Models;
using PagedList;

namespace DABanDan.DAO
{
    public class UserDao
    {
        Database db = new Database();
        public UserDao()
        {
            db = new Database();
        }
        public string Insert(NguoiDung nd)
        {
            db.NguoiDungs.Add(nd);
            db.SaveChanges();
            return nd.TenUser;
        }
        //------------------------------------------------------Tìm kiếm phân trang người dùng------------------------
        public IEnumerable<NguoiDung> ListAllPaging(string searchString,int page, int pageSize)
        {
           IQueryable<NguoiDung> model = db.NguoiDungs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(s => s.TenUser.Contains(searchString) || s.Ten.Contains(searchString));
            }
            return model.OrderByDescending(s => s.Ten).ToPagedList(page, pageSize);
        }
        //------------------------------------------------------Tìm kiếm phân trang sản phẩm------------------------
        public IEnumerable<SanPham> ListAllPagingsp(string searchString, int page, int pageSize)
        {
            IQueryable<SanPham> model = db.SanPhams;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(s => s.TenSP.Contains(searchString) || s.TenSP.Contains(searchString));
            }
            return model.OrderByDescending(s => s.TenSP).ToPagedList(page, pageSize);
        }


        public NguoiDung GetById(string userName)
        {
            return db.NguoiDungs.SingleOrDefault(s => s.TenUser == userName);
        }


        public bool Login(string userName, string passWord)
        {
            var kq = db.NguoiDungs.Count(s => s.TenUser == userName && s.MatKhau == passWord);
            if (kq > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool KTraUserName(string userName)
        {
            return db.NguoiDungs.Count(s => s.TenUser == userName) > 0;
        }

        public bool KTraEmail(string email)
        {
            return db.NguoiDungs.Count(s => s.Email == email) > 0;  
        }
    }
}