using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace AutoUpdate
{
    [XmlRoot("manifest")]
    public class Manifest
    {
        /// <summary>
        /// 版本号
        /// </summary>
        [XmlElement("version")]
        public string Version { get; set; }

        /// <summary>
        /// 描述 
        /// </summary>
        [XmlElement("description")]
        public string Description { get; set; }

        /// <summary>
        ///  下载链接
        /// </summary>
        [XmlElement("webpath")]
        public string WebPath { get; set; }

        /// <summary>
        /// 启动应用
        /// </summary>
        [XmlElement("exepath")]
        public string ExePath { get; set; }
    }
}
