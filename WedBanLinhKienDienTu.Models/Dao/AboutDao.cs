using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WedBanLinhKienDienTu.Models.EF;

namespace WedBanLinhKienDienTu.Models.Dao
{
    public class AboutDao
    {
        private WebBanLinhKienMayTinhDbContext db = new WebBanLinhKienMayTinhDbContext();

        public List<About> getList(string status = "All")
        {
            List<About> list = null;
            switch (status)
            {
                case "Index":
                    {
                        list = db.Abouts.Where(m => m.Status != null).ToList();
                        break;
                    }
                case "Trash":
                    {
                        list = db.Abouts.Where(m => m.Status != null).ToList();
                        break;
                    }
                default:
                    {
                        list = db.Abouts.ToList();
                        break;
                    }
            }

            return list;
        }
        public About getRow(long? id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return db.Abouts.Find(id);
            }
        }
        public int Insert(About row)
        {
            db.Abouts.Add(row);
            return db.SaveChanges();
        }
        public int Update(About row)
        {
            db.Entry(row).State = EntityState.Modified;
            return db.SaveChanges();
        }
        public int Delete(About row)
        {
            db.Abouts.Remove(row);
            return db.SaveChanges();
        }
    }

}
