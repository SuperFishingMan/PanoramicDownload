using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanoramicDownload.Core
{
    public class PlatformLMT : PlatformBase
    {
        public override void WriteDownLoad(DirectionType type = DirectionType.b, int maxIndex = 1, StringBuilder newUrl = null, int maxQuality = 1, StreamWriter SWFile = null)
        {
            SWFile.WriteLine(newUrl + "" + type + ".jpg");
        }
    }
}
