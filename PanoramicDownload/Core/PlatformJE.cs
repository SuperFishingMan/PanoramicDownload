using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanoramicDownload.Core
{
    public class PlatformJE : PlatformBase
    {

        public override void WriteDownLoad(DirectionType type = DirectionType.b, int maxIndex = 1, StringBuilder newUrl = null, int maxQuality = 1, StreamWriter SWFile = null)
        {
            for (int i = 1; i <= maxIndex; i++)
            {
                for (int x = 1; x <= maxIndex; x++)
                {
                    StringBuilder url = new StringBuilder(newUrl + "/" + type + "/" + "l" + maxQuality + "_" + type + "_" + i + "_" + x + ".jpg");
                    SWFile.WriteLine(url);
                }
            }
        }

        public override void MatchingImage(string imagePath, string imageQuality, string tpye, int imageIndex, StreamWriter SWFile, int progindex)
        {
            
        }
    }
}
