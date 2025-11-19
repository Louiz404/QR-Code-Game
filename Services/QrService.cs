using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QRcodeGame.Models;
using QRCoder;
using System.IO;

namespace QRcodeGame.Services
{
    public class QrService
    {
        public static void GerarQRCode(string texto, string caminhoArquivo)
        {
            using var qrGenerator = new QRCodeGenerator();
            using var qrCodeData = qrGenerator.CreateQrCode(texto, QRCodeGenerator.ECCLevel.Q);
            var pngBytes = new PngByteQRCode(qrCodeData).GetGraphic(20);
            File.WriteAllBytes(caminhoArquivo, pngBytes);
        }
    }
}
