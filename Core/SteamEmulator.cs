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
   <http://www.gnu.org/licenses/>.
 */
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OSUtility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.Linq;
using SmartGoldbergEmu.Helpers;
using System.Threading;
using System.Collections.Concurrent;

namespace SmartGoldbergEmu
{
    static class SteamEmulator
    {
        public static EmuConfig Config { get; set; } = new EmuConfig();
        public static List<GameConfig> Apps { get; set; } = new List<GameConfig>();
        private static List<Process> emuGamesProcess = new List<Process>();
        private static int? steamPid = 0;
        private static string steamClientDll = "";
        private static string steamClientDll64 = "";

        public static void Initialize()
        {
            LoadSmartGoldbergEmuCfg();

            // Ensure each loaded game has its default files/folders
            foreach (var app in Apps)
            {
                Create_steam_settings_folder(app);
                string gameEmuFolder = app.GetGameEmuFolder();
                string steamSettings = Path.Combine(gameEmuFolder, "steam_settings");
                string remoteFolder = Path.Combine(gameEmuFolder, "remote");
                if (!Directory.Exists(steamSettings))
                    Directory.CreateDirectory(steamSettings);
                if (!Directory.Exists(remoteFolder))
                    Directory.CreateDirectory(remoteFolder);

                // configs.app.ini
                string appIni = Path.Combine(steamSettings, "configs.app.ini");
                if (!File.Exists(appIni))
                {
                    using (var tw = new StreamWriter(appIni, false, Encoding.UTF8))
                    {
                        tw.WriteLine("[app::general]");
                        tw.WriteLine($"is_beta_branch=0");
                        tw.WriteLine($"branch_name=public");
                        tw.WriteLine("[app::dlcs]");
                        tw.WriteLine(app.UnlockAllDLC ? "unlock_all=1" : "unlock_all=0");
                        // No DLC list or custom paths by default
                    }
                }

                // configs.main.ini
                string mainIni = Path.Combine(steamSettings, "configs.main.ini");
                if (!File.Exists(mainIni))
                {
                    using (var tw = new StreamWriter(mainIni, false, Encoding.UTF8))
                    {
                        tw.WriteLine("[main::general]");
                        tw.WriteLine("new_app_ticket=1");
                        tw.WriteLine("gc_token=1");
                        tw.WriteLine($"steam_deck={(app.SteamDeck ? "1" : "0")}");
                        tw.WriteLine($"enable_account_avatar={(app.DisableAvatar ? "0" : "1")}");
                        tw.WriteLine($"disable_leaderboards_create_unknown={(app.DisLobbyCreation ? "00" : "1")}");
                        tw.WriteLine($"allow_unknown_stats={(app.UnknownStats ? "1" : "0")}");
                        tw.WriteLine($"save_only_higher_stat_achievement_progress={(app.SaveHigherStat ? "1" : "0")}");
                        tw.WriteLine($"immediate_gameserver_stats={(app.GameserverStat ? "1" : "0")}");
                        tw.WriteLine($"matchmaking_server_list_actual_type={(app.ActualType ? "1" : "0")}");
                        tw.WriteLine($"matchmaking_server_details_via_source_query={(app.MatchmakeSource ? "1" : "0")}");
                        tw.WriteLine($"disable_lan_only={(app.DisableLANOnly ? "1" : "0")}");
                        tw.WriteLine($"disable_networking={(app.DisableNetworking ? "1" : "0")}");
                        tw.WriteLine($"offline={(app.Offline ? "1" : "0")}");
                        tw.WriteLine($"disable_sharing_stats_with_gameserver={(app.DisableStatShare ? "1" : "0")}");
                        tw.WriteLine($"disable_source_query={(app.DisableSQuery ? "1" : "0")}");
                        tw.WriteLine($"share_leaderboards_over_network={(app.ShareLeaderboard ? "1" : "0")}");
                        tw.WriteLine($"disable_lobby_creation={(app.DisLobbyCreation ? "1" : "0")}");
                        tw.WriteLine($"download_steamhttp_requests={(app.EnableHTTP ? "1" : "0")}");
                        tw.WriteLine($"achievements_bypass={(app.AchBypass ? "1" : "0")}");
                        tw.WriteLine($"force_steamhttp_success={(app.HttpSuccess ? "1" : "0")}");
                        // No listen_port by default
                    }
                }

                // configs.user.ini
                string userIni = Path.Combine(steamSettings, "configs.user.ini");
                if (!File.Exists(userIni))
                {
                    using (var tw = new StreamWriter(userIni, false, Encoding.UTF8))
                    {
                        tw.WriteLine("[user::general]");
                        tw.WriteLine($"account_name={Config.username}");
                        tw.WriteLine($"account_steamid={Config.steamid}");
                        tw.WriteLine($"language={Config.language}");
                        tw.WriteLine("[user::saves]");
                        if (!string.IsNullOrEmpty(app.LocalSave))
                            tw.WriteLine($"saves_folder_name={app.LocalSave}");
                    }
                }

                // configs.overlay.ini
                string overlayIni = Path.Combine(steamSettings, "configs.overlay.ini");
                if (!File.Exists(overlayIni))
                {
                    using (var tw = new StreamWriter(overlayIni, false, Encoding.UTF8))
                    {
                        tw.WriteLine("[overlay::general]");
                        tw.WriteLine(app.DisableOverlay ? "enable_experimental_overlay=0" : "enable_experimental_overlay=1");
                        tw.WriteLine(app.DisableFriendNotif ? "disable_friend_notification=1" : "disable_friend_notification=0");
                        tw.WriteLine(app.DisableAchNotif ? "disable_achievement_progress=1" : "disable_achievement_progress=0");
                        tw.WriteLine("disable_warning_any=0");
                        tw.WriteLine("disable_warning_bad_appid=0");
                        tw.WriteLine("disable_warning_local_save=0");
                    }
                }

                // Ensure dummy achievement and files if missing
                EnsureDummyAchievementAndFiles(app);
            }

            // Checks if configs.user.ini exits, else it creates it.
            string save_folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GSE Saves", "settings");
            if (!File.Exists(Path.Combine(save_folder, "configs.user.ini")))
            {
                string file_path = Path.Combine(save_folder, "configs.user.ini");

                if (!File.Exists(file_path))
                {
                    // Failsafe
                    Directory.CreateDirectory(Path.GetDirectoryName(file_path));
                    File.WriteAllText(file_path, string.Empty, Encoding.UTF8);
                }
            }
            // Checks if configs.overlay.ini exits, else it creates it.
            if (!File.Exists(Path.Combine(save_folder, "configs.overlay.ini")))
            {
                string file_path = Path.Combine(save_folder, "configs.overlay.ini");

                if (!File.Exists(file_path))
                {
                    Directory.CreateDirectory(save_folder);
                    using (StreamWriter streamWriter = new StreamWriter(new FileStream(file_path, FileMode.Create), Encoding.UTF8))
                    {
                        streamWriter.WriteLine("[overlay::general]");
                        streamWriter.WriteLine("enable_experimental_overlay = 1");
                    }
                }
            }

            // Loads configs.user.ini
            if (File.Exists(Path.Combine(save_folder, "configs.user.ini")))
            {
                var lines = File.ReadAllLines(Path.Combine(save_folder, "configs.user.ini"));
                foreach (var line in lines)
                {
                    if (line.StartsWith("account_name=")) Config.username = line.Substring("account_name=".Length);
                    else if (line.StartsWith("account_steamid=")) Config.steamid = line.Substring("account_steamid=".Length);
                    else if (line.StartsWith("language=")) Config.language = line.Substring("language=".Length);
                }
            }

            // Loads configs.user.ini
            if (File.Exists(Path.Combine(save_folder, "configs.main.ini")))
            {
                using (StreamReader streamReader = new StreamReader(new FileStream(Path.Combine(save_folder, "configs.main.ini"), FileMode.Open), Encoding.UTF8))
                {
                    while (!streamReader.EndOfStream)
                    {
                        var line = streamReader.ReadLine();
                        if (line.StartsWith("listen_port="))
                        {
                            var popravni = line.Replace("listen_port=", "");
                            Config.port = ushort.Parse(popravni);
                        }
                    }
                }
            }
        }

