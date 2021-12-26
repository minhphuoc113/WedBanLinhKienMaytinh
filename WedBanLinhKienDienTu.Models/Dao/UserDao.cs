using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WedBanLinhKienDienTu.Models.EF;

namespace WedBanLinhKienDienTu.Models.Dao
{
    public class UserDao
    {
        WebBanLinhKienMayTinhDbContext context;

        public UserDao()
        {
            context = new WebBanLinhKienMayTinhDbContext();
        }
        public IEnumerable<User> GetUsers(long id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ID", id),
            };
            var result = context.Database.SqlQuery<User>("PSP_User_Select @ID", param).ToList();
            return result;
        }
        public User GetUserById(long id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ID", id),
            };
            var result = context.Database.SqlQuery<User>("PSP_User_Select @ID", param).SingleOrDefault();
            return result;
        }
        public int InsertUser(User user)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ID", user.ID),
                 new SqlParameter ("@UserName", user.UserName),
                  new SqlParameter ("@Password", user.Password),
                   new SqlParameter ("@GroupID", user.GroupID),
                    new SqlParameter ("@Name", user.Name),
                     new SqlParameter ("@Email", user.Email),
                      new SqlParameter ("@Phone", user.Phone),
                       new SqlParameter ("@Status", user.Status),
            };
            var result = context.Database.ExecuteSqlCommand("PSP_User_InsertAndUpdate @ID,@UserName,@Password,@GroupID,@Name,@Email,@Phone,@Status", param);
            return result;
        }
        public int UpdateUser(User user)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ID", user.ID),
                 new SqlParameter ("@UserName", user.UserName),
                  new SqlParameter ("@Password", user.Password),
                   new SqlParameter ("@GroupID", user.GroupID),
                    new SqlParameter ("@Name", user.Name),
                     new SqlParameter ("@Email", user.Email),
                      new SqlParameter ("@Phone", user.Phone),
                       new SqlParameter ("@Status", user.Status),
            };
            var result = context.Database.ExecuteSqlCommand("PSP_User_InsertAndUpdate @ID,@UserName,@Password,@GroupID,@Name,@Email,@Phone,@Status", param);
            return result;
        }
        public int DeleteUser(User user)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ID", user.ID),

            };
            var result = context.Database.ExecuteSqlCommand("PSP_User_Delete @ID", param);
            return result;
        }
    }
}
