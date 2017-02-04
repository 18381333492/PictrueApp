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
    public partial class LikePictureService : ServiceBase
    {

        /// <summary>
        /// 分页获取猜你喜欢数据列表
        /// </summary>
        /// <param name="Info">分页参数</param>
        /// <param name="Params">查询参数</param>
        /// <returns></returns>
        public string GetList(PageInfo Info, Dictionary<string, object> Params)
        {
            return query.QueryPage(@"SELECT * FROM [LikePicture]", Info, null);
        }


        /// <summary>
        /// 获取单个猜你喜欢
        /// </summary>
        /// <param name="ID">主键ID</param>
        /// <returns></returns>
        public LikePicture Get(Guid ID)
        {
            return query.db.LikePicture.Find(ID);
        }

        /// <summary>
        /// 获取随机的猜你喜欢三张图片
        /// </summary>
        /// <returns></returns>
        public List<LikePicture> GetRandmThree()
        {
            var data = query.db.LikePicture.OrderBy(m => Guid.NewGuid()).Take(3).ToList();
            return data;
        }
    }
}