        private static RegistryKey CreateOrOpenKey(string keyPath)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(keyPath, true);

            if (key == null)
            {
                string[] split = keyPath.Split('\\');
                key = CreateOrOpenKey(string.Join("\\", split.Take(split.Length - 1)))
                            .CreateSubKey(split.Last());
            }

            return key;
        }


        public static bool SetupEmu(GameConfig app)
        {
            string game_emu_folder = app.GetGameEmuFolder();
            string save_folder;

            // Check for valid save path
            if (!string.IsNullOrEmpty(app.LocalSave))
            {
                save_folder = Path.Combine(game_emu_folder, app.LocalSave, "settings");
            }
            else
            {
                save_folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Goldberg SteamEmu Saves", "settings");
                // Alternative save path (uncomment if needed)
                // save_folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GSE Saves", "settings");
            }

            try
            {
                // Ensure directory exists
                if (!Directory.Exists(save_folder))
                {
                    Directory.CreateDirectory(save_folder);
                }

                // Write configuration values
                //WriteToFile(Path.Combine(save_folder, "account_name.txt"), Config.username);
                WriteToFile(Path.Combine(save_folder, "language.txt"), Config.language);

                if (Config.port != 0)
                {
                    WriteToFile(Path.Combine(save_folder, "listen_port.txt"), Config.port.ToString());
                }

                if (!string.IsNullOrEmpty(Config.steamid))
                {
                    WriteToFile(Path.Combine(save_folder, "user_steam_id.txt"), Config.steamid);
                }
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                Console.WriteLine($"Error setting up the emulator: {ex.Message}");
                return false;
            }

            return true;
        }

