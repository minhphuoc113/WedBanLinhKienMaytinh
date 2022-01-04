using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WedBanLinhKienDienTu.Models.EF;

namespace WedBanLinhKienDienTu.Models.Dao
{
    public class AccountDao
    {
        private WebBanLinhKienMayTinhDbContext context = null;

        public AccountDao()
        {
            context = new WebBanLinhKienMayTinhDbContext();
        }
        public bool CheckLogin(string userName, string passWord)
        {
            Object[] SqlParams =
            {
                new SqlParameter("@UserName", userName),
                new SqlParameter("@PassWord", passWord),
            };
            var res = context.Database.SqlQuery<bool>("PSP_Db_Shop_Online_CheckLogin @UserName, @PassWord", SqlParams).SingleOrDefault();
            return res;
        }
    }
}
