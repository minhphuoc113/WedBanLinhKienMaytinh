using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WedBanLinhKienDienTu.Models.EF;

namespace WedBanLinhKienDienTu.Models.Dao
{
    public class ContentDao
    {
        private WebBanLinhKienMayTinhDbContext db = new WebBanLinhKienMayTinhDbContext();

        public List<Content> getList(string status = "All")
        {
            List<Content> list = null;
            switch (status)
            {
                case "Index":
                    {
                        list = db.Contents.Where(m => m.Status == false).ToList();
                        break;
                    }
                case "Trash":
                    {
                        list = db.Contents.Where(m => m.Status == false).ToList();
                        break;
                    }
                default:
                    {
                        list = db.Contents.ToList();
                        break;
                    }
            }

            return list;
        }
        public Content getRow(long? id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return db.Contents.Find(id);
            }
        }
        public int Insert(Content row)
        {
            db.Contents.Add(row);
            return db.SaveChanges();
        }
        public int Update(Content row)
        {
            db.Entry(row).State = EntityState.Modified;
            return db.SaveChanges();
        }
        public int Delete(Content row)
        {
            db.Contents.Remove(row);
            return db.SaveChanges();
        }
    }

}
