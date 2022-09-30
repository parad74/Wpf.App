﻿using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace Wpf.Client
{
    public static class UtilsImage
    {
        public static Byte[] FromFileToByteArray(string path)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                Byte[] buffer = null;

                if (fileStream != null  && fileStream.Length > 0)
                {
                    using (BinaryReader binaryReader = new BinaryReader(fileStream))
                    {
                        buffer = binaryReader.ReadBytes((Int32)fileStream.Length);
                    }
                }
                return buffer;
            }
        }

		public static byte[] ImageToByte(BitmapImage imageSource)
		{
			byte[] data;
			PngBitmapEncoder encoder = new PngBitmapEncoder();
			encoder.Frames.Add(BitmapFrame.Create(imageSource));
			using (MemoryStream ms = new MemoryStream())
			{
				encoder.Save(ms);
				data = ms.ToArray();
			}
            return data;
		}

		public static BitmapImage ImageFromBuffer(Byte[] bytes)
        {
            MemoryStream stream = new MemoryStream(bytes);
            BitmapImage image = new BitmapImage();
			image.BeginInit();
			image.StreamSource = stream;
			image.EndInit();
			return image;
        }        

    }
}