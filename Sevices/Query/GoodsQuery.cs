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

        /// <summary>
        /// 获取商品分类一样的的商品
        /// </summary>
        /// <returns></returns>
        public List<Goods> GetTopThree(Guid sGoodsId)
        {
            var good = query.db.Goods.Find(sGoodsId);

            var sGoodsCategoryId = good.sGoodsCategoryId;

            var data = (from m in query.db.Goods
                       where m.bIsDeleted ==false && m.sGoodsCategoryId == sGoodsCategoryId &&m.ID!= sGoodsId
                        orderby m.dInsertTime descending
                       select m).Take(3);
            return data.ToList();
        }

        /// <summary>
        /// 获取首页图片
        /// </summary>
        /// <returns></returns>
        public List<Goods> GetIndexGoodsPicture()
        {
            return query.db.Goods.OrderByDescending(m => m.dInsertTime).Take(10).ToList();
        }


        /// <summary>
        /// 获取所有的分类
        /// </summary>
        /// <returns></returns>
        public List<Dictionary<string,object>> GetAllCategory()
        {
            StringBuilder sSql = new StringBuilder();

            sSql.Append(@"SELECT A.GoodsCatetoryName,A.sPath,COUNT(B.ID) as iCount FROM (SELECT * FROM  GoodsCategory WHERE bIsDeleted=0) AS A 
                                        LEFT JOIN Goods AS B 
                                        ON A.ID=B.sGoodsCategoryId AND A.bIsDeleted=0          
                                        AND B.bIsDeleted=0 
                                        group by A.ID,A.GoodsCatetoryName,A.sPath having A.ID!='366B2C87-38CE-4EC4-A742-1E889C117299'");

            return  query.QueryByDapper(sSql.ToString(),null);

        }
    }
}
