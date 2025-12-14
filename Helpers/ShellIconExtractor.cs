using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace SmartGoldbergEmu.Helpers
{
    public static class ShellIconExtractor
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

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool DestroyIcon(IntPtr handle);

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
} 