using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WedBanLinhKienDienTu.Models.EF;

namespace WedBanLinhKienDienTu.Models.Dao
{
    public class CategoryDao
    {
        private WebBanLinhKienMayTinhDbContext db = new WebBanLinhKienMayTinhDbContext();

        public List<Category> getList(string status = "All")
        {
            List<Category> list = null;
            switch (status)
            {
                case "Index":
                    {
                        list = db.Categories.Where(m => m.Status != null).ToList();
                        break;
                    }
                case "Trash":
                    {
                        list = db.Categories.Where(m => m.Status != null).ToList();
                        break;
                    }
                default:
                    {
                        list = db.Categories.ToList();
                        break;
                    }
            }

            return list;
        }
        public Category getRow(long? id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return db.Categories.Find(id);
            }
        }
        public int Insert(Category row)
        {
            db.Categories.Add(row);
            return db.SaveChanges();
        }
        public int Update(Category row)
        {
            db.Entry(row).State = EntityState.Modified;
            return db.SaveChanges();
        }
        public int Delete(Category row)
        {
            db.Categories.Remove(row);
            return db.SaveChanges();
        }
    }

}