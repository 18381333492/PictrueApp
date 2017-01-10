using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.WeiXin.Controllers
{

    public class CheckDeveloperController : Controller
    {
        //
        // GET: /WeiXin/CheckDeveloper/

        /// <summary>
        /// 验证微信开发者
        /// </summary>
        /// <returns></returns>
        public ActionResult Check()
        {
            return View();
        }

    }
}
