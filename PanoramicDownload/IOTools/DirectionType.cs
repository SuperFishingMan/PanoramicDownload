using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanoramicDownload
{
    /// <summary>
    /// 图片方向类型
    /// </summary>
    public enum DirectionType
    {
        /// <summary>
        /// 上
        /// </summary>
        u,
        /// <summary>
        /// 下
        /// </summary>
        d,
        /// <summary>
        /// 左
        /// </summary>
        l,
        /// <summary>
        /// 右
        /// </summary>
        r,
        /// <summary>
        /// 前
        /// </summary>
        f,
        /// <summary>
        /// 后
        /// </summary>
        b,
    }

    public enum DownLoadType
    {
        /// <summary>
        /// 空
        /// </summary>
        empty,
        /// <summary>
        /// 720云
        /// </summary>
        lx_x_xx_xx, //720云
        /// <summary>
        /// 酷家乐
        /// </summary>
        ssssxssss, //酷家乐      // /u/n3/5/u_5_2.jpg";       
        /// <summary>
        /// 网展
        /// </summary>
        lxlxxlxlx_x_x,//网展
        /// <summary>       
        /// E建
        /// </summary>
        lxlxx_x_x_x,  // /u/l2_u_2_1.jpg";
        /// <summary>
        /// 鱼模网
        /// </summary>
        xxxx_x,//http://720.ajun720.cn/447/works/3536c9e41100e40b/pano_r.jpg
        /// <summary>
        /// 视维
        /// </summary>
        lx_x_x_x,
        /// <summary>
        /// 全景客
        /// </summary>
        lx_x_0x_0x,
        /// <summary>
        /// 全景客_01
        /// </summary>
        lx_x_0x0x,
        /// <summary>
        /// pano_l.jpg
        /// </summary>
        lxxx_x_xxx,
    }

    public  static class ConstPath
    {
        /// <summary>
        /// 根目录
        /// </summary>
        public static string exePath = Environment.CurrentDirectory;

        /// <summary>
        /// 访问qq
        /// </summary>
        public const string qqUrl = "http://wpa.qq.com/msgrd?v=3&uin=1228267639&site=qq&menu=yes";

        /// <summary>
        /// 邮箱
        /// </summary>
        public const string mailUrl = "mailto:yzj520mei@126.com,test2@sample.com";

        /// <summary>
        /// 图片下载保存的路径
        /// </summary>
        public static string saveFile = exePath + "\\下载文件\\";
    }

}
