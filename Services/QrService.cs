using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QRcodeGame.Models;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;

namespace QRcodeGame.Services
{
    public class QrService
    {
        public void GerarQRCode(string texto, string caminhoArquivo)
        {
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(texto, QRCodeGenerator.ECCLevel.Q);
                using (QRCode qrCode = new QRCode(qrCodeData))
                {
                    using (Bitmap qrCodeImage = qrCode.GetGraphic(20))
                    {
                        qrCodeImage.Save(caminhoArquivo, ImageFormat.Png);
                    }
                }
            }
        }
    }
}