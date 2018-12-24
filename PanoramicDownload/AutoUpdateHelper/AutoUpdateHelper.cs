using HslCommunication.BasicFramework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace AutoUpdateHelper
{
    public class AutoUpdate
    {
        public static bool CheckAndUpdate()
        {
            try
            {
                LocalConf local = new LocalConf();
                Uri uri = new Uri(local.Manifest);
                string doc = GetManifest(uri);
                XmlSerializer xser = new XmlSerializer(typeof(Manifest));
                var manifest = xser.Deserialize(new XmlTextReader(doc, XmlNodeType.Document, null)) as Manifest;
                var updateVersion = manifest.Version.Replace(".", "");
                if (GetVersionCount(manifest.Version) > GetVersionCount(local.Version))
                {
                    if (MessageBox.Show("是否更新最新版本！v" + manifest.Version, "更新提示 现版本 v" + local.Version, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        Process.Start(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, local.Update));
                        return true;
                    }

                }
                return false;
            }
            catch (Exception e)
            {
                SoftBasic.ShowExceptionMessage("错误原因：请检查网络连接！！！  \n", e);
                //MessageBox.Show("错误：" +"检测网络！！", "错误提示");
                return false;
            }
        }

        public static string GetVersion()
        {
            LocalConf local = new LocalConf();
            return local.Version;
        }

        public static int GetVersionCount(string version)
        {
            int Version = int.Parse(version.Replace(".", ""));
            return Version;
        }
        private static string GetManifest(Uri uri)
        {
            WebRequest request = WebRequest.Create(uri);
            request.Credentials = CredentialCache.DefaultCredentials;
            string response = String.Empty;
            using (WebResponse res = request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(res.GetResponseStream(), true))
                {
                    response = reader.ReadToEnd();
                }
            }
            return response;
        }
    }
}