        // Helper method for writing to files
        private static void WriteToFile(string filePath, string content)
        {
            if (!string.IsNullOrEmpty(content))
            {
                using (StreamWriter streamWriter = new StreamWriter(new FileStream(filePath, FileMode.Create), Encoding.ASCII))
                {
                    streamWriter.Write(content);
                }
            }
        }


        public static void LoadSmartGoldbergEmuCfg()
        {
            try
            {
                SavedConf save = new SavedConf();
                var xmlserializer = new XmlSerializer(save.GetType());

                using (FileStream file = File.Open("SmartGoldbergEmu.cfg", FileMode.Open))
                {
                    save = (SavedConf)xmlserializer.Deserialize(file);

                    Apps = save.apps;
                    Config.webapi_key = save.webapi_key;
                }
            }
            catch (Exception)
            {
            }
        }

        public static void Save()
        {
            try
            {
                SavedConf save = new SavedConf();
                var xmlserializer = new XmlSerializer(save.GetType());
                var stringWriter = new StringWriter();

                XmlWriterSettings settings = new XmlWriterSettings
                {
                    Indent = true,
                    IndentChars = ("  "),
                    OmitXmlDeclaration = true
                };

                save.apps = Apps;
                save.webapi_key = Config.webapi_key;

                using (var writer = XmlWriter.Create(stringWriter, settings))
                {
                    xmlserializer.Serialize(writer, save);
                    using (FileStream file = File.Open("SmartGoldbergEmu.cfg", FileMode.Create))
                    {
                        byte[] datas = new UTF8Encoding(true).GetBytes(stringWriter.ToString());
                        file.Write(datas, 0, datas.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred", ex);
            }
        }

        public static void AddGame(GameConfig app)
        {
            Apps.Add(app);
            Save();
            // If no API key, ensure dummy achievement and files
            if (string.IsNullOrWhiteSpace(Config.webapi_key))
                EnsureDummyAchievementAndFiles(app);
        }

        public static void SetGame(int index, GameConfig app)
        {
            Apps[index] = app;
            Save();
        }

        public static void RemoveGame(GameConfig app, bool isLastWithAppId)
        {
            Apps.Remove(app);
            Save();
            if (isLastWithAppId)
            {
                // Perform AppID cleanup: delete game emulator folder and related files
                try
                {
                    string gameEmuFolder = app.GetGameEmuFolder();
                    if (Directory.Exists(gameEmuFolder))
                    {
                        Directory.Delete(gameEmuFolder, true);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to clean up AppID files: {ex.Message}", "Cleanup Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // Creates necessary directories and symbolic links for Steam settings in the game emulator folder.
        private static void Create_steam_settings_folder(GameConfig app)
        {
            string game_emu_folder = app.GetGameEmuFolder();

            if (!Directory.Exists(Path.Combine(game_emu_folder, "steam_settings") + Path.DirectorySeparatorChar))
                Directory.CreateDirectory(Path.Combine(game_emu_folder, "steam_settings") + Path.DirectorySeparatorChar);

            if (OSDetector.IsLinux())
            {
                if (!Directory.Exists(Path.Combine(game_emu_folder, ".steam") + Path.DirectorySeparatorChar))
                {
                    using (var p = Process.Start(new ProcessStartInfo
                    {
                        CreateNoWindow = false,
                        UseShellExecute = false,
                        FileName = "ln",
                        WindowStyle = ProcessWindowStyle.Normal,
                        Arguments = "-s . " + Path.Combine(game_emu_folder, ".steam")
                    }))
                    {
                        p.WaitForExit();
                    }
                }

                if (!Directory.Exists(Path.Combine(game_emu_folder, ".steam", (app.UseX64 ? "sdk64" : "sdk32"))))
                {
                    using (var p = Process.Start(new ProcessStartInfo
                    {
                        CreateNoWindow = false,
                        UseShellExecute = false,
                        FileName = "ln",
                        WindowStyle = ProcessWindowStyle.Normal,
                        Arguments = "-s . " + Path.Combine(game_emu_folder, ".steam", (app.UseX64 ? "sdk64" : "sdk32"))
                    }))
                    {
                        p.WaitForExit();
                    }
                }
            }
        }

        // Opens the game emulator folder using the appropriate file explorer for the operating system (Windows or Linux).
        // If opening the folder fails, it shows the folder path in a message box.

        public static void ShowGameEmuFolder(GameConfig app)
        {
            string emu_folder = app.GetGameEmuFolder();

            // Ensure that the steam settings folder is created if needed
            SteamEmulator.Create_steam_settings_folder(app);

            try
            {
                // Open the emulator folder with the appropriate file explorer based on the OS
                if (OSDetector.IsWindows())
                {
                    Process.Start("explorer.exe", emu_folder);
                }
                else if (OSDetector.IsLinux())
                {
                    Process.Start("nautilus", emu_folder);
                }
                else
                {
                    throw new InvalidOperationException("Unsupported OS.");
                }
            }
            catch (Exception ex)
            {
                // If an error occurs (e.g., explorer/nautilus fails), show the folder path in a message box
                MessageBox.Show($"Failed to open the folder: {ex.Message}\nPath: {emu_folder}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sets up the Steam Emulator by modifying registry keys on Windows or setting environment variables on Linux. Returns true if successful.
        private static bool SetupSteamEmu(GameConfig app)
        {
            try
            {
                if (OSDetector.IsWindows())
                {
                    RegistryKey key = CreateOrOpenKey(@"Software\Valve\Steam\ActiveProcess");

                    if (key == null)
                    {
                        MessageBox.Show(@"Cannot setup registry keys in HKEY_CURRENT_USER\Software\Valve\Steam\ActiveProcess", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    if (steamPid == 0)
                    {
                        steamPid = (int?)key.GetValue("pid") ?? 0;
                        steamClientDll = key.GetValue("SteamClientDll")?.ToString() ?? string.Empty;
                        steamClientDll64 = key.GetValue("SteamClientDll64")?.ToString() ?? string.Empty;
                    }

                    key.SetValue("pid", Process.GetCurrentProcess().Id, RegistryValueKind.DWord);
                    key.SetValue("SteamClientDll" + (app.UseX64 ? "64" : ""), Path.Combine(app.GetGameEmuFolder(), OSFuncs.GetSteamAPIName(app.UseX64)), RegistryValueKind.String);

                    key.Close();
                }
                else if (OSDetector.IsLinux())
                {
                    Environment.SetEnvironmentVariable("HOME", app.GetGameEmuFolder());

                    string pidFilePath = Path.Combine(app.GetGameEmuFolder(), "steam.pid");
                    File.WriteAllText(pidFilePath, Process.GetCurrentProcess().Id.ToString(), Encoding.ASCII);

                    // On Linux, setting the HOME env variable ensures Steam uses our custom steamclient.so library
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private static bool SetupGameEmu(GameConfig app)
        {
            string os_folder = OSFuncs.GetEmuApiFolder(app.UseX64);

            if (string.IsNullOrEmpty(os_folder))
            {
                MessageBox.Show("OS folder path is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string emu_api_name = OSFuncs.GetSteamAPIName(app.UseX64);
            string emu_api_path = Path.Combine(os_folder, emu_api_name);

            if (!File.Exists(emu_api_path))
            {
                MessageBox.Show($"Cannot find Goldberg's DLL: {emu_api_name}.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                string game_emu_folder = app.GetGameEmuFolder();
                Create_steam_settings_folder(app);

                string localSaveFilePath = Path.Combine(game_emu_folder, "local_save.txt");
                if (string.IsNullOrEmpty(app.LocalSave))
                {
                    if (File.Exists(localSaveFilePath))
                    {
                        File.Delete(localSaveFilePath);
                    }
                }
                else
                {
                    File.WriteAllText(localSaveFilePath, app.LocalSave, Encoding.ASCII);
                }

                if (app.CustomBroadcasts.Count > 0)
                {
                    string customBroadcastsFilePath = Path.Combine(game_emu_folder, "steam_settings", "custom_broadcasts.txt");
                    File.WriteAllLines(customBroadcastsFilePath, app.CustomBroadcasts, Encoding.ASCII);
                }

                File.Copy(emu_api_path, Path.Combine(game_emu_folder, emu_api_name), true);

                string emu_api_companion = OSFuncs.GetSteamAPICompanion(app.UseX64);
                string emu_api_companion_path = Path.Combine(os_folder, emu_api_companion);
                if (File.Exists(emu_api_companion_path))
                {
                    File.Copy(emu_api_companion_path, Path.Combine(game_emu_folder, emu_api_companion), true);
                }

                string[] overlayDlls = { "GameOverlayRenderer64.dll", "GameOverlayRenderer.dll" };
                foreach (string overlayDll in overlayDlls)
                {
                    string overlayPath = Path.Combine(os_folder, overlayDll);
                    if (File.Exists(overlayPath))
                    {
                        File.Copy(overlayPath, Path.Combine(game_emu_folder, overlayDll), true);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during setup: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return SetupSteamEmu(app);
        }

        private static async Task<string> GetSteamApiResponseWithRetryAsync(string url, int maxRetries = 3, int initialDelayMs = 2000)
        {
            int currentRetry = 0;
            int delayMs = initialDelayMs;

            while (currentRetry <= maxRetries)
            {
                using (var client = new HttpClient { Timeout = TimeSpan.FromSeconds(10) })
                {
                    try
                    {
                        HttpResponseMessage response = await client.GetAsync(url);
                        if (!response.IsSuccessStatusCode)
                        {
                            if (response.StatusCode == HttpStatusCode.BadGateway && currentRetry < maxRetries)
                            {
                                currentRetry++;
                                await Task.Delay(delayMs);
                                delayMs *= 2;
                                continue;
                            }
                            else
                            {
                                return $"ERROR:{(int)response.StatusCode}";
                            }
                        }
                        return await response.Content.ReadAsStringAsync();
                    }
                    catch (HttpRequestException)
                    {
                        if (currentRetry < maxRetries)
                        {
                            currentRetry++;
                            await Task.Delay(delayMs);
                            delayMs *= 2;
                            continue;
                        }
                        throw;
                    }
                    catch (TaskCanceledException)
                    {
                        throw;
                    }
                }
            }
            throw new Exception("Max retries reached.");
        }

        private static async Task DownloadAchievementImagesAsync(List<CAchievement> achievements, string imagesFolder)
        {
            Directory.CreateDirectory(imagesFolder);
            using (var imgClient = new HttpClient { Timeout = TimeSpan.FromSeconds(10) })
            {
                foreach (var achievement in achievements)
                {
                    try
                    {
                        string iconPath = Path.Combine(imagesFolder, achievement.name + ".jpg");
                        string iconGrayPath = Path.Combine(imagesFolder, achievement.name + "_gray.jpg");
                        byte[] iconData = await imgClient.GetByteArrayAsync(achievement.icon);
                        byte[] iconGrayData = await imgClient.GetByteArrayAsync(achievement.icongray);

                        await Task.Run(() => File.WriteAllBytes(iconPath, iconData));
                        await Task.Run(() => File.WriteAllBytes(iconGrayPath, iconGrayData));

                        achievement.icon = Path.Combine("achievement_images", achievement.name + ".jpg").Replace("\\", "/");
                        achievement.icongray = Path.Combine("achievement_images", achievement.name + "_gray.jpg").Replace("\\", "/");
                        achievement.icon_gray = achievement.icongray;
                    }
                    catch
                    {
                        achievement.icon = achievement.icon ?? "";
                        achievement.icongray = achievement.icongray ?? "";
                        achievement.icon_gray = achievement.icon_gray ?? "";
                    }
                }
            }
        }

        // ...existing code...
        public static async Task<bool> AchievementGenerator(GameConfig app, FeedbackReporter feedback = null)
        {
            if (string.IsNullOrWhiteSpace(Config.webapi_key))
            {
                feedback?.SetMessage("WebAPI key missing.");
                return false;
            }

            string gameFolder = app.GetGameEmuFolder();
            string achievementsFile = Path.Combine(gameFolder, "steam_settings", "achievements.json");
            string imagesFolder = Path.Combine(gameFolder, "steam_settings", "achievement_images");

            try
            {
                if (File.Exists(achievementsFile)) File.Delete(achievementsFile);
                if (Directory.Exists(imagesFolder)) Directory.Delete(imagesFolder, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to clean up existing files: {ex.Message}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                feedback?.SetMessage($"Failed to clean up: {ex.Message}");
            }

            Create_steam_settings_folder(app);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            string url = $"https://api.steampowered.com/ISteamUserStats/GetSchemaForGame/v2/?l={Config.language}&key={Config.webapi_key}&appid={app.AppId}";
            string result;
            feedback?.SetMessage("Fetching achievement manifest...");
            try
            {
                result = await GetSteamApiResponseWithRetryAsync(url);
            }
            catch (HttpRequestException httpEx)
            {
                MessageBox.Show($"Web request error: {httpEx.Message}\n\nIs your internet connection working? The AppID might also be incorrect.",
                    "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                feedback?.SetMessage($"Web request error: {httpEx.Message}");
                return false;
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show("The request timed out. Steam servers might be busy or your internet connection is slow.",
                    "Timeout Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                feedback?.SetMessage("Request timed out.");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                feedback?.SetMessage($"Unexpected error: {ex.Message}");
                return false;
            }

            if (result.StartsWith("ERROR:"))
            {
                var statusCode = result.Substring("ERROR:".Length);
                string msg = $"Failed to get achievements definition. Error code: {statusCode}";
                if (statusCode == "401" || statusCode == "403")
                    msg += "\n\nYour WebAPI key may be invalid or has expired. Go to setting menu to update your key.";
                else if (statusCode == "404")
                    msg += $"\n\nThe AppID {app.AppId} might be incorrect or the game may not have achievements.";
                else if (statusCode == "502")
                    msg = "Bad Gateway error while trying to access Steam API.\n\nPlease try again later.";
                MessageBox.Show(msg, "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                feedback?.SetMessage(msg);
                return false;
            }

            CSteamGameSchema schema;
            try
            {
                schema = JsonConvert.DeserializeObject<CSteamGameSchema>(result);
            }
            catch (JsonException jsonEx)
            {
                MessageBox.Show($"Failed to parse achievement data: {jsonEx.Message}\n\nThe API response format may have changed.",
                    "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                feedback?.SetMessage($"Failed to parse achievement data: {jsonEx.Message}");
                return false;
            }

            var achievements = schema?.game?.availableGameStats?.achievements;
            if (achievements == null || achievements.Count == 0)
            {
                // Use default image for fake achievement
                if (!Directory.Exists(imagesFolder))
                    Directory.CreateDirectory(imagesFolder);
                string fakeIconName = "Fake_Achievement.png";
                string fakeIconPath = Path.Combine(imagesFolder, fakeIconName);
                if (!File.Exists(fakeIconPath))
                {
                    using (var bmp = SmartGoldbergEmu.Properties.Resources.achievement)
                    {
                        bmp.Save(fakeIconPath, System.Drawing.Imaging.ImageFormat.Png);
                    }
                }
                achievements = new List<CAchievement>
                {
                    new CAchievement
                    {
                        name = "Fake_Achievement",
                        displayName = "This game has no achievements",
                        description = "Still, this fake achievement was generated to prevent a crash when you click the Test achievement button.",
                        icon = $"achievement_images/{fakeIconName}",
                        icongray = $"achievement_images/{fakeIconName}",
                        icon_gray = $"achievement_images/{fakeIconName}"
                    }
                };
                feedback?.SetMessage($"No achievements found for {app.AppName}.");
                File.WriteAllText(achievementsFile, Newtonsoft.Json.JsonConvert.SerializeObject(achievements, Newtonsoft.Json.Formatting.Indented));
                feedback?.SetProgress(100, 100);
                return false;
            }

            feedback?.SetMessage($"Generating {achievements.Count} achievements...");
            int count = achievements.Count;
            int completed = 0;
            int maxConcurrency = 30; // Limit parallel downloads
            var semaphore = new SemaphoreSlim(maxConcurrency);
            if (!Directory.Exists(imagesFolder))
                Directory.CreateDirectory(imagesFolder);
            var tasks = new List<Task>();
            using (var imgClient = new HttpClient { Timeout = TimeSpan.FromSeconds(10) })
            {
                foreach (var achievement in achievements)
                {
                    var task = Task.Run(async () =>
                    {
                        await semaphore.WaitAsync();
                        try
                        {
                            string iconPath = Path.Combine(imagesFolder, achievement.name + ".jpg");
                            string iconGrayPath = Path.Combine(imagesFolder, achievement.name + "_gray.jpg");
                            bool iconOk = false;
                            bool iconGrayOk = false;

                            try
                            {
                                byte[] iconData = await imgClient.GetByteArrayAsync(achievement.icon);
                                await Task.Run(() => File.WriteAllBytes(iconPath, iconData));
                                iconOk = true;
                            }
                            catch
                            {
                                achievement.icon = achievement.icon ?? "";
                            }

                            try
                            {
                                byte[] iconGrayData = await imgClient.GetByteArrayAsync(achievement.icongray);
                                await Task.Run(() => File.WriteAllBytes(iconGrayPath, iconGrayData));
                                iconGrayOk = true;
                            }
                            catch
                            {
                                achievement.icongray = achievement.icongray ?? "";
                                achievement.icon_gray = achievement.icon_gray ?? "";
                            }

                            if (!iconOk)
                            {
                                using (var bmp = SmartGoldbergEmu.Properties.Resources.achievement)
                                {
                                    bmp.Save(iconPath, System.Drawing.Imaging.ImageFormat.Png);
                                }
                            }
                            if (!iconGrayOk)
                            {
                                using (var bmp = SmartGoldbergEmu.Properties.Resources.achievement)
                                {
                                    bmp.Save(iconGrayPath, System.Drawing.Imaging.ImageFormat.Png);
                                }
                            }
                            // Set local relative paths
                            achievement.icon = Path.Combine("achievement_images", achievement.name + ".png").Replace("\\", "/");
                            achievement.icongray = Path.Combine("achievement_images", achievement.name + "_gray.png").Replace("\\", "/");
                            achievement.icon_gray = achievement.icongray;
                        }
                        finally
                        {
                            int done = Interlocked.Increment(ref completed);
                            feedback?.SetProgress(done, count);
                            feedback?.SetMessage($"Generated {done}/{count} achievements");
                            semaphore.Release();
                        }
                    });
                    tasks.Add(task);
                }
                await Task.WhenAll(tasks);
            }
            File.WriteAllText(achievementsFile, Newtonsoft.Json.JsonConvert.SerializeObject(achievements, Newtonsoft.Json.Formatting.Indented));
            feedback?.SetMessage($"Successfully generated {count} achievements.");
            feedback?.SetProgress(100, 100);
            return true;
        }

        // Generates a game items definition file by retrieving item data from the Steam API. 
        // If successful, saves the items data as a JSON file and notifies the user.
        public static bool GenerateGameItems(GameConfig app, FeedbackReporter feedback = null)
        {
            if (Config.webapi_key.Equals(""))
            {
                feedback?.SetMessage("WebAPI key missing.");
                return false;
            }

            string game_emu_folder = app.GetGameEmuFolder();
            string items_file = Path.Combine(game_emu_folder, "steam_settings", "items.json");

            Create_steam_settings_folder(app);

            string buffer;
            string url = "https://api.steampowered.com/IInventoryService/GetItemDefMeta/v1?key=";
            url += Config.webapi_key + "&appid=" + app.AppId.ToString();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        MessageBox.Show("Failed to get items definition", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        feedback?.SetMessage("Failed to get items definition");
                        return false;
                    }

                    using (Stream sresult = response.GetResponseStream())
                    using (StreamReader streamReader = new StreamReader(sresult))
                    {
                        buffer = streamReader.ReadToEnd();
                    }
                }

                CSteamMetaResponse metaResponse = JsonConvert.DeserializeObject<CSteamMetaResponse>(buffer);
                if (string.IsNullOrEmpty(metaResponse?.response?.digest))
                {
                    feedback?.SetMessage("No items for this game");
                    feedback?.SetProgress(100, 100);
                    return false;
                }

                url = "https://api.steampowered.com/IGameInventory/GetItemDefArchive/v0001?appid=";
                url += app.AppId + "&digest=" + metaResponse.response.digest;

                request = (HttpWebRequest)WebRequest.Create(url);
                request.Headers.Add("Accept-encoding", "gzip, deflate, br");
                request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        MessageBox.Show("Failed to get items archive", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        feedback?.SetMessage("Failed to get items archive");
                        return false;
                    }

                    using (Stream sresult = response.GetResponseStream())
                    using (StreamReader streamReader = new StreamReader(sresult))
                    {
                        buffer = streamReader.ReadToEnd();
                    }
                }

                var archive = Newtonsoft.Json.Linq.JArray.Parse(buffer);
                if (archive.Count == 0)
                {
                    feedback?.SetMessage($"No items for {app.AppName}.");
                    feedback?.SetProgress(100, 100);
                    return false;
                }
                int total = archive.Count;
                int i = 0;
                var new_json = new Dictionary<string, object>();
                feedback?.SetMessage($"Generating 0/{total} items");
                foreach (Newtonsoft.Json.Linq.JObject item in archive)
                {
                    string itemid = item["itemdefid"]?.ToString() ?? $"item_{i}";
                    new_json[itemid] = item;
                    i++;
                    feedback?.SetProgress(i, total);
                    feedback?.SetMessage($"Generating {i}/{total} items");
                }
                using (StreamWriter streamWriter = new StreamWriter(new FileStream(items_file, FileMode.Create), Encoding.UTF8))
                {
                    buffer = JsonConvert.SerializeObject(new_json, Newtonsoft.Json.Formatting.Indented);
                    streamWriter.Write(buffer);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating items: {ex.Message}", "Item Generator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                feedback?.SetMessage($"Error generating items: {ex.Message}");
                return false;
            }

            feedback?.SetMessage("All items generated.");
            feedback?.SetProgress(100, 100);
            return true;
        }

        /// <summary>
        /// Sets up the emulator and starts the game by configuring the necessary environment and launching the game process.
        /// </summary>
        public static void StartGame(GameConfig app)
        {
            if (app.AppId == 0)
            {
                DialogResult result = MessageBox.Show(
                    "App Id for this game is set to 0.\n\nSearch for your game´s page in Steam Store and copy the App Id from the url.\n\nExample: \nHalf-Life's store page URL is https://store.steampowered.com/app/70/HalfLife/\nwhere '70' would be Half-Life´s App Id.\n\nOnce you have it you can manually set it on the game´s settings.\n\nAlternatively you can save it in 'steam_appid.txt' besides your game´s executable for autodetection.\n\nWould you like to open the Steam Store?\r\n",
                    "Smart Goldberg Emu Launcher",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Error);

                if (result == DialogResult.OK)
                {
                    Process.Start("https://store.steampowered.com/search/");
                }
                return;
            }

            // Setup the emulator and game configuration
            if (SetupEmu(app) && SetupGameEmu(app))
            {
                try
                {
                    // Prepare the process start information
                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        CreateNoWindow = false,
                        UseShellExecute = false,
                        FileName = app.Path,
                        WindowStyle = ProcessWindowStyle.Normal,
                        Arguments = app.Parameters,
                        WorkingDirectory = app.StartFolder
                    };

                    // Add environment variables for the game
                    foreach (string var in app.EnvVars)
                    {
                        int pos = var.IndexOf('=');
                        if (pos != -1)
                        {
                            string key = var.Substring(0, pos);
                            string val = var.Substring(pos + 1);
                            psi.EnvironmentVariables.Add(key, val);
                        }
                    }

                    // Add Steam App ID to the environment variables
                    psi.EnvironmentVariables.Add("SteamAppId", app.AppId.ToString());

                    // Start the game process
                    Process p = new Process
                    {
                        EnableRaisingEvents = true,
                        StartInfo = psi
                    };

                    // Handle the process exit event
                    p.Exited += OnProcessExited;
                    emuGamesProcess.Add(p);

                    // Start the game process
                    p.Start();
                }
                catch (Exception e)
                {
                    // Show an error message if game launch fails
                    MessageBox.Show("Cannot launch game: " + e.Message, "Game Launch Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static void RemoveDllsOnGameExit()
        {
            string currentDirectory = Environment.CurrentDirectory;
            string gamesDirectory = Path.Combine(currentDirectory, "games").Replace("\\", "/");

            if (!Directory.Exists(gamesDirectory))
            {
                return;
            }

            string[] subdirectories = Directory.GetDirectories(gamesDirectory);
            string[] dllFiles = { "steamclient64.dll", "GameOverlayRenderer.dll", "GameOverlayRenderer64.dll", "steamclient.dll" };

            foreach (string subdirectory in subdirectories)
            {
                string subdirectoryWithSlash = subdirectory.Replace("\\", "/");

                foreach (string dll in dllFiles)
                {
                    string dllPath = Path.Combine(subdirectoryWithSlash, dll);
                    if (File.Exists(dllPath))
                    {
                        try
                        {
                            File.Delete(dllPath);
                        }
                        catch
                        {
                        }
                    }
                }
            }
        }

        // Handles the process exit event and restores Steam if no more emulated game processes are running.
        private static void OnProcessExited(object sender, EventArgs e)
        {
            emuGamesProcess.RemoveAll(p => p.HasExited);

            if (emuGamesProcess.Count == 0)
            {
                RestoreSteam();
                RemoveDllsOnGameExit();
            }
        }

        // Restores Steam by setting the saved process ID and Steam client DLL paths.
        public static void RestoreSteam()
        {
            if (steamPid != 0)
            {
                if (OSDetector.IsWindows())
                {
                    RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Valve\Steam\ActiveProcess", true);

                    if (key == null)
                        return;

                    key.SetValue("pid", steamPid);
                    key.SetValue("SteamClientDll64", steamClientDll64);
                    key.SetValue("SteamClientDll", steamClientDll);
                }
            }
        }

        public static void RunWithoutEmu(GameConfig app)
        {
            try
            {
                var psi = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = app.Path,
                    Arguments = app.Parameters,
                    WorkingDirectory = app.StartFolder,
                    UseShellExecute = true
                };
                System.Diagnostics.Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to launch game without emulator: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Ensures the steam_settings folder and a dummy achievements.json exist for the game
        public static void EnsureDummyAchievementAndFiles(GameConfig app)
        {
            string gameFolder = app.GetGameEmuFolder();
            string steamSettings = Path.Combine(gameFolder, "steam_settings");
            string achievementsFile = Path.Combine(steamSettings, "achievements.json");
            string imagesFolder = Path.Combine(steamSettings, "achievement_images");
            string fakeIconName = "Fake_Achievement.png";
            string fakeIconPath = Path.Combine(imagesFolder, fakeIconName);

            if (!Directory.Exists(steamSettings))
                Directory.CreateDirectory(steamSettings);
            if (!Directory.Exists(imagesFolder))
                Directory.CreateDirectory(imagesFolder);

            // Copy achievement.png from resources if not already present
            if (!File.Exists(fakeIconPath))
            {
                using (var bmp = SmartGoldbergEmu.Properties.Resources.achievement)
                {
                    bmp.Save(fakeIconPath, System.Drawing.Imaging.ImageFormat.Png);
                }
            }

            if (!File.Exists(achievementsFile))
            {
                var fakeAchievements = new List<CAchievement>
                {
                    new CAchievement
                    {
                        name = "Fake_Achievement",
                        displayName = "Goldberg Crash Prevention Achievement!",
                        description = "This achievement exists solely to prevent Goldberg from crashing. If you see this, the game has no real achievements. Enjoy your fake victory! 🏆",
                        icon = $"achievement_images/{fakeIconName}",
                        icongray = $"achievement_images/{fakeIconName}",
                        icon_gray = $"achievement_images/{fakeIconName}"
                    }
                };
                File.WriteAllText(achievementsFile, Newtonsoft.Json.JsonConvert.SerializeObject(fakeAchievements, Newtonsoft.Json.Formatting.Indented));
            }
        }

        public static EmuConfig GetConfiguration()
        {
            return Config;
        }

        public static void SetEmuConfig(EmuConfig config) => Config = config;

        public static void UpdateAchievementWatcherFile(GameConfig app, string achievementId)
        {
            // Path: games/<appid>/remote/achievements.json
            string gameFolder = app.GetGameEmuFolder();
            string remoteFolder = Path.Combine(gameFolder, "remote");
            string watcherFile = Path.Combine(remoteFolder, "achievements.json");

            // Ensure remote folder exists
            if (!Directory.Exists(remoteFolder))
                Directory.CreateDirectory(remoteFolder);

            // Read or create the dictionary
            ConcurrentDictionary<string, bool> unlocked = new ConcurrentDictionary<string, bool>();
            if (File.Exists(watcherFile))
            {
                try
                {
                    var json = File.ReadAllText(watcherFile);
                    unlocked = Newtonsoft.Json.JsonConvert.DeserializeObject<ConcurrentDictionary<string, bool>>(json)
                        ?? new ConcurrentDictionary<string, bool>();
                }
                catch { }
            }
            // Set/unlock the achievement
            unlocked[achievementId] = true;
            // Write back
            File.WriteAllText(watcherFile, Newtonsoft.Json.JsonConvert.SerializeObject(unlocked, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
