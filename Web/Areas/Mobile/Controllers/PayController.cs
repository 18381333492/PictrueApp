using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.App_Start;
using Sevices;
using EFModel.MyModels;
using System.IO;
using Common;
using System.Net;

namespace Web.Areas.Mobile.Controllers
{
    /// <summary>
    /// 支付页面
    /// </summary>
    public class PayController : MobileBaseController<GoodsService>
    {
        //
        // GET: /Mobile/Pay/

        /// <summary>
        /// 商品列表展示页
        /// </summary>
        /// <returns></returns>
        public ActionResult Success()
        {
            return View();
        }

        /// <summary>
        /// 发起支付请求
        /// </summary>
        /// <param name="money">单位(元)</param>
        public void  PayRequest(string money)
        {
            //商户订单号
            string out_order_no =DateTime.Now.ToString("yyyyMMddhhmmssfff");
            //商品名称
            string subject = "黄金会员";
            //金额
            string total_fee = money;
            //订单描述
            string body = "开通黄金会员";

            //商户号（6位数字）
            string user_seller = C_Config.ReadAppSetting("user_seller");

            //合作身份者PID，签约账号，由16位纯数字组成的字符串，请登录商户后台查看
            string partner = C_Config.ReadAppSetting("partner");

            // MD5密钥，安全检验码，由数字和字母组成的32位字符串，请登录商户后台查看
            string key = C_Config.ReadAppSetting("key");

            // 服务器异步通知页面路径  需http://格式的完整路径，不能加?id=123这类自定义参数，必须外网可以正常访问
            string notify_url = C_Config.ReadAppSetting("notify_url");
            // 页面跳转同步通知页面路径 需http://格式的完整路径，不能加?id=123这类自定义参数，必须外网可以正常访问
            string return_url = C_Config.ReadAppSetting("return_url");
            string UrlParm = GetUrlParm(partner, user_seller, out_order_no, subject, total_fee, body, notify_url, return_url, key);

            //发起请求的url
            string sUrl =string.Format("http://www.passpay.net/PayOrder/payorder?{0}", UrlParm);
        
            result.data = sUrl;
            result.success = true;

        }

        public void AsyncNotify()
        {
            string meg = string.Empty;
            try
            {
                //交易金额
                string total_fee = Request.QueryString["total_fee"].ToString();
                //商户订单号
                string out_order_no = Request.QueryString["out_order_no"].ToString();
                //服务端校验码
                string sign = Request.QueryString["sign"].ToString();
                //云通付交易订单号
                string trade_no = Request.QueryString["trade_no"].ToString();
                //交易结果（TRADE_SUCCESS说明支付成功）
                string trade_status = Request.QueryString["trade_status"].ToString();
                //合作身份者PID，签约账号，由16位纯数字组成的字符串，请登录商户后台查看
                string partner = "738513346376621";
                // MD5密钥，安全检验码，由数字和字母组成的32位字符串，请登录商户后台查看
                string key = "JHeP76Kzd8aMQv8GZxZ3Gi8NgI2gfgAW";
                bool State = NotifyState(total_fee, out_order_no, sign, trade_no, trade_status, partner, key);
                if (State)
                {
                    meg = "验证成功";
                }
                else
                {
                    meg = "验证失败";
                }
            }
            catch (Exception ex)
            {
                meg = "数据未传回或参数错误";
            }
        }


        /// <summary>
        /// 验证状态
        /// </summary>
        /// <param name="total_fee">交易金额</param>
        /// <param name="out_order_no">商户订单号</param>
        /// <param name="sign">服务端校验码</param>
        /// <param name="trade_no">云通付交易订单号</param>
        /// <param name="trade_status">交易结果（TRADE_SUCCESS说明支付成功）</param>
        /// <param name="partner">合作身份者PID，签约账号，由16位纯数字组成的字符串，请登录商户后台查看</param>
        /// <param name="key">MD5密钥，安全检验码，由数字和字母组成的32位字符串，请登录商户后台查看</param>
        /// <returns></returns>
        public bool NotifyState(string total_fee, string out_order_no, string sign, string trade_no, string trade_status, string partner, string key)
        {
            string val = string.Empty;
            val += out_order_no + total_fee + trade_status + partner + key;
            val = md5(val.ToString());
            if (sign == val)
                return true;
            else
                return false;

        }


        /// <summary>
        /// 获取URL参数
        /// </summary>
        /// <param name="partner">云通付PID(必填)</param>
        /// <param name="user_seller">云通付商户号(必填)</param>
        /// <param name="out_order_no">商户网站订单号（唯一）(必填)</param>
        /// <param name="subject">订单名称(必填)</param>
        /// <param name="total_fee">订单价格（整元）(必填)</param>
        /// <param name="body">订单描述(选填)</param>
        /// <param name="notify_url">异步回调地址(必填)</param>
        /// <param name="return_url">同步回调地址(必填)</param>
        /// <param name="key">密钥(必填)</param>
        /// <returns></returns>
        private string GetUrlParm(string partner, string user_seller, string out_order_no, string subject, string total_fee, string body, string notify_url, string return_url, string key)
        {

            string prestr = string.Empty;
            if (!string.IsNullOrEmpty(body))
            {
                prestr += "body=" + body + "&";
            }
            prestr += "notify_url=" + notify_url + "&";
            prestr += "out_order_no=" + out_order_no + "&";
            prestr += "partner=" + partner + "&";
            prestr += "return_url=" + return_url + "&";
            prestr += "subject=" + subject + "&";
            prestr += "total_fee=" + total_fee + "&";
            prestr += "user_seller=" + user_seller;
            string sign =md5(prestr + key);
            return prestr + "&sign=" + sign;
        }


        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private String md5(String s)
        {
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(s);
            bytes = md5.ComputeHash(bytes);
            md5.Clear();

            string ret = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                ret += Convert.ToString(bytes[i], 16).PadLeft(2, '0');
            }

            return ret.PadLeft(32, '0');
        }



    }
}
