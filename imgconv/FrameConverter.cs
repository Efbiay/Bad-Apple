using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace imgconv
{
    public class FrameConverter
    {
        bool IsPixelBlackOrWhite(Bitmap bitmap, int x, int y)
        {
            Color pixelColor = bitmap.GetPixel(x, y);
            int pixelBrightness = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);

            if (pixelBrightness < 128)
            {
                return true; // Siyah piksel
            }
            else
            {
                return false; // Beyaz piksel
            }
        }

        public void FrameToBinFile(string filePath,string outputpath)
        {
            Bitmap bitmap = PNGtoBitmap(filePath);
            int width = bitmap.Width;
            int height = bitmap.Height;
         
            string[] lines = new string[height];

            for (int y = 0; y < height; y++)
            {
                string line = "";
                for (int x = 0; x < width; x++)
                {
                   
                    if (IsPixelBlackOrWhite(bitmap, x, y))
                    {
                        line += "1";
                    }
                    else
                    {
                        line += "0";
                    }

                }
                lines[y] = line;
            }
            File.WriteAllLines(outputpath, lines);

        }

        public Bitmap PNGtoBitmap(string filePath)
        {
            Bitmap bitmap = new Bitmap(filePath);
            return bitmap;
        }



    }
}
