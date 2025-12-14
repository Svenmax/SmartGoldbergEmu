using System.Runtime.InteropServices;

// Windows Shell API interop for high-res icons
private static class ShellIconExtractor
{
    [DllImport("Shell32.dll", CharSet = CharSet.Unicode)]
    public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbFileInfo, uint uFlags);

    [DllImport("Shell32.dll", SetLastError = true)]
    public static extern int SHGetImageList(int iImageList, ref Guid riid, out IImageList ppv);

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SHFILEINFO
    {
        public IntPtr hIcon;
        public int iIcon;
        public uint dwAttributes;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szDisplayName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string szTypeName;
    }

    [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("46EB5926-582E-4017-9FDF-E8998DAA0950")]
    public interface IImageList
    {
        [PreserveSig]
        int Add(IntPtr hbmImage, IntPtr hbmMask, ref int pi);
        [PreserveSig]
        int ReplaceIcon(int i, IntPtr hicon, ref int pi);
        [PreserveSig]
        int SetOverlayImage(int iImage, int iOverlay);
        [PreserveSig]
        int Replace(int i, IntPtr hbmImage, IntPtr hbmMask);
        [PreserveSig]
        int AddMasked(IntPtr hbmImage, int crMask, ref int pi);
        [PreserveSig]
        int Draw(ref IMAGELISTDRAWPARAMS pimldp);
        [PreserveSig]
        int Remove(int i);
        [PreserveSig]
        int GetIcon(int i, int flags, out IntPtr picon);
        // Other methods not used
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct IMAGELISTDRAWPARAMS
    {
        public int cbSize;
        public IntPtr himl;
        public int i;
        public IntPtr hdcDst;
        public int x;
        public int y;
        public int cx;
        public int cy;
        public int xBitmap;
        public int yBitmap;
        public int rgbBk;
        public int rgbFg;
        public int fStyle;
        public int dwRop;
        public int fState;
        public int Frame;
        public int crEffect;
    }

    public const uint SHGFI_SYSICONINDEX = 0x00004000;
    public const uint SHGFI_ICON = 0x000000100;
    public const int SHIL_JUMBO = 0x4; // 256x256
    public const int SHIL_EXTRALARGE = 0x2; // 48x48 or 64x64 depending on system
    public const int ILD_TRANSPARENT = 0x00000001;

    public static Icon GetHighResIcon(string path, int size)
    {
        SHFILEINFO shinfo = new SHFILEINFO();
        IntPtr hImg = SHGetFileInfo(path, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), SHGFI_SYSICONINDEX | SHGFI_ICON);
        if (hImg == IntPtr.Zero)
            return null;

        int iconIndex = shinfo.iIcon;
        Guid guid = typeof(IImageList).GUID;
        IImageList iml = null;
        int hr = SHGetImageList(size >= 128 ? SHIL_JUMBO : SHIL_EXTRALARGE, ref guid, out iml);
        if (hr != 0 || iml == null)
            return null;

        IntPtr hIcon = IntPtr.Zero;
        int res = iml.GetIcon(iconIndex, ILD_TRANSPARENT, out hIcon);
        if (res != 0 || hIcon == IntPtr.Zero)
            return null;

        try
        {
            return (Icon)Icon.FromHandle(hIcon).Clone();
        }
        finally
        {
            DestroyIcon(hIcon);
        }
    }
}

public void LoadIcons(GameConfig app)
{
    try
    {
        if (_image_list_small.Images.ContainsKey(app.Path))
            _image_list_small.Images.RemoveByKey(app.Path);
        if (_image_list_large.Images.ContainsKey(app.Path))
            _image_list_large.Images.RemoveByKey(app.Path);
        if (_image_list_huge.Images.ContainsKey(app.Path))
            _image_list_huge.Images.RemoveByKey(app.Path);

        Icon icon = null;
        bool usedShell = false;
        if (string.IsNullOrEmpty(app.CustomIcon))
        {
            // Use shell for exe/lnk
            if (app.Path.EndsWith(".exe", StringComparison.OrdinalIgnoreCase) || app.Path.EndsWith(".lnk", StringComparison.OrdinalIgnoreCase))
            {
                icon = ShellIconExtractor.GetHighResIcon(app.Path, 128);
                if (icon != null)
                {
                    _image_list_huge.Images.Add(app.Path, new Bitmap(icon.ToBitmap(), _image_list_huge.ImageSize));
                    usedShell = true;
                }
            }
            if (!usedShell)
            {
                icon = Icon.ExtractAssociatedIcon(app.Path);
                _image_list_huge.Images.Add(app.Path, new Bitmap(icon.ToBitmap(), _image_list_huge.ImageSize));
            }
        }
        else
        {
            if (app.CustomIcon.EndsWith(".exe", StringComparison.OrdinalIgnoreCase) || app.CustomIcon.EndsWith(".lnk", StringComparison.OrdinalIgnoreCase))
            {
                icon = ShellIconExtractor.GetHighResIcon(app.CustomIcon, 128);
                if (icon != null)
                {
                    _image_list_huge.Images.Add(app.Path, new Bitmap(icon.ToBitmap(), _image_list_huge.ImageSize));
                    usedShell = true;
                }
            }
            if (!usedShell)
            {
                if (app.CustomIcon.EndsWith(".ico", StringComparison.OrdinalIgnoreCase))
                {
                    icon = new Icon(app.CustomIcon, _image_list_huge.ImageSize);
                    _image_list_huge.Images.Add(app.Path, icon.ToBitmap());
                }
                else
                {
                    Bitmap bmp = new Bitmap(app.CustomIcon);
                    _image_list_huge.Images.Add(app.Path, new Bitmap(bmp, _image_list_huge.ImageSize));
                }
            }
        }
        // Small and large icons (always fallback to normal extraction)
        if (icon == null && (string.IsNullOrEmpty(app.CustomIcon)))
            icon = Icon.ExtractAssociatedIcon(app.Path);
        if (icon == null && !string.IsNullOrEmpty(app.CustomIcon) && app.CustomIcon.EndsWith(".exe", StringComparison.OrdinalIgnoreCase))
            icon = Icon.ExtractAssociatedIcon(app.CustomIcon);
        if (icon != null)
        {
            _image_list_small.Images.Add(app.Path, new Bitmap(icon.ToBitmap(), _image_list_small.ImageSize));
            _image_list_large.Images.Add(app.Path, new Bitmap(icon.ToBitmap(), _image_list_large.ImageSize));
        }
        else if (!string.IsNullOrEmpty(app.CustomIcon))
        {
            Bitmap bmp = new Bitmap(app.CustomIcon);
            _image_list_small.Images.Add(app.Path, new Bitmap(bmp, _image_list_small.ImageSize));
            _image_list_large.Images.Add(app.Path, new Bitmap(bmp, _image_list_large.ImageSize));
        }
    }
    catch (Exception)
    {
        try
        {
            _image_list_small.Images.Add(app.Path, new Bitmap(SystemIcons.Application.ToBitmap(), _image_list_small.ImageSize));
            _image_list_large.Images.Add(app.Path, new Bitmap(SystemIcons.Application.ToBitmap(), _image_list_large.ImageSize));
            _image_list_huge.Images.Add(app.Path, new Bitmap(SystemIcons.Application.ToBitmap(), _image_list_huge.ImageSize));
        }
        catch
        {
            // Silently fail if even this doesn't work
        }
    }
}

[DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
private static extern bool DestroyIcon(IntPtr handle); 