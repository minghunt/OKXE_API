using OKXE_API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OKXE_API.Controllers
{
    public class XuLyController : ApiController
    {
        [Route("api/Xe/LayDSXe")]
        [HttpGet]
        public IHttpActionResult LayDSXe()
        {
            try
            {
                DataTable tb = Database.LayDSXe();

                return Ok(tb);
            }
            catch
            {
                return NotFound();
            }
        }
        [Route("api/Xe/LayDSXeTheoUser")]
        [HttpGet]
        public IHttpActionResult LayDSXeTheoUser(string username)
        {
            try
            {
                DataTable tb = Database.LayDSXeTheoUser(username);

                return Ok(tb);
            }
            catch
            {
                return NotFound();
            }
        }


        [Route("api/Shop/LayDSShopTheoUser")]
        [HttpGet]
        public IHttpActionResult LayDSShopTheoUser(string username)
        {
            try
            {
                DataTable tb = Database.LayDSShopTheoUser(username);

                return Ok(tb);
            }
            catch
            {
                return NotFound();
            }
        }
        [Route("api/User/LayDSUser")]
        [HttpGet]
        public IHttpActionResult LayDSUser()
        {
            try
            {
                DataTable tb = Database.LayDSUser();

                return Ok(tb);
            }
            catch
            {
                return NotFound();
            }
        }
        [Route("api/Shop/LayDSShop")]
        [HttpGet]
        public IHttpActionResult LayDSShop()
        {
            try
            {
                DataTable tb = Database.LayDSShop();

                return Ok(tb);
            }
            catch
            {
                return NotFound();
            }
        }
        [Route("api/Xe/CapNhatXe")]
        [HttpPost]
        public IHttpActionResult CapNhatXe(Xe xe)
        {
            try
            {
                int kq = Database.CapNhatXe(xe);

                return Ok(kq);
            }
            catch
            {
                return NotFound();
            }
        }
        [Route("api/Shop/CapNhatShop")]
        [HttpPost]
        public IHttpActionResult CapNhatShop(Shop e)
        {
            try
            {
                int kq = Database.CapNhatShop(e);

                return Ok(kq);
            }
            catch
            {
                return NotFound();
            }
        }
        [Route("api/User/ThemUser")]
        [HttpPost]
        public IHttpActionResult ThemUser(User user)
        {
            try
            {
                int kq = Database.ThemUser(user);

                return Ok(kq);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
