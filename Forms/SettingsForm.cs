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
using System.Text;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

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


        private EmuConfig _config = new EmuConfig();

        public EmuConfig Config
        {
            set
            {
                general_webApiKey_box.Text = value.webapi_key;
                general_username_box.Text = value.username;
                general_port_box.Text = value.port.ToString();
                general_steamId_box.Text = value.steamid;

                bool found_prefered_lang = false;

                foreach (string lang in languages)
                {
                    general_language_box.Items.Add(lang);
                    if (!found_prefered_lang)
                    {
                        if (lang.Equals(_config.language, StringComparison.OrdinalIgnoreCase))
                        {
                            general_language_box.SelectedItem = lang;
                            found_prefered_lang = true;
                        }
                        else if (lang.Equals("english", StringComparison.OrdinalIgnoreCase))
                        {
                            general_language_box.SelectedItem = lang;
                        }
                    }
                }
            }
            get
            {
                return _config;
            }
        }

        public SettingsForm()
        {
            InitializeComponent();
            SettingLoad();
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

        public void SettingLoad()
        {
            string save_folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GSE Saves", "settings");
            avatarFrameLoader();
            if (File.Exists(Path.Combine(save_folder, "configs.user.ini")))
            {
                using (StreamReader streamReader = new StreamReader(Path.Combine(save_folder, "configs.user.ini")))
                {
                    string line;
                    string prosliline = "a";
                    double result = 0;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        prosliline = line;
                        if (prosliline.Contains("account_name="))
                        {
                            //FontsizeText.Text = prosliline;
                            prosliline = prosliline.Replace("account_name=", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            general_username_box.Text = result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("account_steamid="))
                        {
                            //FontsizeText.Text = prosliline;
                            prosliline = prosliline.Replace("account_steamid=", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            general_steamId_box.Text = result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("language="))
                        {
                            //FontsizeText.Text = prosliline;
                            prosliline = prosliline.Replace("language=", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            general_language_box.Text = result.ToString().Replace(",", ".");
                        }
                    }
                    streamReader.Close();
                }
            }
            if (File.Exists(Path.Combine(save_folder, "configs.main.ini")))
            {
                using (StreamReader streamReader = new StreamReader(Path.Combine(save_folder, "configs.main.ini")))
                {
                    string line;
                    string prosliline = "a";
                    double result = 0;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        prosliline = line;
                        if (prosliline.Contains("listen_port="))
                        {
                            //FontsizeText.Text = prosliline;
                            prosliline = prosliline.Replace("listen_port=", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            general_port_box.Text = result.ToString().Replace(",", ".");
                        }
                    }
                    streamReader.Close();
                }
            }

            if (File.Exists(Path.Combine(save_folder, "configs.overlay.ini")))
            {
                using (StreamReader streamReader = new StreamReader(Path.Combine(save_folder, "configs.overlay.ini")))
                {
                    string line;
                    string prosliline = "a";
                    double result = 0;
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        prosliline = line;
                        if (prosliline.Contains("Font_Size="))
                        {
                            //FontsizeText.Text = prosliline;
                            prosliline = prosliline.Replace("Font_Size=", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            appearance_fontSize_box.Text = result.ToString().Replace(",", ".");
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
                            result = result * 255;
                            result = Math.Round(result);
                            appearance_notification_box.Text = result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("Notification_G="))
                        {
                            prosliline = prosliline.Replace("Notification_G=", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            result = result * 255;
                            result = Math.Round(result);
                            appearance_notification_box.Text = appearance_notification_box.Text + ", " + result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("Notification_B="))
                        {
                            prosliline = prosliline.Replace("Notification_B=", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            result = result * 255;
                            result = Math.Round(result);
                            appearance_notification_box.Text = appearance_notification_box.Text + ", " + result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("Notification_A="))
                        {
                            prosliline = prosliline.Replace("Notification_A=", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            appearance_notification_box.Text = appearance_notification_box.Text + ", " + result.ToString().Replace(",", ".");
                        }

                        if (prosliline.Contains("Notification_Rounding="))
                        {
                            prosliline = prosliline.Replace("Notification_Rounding=", "");
                            notification_rounding_box.Text = prosliline;
                        }
                        if (prosliline.Contains("Notification_Margin_x="))
                        {
                            prosliline = prosliline.Replace("Notification_Margin_x=", "");
                            notification_marginX_box.Text = prosliline;
                        }
                        if (prosliline.Contains("Notification_Margin_y="))
                        {
                            prosliline = prosliline.Replace("Notification_Margin_y=", "");
                            notification_marginY_box.Text = prosliline;
                        }
                        if (prosliline.Contains("Notification_Animation="))
                        {
                            prosliline = prosliline.Replace("Notification_Animation=", "");
                            notification_animation_box.Text = prosliline;
                        }
                        if (prosliline.Contains("Notification_Duration_Progress="))
                        {
                            prosliline = prosliline.Replace("Notification_Duration_Progress=", "");
                            notification_progressDuration_box.Text = prosliline;
                        }
                        if (prosliline.Contains("Notification_Duration_Achievement="))
                        {
                            prosliline = prosliline.Replace("Notification_Duration_Achievement=", "");
                            notification_achDuration_box.Text = prosliline;
                        }
                        if (prosliline.Contains("Notification_Duration_Invitation="))
                        {
                            prosliline = prosliline.Replace("Notification_Duration_Invitation=", "");
                            notification_inviteDuration_box.Text = prosliline;
                        }
                        if (prosliline.Contains("Notification_Duration_Chat="))
                        {
                            prosliline = prosliline.Replace("Notification_Duration_Chat=", "");
                            notification_chatDuration_box.Text = prosliline;
                        }

                        if (prosliline.Contains("Background_R="))
                        {
                            prosliline = prosliline.Replace("Background_R=", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            result = result * 255;
                            result = Math.Round(result);
                            appearance_background_box.Text = result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("Background_G="))
                        {
                            prosliline = prosliline.Replace("Background_G=", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            result = result * 255;
                            result = Math.Round(result);
                            appearance_background_box.Text = appearance_background_box.Text + ", " + result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("Background_B="))
                        {
                            prosliline = prosliline.Replace("Background_B=", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            result = result * 255;
                            result = Math.Round(result);
                            appearance_background_box.Text = appearance_background_box.Text + ", " + result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("Background_A="))
                        {
                            prosliline = prosliline.Replace("Background_A=", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            appearance_background_box.Text = appearance_background_box.Text + ", " + result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("Element_R="))
                        {
                            prosliline = prosliline.Replace("Element_R=", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            result = result * 255;
                            result = Math.Round(result);
                            appearance_element_box.Text = result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("Element_G="))
                        {
                            prosliline = prosliline.Replace("Element_G=", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            result = result * 255;
                            result = Math.Round(result);
                            appearance_element_box.Text = appearance_element_box.Text + ", " + result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("Element_B="))
                        {
                            prosliline = prosliline.Replace("Element_B=", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            result = result * 255;
                            result = Math.Round(result);
                            appearance_element_box.Text = appearance_element_box.Text + ", " + result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("Element_A="))
                        {
                            prosliline = prosliline.Replace("Element_A=", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            appearance_element_box.Text = appearance_element_box.Text + ", " + result.ToString().Replace(",", ".");
                        }


                        if (prosliline.Contains("ElementHovered_R="))
                        {
                            prosliline = prosliline.Replace("ElementHovered_R=", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            result = result * 255;
                            result = Math.Round(result);
                            appearance_hover_box.Text = result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("ElementHovered_G="))
                        {
                            prosliline = prosliline.Replace("ElementHovered_G=", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            result = result * 255;
                            result = Math.Round(result);
                            appearance_hover_box.Text = appearance_hover_box.Text + ", " + result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("ElementHovered_B="))
                        {
                            prosliline = prosliline.Replace("ElementHovered_B=", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            result = result * 255;
                            result = Math.Round(result);
                            appearance_hover_box.Text = appearance_hover_box.Text + ", " + result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("ElementHovered_A="))
                        {
                            prosliline = prosliline.Replace("ElementHovered_A=", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            appearance_hover_box.Text = appearance_hover_box.Text + ", " + result.ToString().Replace(",", ".");
                        }


                        if (prosliline.Contains("ElementActive_R="))
                        {
                            prosliline = prosliline.Replace("ElementActive_R=", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            result = result * 255;
                            result = Math.Round(result);
                            appearance_active_box.Text = result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("ElementActive_G="))
                        {
                            prosliline = prosliline.Replace("ElementActive_G=", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            result = result * 255;
                            result = Math.Round(result);
                            appearance_active_box.Text = appearance_active_box.Text + ", " + result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("ElementActive_B="))
                        {
                            prosliline = prosliline.Replace("ElementActive_B=", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            result = result * 255;
                            result = Math.Round(result);
                            appearance_active_box.Text = appearance_active_box.Text + ", " + result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("ElementActive_A="))
                        {
                            prosliline = prosliline.Replace("ElementActive_A=", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            appearance_active_box.Text = appearance_active_box.Text + ", " + result.ToString().Replace(",", ".");
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
                }
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
                        double.TryParse(clanovi[3], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out A);


                        if (R > 255) R = 255;
                        if (G > 255) G = 255;
                        if (B > 255) B = 255;
                        if (A > 100) A = 100;

                        R = Math.Round(R / 255, 2);
                        G = Math.Round(G / 255, 2);
                        B = Math.Round(B / 255, 2);

                        string R1 = R.ToString().Replace(",", ".");
                        string G1 = G.ToString().Replace(",", ".");
                        string B1 = B.ToString().Replace(",", ".");
                        string A1 = A.ToString().Replace(",", ".");

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
                        double.TryParse(clanovi[3], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out A);

                        if (R > 255) R = 255;
                        if (G > 255) G = 255;
                        if (B > 255) B = 255;
                        if (A > 100) A = 100;

                        R = Math.Round(R / 255, 2);
                        G = Math.Round(G / 255, 2);
                        B = Math.Round(B / 255, 2);

                        string R1 = R.ToString().Replace(",", ".");
                        string G1 = G.ToString().Replace(",", ".");
                        string B1 = B.ToString().Replace(",", ".");
                        string A1 = A.ToString().Replace(",", ".");

                        streamWriter.Write("Background_R=" + R1 + "\n" + "Background_G=" + G1 + "\n" + "Background_B=" + B1 + "\n" + "Background_A=" + A1 + "\n");

                    }
                    if (!string.IsNullOrWhiteSpace(appearance_element_box.Text))
                    {
                        string lajna = appearance_element_box.Text.Replace(" ", "");
                        string[] clanovi = lajna.Split(',');

                        double.TryParse(clanovi[0], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out R);
                        double.TryParse(clanovi[1], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out G);
                        double.TryParse(clanovi[2], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out B);
                        double.TryParse(clanovi[3], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out A);

                        if (R > 255) R = 255;
                        if (G > 255) G = 255;
                        if (B > 255) B = 255;
                        if (A > 100) A = 100;

                        R = Math.Round(R / 255, 2);
                        G = Math.Round(G / 255, 2);
                        B = Math.Round(B / 255, 2);

                        string R1 = R.ToString().Replace(",", ".");
                        string G1 = G.ToString().Replace(",", ".");
                        string B1 = B.ToString().Replace(",", ".");
                        string A1 = A.ToString().Replace(",", ".");

                        streamWriter.Write("Element_R=" + R1 + "\n" + "Element_G=" + G1 + "\n" + "Element_B=" + B1 + "\n" + "Element_A=" + A1 + "\n");
                    }
                    if (!string.IsNullOrWhiteSpace(appearance_hover_box.Text))
                    {
                        string lajna = appearance_hover_box.Text.Replace(" ", "");
                        string[] clanovi = lajna.Split(',');

                        double.TryParse(clanovi[0], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out R);
                        double.TryParse(clanovi[1], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out G);
                        double.TryParse(clanovi[2], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out B);
                        double.TryParse(clanovi[3], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out A);

                        if (R > 255) R = 255;
                        if (G > 255) G = 255;
                        if (B > 255) B = 255;
                        if (A > 100) A = 100;

                        R = Math.Round(R / 255, 2);
                        G = Math.Round(G / 255, 2);
                        B = Math.Round(B / 255, 2);

                        string R1 = R.ToString().Replace(",", ".");
                        string G1 = G.ToString().Replace(",", ".");
                        string B1 = B.ToString().Replace(",", ".");
                        string A1 = A.ToString().Replace(",", ".");

                        streamWriter.Write("ElementHovered_R=" + R1 + "\n" + "ElementHovered_G=" + G1 + "\n" + "ElementHovered_B=" + B1 + "\n" + "ElementHovered_A=" + A1 + "\n");
                    }
                    if (!string.IsNullOrWhiteSpace(appearance_active_box.Text))
                    {
                        string lajna = appearance_active_box.Text.Replace(" ", "");
                        string[] clanovi = lajna.Split(',');

                        double.TryParse(clanovi[0], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out R);
                        double.TryParse(clanovi[1], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out G);
                        double.TryParse(clanovi[2], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out B);
                        double.TryParse(clanovi[3], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out A);

                        if (R > 255) R = 255;
                        if (G > 255) G = 255;
                        if (B > 255) B = 255;
                        if (A > 100) A = 100;

                        R = Math.Round(R / 255, 2);
                        G = Math.Round(G / 255, 2);
                        B = Math.Round(B / 255, 2);

                        string R1 = R.ToString().Replace(",", ".");
                        string G1 = G.ToString().Replace(",", ".");
                        string B1 = B.ToString().Replace(",", ".");
                        string A1 = A.ToString().Replace(",", ".");

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
                    if (!string.IsNullOrWhiteSpace(general_username_box.Text))
                    {
                        streamWriter.WriteLine("account_steamid=" + general_steamId_box.Text);
                    }
                    if (!string.IsNullOrWhiteSpace(general_username_box.Text))
                    {
                        streamWriter.WriteLine("language=" + general_language_box.Text);
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
        }

        private void ApiKeyBttn_Click(object sender, EventArgs e)
        {
            // Open the URL in the default web browser
            System.Diagnostics.Process.Start("https://steamcommunity.com/dev/apikey");
        }

        private void Save_button_Click(object sender, EventArgs e)
        {
            Spremanje();
            if (Check_settings())
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void Cancel_button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
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
            Config.steamid = general_steamId_box.Text;
            Config.username = general_username_box.Text;
            Config.webapi_key = general_webApiKey_box.Text;
            Config.language = general_language_box.SelectedItem.ToString();

            if (Config.webapi_key.Length != 0 && Config.webapi_key.Length != 32)
            {
                MessageBox.Show("The webapi key consists of 32 alphanum char in upper case.\n\nCheck settings menu to get yours.", "Webapi Key invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
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

        private void addfriendsoundbutton_Click(object sender, EventArgs e)
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
                    if (!Directory.Exists(Path.Combine(save_folder, "sounds")))
                    {
                        DirectoryInfo di = Directory.CreateDirectory(Path.Combine(save_folder, "sounds"));
                    }
                    File.Copy(dijalog.FileName, Path.Combine(save_folder, "sounds", "overlay_friend_notification.wav"), true);
                    MessageBox.Show("Friend notification sound set.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (IOException ex)
                {
                    MessageBox.Show($"Error setting friend notification sound: {ex.Message}", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddAchSoundButton_Click(object sender, EventArgs e)
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
                    if (!Directory.Exists(Path.Combine(save_folder, "sounds")))
                    {
                        DirectoryInfo di = Directory.CreateDirectory(Path.Combine(save_folder, "sounds"));
                    }
                    File.Copy(dijalog.FileName, Path.Combine(save_folder, "sounds", "overlay_achievement_notification.wav"), true);
                    MessageBox.Show("Achievement sound set.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (IOException ex)
                {
                    MessageBox.Show($"Error setting Achievement sound: {ex.Message}", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DelFriendSundButton_Click(object sender, EventArgs e)
        {
            string save_folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GSE Saves", "settings");
            if (File.Exists(Path.Combine(save_folder, "sounds", "overlay_friend_notification.wav")))
            {
                File.Delete(Path.Combine(save_folder, "sounds", "overlay_friend_notification.wav"));
                MessageBox.Show("Friend notification sound removed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No Friend notification sound set yet.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void DelAchSoundButton_Click(object sender, EventArgs e)
        {
            string save_folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GSE Saves", "settings");
            if (File.Exists(Path.Combine(save_folder, "sounds", "overlay_achievement_notification.wav")))
            {
                File.Delete(Path.Combine(save_folder, "sounds", "overlay_achievement_notification.wav"));
                MessageBox.Show("Achievement sound removed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No achievement sound has been set yet.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AddFontButton_Click(object sender, EventArgs e)
        {
            string save_folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GSE Saves", "settings");
            string fontFolder = Path.Combine(save_folder, "fonts");
            string iniFilePath = Path.Combine(save_folder, "configs.overlay.ini");

            OpenFileDialog dijalog = new OpenFileDialog
            {
                Filter = "TTF|*.ttf|All files|*.*",
                FilterIndex = 2
            };

            if (dijalog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (!Directory.Exists(fontFolder))
                    {
                        Directory.CreateDirectory(fontFolder);
                    }

                    string fontFileName = Path.GetFileName(dijalog.FileName);
                    File.Copy(dijalog.FileName, Path.Combine(fontFolder, fontFileName), true);

                    string[] lines = File.Exists(iniFilePath) ? File.ReadAllLines(iniFilePath) : new string[0];
                    bool categoryFound = false;
                    bool fontOverrideFound = false;

                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (lines[i].Trim() == "[overlay::appearance]")
                        {
                            categoryFound = true;

                            for (int j = i + 1; j < lines.Length; j++)
                            {
                                if (lines[j].StartsWith("Font_Override="))
                                {
                                    lines[j] = "Font_Override=" + fontFileName;
                                    fontOverrideFound = true;
                                    break;
                                }
                                if (lines[j].StartsWith("["))
                                {
                                    break;
                                }
                            }

                            if (!fontOverrideFound)
                            {
                                List<string> lineList = lines.ToList();
                                lineList.Insert(i + 1, "Font_Override=" + fontFileName);
                                lines = lineList.ToArray();
                            }

                            break;
                        }
                    }
                    if (!categoryFound)
                    {
                        List<string> lineList = lines.ToList();
                        lineList.Add("");
                        lineList.Add("[overlay::appearance]");
                        lineList.Add("Font_Override=" + fontFileName);
                        lines = lineList.ToArray();
                    }
                    File.WriteAllLines(iniFilePath, lines);
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void DelFontButton_Click(object sender, EventArgs e)
        {
            string save_folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GSE Saves", "settings");
            string fontFolder = Path.Combine(save_folder, "fonts");
            string iniFilePath = Path.Combine(save_folder, "configs.overlay.ini");

            bool filesNotDeleted = false;

            if (Directory.Exists(fontFolder))
            {
                foreach (string file in Directory.GetFiles(fontFolder))
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch (UnauthorizedAccessException)
                    {
                        filesNotDeleted = true;
                    }
                    catch (IOException)
                    {
                        filesNotDeleted = true;
                    }
                    catch (Exception)
                    {
                        filesNotDeleted = true;
                    }
                }
            }

            try
            {
                string[] lines = File.Exists(iniFilePath) ? File.ReadAllLines(iniFilePath) : new string[0];
                bool categoryFound = false;

                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Trim() == "[overlay::appearance]")
                    {
                        categoryFound = true;

                        for (int j = i + 1; j < lines.Length; j++)
                        {
                            if (lines[j].StartsWith("Font_Override="))
                            {
                                lines[j] = "Font_Override=";
                                break;
                            }
                            if (lines[j].StartsWith("["))
                            {
                                break;
                            }
                        }
                        break;
                    }
                }
                if (categoryFound)
                {
                    File.WriteAllLines(iniFilePath, lines);
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            if (filesNotDeleted)
            {
                MessageBox.Show("Fonts folder could not be cleared because\n some files where in use or access was denied.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Fonts folder successfully cleared.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void PosMsg_Dropdown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void webapi_key_edit_TextChanged(object sender, EventArgs e)
        {

        }

        private void fontSpacingY_settings_sound_edit_TextChanged(object sender, EventArgs e)
        {

        }

        private void sounds_fontSpacingX_box_TextChanged(object sender, EventArgs e)
        {

        }

        private void setting_sound_tab_Click(object sender, EventArgs e)
        {

        }

        private void inviteduration_text_TextChanged(object sender, EventArgs e)
        {

        }

        private void appearance_background_box_TextChanged(object sender, EventArgs e)
        {

        }

        private void setting_randomizePort_bttn_Click(object sender, EventArgs e)
        {
            // Generate a random port number between 1024 and 65535
            ushort randomPort = (ushort)new Random().Next(1024, 65535);
            
            // Update the port text box with the new random port
            general_port_box.Text = randomPort.ToString();
        }

        private void ramoveAvatar_bttn_Click(object sender, EventArgs e)
        {
            // Set the avatar image to the default one from resources
            general_avatar_frame.Image = SmartGoldbergEmu.Properties.Resources.account_avatar;
            
            //MessageBox.Show("Avatar successfully reset to default.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
