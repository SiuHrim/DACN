using DABanDan.Models;

namespace DABanDan.DAO
{
    public class ChiTietDonHangDAO
    {
        Database db = new Database();
        public ChiTietDonHangDAO()
        {
            db = new Database();
        }
        public bool Insert(CTHoaDon ctHD)
        {
            try
            {
                db.CTHoaDons.Add(ctHD);
                db.SaveChanges();
                return true;
            }
            catch 
            {
                return false;               
            }
        }
    }
}