using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WedBanLinhKienDienTu.Models.EF;

namespace WedBanLinhKienDienTu.Models.Dao
{
    public class FeedbackDao
    {
        WebBanLinhKienMayTinhDbContext context;
        
        public FeedbackDao()
        {
            context = new WebBanLinhKienMayTinhDbContext();
        }

        public IEnumerable<Feedback> GetFeedbacks(int id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ID",id)
            };
            var Result = context.Database.SqlQuery<Feedback>("PSP_Feedback_Select @ID", param).ToList();
            return Result;
        }
        public Feedback GetFeedbackByID(int id)
        {
            SqlParameter[] pram = new SqlParameter[]
            {
                new SqlParameter("@ID",id)
            };
            var Result = context.Database.SqlQuery<Feedback>("PSP_Feedback_Select @ID", pram).SingleOrDefault();
            return Result;
        }
        public int InsertFeedback (Feedback feedback)
        {
            SqlParameter[] pram = new SqlParameter[]
            {
                new SqlParameter("@ID", feedback.ID),
                new SqlParameter("@Name", feedback.Name),
                new SqlParameter("@Phone", feedback.Phone),
                new SqlParameter("@Email", feedback.Email),
                new SqlParameter("@Address", feedback.Address),
                new SqlParameter("@Content", feedback.Content),
                new SqlParameter("@CreatedDate", feedback.CreatedDate),
                new SqlParameter("@Status", feedback.Status)
            };
            var result = context.Database.ExecuteSqlCommand("PSP_Feedback_InsertAndUpdate @ID,@Name,@Phone,@Email,@Address,@Content,@CreatedDate,@Status", pram);
            return result;
        }
        public int UpdateFeedback(Feedback feedback)
        {
            SqlParameter[] pram = new SqlParameter[]
            {
                new SqlParameter("@ID", feedback.ID),
                new SqlParameter("@Name", feedback.Name),
                new SqlParameter("@Phone", feedback.Phone),
                new SqlParameter("@Email", feedback.Email),
                new SqlParameter("@Address", feedback.Address),
                new SqlParameter("@Content", feedback.Content),
                new SqlParameter("@CreatedDate", feedback.CreatedDate),
                new SqlParameter("@Status", feedback.Status)
            };
            var result = context.Database.ExecuteSqlCommand("PSP_Feedback_InsertAndUpdate @ID,@Name,@Phone,@Email,@Address,@Content,@CreatedDate,@Status", pram);
            return result;
        }
        public int DeleteFeedback(Feedback feedback)
        {
            SqlParameter[] pram = new SqlParameter[]
            {
                new SqlParameter("@ID", feedback.ID)
              
            };
            var result = context.Database.ExecuteSqlCommand("PSP_Feedback_Delete @ID", pram);
            return result;
        }
    }
}
