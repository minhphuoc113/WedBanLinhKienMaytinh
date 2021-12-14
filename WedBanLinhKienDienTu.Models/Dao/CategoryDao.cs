using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WedBanLinhKienDienTu.Models.EF;

namespace WedBanLinhKienDienTu.Models.Dao
{
  public  class CategoryDao
    {
        WebBanLinhKienMayTinhDbContext context;

        public CategoryDao()
        {
            context = new WebBanLinhKienMayTinhDbContext();
        }
        public IEnumerable<Category> GetCategories(long id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ID", id)
            };
            var Reustl = context.Database.SqlQuery<Category>("PSP_Category_Select @ID", param).ToList();
            return Reustl;
        }
        public Category GetCategoryByID(long id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ID", id)
            };
            var Reustl = context.Database.SqlQuery<Category>("PSP_Category_Select @ID", param).SingleOrDefault();
            return Reustl;
        }
        public int InsertCategory(Category category)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ID", category.ID),
                new SqlParameter("@Name", category.Name),
                new SqlParameter("@MetaTitle", category.MetaTitle),
                new SqlParameter("@ParentID", category.ParentID),
                new SqlParameter("@DisplayOrder", category.DisplayOrder),
            };
            var reustl = context.Database.ExecuteSqlCommand ("PSP_Category_InsertAndUpdate @ID,@Name,@MetaTitle,@ParentID,@DisplayOrder",  param);
            return reustl;
        }
        public int UpdateCategory(Category category)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ID", category.ID),
                new SqlParameter("@Name", category.Name),
                new SqlParameter("@MetaTitle", category.MetaTitle),
                new SqlParameter("@ParentID", category.ParentID),
                new SqlParameter("@DisplayOrder", category.DisplayOrder),
            };
            var reustl = context.Database.ExecuteSqlCommand("PSP_Category_InsertAndUpdate @ID,@Name,@MetaTitle,@ParentID,@DisplayOrder", param);
            return reustl;
        }
        public int Delete (Category category)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ID", category.ID),
                
            };
            var reustl = context.Database.ExecuteSqlCommand("PSP_Category_Delete @ID", param);
            return reustl;
        }


    }
}
