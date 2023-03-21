using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace PuzzleGame.WebUI.Models
{
	public  class ImageProp
	{
		public static byte[] ImageToByteArray(SixLabors.ImageSharp.Image image)
		{
			if (image != null)
			{
				MemoryStream memoryStream = new MemoryStream();
				image.Save(memoryStream,new PngEncoder());
				return memoryStream.ToArray();
			}
			else
			{
				return null;
			}
		}
		public static string ByteArrayToImageAsync(byte[] image)
		{
			string base64String = Convert.ToBase64String(image, 0, image.Length);
			return "data:image/png;base64," + base64String;
		}
	}
}
