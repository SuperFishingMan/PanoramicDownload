using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PanoramicDownload.Core
{
    public class PlatformYun : PlatformBase
    {


        public override void WriteDownLoad(DirectionType type, int maxIndex, StringBuilder newUrl, int maxQuality = 0, StreamWriter SWFile = null)
        {
            for (int i = 1; i <= maxIndex; i++)
            {
                for (int x = 1; x <= maxIndex; x++)
                {
                    if (i < 10 && x < 10)
                    {
                        StringBuilder url = new StringBuilder(newUrl + "" + type + "/" + "l" + maxQuality + "/0" + i + "/l" + maxQuality + "_" + type + "_0" + i + "_0" + x + ".jpg");
                        SWFile.WriteLine(url);
                    }
                    if (i < 10 && x >= 10)
                    {
                        StringBuilder url = new StringBuilder(newUrl + "" + type + "/" + "l" + maxQuality + "/0" + i + "/l" + maxQuality + "_" + type + "_0" + i + "_" + x + ".jpg");
                        SWFile.WriteLine(url);
                    }
                    if (i >= 10 && x >= 10)
                    {
                        StringBuilder url = new StringBuilder(newUrl + "" + type + "/" + "l" + maxQuality + "/" + i + "/l" + maxQuality + "_" + type + "_" + i + "_" + x + ".jpg");
                        SWFile.WriteLine(url);
                    }
                    if (i >= 10 && x < 10)
                    {
                        StringBuilder url = new StringBuilder(newUrl + "" + type + "/" + "l" + maxQuality + "/" + i + "/l" + maxQuality + "_" + type + "_" + i + "_0" + x + ".jpg");
                        SWFile.WriteLine(url);
                    }
                }
            }

        }

        public void WriteDownLoad_(DirectionType type, int maxIndex, StringBuilder newUrl, int maxQuality = 0, StreamWriter SWFile = null)
        {
            for (int i = 1; i <= maxIndex; i++)
            {
                for (int x = 1; x <= maxIndex; x++)
                {
                    StringBuilder url = new StringBuilder(newUrl + "" + type + "/" + "l" + maxQuality + "/" + i + "/l" + maxQuality + "_" + type + "_" + i + "_" + x + ".jpg");
                    SWFile.WriteLine(url);
                }
            }
        }


        public override void MatchingImage(string imagePath, string imageQuality, string tpye, int imageIndex, StreamWriter SWFile)
        {
            ListViewItem lvi = new ListViewItem();
            ProgressBar dd = new ProgressBar();


        }
    }
}
