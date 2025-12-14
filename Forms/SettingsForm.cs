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

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using File = System.IO.File;
using SmartGoldbergEmu.Helpers;
// using SmartGoldbergEmu.Models;
// using SmartGoldbergEmu.Core;

namespace SmartGoldbergEmu
{
    public partial class SettingsForm : Form
    {
        static public readonly List<string> languages = new List<string>
        {
            "arabic",
            "brazilian",
            "bulgarian",
            "chinese_simplified",
            "chinese_traditional",
            "croatian",
            "czech",
            "danish",
            "dutch",
            "english",
            "finnish",
            "french",
            "german",
            "greek",
            "hungarian",
            "italian",
            "japanese",
            "koreana",
            "latam",
            "norwegian",
            "polish",
            "portuguese",
            "romanian",
            "russian",
            "spanish",
            "swedish",
            "thai",
            "turkish",
            "ukrainian",
            "vietnamese"
        };

        public EmuConfig Config
        {
            get
            {
                return SteamEmulator.GetConfiguration();
            }
            set
            {
                SteamEmulator.SetEmuConfig(value);
            }
        }

        public SettingsForm()
        {
            InitializeComponent();
            SettingLoad();
            InitializeColorPreviews();
            UpdateSoundLabels(); // Initialize sound labels on form load

            // Wire up reset buttons for appearance colors
            appearance_notification_reset.Click += (s, e) => ResetAppearanceColor(appearance_notification_box, appearance_notification_alpha, ColorHelper.DefaultNotificationColorNormalized, ColorHelper.DefaultNotificationAlpha);
            appearance_background_reset.Click += (s, e) => ResetAppearanceColor(appearance_background_box, appearance_background_alpha, ColorHelper.DefaultBackgroundColorNormalized, ColorHelper.DefaultBackgroundAlpha);
            appearance_element_reset.Click += (s, e) => ResetAppearanceColor(appearance_element_box, appearance_element_alpha, ColorHelper.DefaultElementColorNormalized, ColorHelper.DefaultElementAlpha);
            appearance_hover_reset.Click += (s, e) => ResetAppearanceColor(appearance_hover_box, appearance_hover_alpha, ColorHelper.DefaultHoverColorNormalized, ColorHelper.DefaultHoverAlpha);
            appearance_active_reset.Click += (s, e) => ResetAppearanceColor(appearance_active_box, appearance_active_alpha, ColorHelper.DefaultActiveColorNormalized, ColorHelper.DefaultActiveAlpha);
        }

        private void ResetAppearanceColor(TextBox colorBox, TextBox alphaBox, string defaultColor, string defaultAlpha)
        {
            colorBox.Text = defaultColor;
            alphaBox.Text = defaultAlpha;
        }

