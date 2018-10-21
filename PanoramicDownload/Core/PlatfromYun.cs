using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanoramicDownload.Core
{
    public class PlatfromYun : PlatformBase
    {


        public override void WriteDownLoad(DirectionType type, int maxIndex, StringBuilder newUrl, int maxQuality, StreamWriter SWFile)
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
    }
}
