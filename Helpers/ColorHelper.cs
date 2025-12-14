/* Copyright (C) 2019-2020 Nemirtingas
   This file is part of the SmartGoldbergEmu Launcher

   The SmartGoldbergEmu Launcher is free software; you can redistribute it and/or
   modify it under the terms of the GNU Lesser General Public
   License as published by the Free Software Foundation; either
   version 3 of the License, or (at your option) any later version.

   The SmartGoldbergEmu Launcher is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
   Lesser General Public License for more details.

   You should have received a copy of the GNU Lesser General Public
   License along with the SmartGoldbergEmu Launcher; if not, see
   <http://www.gnu.org/licenses/>. */

using System;
using System.Drawing;
using System.Globalization;

namespace SmartGoldbergEmu.Helpers
{
    /// <summary>
    /// Helper class for color conversion and default color values
    /// </summary>
    public static class ColorHelper
    {          
        // Default colors for overlay appearance (normalized RGB format 0.0-1.0) from configs.overlay.EXAMPLE.ini
        public static readonly string DefaultNotificationColorNormalized = "0.12,0.14,0.21";     // Notification_R/G/B
        public static readonly string DefaultBackgroundColorNormalized = "0.12,0.11,0.11";       // Background_R/G/B
        public static readonly string DefaultElementColorNormalized = "0.30,0.32,0.40";          // Element_R/G/B
        public static readonly string DefaultHoverColorNormalized = "0.28,0.39,0.60";            // ElementHovered_R/G/B (0.278,0.393,0.602 rounded)
        public static readonly string DefaultActiveColorNormalized = "0.30,0.32,0.40";           // ElementActive uses Element values when negative
        
        // Default alpha values from configs.overlay.EXAMPLE.ini
        public static readonly string DefaultNotificationAlpha = "1.0";     // Notification_A=1.0
        public static readonly string DefaultBackgroundAlpha = "0.55";       // Background_A=0.55
        public static readonly string DefaultElementAlpha = "1.0";          // Element_A=1.0
        public static readonly string DefaultHoverAlpha = "1.0";            // ElementHovered_A=1.0
        public static readonly string DefaultActiveAlpha = "1.0";           // ElementActive uses Element alpha when negative

        // Default notification settings from configs.overlay.EXAMPLE.ini
        public static readonly string DefaultNotificationRounding = "10.0";    // Notification_Rounding
        public static readonly string DefaultNotificationMarginX = "5.0";      // Notification_Margin_x
        public static readonly string DefaultNotificationMarginY = "5.0";      // Notification_Margin_y
        public static readonly string DefaultNotificationAnimation = "0.35";   // Notification_Animation
        public static readonly string DefaultNotificationProgressDuration = "6.0";    // Notification_Duration_Progress
        public static readonly string DefaultNotificationAchievementDuration = "7.0"; // Notification_Duration_Achievement
        public static readonly string DefaultNotificationInvitationDuration = "8.0";  // Notification_Duration_Invitation
        public static readonly string DefaultNotificationChatDuration = "4.0";        // Notification_Duration_Chat

        // Default appearance settings from configs.overlay.EXAMPLE.ini
        public static readonly string DefaultFontSize = "16.0";           // Font_Size
        public static readonly string DefaultIconSize = "64.0";           // Icon_Size

        // Default colors as Color objects for fallback (RGBA format 0-255)
        public static readonly Color DefaultNotificationColor = Color.FromArgb(255, 31, 36, 54);   // 0.12,0.14,0.21 converted to RGB
        public static readonly Color DefaultBackgroundColor = Color.FromArgb(255, 31, 28, 28);     // 0.12,0.11,0.11 converted to RGB  
        public static readonly Color DefaultElementColor = Color.FromArgb(255, 77, 82, 102);       // 0.30,0.32,0.40 converted to RGB
        public static readonly Color DefaultHoverColor = Color.FromArgb(255, 71, 100, 153);        // 0.28,0.39,0.60 converted to RGB
        public static readonly Color DefaultActiveColor = Color.FromArgb(255, 77, 82, 102);        // Same as Element when negative

        /// <summary>
        /// Converts normalized RGB string (comma-separated) to Color object for display/picker
        /// </summary>
        /// <param name="normalizedRgbaString">String in format "R,G,B" (0.0-1.0 values)</param>
        /// <param name="defaultColor">Default color to return if parsing fails</param>
        /// <returns>Color object with 0-255 values</returns>
        public static Color ParseNormalizedRgbaString(string normalizedRgbaString, Color defaultColor)
        {
            if (string.IsNullOrWhiteSpace(normalizedRgbaString))
                return defaultColor;

            try
            {
                string[] parts = normalizedRgbaString.Replace(" ", "").Split(',');
                if (parts.Length < 3)
                    return defaultColor;

                double r = Math.Max(0, Math.Min(1, double.Parse(parts[0], CultureInfo.InvariantCulture)));
                double g = Math.Max(0, Math.Min(1, double.Parse(parts[1], CultureInfo.InvariantCulture)));
                double b = Math.Max(0, Math.Min(1, double.Parse(parts[2], CultureInfo.InvariantCulture)));
                
                // Always use full alpha (255) for display purposes
                int rInt = (int)Math.Round(r * 255);
                int gInt = (int)Math.Round(g * 255);
                int bInt = (int)Math.Round(b * 255);

                return Color.FromArgb(255, rInt, gInt, bInt);
            }
            catch
            {
                return defaultColor;
            }
        }

