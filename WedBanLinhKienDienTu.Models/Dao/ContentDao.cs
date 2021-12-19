using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WedBanLinhKienDienTu.Models.EF;

namespace WedBanLinhKienDienTu.Models.Dao
{
   public class ContentDao
    {
        WebBanLinhKienMayTinhDbContext context;

        public ContentDao()
        {
            context = new WebBanLinhKienMayTinhDbContext();
        }
        public IEnumerable<Content> GetContents(long id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                 new SqlParameter("@ID", id)
            };
            var Reustl = context.Database.SqlQuery<Content>("PSP_Content_Select @ID", param).ToList();
            return Reustl;
        }
        public Content GetContentByID(long id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                  new SqlParameter("@ID", id)
            };
            var reustl = context.Database.SqlQuery<Content>("PSP_Content_Select @ID", param).SingleOrDefault();
            return reustl;
        }
        public int InsertContent(Content content)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                 new SqlParameter("@ID", content.ID),
                new SqlParameter("@Name", content.Name),
                new SqlParameter("@MetaTitle", content.MetaTitle),
                new SqlParameter("@Description", content.Description),
                new SqlParameter("@Image", content.Image),
                new SqlParameter("@CategoryID", content.CategoryID),
                new SqlParameter("@Detail", content.Detail),
                new SqlParameter("@Warranty", content.Warranty),
                new SqlParameter("@CreatedDate", content.CreatedDate),
                new SqlParameter("@CreatedBy", content.CreatedBy),
                new SqlParameter("@MetaKeywords", content.MetaKeywords),
                new SqlParameter("@MetaDescriptions", content.MetaDescriptions),
                new SqlParameter("@Status", content.Status),
                new SqlParameter("@TopHot", content.TopHot),
                new SqlParameter("@ViewCount", content.ViewCount),
                new SqlParameter("@Tags", content.Tags),
                new SqlParameter("@Language", content.Language),
            };
            var reustl = context.Database.ExecuteSqlCommand("PSP_Content_InsertAndUpdate @ID, @Name, @MetaTitle, @Description, @Image, @CategoryID, @Detail, @Warranty, @CreatedDate, @CreatedBy, @ModifiedDate, @ModifiedBy, @MetaKeywords, @MetaDescriptions, @Status, @TopHot, @ViewCount, @Tags, @Language", param);
            return reustl;
        }
        public int UpdateContent(Content content)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ID", content.ID),
                new SqlParameter("@Name", content.Name),
                new SqlParameter("@MetaTitle", content.MetaTitle),
                new SqlParameter("@Description", content.Description),
                new SqlParameter("@Image", content.Image),
                new SqlParameter("@CategoryID", content.CategoryID),
                new SqlParameter("@Detail", content.Detail),
                new SqlParameter("@Warranty", content.Warranty),
                new SqlParameter("@CreatedDate", content.CreatedDate),
                new SqlParameter("@CreatedBy", content.CreatedBy),
                new SqlParameter("@MetaKeywords", content.MetaKeywords),
                new SqlParameter("@MetaDescriptions", content.MetaDescriptions),
                new SqlParameter("@Status", content.Status),
                new SqlParameter("@TopHot", content.TopHot),
                new SqlParameter("@ViewCount", content.ViewCount),
                new SqlParameter("@Tags", content.Tags),
                new SqlParameter("@Language", content.Language),
            };
            var reustl = context.Database.ExecuteSqlCommand("PSP_Category_InsertAndUpdate @ID, @Name, @MetaTitle, @Description, @Image, @CategoryID, @Detail, @Warranty, @CreatedDate, @CreatedBy, @ModifiedDate, @ModifiedBy, @MetaKeywords, @MetaDescriptions, @Status, @TopHot, @ViewCount, @Tags, @Language", param);
            return reustl;
        }
        public int Delete(Content content)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ID", content.ID),
            };
            var reustl = context.Database.ExecuteSqlCommand("PSP_Content_Delete @ID", param);
            return reustl;
        }
    }
}
