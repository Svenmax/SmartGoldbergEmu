using System;
using System.Drawing;
using System.IO;

namespace SmartGoldbergEmu.Helpers
{
    public static class IconHelper
    {
        public static Icon IconFromBitmap(Bitmap bitmap)
        {
            IntPtr hIcon = bitmap.GetHicon();
            Icon tempIcon = Icon.FromHandle(hIcon);
            Icon clonedIcon = (Icon)tempIcon.Clone();
            ShellIconExtractor.DestroyIcon(hIcon);
            return clonedIcon;
        }

        public static void ConvertImageToIcon(string imagePath, string iconPath)
        {
            using (Bitmap bitmap = new Bitmap(imagePath))
            {
                using (Bitmap iconBitmap = new Bitmap(bitmap, new Size(64, 64)))
                {
                    using (Icon icon = IconFromBitmap(iconBitmap))
                    {
                        using (FileStream stream = new FileStream(iconPath, FileMode.Create))
                        {
                            icon.Save(stream);
                        }
                    }
                }
            }
        }

        public static string SanitizeFileName(string fileName)
        {
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                fileName = fileName.Replace(c, ' ');
            }
            return fileName;
        }

        public static Bitmap CenterIconInBitmap(Bitmap icon, Size targetSize)
        {
            Bitmap result = new Bitmap(targetSize.Width, targetSize.Height);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.Clear(Color.Transparent);
                int x = (targetSize.Width - icon.Width) / 2;
                int y = (targetSize.Height - icon.Height) / 2;
                Rectangle destRect = new Rectangle(x, y, Math.Min(icon.Width, targetSize.Width), Math.Min(icon.Height, targetSize.Height));
                Rectangle srcRect = new Rectangle(0, 0, destRect.Width, destRect.Height);
                if (icon.Width > targetSize.Width || icon.Height > targetSize.Height)
                {
                    // Crop the icon if it's too large
                    srcRect.X = (icon.Width - targetSize.Width) / 2;
                    srcRect.Y = (icon.Height - targetSize.Height) / 2;
                    srcRect.Width = destRect.Width;
                    srcRect.Height = destRect.Height;
                }
                g.DrawImage(icon, destRect, srcRect, GraphicsUnit.Pixel);
            }
            return result;
        }
    }
} 