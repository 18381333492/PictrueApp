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
    public class GoodsController : AdminBaseController<GoodsService>
    {
        // GET: /Admin/Goods/

        #region 商品相关视图
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// 编辑商品使视图
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(Guid ID)
        {
            return View(_server.Get(ID));
        }

        #endregion


        /// <summary>
        /// 获取商品数据列表
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public ActionResult List(PageInfo Info,string sGoodsCategoryId,string sKeyWord)
        {
            return Content(_server.GetList(Info, sGoodsCategoryId, sKeyWord));
        }

        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public void Insert(Goods item)
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
        /// 编辑商品
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public void Update(Goods item)
        {
            int res = _server.Edit(item);
            if (res > 0)
                result.success = true;
            else
                result.info = "编辑失败!";
        }

        /// <summary>
        /// 逻辑删除商品
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public void Cancel(string Ids)
        {
            int res = _server.Cancel(Ids);
            if (res > 0)
                result.success = true;
            else
                result.info = "删除失败!";
        }
    }
}
