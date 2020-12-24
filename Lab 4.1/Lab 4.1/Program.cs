using System;
using System.IO;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Lab_4._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regexExtForImage = new Regex(@"((bmp)|(gif)|(tiff)|(jpeg)|(png))$", RegexOptions.IgnoreCase);
            string path = @"C:\Users\Admin\source\repos\Lab_4.1\Lab_4.1\Test";
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                if (regexExtForImage.IsMatch(Path.GetExtension(file)))
                {
                    Image img = Image.FromFile(file);
                    img.RotateFlip(RotateFlipType.Rotate180FlipY);
                    img.Save(regexExtForImage.Replace(file, " ") + "-mirrored.gif");
                }
            }
        }
    }
}
