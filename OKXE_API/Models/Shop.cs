using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OKXE_API.Models
{
    public class Shop
    {
        public int idShopXe { get; set; }

        public int maShopXe { get; set; }
        public string username { get; set; }

        public string tenShop { get; set; }
        public string tenTp { get; set; }
        public double Sao { get; set; }
        public string hinhNenShop { get; set; }
        public string hinhShop { get; set; }
        public string diaChi { get; set; }
        public string loveImg { get; set; } 
        public string Sdt { get; set; } 
    }
}