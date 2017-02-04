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
    public partial class CommentService : ServiceBase
    {


        /// <summary>
        /// 根据商品ID分页获取商品评价数据列表
        /// </summary>
        /// <param name="Info"></param>
        /// <param name="sGoodsId"></param>
        /// <returns></returns>
        public string GetList(PageInfo Info, Guid sGoodsId)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendFormat(@"SELECT * FROM [Comment] 
                                        WHERE bIsDeleted=0 AND sGoodsId='{0}'", sGoodsId.ToString());
            return query.QueryPage(sSql.ToString(), Info, null);
        }

        /// <summary>
        /// 获取单个评价
        /// </summary>
        /// <param name="ID">主键ID</param>
        /// <returns></returns>
        public Comment Get(Guid ID)
        {
            return query.db.Comment.Find(ID);
        }


        /// <summary>
        /// 随机获取评论数据
        /// </summary>
        /// <returns></returns>
        public string GetRandomList()
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendFormat(@"SELECT TOP 15 * FROM [Comment] 
                                        WHERE bIsDeleted=0 ORDER BY NEWID()");
            return C_Json.toJson(query.QueryByDapper(sSql.ToString(),null));
        }

    }
}
