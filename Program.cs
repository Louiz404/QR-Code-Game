using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QRcodeGame.Models;
using QRCoder;
using QRcodeGame.Services;
using System.Drawing;
using System.Drawing.Imaging;

var qr = new QRcodeGame.Services.QrService();
QrService.GerarQRCode("https://youtu.be/dQw4w9WgXcQ?si=mGvnwZs-7WM8Ognj", "qrcode.png");

Console.WriteLine("QR gerado!");
