using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OKXE_API.Models
{
    public class User
    {
        public int maUser { get; set; }
        public string username { get; set; }
        public string mkUser { get; set; }
        public string hoTenUser { get; set; }
        public string hinhUser { get; set; } = "User.jpg";
        public string phoneUser { get; set; }
        public string emailUser { get; set; }
        public string diaChiUser { get; set; }
    }
}