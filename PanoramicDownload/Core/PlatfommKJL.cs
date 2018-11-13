using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanoramicDownload.Core
{
    public class PlatfommKJL:PlatformBase
    {

        public override void WriteDownLoad(DirectionType type, int maxIndex, StringBuilder newUrl, int maxQuality, StreamWriter SWFile)
        {
            SWFile.WriteLine(newUrl + "_" + type);
        }

        public override void MatchingImage(string imagePath, string imageQuality, string tpye, int imageIndex, StreamWriter SWFile, int progindex)
        {
           
        }
    }
}
