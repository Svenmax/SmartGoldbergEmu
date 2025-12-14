using System;
using System.Drawing;
using System.Windows.Forms;
using SmartGoldbergEmu.Models;

namespace SmartGoldbergEmu.Services
{
    public class IconManager
    {
        private readonly ImageList _imageListSmall;
        private readonly ImageList _imageListLarge;
        private readonly ImageList _imageListHuge;

        public IconManager(ImageList imageListSmall, ImageList imageListLarge, ImageList imageListHuge)
        {
            _imageListSmall = imageListSmall;
            _imageListLarge = imageListLarge;
            _imageListHuge = imageListHuge;
        }

        public void LoadIcons(GameConfig app)
        {
            try
            {
                RemoveExistingIcons(app.Path);
                Icon icon = GetIconForApp(app);
                AddIconsToImageLists(app.Path, icon);
            }
            catch (Exception)
            {
                AddDefaultIcons(app.Path);
            }
        }

        private void RemoveExistingIcons(string path)
        {
            if (_imageListSmall.Images.ContainsKey(path))
                _imageListSmall.Images.RemoveByKey(path);
            if (_imageListLarge.Images.ContainsKey(path))
                _imageListLarge.Images.RemoveByKey(path);
            if (_imageListHuge.Images.ContainsKey(path))
                _imageListHuge.Images.RemoveByKey(path);
        }

        private Icon GetIconForApp(GameConfig app)
        {
            Icon icon = null;
            bool usedShell = false;

            if (string.IsNullOrEmpty(app.CustomIcon))
            {
                icon = TryGetShellIcon(app.Path, ref usedShell);
                if (!usedShell)
                {
                    icon = Icon.ExtractAssociatedIcon(app.Path);
                }
            }
            else
            {
                icon = TryGetShellIcon(app.CustomIcon, ref usedShell);
                if (!usedShell)
                {
                    icon = TryGetCustomIcon(app.CustomIcon);
                }
            }

            return icon;
        }

        private Icon TryGetShellIcon(string path, ref bool usedShell)
        {
            if (path.EndsWith(".exe", StringComparison.OrdinalIgnoreCase) || 
                path.EndsWith(".lnk", StringComparison.OrdinalIgnoreCase))
            {
                var icon = IconService.GetHighResIcon(path, 128);
                if (icon != null)
                {
                    usedShell = true;
                    return icon;
                }
            }
            return null;
        }

        private Icon TryGetCustomIcon(string customIconPath)
        {
            if (customIconPath.EndsWith(".ico", StringComparison.OrdinalIgnoreCase))
            {
                return new Icon(customIconPath, _imageListHuge.ImageSize);
            }
            else
            {
                using (var bmp = new Bitmap(customIconPath))
                {
                    return Icon.FromHandle(bmp.GetHicon());
                }
            }
        }

        private void AddIconsToImageLists(string path, Icon icon)
        {
            if (icon != null)
            {
                _imageListHuge.Images.Add(path, new Bitmap(icon.ToBitmap(), _imageListHuge.ImageSize));
                _imageListSmall.Images.Add(path, new Bitmap(icon.ToBitmap(), _imageListSmall.ImageSize));
                _imageListLarge.Images.Add(path, new Bitmap(icon.ToBitmap(), _imageListLarge.ImageSize));
            }
        }

        private void AddDefaultIcons(string path)
        {
            try
            {
                var defaultIcon = IconService.GetDefaultIcon();
                _imageListSmall.Images.Add(path, new Bitmap(defaultIcon.ToBitmap(), _imageListSmall.ImageSize));
                _imageListLarge.Images.Add(path, new Bitmap(defaultIcon.ToBitmap(), _imageListLarge.ImageSize));
                _imageListHuge.Images.Add(path, new Bitmap(defaultIcon.ToBitmap(), _imageListHuge.ImageSize));
            }
            catch
            {
                // Silently fail if even this doesn't work
            }
        }
    }
} 