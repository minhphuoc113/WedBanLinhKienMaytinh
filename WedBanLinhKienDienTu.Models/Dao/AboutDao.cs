using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WedBanLinhKienDienTu.Models.EF;

namespace WedBanLinhKienDienTu.Models.Dao
{
    public class AboutDao
    {
        WebBanLinhKienMayTinhDbContext context;

        public AboutDao()
        {
            context = new WebBanLinhKienMayTinhDbContext();
        }
        public IEnumerable<About> GetAbouts(long id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                 new SqlParameter("@ID", id)
            };
            var Reustl = context.Database.SqlQuery<About>("PSP_About_Select @ID", param).ToList();
            return Reustl;
        }



        public About GetAboutByID(long id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                 new SqlParameter("@ID", id)
            };
            var Reustl = context.Database.SqlQuery<About>("PSP_About_Select @ID", param).SingleOrDefault();
            return Reustl;
        }
        public int InsertAbout(About about)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ID", about.ID),
                new SqlParameter("@Name", about.Name),
                new SqlParameter("MetaTitle", about.MetaTitle),
                new SqlParameter("@Description", about.Description),
                new SqlParameter("@Image", about.Image),
                new SqlParameter("@Detail", about.Detail),
                new SqlParameter("@CreatedDate", about.CreatedDate),
                new SqlParameter("@CreatedBy", about.CreatedBy),
                new SqlParameter("@ModifiedDate", about.CreatedDate),
                new SqlParameter("@ModifiedBy", about.CreatedBy),
                new SqlParameter("@MetaKeywords", about.MetaKeywords),
                new SqlParameter("@MetaDescriptions", about.MetaDescriptions),
                new SqlParameter("@Status ", about.Status),
            };
            var reustl = context.Database.ExecuteSqlCommand("PSP_About_InsertAndUpdate @ID, @Name, @MetaTitle, @Description, @Image, @Detail, @CreatedDate, @CreatedBy, @ModifiedDate, @ModifiedBy, @MetaKeywords, @MetaDescriptions, @Status", param);
            return reustl;
        }
        public int UpdateAbout(About about)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ID", about.ID),
                new SqlParameter("@Name", about.Name),
                new SqlParameter("MetaTitle", about.MetaTitle),
                new SqlParameter("@Description", about.Description),
                new SqlParameter("@Image", about.Image),
                new SqlParameter("@Detail", about.Detail),
                new SqlParameter("@CreatedDate", about.CreatedDate),
                new SqlParameter("@CreatedBy", about.CreatedBy),
                new SqlParameter("@ModifiedDate", about.CreatedDate),
                new SqlParameter("@ModifiedBy", about.CreatedBy),
                new SqlParameter("@MetaKeywords", about.MetaKeywords),
                new SqlParameter("@MetaDescriptions", about.MetaDescriptions),
                new SqlParameter("@Status ", about.Status),
            };
            var reustl = context.Database.ExecuteSqlCommand("PSP_About_InsertAndUpdate @ID, @Name, @MetaTitle, @Description, @Image, @Detail, @CreatedDate, @CreatedBy, @ModifiedDate, @ModifiedBy, @MetaKeywords, @MetaDescriptions, @Status", param);
            return reustl;
        }
        public int Delete(About about)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                 new SqlParameter("@ID", about.ID),
            };
            var reustl = context.Database.ExecuteSqlCommand("PSP_About_Delete @ID", param);
            return reustl;
        }

    }
}
