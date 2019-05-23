using DABanDan.Models;
using System.Collections.Generic;

namespace DABanDan.DAO
{
    public class DonHangDAO
    {
        Database db = new Database();
        public DonHangDAO()
        {
            db = new Database();
        }
        public int Insert(HoaDon hd)
        {
            db.HoaDons.Add(hd);
            db.SaveChanges();
            return hd.MaHD;
        }
    }
}