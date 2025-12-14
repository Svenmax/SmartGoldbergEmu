using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace SmartGoldbergEmu.Services
{
    public class IconService
    {
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
                int GetIcon(int i, int flags, out IntPtr picon);
            }

            public const uint SHGFI_SYSICONINDEX = 0x00004000;
            public const uint SHGFI_ICON = 0x000000100;
            public const int SHIL_JUMBO = 0x4;
            public const int SHIL_EXTRALARGE = 0x2;
            public const int ILD_TRANSPARENT = 0x00000001;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool DestroyIcon(IntPtr handle);

        public static Icon GetHighResIcon(string path, int size)
        {
            try
            {
                ShellIconExtractor.SHFILEINFO shinfo = new ShellIconExtractor.SHFILEINFO();
                IntPtr hImg = ShellIconExtractor.SHGetFileInfo(path, 0, ref shinfo, 
                    (uint)Marshal.SizeOf(shinfo), 
                    ShellIconExtractor.SHGFI_SYSICONINDEX | ShellIconExtractor.SHGFI_ICON);

                if (hImg == IntPtr.Zero)
                    return null;

                int iconIndex = shinfo.iIcon;
                Guid guid = typeof(ShellIconExtractor.IImageList).GUID;
                ShellIconExtractor.IImageList iml = null;
                
                int hr = ShellIconExtractor.SHGetImageList(
                    size >= 128 ? ShellIconExtractor.SHIL_JUMBO : ShellIconExtractor.SHIL_EXTRALARGE, 
                    ref guid, 
                    out iml);

                if (hr != 0 || iml == null)
                    return null;

                IntPtr hIcon = IntPtr.Zero;
                int res = iml.GetIcon(iconIndex, ShellIconExtractor.ILD_TRANSPARENT, out hIcon);
                
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
            catch (Exception ex)
            {
                // Log error here if needed
                return null;
            }
        }

        public static Icon GetDefaultIcon()
        {
            return SystemIcons.Application;
        }
    }
} 