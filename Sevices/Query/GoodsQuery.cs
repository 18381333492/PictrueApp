using EFModel;
using EFModel.MyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Sevices
{
    public partial class GoodsService : ServiceBase
    {


        /// <summary>
        /// 分页获取商品数据列表
        /// </summary>
        /// <param name="Info"></param>
        /// <param name="sGoodsCategoryId"></param>
        /// <param name="sKeyWord"></param>
        /// <returns></returns>
        public string GetList(PageInfo Info, string sGoodsCategoryId, string sKeyWord)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.Append(@"SELECT A.*,B.GoodsCatetoryName FROM [Goods] AS A 
                                        LEFT JOIN GoodsCategory AS B
                                        ON A.sGoodsCategoryId=B.ID
                                        WHERE A.bIsDeleted=0");
            if (!string.IsNullOrEmpty(sGoodsCategoryId))
            {//分类查询
                sSql.AppendFormat(" AND B.ID='{0}'", sGoodsCategoryId);
            }
            if (!string.IsNullOrEmpty(sKeyWord))
            {//名称模糊查询

                sSql.AppendFormat(" AND A.sGoodsName LIKE '%{0}%'", sKeyWord);
            }
            return query.QueryPage(sSql.ToString(), Info, null);
        }

        /// <summary>
        /// 获取单个商品
        /// </summary>
        /// <param name="ID">主键ID</param>
        /// <returns></returns>
        public Goods Get(Guid ID)
        {
            return query.db.Goods.Find(ID);
        }

    }
}
