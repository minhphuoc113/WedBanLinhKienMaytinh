using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WedBanLinhKienDienTu.Models.EF;

namespace WedBanLinhKienDienTu.Models.Dao
{
    
        public class UserDb
        {
            WebBanLinhKienMayTinhDbContext context;
            public UserDb()
            {
                context = new WebBanLinhKienMayTinhDbContext();
            }
            public bool Login(string Useranme, string Password)
            {
                SqlParameter[] param = new SqlParameter[]
                {
                new SqlParameter("@Useranme",Useranme),
                new SqlParameter("@Password",Password)
                };
                return context.Database.SqlQuery<bool>("SP_User_Login @Username,@Password", param).SingleOrDefault();
            }

        }
    }
