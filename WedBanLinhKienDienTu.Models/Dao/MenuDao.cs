using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WedBanLinhKienDienTu.Models.EF;

namespace WedBanLinhKienDienTu.Models.Dao
{
    public class MenuDao
    {
        WebBanLinhKienMayTinhDbContext context;

        public MenuDao()
        {
            context = new WebBanLinhKienMayTinhDbContext();
        }
        public IEnumerable<Menu> GetMenus(long id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ID",id)
            };
            var reustl = context.Database.SqlQuery<Menu>("PSP_Menu_Select @ID", param).ToList();
            return reustl;
        }
        public Menu GetMenuByID(long id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ID",id)
            };
            var reustl = context.Database.SqlQuery<Menu>("PSP_Menu_Select @ID", param).SingleOrDefault();
            return reustl;
        }
        public int InsertMenu(Menu menu)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ID", menu.ID),
                new SqlParameter("@Text", menu.Text),
                new SqlParameter("@Link", menu.Link),
                new SqlParameter("@DisplayOrder", menu.DisplayOrder),
                new SqlParameter("@Target", menu.Target),
                new SqlParameter("@Status", menu.Status),
                new SqlParameter("@TypeID", menu.TypeID),

            };
            var reustl = context.Database.ExecuteSqlCommand("PSP_Menu_InsertAndUpdate @ID,@Text,@Link,@DisplayOrder,@Target,@Status,@TypeID", param);
            return reustl;
        }
        public int UpdatetMenu(Menu menu)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ID", menu.ID),
                new SqlParameter("@Text", menu.Text),
                new SqlParameter("@Link", menu.Link),
                new SqlParameter("@DisplayOrder", menu.DisplayOrder),
                new SqlParameter("@Target", menu.Target),
                new SqlParameter("@Status", menu.Status),
                new SqlParameter("@TypeID", menu.TypeID),

            };
            var reustl = context.Database.ExecuteSqlCommand("PSP_Menu_InsertAndUpdate @ID,@Text,@Link,@DisplayOrder,@Target,@Status,@TypeID", param);
            return reustl;
        }
        public int DeleteMenu(Menu menu)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ID", menu.ID),

            };
            var reustl = context.Database.ExecuteSqlCommand("PSP_Menu_InsertAndUpdate @ID", param);
            return reustl;
        }

    }
}