using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WedBanLinhKienMayTinh.Areas.Admin.Model
{
    public class LoginModel
    {
        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(32)]
        public string Password { get; set; }
    }
}