using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp01_WebServices
{
    public class Picture
    {
        public string FileType { get; set; }
        public string FileTypeExtension { get; set; }
        public string MIMEType { get; set; }
        public double JFIFVersion { get; set; }
        public string ResolutionUnit { get; set; }
        public int XResolution { get; set; }
        public int YResolution { get; set; }
        public int ImageWidth { get; set; }
        public int ImageHeight { get; set; }
        public string EncodingProcess { get; set; }
        public int BitsPerSample { get; set; }
        public int ColorComponents { get; set; }
        public string YCbCrSubSampling { get; set; }
        public string ImageSize { get; set; }
        public double Megapixels { get; set; }
    }
}
