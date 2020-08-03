using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace ControlAccesoChecadorKioskoASP.Application
{
    public class QRCodeManager
    {
        public static byte[] ToBytes(string data)
        {
            QRCodeGenerator generator = new QRCodeGenerator();
            QRCodeData codeData = generator.CreateQrCode(data, QRCodeGenerator.ECCLevel.M);
            QRCode qrCode = new QRCode(codeData);

            using (Bitmap bitmap = qrCode.GetGraphic(5))
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    bitmap.Save(stream, ImageFormat.Png);

                    return stream.ToArray();
                }
            }
        }
    }
}