        /// <summary>
        /// Converts Color object to normalized RGBA string (comma-separated)
        /// </summary>
        /// <param name="color">Color object with 0-255 values</param>
        /// <returns>String in format "R,G,B" (0.0-1.0 values) with 2 decimal precision</returns>
        public static string ColorToNormalizedRgbaString(Color color)
        {
            double r = color.R / 255.0;
            double g = color.G / 255.0;
            double b = color.B / 255.0;
            
            return string.Format(CultureInfo.InvariantCulture, "{0:F2},{1:F2},{2:F2}", r, g, b);
        }        

        /// <summary>
        /// Converts Color object to RGB string (comma-separated)
        /// </summary>
        /// <param name="color">Color object</param>
        /// <returns>String in format "R,G,B" (0-255 values)</returns>
        public static string ColorToRgbaString(Color color)
        {
            return $"{color.R},{color.G},{color.B}";
        }

        /// <summary>
        /// Converts decimal color values (0.0-1.0) to RGB values (0-255) and formats as string
        /// </summary>
        /// <param name="r">Red component (0.0-1.0)</param>
        /// <param name="g">Green component (0.0-1.0)</param>
        /// <param name="b">Blue component (0.0-1.0)</param>
        /// <param name="a">Alpha component (0.0-1.0)</param>
        /// <returns>String in format "R,G,B,A" (0-255 values)</returns>
        public static string DecimalToRgbaString(double r, double g, double b, double a)
        {
            int rInt = (int)Math.Round(Math.Max(0, Math.Min(1, r)) * 255);
            int gInt = (int)Math.Round(Math.Max(0, Math.Min(1, g)) * 255);
            int bInt = (int)Math.Round(Math.Max(0, Math.Min(1, b)) * 255);
            int aInt = (int)Math.Round(Math.Max(0, Math.Min(1, a)) * 255);

            return $"{rInt},{gInt},{bInt},{aInt}";
        }

        /// <summary>
        /// Converts RGBA string (comma-separated) to Color object
        /// </summary>
        /// <param name="rgbaString">String in format "R,G,B,A" (0-255 values)</param>
        /// <param name="defaultColor">Default color to return if parsing fails</param>
        /// <returns>Color object</returns>
        public static Color ParseRgbaString(string rgbaString, Color defaultColor)
        {
            if (string.IsNullOrWhiteSpace(rgbaString))
                return defaultColor;

            try
            {
                string[] parts = rgbaString.Replace(" ", "").Split(',');
                if (parts.Length != 4)
                    return defaultColor;

                int r = Math.Max(0, Math.Min(255, int.Parse(parts[0])));
                int g = Math.Max(0, Math.Min(255, int.Parse(parts[1])));
                int b = Math.Max(0, Math.Min(255, int.Parse(parts[2])));
                int a = Math.Max(0, Math.Min(255, int.Parse(parts[3])));

                return Color.FromArgb(a, r, g, b);
            }
            catch
            {
                return defaultColor;
            }
        }

        /// <summary>
        /// Validates and corrects RGBA string format
        /// </summary>
        /// <param name="rgbaString">Input RGBA string</param>
        /// <param name="defaultColor">Default color to use if parsing fails</param>
        /// <returns>Corrected RGBA string</returns>
        public static string ValidateRgbaString(string rgbaString, Color defaultColor)
        {
            Color color = ParseRgbaString(rgbaString, defaultColor);
            return ColorToRgbaString(color);
        }

        /// <summary>
        /// Validates and corrected normalized RGBA string format
        /// </summary>
        /// <param name="normalizedRgbaString">Input normalized RGBA string</param>
        /// <param name="defaultNormalizedString">Default normalized string to use if parsing fails</param>
        /// <returns>Corrected normalized RGBA string</returns>
        public static string ValidateNormalizedRgbaString(string normalizedRgbaString, string defaultNormalizedString)
        {
            if (string.IsNullOrWhiteSpace(normalizedRgbaString))
                return defaultNormalizedString;

            try
            {
                string[] parts = normalizedRgbaString.Replace(" ", "").Split(',');
                if (parts.Length != 4)
                    return defaultNormalizedString;

                double r = Math.Max(0, Math.Min(1, double.Parse(parts[0], CultureInfo.InvariantCulture)));
                double g = Math.Max(0, Math.Min(1, double.Parse(parts[1], CultureInfo.InvariantCulture)));
                double b = Math.Max(0, Math.Min(1, double.Parse(parts[2], CultureInfo.InvariantCulture)));
                double a = Math.Max(0, Math.Min(1, double.Parse(parts[3], CultureInfo.InvariantCulture)));

                return string.Format(CultureInfo.InvariantCulture, "{0:F5},{1:F5},{2:F5},{3:F1}", r, g, b, a);
            }
            catch
            {
                return defaultNormalizedString;
            }
        }

