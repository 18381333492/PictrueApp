using EFModel;
using EFModel.MyModels;
using Sevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.App_Start;

namespace Web.Areas.Admin.Controllers
{
    public class LikePictureController : AdminBaseController<LikePictureService>
    {
        // GET: /Admin/LikePicture/

        #region 猜你喜欢的图片控制器

        /// <summary>
        /// 商品评价视图
        /// </summary>
        /// <param name="sGoodsId">商品ID</param>
        /// <returns></returns>
        public ActionResult Index()
        {          
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// 编辑商品分类
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ActionResult Edit(Guid ID)
        {
            return View(_server.Get(ID));
        }



        /// <summary>
        /// 获取猜你喜欢列表
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public ActionResult List(PageInfo Info)
        {
            return Content(_server.GetList(Info, null));
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public void Insert(LikePicture item)
        {
            int res = _server.Add(item);
            if (res > 0)
            {
                result.success = true;
            }
            else
            {
                result.info = "添加失败!";
            }
        }

        /// <summary>
        /// 编辑
        /// <param name="item"></param>
        /// <returns></returns>
        public void Update(LikePicture item)
        {
            int res = _server.Edit(item);
            if (res > 0)
                result.success = true;
            else
                result.info = "编辑失败!";
        }
        #endregion
    }
}
