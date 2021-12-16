using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WedBanLinhKienDienTu.Models.EF;

namespace WedBanLinhKienDienTu.Models.Dao
{
    public class ProductDao
    {
        WebBanLinhKienMayTinhDbContext context;

        public ProductDao()
        {
            context = new WebBanLinhKienMayTinhDbContext();
        }
        public IEnumerable<Product> GetProducts(long id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ID", id)
            };
            var reustl = context.Database.SqlQuery<Product>("PSP_Product_Select @ID", param).ToList();
            return reustl;
        }
        public Product GetProductByID(long id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ID", id)
            };
            var reustl = context.Database.SqlQuery<Product>("PSP_Product_Select @ID", param).SingleOrDefault();
            return reustl;
        }
        public int InsertProduct(Product product)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ID", product.ID),
                new SqlParameter("@Name", product.Name),
                new SqlParameter("@Code", product.Code),
                new SqlParameter("@MetaTitle", product.MetaTitle),
                new SqlParameter("@Description", product.Description),
                new SqlParameter("@Image", product.Image),
                new SqlParameter("@Price", product.Price),
                new SqlParameter("@PromotionPrice", product.PromotionPrice),
                new SqlParameter("@IncludedVAT", product.IncludedVAT),
                new SqlParameter("@Quantity", product.Quantity),
                new SqlParameter("@CategoryID", product.CategoryID),
                new SqlParameter("@Detail", product.Detail),
                new SqlParameter("@Warranty", product.Warranty),
                new SqlParameter("@MetaKeywords", product.MetaKeywords),
                new SqlParameter("@MetaDescriptions", product.MetaDescriptions),
                new SqlParameter("@Status", product.Status),
                new SqlParameter("@TopHot", product.TopHot),
                new SqlParameter("@ViewCount", product.ViewCount),

            };
            var reustl = context.Database.ExecuteSqlCommand
                ("PSP_Product_InsertAndUpdate @ID,@Name,@Code,@MetaTitle,@Description,@Image,@Price,@PromotionPrice," +
                "@IncludedVAT,@Quantity,@CategoryID,@Detail,@Warranty,@MetaKeywords,@MetaDescriptions,@Status,@TapHot,@ViewCount", param);
            return reustl;
        }
        public int UpdateProduct(Product product)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ID", product.ID),
                new SqlParameter("@Name", product.Name),
                new SqlParameter("@Code", product.Code),
                new SqlParameter("@MetaTitle", product.MetaTitle),
                new SqlParameter("@Description", product.Description),
                new SqlParameter("@Image", product.Image),
                new SqlParameter("@Price", product.Price),
                new SqlParameter("@PromotionPrice", product.PromotionPrice),
                new SqlParameter("@IncludedVAT", product.IncludedVAT),
                new SqlParameter("@Quantity", product.Quantity),
                new SqlParameter("@CategoryID", product.CategoryID),
                new SqlParameter("@Detail", product.Detail),
                new SqlParameter("@Warranty", product.Warranty),
                new SqlParameter("@MetaKeywords", product.MetaKeywords),
                new SqlParameter("@MetaDescriptions", product.MetaDescriptions),
                new SqlParameter("@Status", product.Status),
                new SqlParameter("@TopHot", product.TopHot),
                new SqlParameter("@ViewCount", product.ViewCount),

            };
            var reustl = context.Database.ExecuteSqlCommand
                ("PSP_Product_InsertAndUpdate @ID,@Name,@Code,@MetaTitle,@Description,@Image,@Price,@PromotionPrice," +
                "@IncludedVAT,@Quantity,@CategoryID,@Detail,@Warranty,@MetaKeywords,@MetaDescriptions,@Status,@TapHot,@ViewCount", param);
            return reustl;
        }
        public int Delete(Product product)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ID", product.ID)
            };
            var reustl = context.Database.ExecuteSqlCommand("PSP_Product_Delete @ID", param);
            return reustl;

        }
    }
}