using EFModel;
using EFModel.MyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Sevices
{
    public partial class GoodsCategoryService : ServiceBase
    {

        /// <summary>
        /// 分页获取商品分类数据列表
        /// </summary>
        /// <param name="Info">分页参数</param>
        /// <param name="Params">查询参数</param>
        /// <returns></returns>
        public string GetList(PageInfo Info,Dictionary<string,object> Params)
        {
            return query.QueryPage(@"SELECT * FROM [GoodsCategory]
                                             WHERE bIsDeleted=0 ", Info, null);
        }

        /// <summary>
        /// 获取单个商品分类
        /// </summary>
        /// <param name="ID">主键ID</param>
        /// <returns></returns>
        public GoodsCategory Get(Guid ID)
        {
            return query.db.GoodsCategory.Find(ID);
        }

        /// <summary>
        /// 获取所有的分类数据
        /// </summary>
        public string GetAllGoodsCategory(int bIsAdd)
        {
            var data = from m in query.db.GoodsCategory
                       where m.bIsDeleted == false
                       select new
                       {
                           id = m.ID,
                           text = m.GoodsCatetoryName
                       };

            JArray array = JArray.Parse(JsonConvert.SerializeObject(data));
            if (bIsAdd == 1)
            {
                JObject job = new JObject();
                job.Add(new JProperty("id", string.Empty));
                job.Add(new JProperty("text", "全部"));
                array.AddFirst(job);
            }
            return array.ToString();
        }

    }
}
