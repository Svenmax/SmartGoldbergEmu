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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace SmartGoldbergEmu
{
    public class EmuConfig
    {
        public string username;
        public string language;
        public ushort port;
        public string steamid;
        public string webapi_key;
        public string friend_sound_path { get; set; } = string.Empty;
        public bool friend_sound_is_steam_default { get; set; } = false;
        public string achievement_sound_path { get; set; } = string.Empty;
        public bool achievement_sound_is_steam_default { get; set; } = false;

        private readonly string settingsDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"GSE Saves\settings");
        private readonly string userConfigFilePath;
        private readonly string mainConfigFilePath;
        private readonly string cfgFilePath;

        private const string GoldbergVersionFile = "goldberg_version.txt";
        private const string GoldbergRepoApi = "https://api.github.com/repos/Detanup01/gbe_fork/releases/latest";
        private const string GoldbergAssetName = "emu-win-release.7z";
        private const string GoldbergTempFolder = "temp";
        private const string GoldbergArchiveName = "emu-win-release.7z";
        private const string Goldberg7zrUrl = "https://www.7-zip.org/a/7zr.exe";
        private const string Goldberg7zrExe = "7zr.exe";
        private const string DefenderExclusionCmd = "powershell.exe";

        public EmuConfig()
        {
            string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;
            cfgFilePath = Path.Combine(exeDirectory, "SmartGoldbergEmu.cfg");

            userConfigFilePath = Path.Combine(settingsDirectory, "configs.user.ini");
            mainConfigFilePath = Path.Combine(settingsDirectory, "configs.main.ini");

            Directory.CreateDirectory(settingsDirectory);

            LoadUserConfig();
            LoadMainConfig();
            LoadWebApiKeyCfg();
            LoadWebApiKeTxt();
            CheckSoundFiles();
            CheckGoldbergFiles().Wait();
        }

        private void LoadUserConfig()
        {
            username = "SmartGoldberg";
            steamid = GenerateRandomSteamId();
            language = "english";

            if (File.Exists(userConfigFilePath))
            {
                foreach (var line in File.ReadLines(userConfigFilePath))
                {
                    if (line.StartsWith("account_name=")) username = line.Split('=')[1].Trim();
                    else if (line.StartsWith("account_steamid=")) steamid = line.Split('=')[1].Trim();
                    else if (line.StartsWith("language=")) language = line.Split('=')[1].Trim();
                }
            }

            CreateUserConfig();
        }

        private void LoadMainConfig()
        {
            port = GenerateRandomPort();

            if (File.Exists(mainConfigFilePath))
            {
                foreach (var line in File.ReadLines(mainConfigFilePath))
                {
                    if (line.StartsWith("listen_port=")) port = ushort.Parse(line.Split('=')[1].Trim());
                }
            }
            CreateMainConfig();
        }

        private void LoadWebApiKeyCfg()
        {
            webapi_key = string.Empty;

            if (File.Exists(cfgFilePath))
            {
                try
                {
                    foreach (var line in File.ReadLines(cfgFilePath))
                    {
                        if (line.Trim().StartsWith("<webapi_key>"))
                        {
                            int startIndex = line.IndexOf('>') + 1;
                            int endIndex = line.LastIndexOf('<');
                            if (startIndex > 0 && endIndex > startIndex)
                            {
                                webapi_key = line.Substring(startIndex, endIndex - startIndex).Trim();
                            }
                            break;
                        }
                    }
                }
                catch
                {
                    webapi_key = string.Empty;
                }
            }
        }

        private void LoadWebApiKeTxt()
        {
            webapi_key = string.Empty;

            string steamApiKeyFilePath = "steam_apikey.txt";

            if (File.Exists(steamApiKeyFilePath))
            {
                try
                {
                    webapi_key = File.ReadAllText(steamApiKeyFilePath).Trim();
                }
                catch
                {
                    webapi_key = string.Empty;
                }
            }
        }


        private void CreateUserConfig()
        {
            var sb = new StringBuilder();
            sb.AppendLine("[user::general]");
            sb.AppendLine($"account_name={username}");
            sb.AppendLine($"account_steamid={steamid}");
            sb.AppendLine($"language={language}");
            sb.AppendLine($"webapi_key={webapi_key}");
            File.WriteAllText(userConfigFilePath, sb.ToString());
        }

        private void CreateMainConfig()
        {
            var sb = new StringBuilder();
            sb.AppendLine("[main::connectivity]");
            sb.AppendLine($"listen_port={port}");
            File.WriteAllText(mainConfigFilePath, sb.ToString());
        }

        private ushort GenerateRandomPort() => (ushort)new Random().Next(1024, 65535);

        private string GenerateRandomSteamId() => (76561197960265728 + (ulong)new Random().Next(0, int.MaxValue)).ToString();

        private void CheckSoundFiles()
        {
            string destinationPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GSE Saves", "settings", "sounds");

            try
            {
                if (!Directory.Exists(destinationPath))
                {
                    Directory.CreateDirectory(destinationPath);
                }

                string steamSoundsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "Steam", "steamui", "sounds");

                var filesToCopy = new Dictionary<string, string>
                {
                    { "overlay_achievement_notification.wav", "desktop_toast_default.wav" },
                    { "overlay_friend_notification.wav", "deck_ui_misc_01.wav" }
                };

                foreach (var filePair in filesToCopy)
                {
                    string destinationFile = Path.Combine(destinationPath, filePair.Key);

                    if (!File.Exists(destinationFile))
                    {
                        string sourceFile = Path.Combine(steamSoundsPath, filePair.Value);

                        if (File.Exists(sourceFile))
                        {
                            File.Copy(sourceFile, destinationFile, true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error copying Steam sounds: {ex.Message}", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task CheckGoldbergFiles()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string win32Folder = Path.Combine(baseDirectory, "win32");
            string win64Folder = Path.Combine(baseDirectory, "win64");

            CreateDirectoryIfNotExists(win32Folder);
            CreateDirectoryIfNotExists(win64Folder);

            var requiredFiles = new (string FileName, string Folder)[]
            {
        ("GameOverlayRenderer.dll", win32Folder),
        ("steamclient.dll", win32Folder),
        ("GameOverlayRenderer64.dll", win64Folder),
        ("steamclient64.dll", win64Folder)
            };

            bool missingClient = requiredFiles
                .Where(item => item.FileName.Contains("steamclient"))
                .Any(item => !File.Exists(Path.Combine(item.Folder, item.FileName)));

            bool missingOverlay = requiredFiles
                .Where(item => item.FileName.Contains("GameOverlayRenderer"))
                .Any(item => !File.Exists(Path.Combine(item.Folder, item.FileName)));

            if (!missingClient && !missingOverlay)
                return;

            string message = missingClient
                ? "Goldberg Emulator is not installed. Do you want me to install it?\n\nNote: The update file may trigger fake positives with Windows Defender so\nI will temporary add an exception for downloaded file.\n\nYou can also manually download and setup from\nhttps://github.com/Detanup01/gbe_fork"
                : "Some overlay files are missing. Do you want me to fix the installation?\n\nNote: The update file may trigger fake positives with Windows Defender so\nI will temporary add an exception for downloaded file.\n\nYou can also manually download and setup from\nhttps://github.com/Detanup01/gbe_fork";
            MessageBoxIcon icon = missingClient ? MessageBoxIcon.Error : MessageBoxIcon.Warning;

            var result = MessageBox.Show(message, "SmartGoldbergEmu Launcher", MessageBoxButtons.OKCancel, icon);
            if (result == DialogResult.OK)
            {
                await FixGoldbergEmuInstallation();
            }
        }

        private async Task FixGoldbergEmuInstallation()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string tempFolder = Path.Combine(baseDirectory, "temp");
            CreateDirectoryIfNotExists(tempFolder);

            bool success = false;
            bool defenderAdded = false;
            string archivePath = Path.Combine(tempFolder, "emu-win-release.7z");
            try
            {
                string downloadUrl = await GetLatestReleaseUrlFromApi();
                if (string.IsNullOrEmpty(downloadUrl))
                    throw new Exception("Failed to get download URL.");

                // Add Defender exclusion before download
                try
                {
                    var psi = new ProcessStartInfo
                    {
                        FileName = DefenderExclusionCmd,
                        Arguments = $"-Command \"Add-MpPreference -ExclusionPath '{archivePath}'\"",
                        Verb = "runas",
                        UseShellExecute = true,
                        CreateNoWindow = true,
                        WindowStyle = ProcessWindowStyle.Hidden
                    };
                    using (var proc = Process.Start(psi))
                    {
                        proc.WaitForExit();
                        defenderAdded = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to add Defender exclusion: {ex.Message}\nYou may need to run as administrator.", "Defender Exclusion Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                await DownloadFileAsync(downloadUrl, archivePath);

                string extractor = await Download7zrAsync(tempFolder);
                if (string.IsNullOrEmpty(extractor) || !File.Exists(extractor))
                    throw new Exception("Extractor not found.");

                string win32Folder = Path.Combine(baseDirectory, "win32");
                string win64Folder = Path.Combine(baseDirectory, "win64");

                Extract7zFiles(extractor, archivePath, win32Folder, new string[]
                {
                    "release/steamclient_experimental/GameOverlayRenderer.dll",
                    "release/steamclient_experimental/steamclient.dll"
                });

                Extract7zFiles(extractor, archivePath, win64Folder, new string[]
                {
                    "release/steamclient_experimental/GameOverlayRenderer64.dll",
                    "release/steamclient_experimental/steamclient64.dll"
                });
                success = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fixing Goldberg Emu installation: {ex.Message}",
                                "Fix Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DeleteDirectoryIfExists(tempFolder);
                // Remove Defender exclusion if it was added
                if (defenderAdded)
                {
                    try
                    {
                        var psi = new ProcessStartInfo
                        {
                            FileName = DefenderExclusionCmd,
                            Arguments = $"-Command \"Remove-MpPreference -ExclusionPath '{archivePath}'\"",
                            Verb = "runas",
                            UseShellExecute = true,
                            CreateNoWindow = true,
                            WindowStyle = ProcessWindowStyle.Hidden
                        };
                        using (var proc = Process.Start(psi))
                        {
                            proc.WaitForExit();
                        }
                    }
                    catch { }
                }
                if (success)
                {
                    MessageBox.Show(
                        "Goldberg Emulator installation complete.\nWindows Defender exceptions have been removed.",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private async Task<string> Download7zrAsync(string tempFolder)
        {
            string sevenZipExePath = Path.Combine(tempFolder, "7zr.exe");
            if (!File.Exists(sevenZipExePath))
            {
                await DownloadFileAsync("https://www.7-zip.org/a/7zr.exe", sevenZipExePath);
            }
            return File.Exists(sevenZipExePath) ? sevenZipExePath : null;
        }

        private async Task DownloadFileAsync(string url, string destinationPath)
        {
            using (var client = new WebClient())
            {
                await client.DownloadFileTaskAsync(new Uri(url), destinationPath);
            }
        }

        private void Extract7zFiles(string extractor, string archivePath, string destinationFolder, string[] includeFiles)
        {
            if (!File.Exists(extractor))
                throw new Exception("Extractor not found.");

            string includeArgs = string.Join(" ", includeFiles.Select(f => $"-ir!\"{f}\""));
            string arguments = $"e \"{archivePath}\" -o\"{destinationFolder}\" -y {includeArgs}";

            using (var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = extractor,
                    Arguments = arguments,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            })
            {
                process.Start();
                process.WaitForExit();
            }
        }

        private void CreateDirectoryIfNotExists(string directory)
        {
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
        }

        private void DeleteDirectoryIfExists(string directory)
        {
            if (Directory.Exists(directory))
                Directory.Delete(directory, true);
        }

        private async Task<string> GetLatestReleaseUrlFromApi()
        {
            using (var client = new WebClient())
            {
                client.Headers.Add("User-Agent", "Mozilla/5.0");
                string json = await client.DownloadStringTaskAsync("https://api.github.com/repos/Detanup01/gbe_fork/releases");
                var releases = Newtonsoft.Json.Linq.JArray.Parse(json);
                return releases.SelectMany(r => r["assets"])
                    .FirstOrDefault(a => a["name"].Value<string>() == "emu-win-release.7z")?["browser_download_url"].Value<string>();
            }
        }

        // Call this at startup and from menu
        public async Task CheckGoldbergUpdate(bool isStartup)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string tempFolder = Path.Combine(baseDirectory, GoldbergTempFolder);
            string versionFile = Path.Combine(baseDirectory, GoldbergVersionFile);
            string archivePath = Path.Combine(tempFolder, GoldbergArchiveName);
            string sevenZipExePath = Path.Combine(tempFolder, Goldberg7zrExe);
            string win32Folder = Path.Combine(baseDirectory, "win32");
            string win64Folder = Path.Combine(baseDirectory, "win64");
            CreateDirectoryIfNotExists(tempFolder);
            CreateDirectoryIfNotExists(win32Folder);
            CreateDirectoryIfNotExists(win64Folder);

            string lastVersion = File.Exists(versionFile) ? File.ReadAllText(versionFile).Trim() : null;
            string currentVersion = null;
            string downloadUrl = null;
            try
            {
                // Get latest release info
                using (var client = new WebClient())
                {
                    client.Headers.Add("User-Agent", "Mozilla/5.0");
                    string json = await client.DownloadStringTaskAsync(GoldbergRepoApi);
                    var release = Newtonsoft.Json.Linq.JObject.Parse(json);
                    currentVersion = release["tag_name"]?.ToString();
                    var asset = release["assets"]?.FirstOrDefault(a => a["name"].ToString() == GoldbergAssetName);
                    downloadUrl = asset?["browser_download_url"]?.ToString();
                }
            }
            catch (Exception ex)
            {
                if (!isStartup)
                    MessageBox.Show($"Failed to check for Goldberg updates: {ex.Message}", "Update Check Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // If no version file but files exist, treat as pre-existent
            if (lastVersion == null && (File.Exists(Path.Combine(win32Folder, "steamclient.dll")) || File.Exists(Path.Combine(win64Folder, "steamclient64.dll"))))
            {
                lastVersion = "pre-existent";
                if (isStartup)
                {
                    var result = MessageBox.Show(
                        "Goldberg Emulator files are present, but the current version cannot be determined.\n" +
                        "Would you like to download and install the latest version to enable future update checks?",
                        "Goldberg Emulator Version Unknown",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (result != DialogResult.Yes)
                        return; // User declined, skip update
                    // else: continue with update as normal
                }
            }

            if (currentVersion == null || downloadUrl == null)
            {
                if (!isStartup)
                    MessageBox.Show("Could not determine latest Goldberg release.", "Update Check Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (lastVersion == currentVersion)
            {
                if (!isStartup)
                    MessageBox.Show($"Goldberg Emulator is up to date. (Version: {currentVersion})", "No Update Needed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Ask user if they want to update
            var askUpdate = MessageBox.Show($"A new Goldberg Emulator version is available: {currentVersion}\n(Current: {lastVersion})\nDo you want to update now?", "Goldberg Emulator Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (askUpdate != DialogResult.Yes)
                return;

            await FixGoldbergEmuInstallation();
        }
    }

    public class SavedConf
    {
        public string webapi_key = string.Empty;
        public List<GameConfig> apps = new List<GameConfig>();
    }
}
