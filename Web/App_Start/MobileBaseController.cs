using EFModel;
using EFModel.MyModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Newtonsoft.Json;
using System.IO;

namespace Web.App_Start
{
    public class MobileBaseController<T> : Controller, IExceptionFilter where T:class,new ()
    {
        //
        // GET: /MobileBase/

        public Result result;//返回结果集

        protected T _server;

        public MobileBaseController()
        {
            result = new Result();
            _server = Resolve<T>();
        }

        protected M Resolve<M>()
        {
            return (M)Activator.CreateInstance(typeof(M));
        }

        /// <summary>
        /// 缓存的session的相关信息
        /// </summary>
        public class SESSION
        { 
            public static string User = "@_User";
            public static string Menu = "@_Menu";
            public static string Button = "@_Button";
            public static string ImgCode = "@_ImgCode";
        }

      
        /// <summary>
        /// 在Action执行完之后操作
        /// </summary>
        /// <param name = "filterContext" ></ param >
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var request = filterContext.HttpContext.Request;
            var actionMethod = filterContext.Controller
              .GetType()
              .GetMethod(filterContext.ActionDescriptor.ActionName);//获取访问方法
            if (actionMethod.ReturnType.Name.ToString() == "Void"&& request.IsAjaxRequest()&& request.HttpMethod.ToUpper()=="POST")
            {
                filterContext.Result = Content(result.toJson()); /**统一处理ajax的返回结果**/
            }

        }

        /// <summary>
        /// 异常捕捉
        /// tip：捕捉代码异常,写代码错误日志.
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnException(ExceptionContext filterContext)
        {
            Exception e = filterContext.Exception;
            Logs.LogHelper.ErrorLog(e);
        }

    }
}
