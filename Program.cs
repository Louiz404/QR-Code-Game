using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QRcodeGame.Models;
using QRCoder;
using QRcodeGame.Services;
using System.Drawing;
using System.Drawing.Imaging;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var qr = new QRcodeGame.Services.QrService();
qr.GerarQRCode("TOKEN12345", "qrcode.png");

Console.WriteLine("QR gerado!");