        /// <summary>
        /// Combines RGB values and a separate alpha value into a normalized RGBA string
        /// </summary>
        /// <param name="rgbString">String in format "R,G,B" (0.0-1.0 values)</param>
        /// <param name="alphaString">Alpha value (0.0-1.0)</param>
        /// <returns>Combined RGBA string formatted as "R,G,B,A" with standardized decimal places</returns>
        public static string CombineRgbAndAlpha(string rgbString, string alphaString)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(rgbString) || string.IsNullOrWhiteSpace(alphaString))
                    return string.Empty;
                
                string[] rgbParts = rgbString.Replace(" ", "").Split(',');
                if (rgbParts.Length < 3)
                    return string.Empty;
                
                double r, g, b, alpha;
                double.TryParse(rgbParts[0], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out r);
                double.TryParse(rgbParts[1], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out g);
                double.TryParse(rgbParts[2], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out b);
                double.TryParse(alphaString, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out alpha);
                
                // Clamp values to valid ranges (RGB can go up to 1.24, alpha stays 0.0-1.0)
                r = Math.Max(0, Math.Min(1.24, r));
                g = Math.Max(0, Math.Min(1.24, g));
                b = Math.Max(0, Math.Min(1.24, b));
                alpha = Math.Max(0, Math.Min(1.0, alpha));
                
                // Format with fixed decimal places
                return string.Format(CultureInfo.InvariantCulture, "{0:F2},{1:F2},{2:F2},{3:F2}", r, g, b, alpha);
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Creates a transparency checker pattern image for background
        /// </summary>
        /// <param name="width">Width of the image</param>
        /// <param name="height">Height of the image</param>
        /// <param name="checkerSize">Size of each checker square</param>
        /// <returns>Bitmap with transparency checker pattern</returns>
        public static Bitmap CreateTransparencyBackground(int width, int height, int checkerSize = 8)
        {
            Bitmap bitmap = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                // Light and dark colors for transparency pattern
                Color lightColor = Color.FromArgb(255, 255, 255, 255); // White
                Color darkColor = Color.FromArgb(255, 192, 192, 192);  // Light gray
                
                for (int x = 0; x < width; x += checkerSize)
                {
                    for (int y = 0; y < height; y += checkerSize)
                    {
                        // Determine checker color based on position
                        bool isEven = ((x / checkerSize) + (y / checkerSize)) % 2 == 0;
                        Color checkerColor = isEven ? lightColor : darkColor;
                        
                        using (Brush brush = new SolidBrush(checkerColor))
                        {
                            g.FillRectangle(brush, x, y, checkerSize, checkerSize);
                        }
                    }
                }
            }
            return bitmap;
        }

        /// <summary>
        /// Parses RGB and alpha from separate textboxes and creates a Color with transparency
        /// </summary>
        /// <param name="rgbString">RGB string in format "R,G,B" (0.0-1.0 values)</param>
        /// <param name="alphaString">Alpha string (0.0-1.0 value)</param>
        /// <param name="defaultColor">Default color to return if parsing fails</param>
        /// <param name="defaultAlpha">Default alpha to use if parsing fails</param>
        /// <returns>Color object with RGBA values</returns>
        public static Color ParseRgbAndAlpha(string rgbString, string alphaString, Color defaultColor, string defaultAlpha)
        {
            try
            {
                double r = 0, g = 0, b = 0, alpha = 1.0;
                
                // Parse RGB values
                if (!string.IsNullOrWhiteSpace(rgbString))
                {
                    string[] colorParts = rgbString.Replace(" ", "").Split(',');
                    if (colorParts.Length >= 3)
                    {
                        double.TryParse(colorParts[0], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out r);
                        double.TryParse(colorParts[1], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out g);
                        double.TryParse(colorParts[2], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out b);
                    }
                    else
                    {
                        return defaultColor;
                    }
                }
                else
                {
                    return defaultColor;
                }
                
                // Parse alpha value
                if (!string.IsNullOrWhiteSpace(alphaString))
                {
                    double.TryParse(alphaString, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out alpha);
                }
                else
                {
                    // Use default alpha value when textbox is blank
                    double.TryParse(defaultAlpha, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out alpha);
                }
                
                // Clamp values to valid ranges (RGB can go up to 1.24, alpha stays 0.0-1.0)
                r = Math.Max(0, Math.Min(1.24, r));
                g = Math.Max(0, Math.Min(1.24, g));
                b = Math.Max(0, Math.Min(1.24, b));
                alpha = Math.Max(0, Math.Min(1.0, alpha));
                
                // Convert to integer RGB for Color
                int rInt = (int)Math.Round(r * 255);
                int gInt = (int)Math.Round(g * 255);
                int bInt = (int)Math.Round(b * 255);
                int alphaInt = (int)Math.Round(alpha * 255);
                
                return Color.FromArgb(alphaInt, rInt, gInt, bInt);
            }
            catch
            {
                return defaultColor;
            }
        }
    }
}
