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

        public string Message()
        {
            string x = "FileType: " + FileType + Environment.NewLine +
                       "FileTypeExtension: " + FileTypeExtension + Environment.NewLine +
                       "MIMEType: " + MIMEType + Environment.NewLine +
                       "JFIFVersion: " + JFIFVersion + Environment.NewLine +
                       "ResolutionUnit: " + ResolutionUnit + Environment.NewLine +
                       "XResolution: " + XResolution + Environment.NewLine +
                       "YResolution: " + YResolution + Environment.NewLine +
                       "ImageWidth: " + ImageWidth + Environment.NewLine +
                       "ImageHeight: " + ImageHeight + Environment.NewLine +
                       "EncodingProcess: " + EncodingProcess + Environment.NewLine +
                       "BitsPerSample: " + BitsPerSample + Environment.NewLine +
                       "ColorComponents: " + ColorComponents + Environment.NewLine +
                       "YCbCrSubSampling: " + YCbCrSubSampling + Environment.NewLine +
                       "ImageSize: " + ImageSize + Environment.NewLine +
                       "Megapixels: " + Megapixels + Environment.NewLine;
            return x;
        }
    }
}
