﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WedBanLinhKienDienTu.Models.EF;

namespace WedBanLinhKienDienTu.Models.Dao
{
    public class MenuDao
    {
        private WebBanLinhKienMayTinhDbContext db = new WebBanLinhKienMayTinhDbContext();

        public List<Menu> getList(string status = "All")
        {
            List<Menu> list = null;
            switch (status)
            {
                case "Index":
                    {
                        list = db.Menus.Where(m => m.Status != null).ToList();
                        break;
                    }
                case "Trash":
                    {
                        list = db.Menus.Where(m => m.Status != null).ToList();
                        break;
                    }
                default:
                    {
                        list = db.Menus.ToList();
                        break;
                    }
            }

            return list;
        }
        public Menu getRow(long? id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return db.Menus.Find(id);
            }
        }
        public int Insert(Menu row)
        {
            db.Menus.Add(row);
            return db.SaveChanges();
        }
        public int Update(Menu row)
        {
            db.Entry(row).State = EntityState.Modified;
            return db.SaveChanges();
        }
        public int Delete(Menu row)
        {
            db.Menus.Remove(row);
            return db.SaveChanges();
        }
    }
}
