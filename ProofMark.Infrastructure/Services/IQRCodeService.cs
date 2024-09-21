
using System.Drawing;
using System.Drawing.Imaging;
using ZXing;
using ZXing.Common;


namespace ProofMark.Infrastructure.Services
{
	public interface IQRCodeService
	{
		string GenerateQRCode(string content);
		List<string> GenerateMultipleQRCodes(List<string> contents);
	}
	// Services/QRCodeService.cs
	public class QRCodeService : IQRCodeService
	{
		// Generates a single QR code
		public string GenerateQRCode(string content)
		{
			var qrWriter = new BarcodeWriterPixelData
			{
				Format = BarcodeFormat.QR_CODE,
				Options = new EncodingOptions
				{
					Height = 250, // Customize QR code size as needed
					Width = 250,
					Margin = 1
				}
			};

			var pixelData = qrWriter.Write(content);
			using (var bitmap = new Bitmap(pixelData.Width, pixelData.Height, PixelFormat.Format32bppRgb))
			{
				var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
												 ImageLockMode.WriteOnly, PixelFormat.Format32bppRgb);
				try
				{
					System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0,
																pixelData.Pixels.Length);
				}
				finally
				{
					bitmap.UnlockBits(bitmapData);
				}

				using (var ms = new MemoryStream())
				{
					bitmap.Save(ms, ImageFormat.Png);
					byte[] byteImage = ms.ToArray();
					return Convert.ToBase64String(byteImage);  // Return base64 string for easy use
				}
			}
		}

		// Generates multiple QR codes for a list of content strings
		public List<string> GenerateMultipleQRCodes(List<string> contents)
		{
			List<string> qrCodes = new List<string>();
			foreach (var content in contents)
			{
				string qrCode = GenerateQRCode(content);
				qrCodes.Add(qrCode);
			}
			return qrCodes;
		}
	}

}
