﻿using System;
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
        empty,
        lx_x_xx_xx, //720云
        ssssxssss, //酷家乐      // /u/n3/5/u_5_2.jpg";       
        lxlxxlxlx_x_x,//网展
    }

    public  static class ConstPath
    {
        public static string exePath = Environment.CurrentDirectory;

        public const string qqUrl = "http://wpa.qq.com/msgrd?v=3&uin=1228267639&site=qq&menu=yes";

        public const string mailUrl = "mailto:yzj520mei@126.com,test2@sample.com";
    }

}