        public void avatarFrameLoader()
        {
            Image img = null;
            string save_folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GSE Saves", "settings");
            try
            {
                string avatarPngPath = Path.Combine(save_folder, "account_avatar.png");
                string avatarJpgPath = Path.Combine(save_folder, "account_avatar.jpg");

                if (!File.Exists(avatarPngPath))
                {
                    img = general_avatar_frame.Image = SmartGoldbergEmu.Properties.Resources.account_avatar;
                }
                else
                {
                    using (var bmpTemp = new Bitmap(avatarPngPath))
                    {
                        img = new Bitmap(bmpTemp);
                    }
                }

                if (File.Exists(avatarJpgPath))
                {
                    using (var bmpTemp = new Bitmap(avatarJpgPath))
                    {
                        img = new Bitmap(bmpTemp);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine($"Error loading avatar: {ex.Message}");
            }
            finally
            {
                general_avatar_frame.Image = img;
            }
        }

        private void LoadDefaultAppearanceAndNotificationValues()
        {
            // Load default appearance values
            appearance_fontSize_box.Text = ColorHelper.DefaultFontSize;
            appearance_imageSize_box.Text = ColorHelper.DefaultIconSize;
            appearance_achPos_box.SelectedIndex = 0; // Top Left
            appearance_invPos_box.SelectedIndex = 0; // Top Left
            appearance_chatPos_box.SelectedIndex = 0; // Top Left

            // Load default notification values
            notification_rounding_box.Text = ColorHelper.DefaultNotificationRounding;
            notification_marginX_box.Text = ColorHelper.DefaultNotificationMarginX;
            notification_marginY_box.Text = ColorHelper.DefaultNotificationMarginY;
            notification_animation_box.Text = ColorHelper.DefaultNotificationAnimation;
            notification_progressDuration_box.Text = ColorHelper.DefaultNotificationProgressDuration;
            notification_achDuration_box.Text = ColorHelper.DefaultNotificationAchievementDuration;
            notification_inviteDuration_box.Text = ColorHelper.DefaultNotificationInvitationDuration;
            notification_chatDuration_box.Text = ColorHelper.DefaultNotificationChatDuration;

            // Load default colors
            ResetAppearanceColor(appearance_notification_box, appearance_notification_alpha, ColorHelper.DefaultNotificationColorNormalized, ColorHelper.DefaultNotificationAlpha);
            ResetAppearanceColor(appearance_background_box, appearance_background_alpha, ColorHelper.DefaultBackgroundColorNormalized, ColorHelper.DefaultBackgroundAlpha);
            ResetAppearanceColor(appearance_element_box, appearance_element_alpha, ColorHelper.DefaultElementColorNormalized, ColorHelper.DefaultElementAlpha);
            ResetAppearanceColor(appearance_hover_box, appearance_hover_alpha, ColorHelper.DefaultHoverColorNormalized, ColorHelper.DefaultHoverAlpha);
            ResetAppearanceColor(appearance_active_box, appearance_active_alpha, ColorHelper.DefaultActiveColorNormalized, ColorHelper.DefaultActiveAlpha);
        }

        private void ValidateFontSize()
        {
            if (double.TryParse(appearance_fontSize_box.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double fontSize))
            {
                // Ensure font size is at least 1.0
                if (fontSize < 1.0)
                {
                    appearance_fontSize_box.Text = ColorHelper.DefaultFontSize; // Reset to default if too small
                }
            }
            else
            {
                appearance_fontSize_box.Text = ColorHelper.DefaultFontSize; // Reset to default if invalid
            }
        }

        private void ValidateIconSize()
        {
            if (double.TryParse(appearance_imageSize_box.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double iconSize))
            {
                // Ensure icon size is at least 1.0
                if (iconSize < 1.0)
                {
                    appearance_imageSize_box.Text = ColorHelper.DefaultIconSize; // Reset to default if too small
                }
            }
            else
            {
                appearance_imageSize_box.Text = ColorHelper.DefaultIconSize; // Reset to default if invalid
            }
        }

        private void appearance_fontSize_box_TextChanged(object sender, EventArgs e)
        {
            ValidateFontSize();
        }

        private void appearance_imageSize_box_TextChanged(object sender, EventArgs e)
        {
            ValidateIconSize();
        }

        public void SettingLoad()
        {
            avatarFrameLoader(); // Loads avatar, independent of EmuConfig for now

            // Initialize language selector
            general_language_box.Items.Clear();
            foreach (string lang in languages)
            {
                general_language_box.Items.Add(lang);
            }

            // Load settings from configs.user.ini
            string save_folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GSE Saves", "settings");
            if (File.Exists(Path.Combine(save_folder, "configs.user.ini")))
            {
                using (StreamReader streamReader = new StreamReader(Path.Combine(save_folder, "configs.user.ini")))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (line.StartsWith("account_name="))
                        {
                            general_username_box.Text = line.Replace("account_name=", "");
                        }
                        if (line.StartsWith("account_steamid="))
                        {
                            general_steamId_box.Text = line.Replace("account_steamid=", "");
                        }
                        if (line.StartsWith("language="))
                        {
                            string lang = line.Replace("language=", "");
                            int index = general_language_box.Items.IndexOf(lang);
                            if (index >= 0)
                            {
                                general_language_box.SelectedIndex = index;
                            }
                            else
                            {
                                general_language_box.SelectedIndex = general_language_box.Items.IndexOf("english");
                            }
                        }
                    }
                }
            }
            else
            {
                // Set default language to English if no config exists
                general_language_box.SelectedIndex = general_language_box.Items.IndexOf("english");
            }

            // Load API key from Config
            general_webApiKey_box.Text = Config.webapi_key;
            general_port_box.Text = Config.port.ToString();

            // The rest of the method loads settings for other tabs (e.g., Appearance from configs.overlay.ini)
            if (File.Exists(Path.Combine(save_folder, "configs.overlay.ini")))
            {
                using (StreamReader streamReader = new StreamReader(Path.Combine(save_folder, "configs.overlay.ini")))
                {
                    string line;
                    string prosliline = "a";
                    double result = 0;
                    bool loadedAnySettings = false;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        prosliline = line;
                        if (prosliline.Contains("Font_Size="))
                        {
                            prosliline = prosliline.Replace("Font_Size=", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            appearance_fontSize_box.Text = result.ToString().Replace(",", ".");
                            loadedAnySettings = true;
                        }

                        if (prosliline.Contains("Icon_Size="))
                        {
                            prosliline = prosliline.Replace("Icon_Size=", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            appearance_imageSize_box.Text = result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("Font_Glyph_Extra_Spacing_x="))
                        {
                            prosliline = prosliline.Replace("Font_Glyph_Extra_Spacing_x=", "");
                            sounds_fontSpacingX_box.Text = prosliline;
                        }
                        if (prosliline.Contains("Font_Glyph_Extra_Spacing_y="))
                        {
                            prosliline = prosliline.Replace("Font_Glyph_Extra_Spacing_y=", "");
                            sounds_fontSpacingY_box.Text = prosliline;
                        }
                        if (prosliline.Contains("Notification_R="))
                        {
                            prosliline = prosliline.Replace("Notification_R=", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            appearance_notification_box.Text = result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("Notification_G="))
                        {
                            prosliline = prosliline.Replace("Notification_G=", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            appearance_notification_box.Text = appearance_notification_box.Text + ", " + result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("Notification_B="))
                        {
                            prosliline = prosliline.Replace("Notification_B=", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            appearance_notification_box.Text = appearance_notification_box.Text + ", " + result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("Notification_A="))
                        {
                            prosliline = prosliline.Replace("Notification_A=", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            appearance_notification_alpha.Text = result.ToString().Replace(",", ".");
                        }

                        if (prosliline.Contains("Notification_Rounding="))
                        {
                            prosliline = prosliline.Replace("Notification_Rounding=", "");
                            notification_rounding_box.Text = prosliline;
                        }
                        else
                        {
                            notification_rounding_box.Text = ColorHelper.DefaultNotificationRounding;
                        }
                        if (prosliline.Contains("Notification_Margin_x="))
                        {
                            prosliline = prosliline.Replace("Notification_Margin_x=", "");
                            notification_marginX_box.Text = prosliline;
                        }
                        else
                        {
                            notification_marginX_box.Text = ColorHelper.DefaultNotificationMarginX;
                        }
                        if (prosliline.Contains("Notification_Margin_y="))
                        {
                            prosliline = prosliline.Replace("Notification_Margin_y=", "");
                            notification_marginY_box.Text = prosliline;
                        }
                        else
                        {
                            notification_marginY_box.Text = ColorHelper.DefaultNotificationMarginY;
                        }
                        if (prosliline.Contains("Notification_Animation="))
                        {
                            prosliline = prosliline.Replace("Notification_Animation=", "");
                            notification_animation_box.Text = prosliline;
                        }
                        else
                        {
                            notification_animation_box.Text = ColorHelper.DefaultNotificationAnimation;
                        }
                        if (prosliline.Contains("Notification_Duration_Progress="))
                        {
                            prosliline = prosliline.Replace("Notification_Duration_Progress=", "");
                            notification_progressDuration_box.Text = prosliline;
                        }
                        else
                        {
                            notification_progressDuration_box.Text = ColorHelper.DefaultNotificationProgressDuration;
                        }
                        if (prosliline.Contains("Notification_Duration_Achievement="))
                        {
                            prosliline = prosliline.Replace("Notification_Duration_Achievement=", "");
                            notification_achDuration_box.Text = prosliline;
                        }
                        else
                        {
                            notification_achDuration_box.Text = ColorHelper.DefaultNotificationAchievementDuration;
                        }
                        if (prosliline.Contains("Notification_Duration_Invitation="))
                        {
                            prosliline = prosliline.Replace("Notification_Duration_Invitation=", "");
                            notification_inviteDuration_box.Text = prosliline;
                        }
                        else
                        {
                            notification_inviteDuration_box.Text = ColorHelper.DefaultNotificationInvitationDuration;
                        }
                        if (prosliline.Contains("Notification_Duration_Chat="))
                        {
                            prosliline = prosliline.Replace("Notification_Duration_Chat=", "");
                            notification_chatDuration_box.Text = prosliline;
                        }
                        else
                        {
                            notification_chatDuration_box.Text = ColorHelper.DefaultNotificationChatDuration;
                        }
                        if (prosliline.Contains("Background_R="))
                        {
                            prosliline = prosliline.Replace("Background_R=", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            appearance_background_box.Text = result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("Background_G="))
                        {
                            prosliline = prosliline.Replace("Background_G=", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            appearance_background_box.Text = appearance_background_box.Text + ", " + result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("Background_B="))
                        {
                            prosliline = prosliline.Replace("Background_B=", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            appearance_background_box.Text = appearance_background_box.Text + ", " + result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("Background_A="))
                        {
                            prosliline = prosliline.Replace("Background_A=", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            appearance_background_alpha.Text = result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("Element_R="))
                        {
                            prosliline = prosliline.Replace("Element_R=", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            appearance_element_box.Text = result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("Element_G="))
                        {
                            prosliline = prosliline.Replace("Element_G=", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            appearance_element_box.Text = appearance_element_box.Text + ", " + result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("Element_B="))
                        {
                            prosliline = prosliline.Replace("Element_B=", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            appearance_element_box.Text = appearance_element_box.Text + ", " + result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("Element_A="))
                        {
                            prosliline = prosliline.Replace("Element_A=", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            appearance_element_alpha.Text = result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("ElementHovered_R="))
                        {
                            prosliline = prosliline.Replace("ElementHovered_R=", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            appearance_hover_box.Text = result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("ElementHovered_G="))
                        {
                            prosliline = prosliline.Replace("ElementHovered_G=", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            appearance_hover_box.Text = appearance_hover_box.Text + ", " + result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("ElementHovered_B="))
                        {
                            prosliline = prosliline.Replace("ElementHovered_B=", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            appearance_hover_box.Text = appearance_hover_box.Text + ", " + result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("ElementHovered_A="))
                        {
                            prosliline = prosliline.Replace("ElementHovered_A=", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            appearance_hover_alpha.Text = result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("ElementActive_R="))
                        {
                            prosliline = prosliline.Replace("ElementActive_R=", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            appearance_active_box.Text = result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("ElementActive_G="))
                        {
                            prosliline = prosliline.Replace("ElementActive_G=", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            appearance_active_box.Text = appearance_active_box.Text + ", " + result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("ElementActive_B="))
                        {
                            prosliline = prosliline.Replace("ElementActive_B=", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            appearance_active_box.Text = appearance_active_box.Text + ", " + result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("ElementActive_A="))
                        {
                            prosliline = prosliline.Replace("ElementActive_A=", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            appearance_active_alpha.Text = result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("PosAchievement="))
                        {
                            prosliline = prosliline.Replace("PosAchievement=", "");
                            appearance_achPos_box.Text = prosliline;
                        }
                        if (prosliline.Contains("PosInvitation="))
                        {
                            prosliline = prosliline.Replace("PosInvitation=", "");
                            appearance_invPos_box.Text = prosliline;
                        }
                        if (prosliline.Contains("PosChatMsg="))
                        {
                            prosliline = prosliline.Replace("PosChatMsg=", "");
                            appearance_chatPos_box.Text = prosliline;
                        }
                    }
                    streamReader.Close();

                    // If no settings were loaded, use defaults
                    if (!loadedAnySettings)
                    {
                        LoadDefaultAppearanceAndNotificationValues();
                    }
                }
            }
            else
            {
                // If config file doesn't exist, use defaults
                LoadDefaultAppearanceAndNotificationValues();
            }
        }

        public void Spremanje()
        {
            double R, G, B, A;
            string save_folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GSE Saves", "settings");
            if (!string.IsNullOrWhiteSpace(appearance_imageSize_box.Text) | !string.IsNullOrWhiteSpace(appearance_fontSize_box.Text)
                | !string.IsNullOrWhiteSpace(appearance_achPos_box.Text) | !string.IsNullOrWhiteSpace(appearance_invPos_box.Text) | !string.IsNullOrWhiteSpace(appearance_chatPos_box.Text)
                | !string.IsNullOrWhiteSpace(sounds_fontSpacingX_box.Text) | !string.IsNullOrWhiteSpace(sounds_fontSpacingY_box.Text)
                | !string.IsNullOrWhiteSpace(appearance_notification_box.Text) | !string.IsNullOrWhiteSpace(appearance_background_box.Text)
                | !string.IsNullOrWhiteSpace(appearance_element_box.Text) | !string.IsNullOrWhiteSpace(appearance_hover_box.Text)
                | !string.IsNullOrWhiteSpace(appearance_active_box.Text)
                | !string.IsNullOrWhiteSpace(notification_rounding_box.Text) | !string.IsNullOrWhiteSpace(notification_animation_box.Text) | !string.IsNullOrWhiteSpace(notification_marginX_box.Text) | !string.IsNullOrWhiteSpace(notification_marginY_box.Text)
                | !string.IsNullOrWhiteSpace(notification_achDuration_box.Text) | !string.IsNullOrWhiteSpace(notification_progressDuration_box.Text)
                | !string.IsNullOrWhiteSpace(notification_inviteDuration_box.Text) | !string.IsNullOrWhiteSpace(notification_chatDuration_box.Text)
                | File.Exists(Path.Combine(save_folder, "fonts", "dinamo.ttf")))
            {
                using (StreamWriter streamWriter = new StreamWriter(new FileStream(Path.Combine(save_folder, "configs.overlay.ini"), FileMode.Create), Encoding.ASCII))
                {
                    streamWriter.WriteLine("[overlay::general]");
                    streamWriter.WriteLine("enable_experimental_overlay=0");
                    streamWriter.WriteLine("[overlay::appearance]");
                    if (File.Exists(Path.Combine(save_folder, "fonts", "dinamo.ttf")))
                    {
                        streamWriter.WriteLine("Font_Override=dinamo.ttf");
                    }
                    if (!string.IsNullOrWhiteSpace(appearance_fontSize_box.Text))
                    {
                        streamWriter.Write("Font_Size=" + appearance_fontSize_box.Text + ".0" + "\n");
                    }
                    if (!string.IsNullOrWhiteSpace(appearance_imageSize_box.Text))
                    {
                        streamWriter.Write("Icon_Size=" + appearance_imageSize_box.Text + ".0" + "\n");
                    }
                    if (!string.IsNullOrWhiteSpace(sounds_fontSpacingX_box.Text))
                    {
                        streamWriter.WriteLine("Font_Glyph_Extra_Spacing_x=" + sounds_fontSpacingX_box.Text);
                    }
                    if (!string.IsNullOrWhiteSpace(sounds_fontSpacingY_box.Text))
                    {
                        streamWriter.WriteLine("Font_Glyph_Extra_Spacing_y=" + sounds_fontSpacingY_box.Text);
                    }
                    if (!string.IsNullOrWhiteSpace(appearance_notification_box.Text))
                    {
                        string lajna = appearance_notification_box.Text.Replace(" ", "");
                        string[] clanovi = lajna.Split(',');

                        double.TryParse(clanovi[0], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out R);
                        double.TryParse(clanovi[1], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out G);
                        double.TryParse(clanovi[2], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out B);

                        // Get alpha from separate alpha textbox
                        if (!string.IsNullOrWhiteSpace(appearance_notification_alpha.Text))
                        {
                            double.TryParse(appearance_notification_alpha.Text, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out A);
                        }
                        else
                        {
                            // Use default alpha value when textbox is blank
                            double.TryParse(ColorHelper.DefaultNotificationAlpha, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out A);
                        }
                        // Clamp normalized RGB values to valid ranges (RGB can go up to 1.24, alpha stays 0.0-1.0)
                        if (R > 1.24) R = 1.24;
                        if (G > 1.24) G = 1.24;
                        if (B > 1.24) B = 1.24;
                        if (A > 1.0) A = 1.0;

                        string R1 = R.ToString().Replace(",", ".");
                        string G1 = G.ToString().Replace(",", ".");
                        string B1 = B.ToString().Replace(",", ".");
                        string A1 = FormatAlphaValue(A);

                        streamWriter.Write("Notification_R=" + R1 + "\n" + "Notification_G=" + G1 + "\n" + "Notification_B=" + B1 + "\n" + "Notification_A=" + A1 + "\n");

                    }
                    if (!string.IsNullOrWhiteSpace(notification_rounding_box.Text))
                    {
                        streamWriter.WriteLine("Notification_Rounding=" + notification_rounding_box.Text);
                    }
                    if (!string.IsNullOrWhiteSpace(notification_marginX_box.Text))
                    {
                        streamWriter.WriteLine("Notification_Margin_x=" + notification_marginX_box.Text);
                    }
                    if (!string.IsNullOrWhiteSpace(notification_marginY_box.Text))
                    {
                        streamWriter.WriteLine("Notification_Margin_y=" + notification_marginY_box.Text);
                    }
                    if (!string.IsNullOrWhiteSpace(notification_animation_box.Text))
                    {
                        streamWriter.WriteLine("Notification_Animation=" + notification_animation_box.Text);
                    }
                    if (!string.IsNullOrWhiteSpace(notification_progressDuration_box.Text))
                    {
                        streamWriter.WriteLine("Notification_Duration_Progress=" + notification_progressDuration_box.Text);
                    }
                    if (!string.IsNullOrWhiteSpace(notification_achDuration_box.Text))
                    {
                        streamWriter.WriteLine("Notification_Duration_Achievement=" + notification_achDuration_box.Text);
                    }
                    if (!string.IsNullOrWhiteSpace(notification_inviteDuration_box.Text))
                    {
                        streamWriter.WriteLine("Notification_Duration_Invitation=" + notification_inviteDuration_box.Text);
                    }
                    if (!string.IsNullOrWhiteSpace(notification_chatDuration_box.Text))
                    {
                        streamWriter.WriteLine("Notification_Duration_Chat=" + notification_chatDuration_box.Text);
                    }
                    if (!string.IsNullOrWhiteSpace(appearance_background_box.Text))
                    {
                        string lajna = appearance_background_box.Text.Replace(" ", "");
                        string[] clanovi = lajna.Split(',');

                        double.TryParse(clanovi[0], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out R);
                        double.TryParse(clanovi[1], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out G);
                        double.TryParse(clanovi[2], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out B);

                        // Get alpha from separate alpha textbox
                        if (!string.IsNullOrWhiteSpace(appearance_background_alpha.Text))
                        {
                            double.TryParse(appearance_background_alpha.Text, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out A);
                        }
                        else
                        {
                            // Use default alpha value when textbox is blank
                            double.TryParse(ColorHelper.DefaultBackgroundAlpha, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out A);
                        }
                        // Clamp normalized RGB values to valid ranges (RGB can go up to 1.24, alpha stays 0.0-1.0)
                        if (R > 1.24) R = 1.24;
                        if (G > 1.24) G = 1.24;
                        if (B > 1.24) B = 1.24;
                        if (A > 1.0) A = 1.0;

                        string R1 = R.ToString().Replace(",", ".");
                        string G1 = G.ToString().Replace(",", ".");
                        string B1 = B.ToString().Replace(",", ".");
                        string A1 = FormatAlphaValue(A);

                        streamWriter.Write("Background_R=" + R1 + "\n" + "Background_G=" + G1 + "\n" + "Background_B=" + B1 + "\n" + "Background_A=" + A1 + "\n");

                    }
                    if (!string.IsNullOrWhiteSpace(appearance_element_box.Text))
                    {
                        string lajna = appearance_element_box.Text.Replace(" ", "");
                        string[] clanovi = lajna.Split(',');

                        double.TryParse(clanovi[0], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out R);
                        double.TryParse(clanovi[1], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out G);
                        double.TryParse(clanovi[2], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out B);

                        // Get alpha from separate alpha textbox
                        if (!string.IsNullOrWhiteSpace(appearance_element_alpha.Text))
                        {
                            double.TryParse(appearance_element_alpha.Text, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out A);
                        }
                        else
                        {
                            // Use default alpha value when textbox is blank
                            double.TryParse(ColorHelper.DefaultElementAlpha, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out A);
                        }
                        // Clamp normalized RGB values to valid ranges (RGB can go up to 1.24, alpha stays 0.0-1.0)
                        if (R > 1.24) R = 1.24;
                        if (G > 1.24) G = 1.24;
                        if (B > 1.24) B = 1.24;
                        if (A > 1.0) A = 1.0;

                        string R1 = R.ToString().Replace(",", ".");
                        string G1 = G.ToString().Replace(",", ".");
                        string B1 = B.ToString().Replace(",", ".");
                        string A1 = FormatAlphaValue(A);

                        streamWriter.Write("Element_R=" + R1 + "\n" + "Element_G=" + G1 + "\n" + "Element_B=" + B1 + "\n" + "Element_A=" + A1 + "\n");
                    }
                    if (!string.IsNullOrWhiteSpace(appearance_hover_box.Text))
                    {
                        string lajna = appearance_hover_box.Text.Replace(" ", "");
                        string[] clanovi = lajna.Split(',');

                        double.TryParse(clanovi[0], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out R);
                        double.TryParse(clanovi[1], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out G);
                        double.TryParse(clanovi[2], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out B);

                        // Get alpha from separate alpha textbox
                        if (!string.IsNullOrWhiteSpace(appearance_hover_alpha.Text))
                        {
                            double.TryParse(appearance_hover_alpha.Text, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out A);
                        }
                        else
                        {
                            // Use default alpha value when textbox is blank
                            double.TryParse(ColorHelper.DefaultHoverAlpha, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out A);
                        }

                        // Clamp normalized RGB values to valid ranges (0.0-1.0 for RGB, 0.0-1.0 for A)
                        if (R > 1.24) R = 1.24;
                        if (G > 1.24) G = 1.24;
                        if (B > 1.24) B = 1.24;
                        if (A > 1.0) A = 1.0;

                        string R1 = R.ToString().Replace(",", ".");
                        string G1 = G.ToString().Replace(",", ".");
                        string B1 = B.ToString().Replace(",", ".");
                        string A1 = FormatAlphaValue(A);

                        streamWriter.Write("ElementHovered_R=" + R1 + "\n" + "ElementHovered_G=" + G1 + "\n" + "ElementHovered_B=" + B1 + "\n" + "ElementHovered_A=" + A1 + "\n");
                    }
                    if (!string.IsNullOrWhiteSpace(appearance_active_box.Text))
                    {
                        string lajna = appearance_active_box.Text.Replace(" ", "");
                        string[] clanovi = lajna.Split(',');

                        double.TryParse(clanovi[0], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out R);
                        double.TryParse(clanovi[1], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out G);
                        double.TryParse(clanovi[2], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out B);

                        // Get alpha from separate alpha textbox
                        if (!string.IsNullOrWhiteSpace(appearance_active_alpha.Text))
                        {
                            double.TryParse(appearance_active_alpha.Text, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out A);
                        }
                        else
                        {
                            // Use default alpha value when textbox is blank
                            double.TryParse(ColorHelper.DefaultActiveAlpha, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out A);
                        }

                        // Clamp normalized RGB values to valid ranges (0.0-1.0 for RGB, 0.0-1.0 for A)
                        if (R > 1.24) R = 1.24;
                        if (G > 1.24) G = 1.24;
                        if (B > 1.24) B = 1.24;
                        if (A > 1.0) A = 1.0;

                        string R1 = R.ToString().Replace(",", ".");
                        string G1 = G.ToString().Replace(",", ".");
                        string B1 = B.ToString().Replace(",", ".");
                        string A1 = FormatAlphaValue(A);

                        streamWriter.Write("ElementActive_R=" + R1 + "\n" + "ElementActive_G=" + G1 + "\n" + "ElementActive_B=" + B1 + "\n" + "ElementActive_A=" + A1 + "\n");

                    }
                    if (!string.IsNullOrWhiteSpace(appearance_achPos_box.Text))
                    {
                        streamWriter.WriteLine("PosAchievement=" + appearance_achPos_box.Text);
                    }
                    if (!string.IsNullOrWhiteSpace(appearance_invPos_box.Text))
                    {
                        streamWriter.WriteLine("PosInvitation=" + appearance_invPos_box.Text);
                    }
                    if (!string.IsNullOrWhiteSpace(appearance_chatPos_box.Text))
                    {
                        streamWriter.WriteLine("PosChatMsg=" + appearance_chatPos_box.Text);
                    }
                    streamWriter.Close();
                }
            }
            if (!string.IsNullOrWhiteSpace(general_username_box.Text) | !string.IsNullOrWhiteSpace(general_steamId_box.Text) | !string.IsNullOrWhiteSpace(general_language_box.Text))
            {
                using (StreamWriter streamWriter = new StreamWriter(new FileStream(Path.Combine(save_folder, "configs.user.ini"), FileMode.Create), Encoding.ASCII))
                {
                    streamWriter.WriteLine("[user::general]");
                    if (!string.IsNullOrWhiteSpace(general_username_box.Text))
                    {
                        streamWriter.WriteLine("account_name=" + general_username_box.Text);
                    }
                    if (!string.IsNullOrWhiteSpace(general_steamId_box.Text))
                    {
                        streamWriter.WriteLine("account_steamid=" + general_steamId_box.Text);
                    }
                    if (general_language_box.SelectedItem != null)
                    {
                        streamWriter.WriteLine("language=" + general_language_box.SelectedItem.ToString());
                    }
                    streamWriter.Close();
                }
            }
            if (!string.IsNullOrWhiteSpace(general_port_box.Text))
            {
                using (StreamWriter streamWriter = new StreamWriter(new FileStream(Path.Combine(save_folder, "configs.main.ini"), FileMode.Create), Encoding.ASCII))
                {
                    streamWriter.WriteLine("[main::general]\nenable_account_avatar=1\n[main::connectivity]");
                    if (!string.IsNullOrWhiteSpace(general_port_box.Text))
                    {
                        streamWriter.WriteLine("listen_port=" + general_port_box.Text);
                    }
                    else
                    {
                        streamWriter.WriteLine("listen_port=47584");
                    }
                    streamWriter.Close();
                }
            }

            // Save the API key and other config changes to main configuration
            SteamEmulator.Save();
        }

        private void ApiKeyBttn_Click(object sender, EventArgs e)
        {
            // Open the URL in the default web browser
            System.Diagnostics.Process.Start("https://steamcommunity.com/dev/apikey");
        }

        private void Save_button_Click(object sender, EventArgs e)
        {
            // Validate settings first before saving
            if (Check_settings())
            {
                Spremanje(); // Only save if validation passes
                // Write API key to steam_apikey.txt for compatibility
                if (!string.IsNullOrWhiteSpace(Config.webapi_key) && Config.webapi_key.Length == 32)
                {
                    try
                    {
                        File.WriteAllText("steam_apikey.txt", Config.webapi_key.Trim());
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Failed to write steam_apikey.txt: {ex.Message}");
                    }
                }
                DialogResult = DialogResult.OK;
                this.Close();
            }
            // If validation fails, Check_settings() will show error messages and return false
        }

        private void Cancel_button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Validates a Steam Web API key by making a test request to Steam servers
        /// </summary>
        /// <param name="apiKey">The API key to validate</param>
        /// <returns>True if the key is valid (200 OK), false if invalid (403 Forbidden or API error codes)</returns>
        /// <exception cref="InvalidOperationException">Thrown when user chooses not to keep key due to network error</exception>
        private bool ValidateSteamApiKey(string apiKey)
        {
            // Query Steam Web API for appid 480 (Spacewar)
            string url = $"https://api.steampowered.com/ISteamUserStats/GetSchemaForGame/v2/?key={apiKey}&appid=480";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.Timeout = 5000; // 5 seconds
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                        return false;
                    using (Stream stream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string json = reader.ReadToEnd();
                        if (string.IsNullOrWhiteSpace(json))
                            return false;
                        try
                        {
                            var obj = JObject.Parse(json);
                            // If the response contains a valid 'game' object, the key is valid
                            if (obj["game"] != null || (obj["game"] == null && obj["gameName"] != null))
                                return true;
                        }
                        catch { return false; }
                    }
                }
            }
            catch (WebException ex)
            {
                if (ex.Response is HttpWebResponse errorResponse)
                {
                    if (errorResponse.StatusCode == HttpStatusCode.Forbidden || errorResponse.StatusCode == HttpStatusCode.Unauthorized)
                        return false;
                }
                // Network error, ask user if they want to keep the key
                var result = MessageBox.Show("Network error occurred while validating the API key.\nDo you want to keep the key anyway?", "Network Error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                    throw new InvalidOperationException();
                return true;
            }
            catch
            {
                // Other errors
                return false;
            }
            return false;
        }

        private bool Check_settings()
        {
            try
            {
                Config.port = Convert.ToUInt16(general_port_box.Text);
            }
            catch
            {
                MessageBox.Show("The port must be a number >1024", "Port invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            // Validate API key BEFORE assigning to Config
            string apiKeyToValidate = general_webApiKey_box.Text;
            if (apiKeyToValidate.Length != 0)
            {
                // First check format (32 characters)
                if (apiKeyToValidate.Length != 32)
                {
                    MessageBox.Show("The webapi key consists of 32 alphanum char in upper case.\n\nCheck settings menu to get yours.", "Webapi Key invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                // Then validate against Steam servers
                try
                {
                    var validationResult = ValidateSteamApiKey(apiKeyToValidate);
                    if (!validationResult)
                    {
                        // Show popup warning and clear the invalid key
                        MessageBox.Show("Your Steam Web API key is invalid or has expired.\n\nPlease get a new key from:\nhttps://steamcommunity.com/dev/apikey\n\nThe invalid key has been removed from your settings.",
                            "Steam API Key Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        // Clear the invalid key from UI
                        general_webApiKey_box.Text = "";

                        // Also clear the steam_apikey.txt file if it exists
                        string steamApiKeyFilePath = "steam_apikey.txt";
                        try
                        {
                            if (File.Exists(steamApiKeyFilePath))
                            {
                                File.Delete(steamApiKeyFilePath);
                            }
                        }
                        catch (Exception ex)
                        {
                            // Log the error but don't block the operation
                            System.Diagnostics.Debug.WriteLine($"Failed to delete steam_apikey.txt: {ex.Message}");
                        }

                        return false;
                    }
                }
                catch (InvalidOperationException)
                {
                    // User chose to remove key due to network error
                    // Clear the key from UI but don't show the "invalid key" message
                    general_webApiKey_box.Text = "";

                    // Also clear the steam_apikey.txt file if it exists
                    string steamApiKeyFilePath = "steam_apikey.txt";
                    try
                    {
                        if (File.Exists(steamApiKeyFilePath))
                        {
                            File.Delete(steamApiKeyFilePath);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log the error but don't block the operation
                        System.Diagnostics.Debug.WriteLine($"Failed to delete steam_apikey.txt: {ex.Message}");
                    }

                    return false;
                }
            }

            // Only assign to Config after validation passes
            Config.steamid = general_steamId_box.Text;
            Config.username = general_username_box.Text;
            Config.webapi_key = general_webApiKey_box.Text;
            if (general_language_box.SelectedItem != null)
            Config.language = general_language_box.SelectedItem.ToString();
            else
                Config.language = "english";

            if (Config.port != 0 && Config.port < 1024)
            {
                MessageBox.Show("The port must be a number >1024", "Port invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void AvatarChange_Click(object sender, EventArgs e)
        {
            string save_folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GSE Saves", "settings");
            Directory.CreateDirectory(save_folder);

            OpenFileDialog dijalog = new OpenFileDialog
            {
                Filter = "Image Files (*.png, *.jpg)|*.png;*.jpg",
                FilterIndex = 1
            };

            if (dijalog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string destinationPath = Path.Combine(save_folder, "account_avatar.png");
                    File.Copy(dijalog.FileName, destinationPath, true);
                    avatarFrameLoader();
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Error setting avatar image: " + ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void sounds_changeFriendSound_bttn_Click(object sender, EventArgs e)
        {
            string save_folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GSE Saves", "settings");
            OpenFileDialog dijalog = new OpenFileDialog
            {
                Filter = "WAV|*.wav|All files|*.*",
                FilterIndex = 2
            };
            if (dijalog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string soundsDir = Path.Combine(save_folder, "sounds");
                    if (!Directory.Exists(soundsDir))
                        Directory.CreateDirectory(soundsDir);
                    File.Copy(dijalog.FileName, Path.Combine(soundsDir, "overlay_friend_notification.wav"), true);
                    MessageBox.Show("Friend notification sound set.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateSoundLabels();
                }
                catch (IOException ex)
                {
                    MessageBox.Show($"Error setting friend notification sound: {ex.Message}", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void sounds_changeAlertSound_bttn_Click(object sender, EventArgs e)
        {
            string save_folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GSE Saves", "settings");
            OpenFileDialog dijalog = new OpenFileDialog
            {
                Filter = "WAV|*.wav|All files|*.*",
                FilterIndex = 2
            };
            if (dijalog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string soundsDir = Path.Combine(save_folder, "sounds");
                    if (!Directory.Exists(soundsDir))
                        Directory.CreateDirectory(soundsDir);
                    File.Copy(dijalog.FileName, Path.Combine(soundsDir, "overlay_achievement_notification.wav"), true);
                    MessageBox.Show("Achievement sound set.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateSoundLabels();
                }
                catch (IOException ex)
                {
                    MessageBox.Show($"Error setting Achievement sound: {ex.Message}", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void sounds_deleteFriendSound_bttn_Click(object sender, EventArgs e)
        {
            string save_folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GSE Saves", "settings");
            string soundPath = Path.Combine(save_folder, "sounds", "overlay_friend_notification.wav");
            if (File.Exists(soundPath))
            {
                File.Delete(soundPath);
                MessageBox.Show("Friend notification sound removed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No Friend notification sound set yet.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            UpdateSoundLabels();
        }

        private void sounds_deleteAlertSound_bttn_Click(object sender, EventArgs e)
        {
            string save_folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GSE Saves", "settings");
            string soundPath = Path.Combine(save_folder, "sounds", "overlay_achievement_notification.wav");
            if (File.Exists(soundPath))
            {
                File.Delete(soundPath);
                MessageBox.Show("Achievement sound removed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No achievement sound has been set yet.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            UpdateSoundLabels();
        }

        private void UpdateSoundLabels()
        {
            string save_folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GSE Saves", "settings");
            string friendPath = Path.Combine(save_folder, "sounds", "overlay_friend_notification.wav");
            string achPath = Path.Combine(save_folder, "sounds", "overlay_achievement_notification.wav");
            sounds_friendFilename_label.Text = File.Exists(friendPath) ? Path.GetFileName(friendPath) : "No sound set";
            sounds_achievementFilename_label.Text = File.Exists(achPath) ? Path.GetFileName(achPath) : "No sound set";
            sounds_deleteFriendSound_bttn.Text = "Clear Sound";
            sounds_deleteAlertSound_bttn.Text = "Clear Sound";
        }

        private void sounds_playFriendSound_bttn_Click(object sender, EventArgs e)
            {
                try
                {
                SoundManager.PlayFriendSound();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error playing friend sound: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SoundManager.PlayAchievementSound();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error playing achievement sound: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Color Preview and Picker Integration with Legacy Logic
        private void InitializeColorPreviews()
        {
            // Set up preview panels for all appearance colors
            UpdateColorPreviewLegacy(appearance_notification_colorPreview, appearance_notification_box, appearance_notification_alpha);
            UpdateColorPreviewLegacy(appearance_background_colorPreview, appearance_background_box, appearance_background_alpha);
            UpdateColorPreviewLegacy(appearance_element_colorPreview, appearance_element_box, appearance_element_alpha);
            UpdateColorPreviewLegacy(appearance_hover_colorPreview, appearance_hover_box, appearance_hover_alpha);
            UpdateColorPreviewLegacy(appearance_active_colorPreview, appearance_active_box, appearance_active_alpha);

            // Add click event handlers for color preview panels
            appearance_notification_colorPreview.Click += (s, e) => ShowColorPickerLegacy(appearance_notification_box, appearance_notification_alpha, appearance_notification_colorPreview);
            appearance_background_colorPreview.Click += (s, e) => ShowColorPickerLegacy(appearance_background_box, appearance_background_alpha, appearance_background_colorPreview);
            appearance_element_colorPreview.Click += (s, e) => ShowColorPickerLegacy(appearance_element_box, appearance_element_alpha, appearance_element_colorPreview);
            appearance_hover_colorPreview.Click += (s, e) => ShowColorPickerLegacy(appearance_hover_box, appearance_hover_alpha, appearance_hover_colorPreview);
            appearance_active_colorPreview.Click += (s, e) => ShowColorPickerLegacy(appearance_active_box, appearance_active_alpha, appearance_active_colorPreview);

            // Add text changed event handlers to update color previews when text changes
            appearance_notification_box.TextChanged += (s, e) => UpdateColorPreviewLegacy(appearance_notification_colorPreview, appearance_notification_box, appearance_notification_alpha);
            appearance_notification_alpha.TextChanged += (s, e) => UpdateColorPreviewLegacy(appearance_notification_colorPreview, appearance_notification_box, appearance_notification_alpha);
            appearance_background_box.TextChanged += (s, e) => UpdateColorPreviewLegacy(appearance_background_colorPreview, appearance_background_box, appearance_background_alpha);
            appearance_background_alpha.TextChanged += (s, e) => UpdateColorPreviewLegacy(appearance_background_colorPreview, appearance_background_box, appearance_background_alpha);
            appearance_element_box.TextChanged += (s, e) => UpdateColorPreviewLegacy(appearance_element_colorPreview, appearance_element_box, appearance_element_alpha);
            appearance_element_alpha.TextChanged += (s, e) => UpdateColorPreviewLegacy(appearance_element_colorPreview, appearance_element_box, appearance_element_alpha);
            appearance_hover_box.TextChanged += (s, e) => UpdateColorPreviewLegacy(appearance_hover_colorPreview, appearance_hover_box, appearance_hover_alpha);
            appearance_hover_alpha.TextChanged += (s, e) => UpdateColorPreviewLegacy(appearance_hover_colorPreview, appearance_hover_box, appearance_hover_alpha);
            appearance_active_box.TextChanged += (s, e) => UpdateColorPreviewLegacy(appearance_active_colorPreview, appearance_active_box, appearance_active_alpha);
            appearance_active_alpha.TextChanged += (s, e) => UpdateColorPreviewLegacy(appearance_active_colorPreview, appearance_active_box, appearance_active_alpha);
        }

        private void UpdateColorPreviewLegacy(Panel previewPanel, TextBox colorBox, TextBox alphaBox)
                {
                    try
                    {
                // Parse R,G,B from colorBox, A from alphaBox
                var rgb = colorBox.Text.Split(',').Select(x => x.Trim()).ToArray();
                double r = 0, g = 0, b = 0, a = 1;
                if (rgb.Length >= 3)
                {
                    double.TryParse(rgb[0], NumberStyles.Any, CultureInfo.InvariantCulture, out r);
                    double.TryParse(rgb[1], NumberStyles.Any, CultureInfo.InvariantCulture, out g);
                    double.TryParse(rgb[2], NumberStyles.Any, CultureInfo.InvariantCulture, out b);
                }
                double.TryParse(alphaBox.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out a);
                // Clamp
                r = Math.Max(0, Math.Min(1.24, r));
                g = Math.Max(0, Math.Min(1.24, g));
                b = Math.Max(0, Math.Min(1.24, b));
                a = Math.Max(0, Math.Min(1, a));
                // Convert to 0-255
                int R = (int)Math.Round(r * 255);
                int G = (int)Math.Round(g * 255);
                int B = (int)Math.Round(b * 255);
                int A = (int)Math.Round(a * 255);
                Color color = Color.FromArgb(A, R, G, B);
                // Checkerboard for transparency
                if (A < 255)
                {
                    Bitmap bmp = new Bitmap(previewPanel.Width, previewPanel.Height);
                    using (Graphics gph = Graphics.FromImage(bmp))
                    {
                        for (int y = 0; y < bmp.Height; y += 4)
                        {
                            for (int x = 0; x < bmp.Width; x += 4)
                            {
                                bool light = ((x / 4 + y / 4) % 2 == 0);
                                gph.FillRectangle(new SolidBrush(light ? Color.LightGray : Color.White), x, y, 4, 4);
                            }
                        }
                        using (Brush bsh = new SolidBrush(color))
                        {
                            gph.FillRectangle(bsh, 0, 0, bmp.Width, bmp.Height);
                        }
                    }
                    if (previewPanel.BackgroundImage != null) previewPanel.BackgroundImage.Dispose();
                    previewPanel.BackgroundImage = bmp;
                    previewPanel.BackColor = Color.Transparent;
                }
                else
                {
                    if (previewPanel.BackgroundImage != null) previewPanel.BackgroundImage.Dispose();
                    previewPanel.BackgroundImage = null;
                    previewPanel.BackColor = Color.FromArgb(R, G, B);
                }
            }
            catch
            {
                if (previewPanel.BackgroundImage != null) previewPanel.BackgroundImage.Dispose();
                previewPanel.BackgroundImage = null;
                previewPanel.BackColor = Color.Gray;
            }
        }

        private void ShowColorPickerLegacy(TextBox colorBox, TextBox alphaBox, Panel previewPanel)
        {
            // Parse R,G,B from colorBox
            var rgb = colorBox.Text.Split(',').Select(x => x.Trim()).ToArray();
            double r = 0, g = 0, b = 0;
            if (rgb.Length >= 3)
            {
                double.TryParse(rgb[0], NumberStyles.Any, CultureInfo.InvariantCulture, out r);
                double.TryParse(rgb[1], NumberStyles.Any, CultureInfo.InvariantCulture, out g);
                double.TryParse(rgb[2], NumberStyles.Any, CultureInfo.InvariantCulture, out b);
            }
            int R = (int)Math.Round(r * 255);
            int G = (int)Math.Round(g * 255);
            int B = (int)Math.Round(b * 255);
            using (ColorDialog dlg = new ColorDialog())
            {
                dlg.Color = Color.FromArgb(R, G, B);
                dlg.FullOpen = true;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    double nr = Math.Round(dlg.Color.R / 255.0, 2);
                    double ng = Math.Round(dlg.Color.G / 255.0, 2);
                    double nb = Math.Round(dlg.Color.B / 255.0, 2);
                    colorBox.Text = $"{nr.ToString(CultureInfo.InvariantCulture)},{ng.ToString(CultureInfo.InvariantCulture)},{nb.ToString(CultureInfo.InvariantCulture)}";
                }
            }
        }
        #endregion

        /// <summary>
        /// Formats color values (RGB or alpha) to display clean decimal formatting
        /// Examples: 1.0 → "1.0", 0.5 → "0.5", 0.75 → "0.75", 0 → "0"
        /// </summary>
        private string FormatColorValue(double value, bool isAlpha = false)
        {
            // Apply validation based on value type
            if (isAlpha)
            {
                if (value < 0.0) value = 0.0;
                if (value > 1.0) value = 1.0;
            }
            else
            {
                // RGB values can go up to 1.24 based on existing validation
                if (value < 0.0) value = 0.0;
                if (value > 1.24) value = 1.24;
            }

            // Round to 2 decimal places for cleaner display
            value = Math.Round(value * 100) / 100;

            // Format as "1.0" when exactly 1.0
            if (Math.Abs(value - 1.0) < 0.0001) // Using small epsilon for floating point comparison
            {
                return "1.0";
            }
            else if (Math.Abs(value - Math.Floor(value)) < 0.0001)
            {
                // For whole numbers other than 1.0, display without decimal point
                return ((int)value).ToString();
            }
            else if (Math.Abs((value * 10) - Math.Floor(value * 10)) < 0.0001)
            {
                // For values like 0.5, display with just one decimal place
                return value.ToString("0.#", CultureInfo.InvariantCulture);
            }
            else
            {
                // For other values, display with up to two decimal places, no trailing zeros
                return value.ToString("0.##", CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// Formats alpha value using the unified color formatting method
        /// </summary>
        private string FormatAlphaValue(double value)
        {
            return FormatColorValue(value, isAlpha: true);
        }

        // Add missing event handler stubs and method stubs for designer compatibility
        private void LoadDefaultColorsIfEmpty() { }
        private void ramoveAvatar_bttn_Click(object sender, EventArgs e) { }
        private void webapi_key_edit_TextChanged(object sender, EventArgs e) { }
        private void sounds_fontSpacingX_box_TextChanged(object sender, EventArgs e) { }
        private void setting_sound_tab_Click(object sender, EventArgs e) { }
        private void setting_randomizePort_bttn_Click(object sender, EventArgs e) { }
        private void PosMsg_Dropdown_SelectedIndexChanged(object sender, EventArgs e) { }
        private void inviteduration_text_TextChanged(object sender, EventArgs e) { }
        private void fontSpacingY_settings_sound_edit_TextChanged(object sender, EventArgs e) { }
        private void DelFontButton_Click(object sender, EventArgs e) { }
        private void appearance_background_box_TextChanged(object sender, EventArgs e) { }
        private void AddFontButton_Click(object sender, EventArgs e) { }
    }
}
