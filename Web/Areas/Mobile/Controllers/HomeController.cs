using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.App_Start;
using Sevices;

namespace Web.Areas.Mobile.Controllers
{
    public class HomeController : MobileBaseController<GoodsService>
    {
        //
        // GET: /Mobile/Home/

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(_server.GetIndexGoodsPicture());
        }


        /// <summary>
        /// 个人中心
        /// </summary>
        /// <returns></returns>
        public ActionResult Person()
        {
            ViewBag.UserId = Guid.NewGuid().ToString().ToLower().Substring(0, 10);
            ViewBag.Password = new Random().Next(100000, 999999);
            return View();
        }
    }
}
