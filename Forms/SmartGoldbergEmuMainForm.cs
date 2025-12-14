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
   <http://www.gnu.org/licenses/>.*/

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using OSUtility;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using SmartGoldbergEmu.Helpers;

namespace SmartGoldbergEmu
{
    public partial class SmartGoldbergEmuMainForm : Form
    {
        private ImageList _image_list = new ImageList();
        private ImageList _image_list_small = new ImageList();
        private ImageList _image_list_tile = new ImageList();
        private ImageList _image_list_capsule_tile = new ImageList();
        SavedConf crnilo = new SavedConf();
        private string[] dragndrop_files;
        private Dictionary<int, int> listViewToAppsIndexMap = new Dictionary<int, int>();
        private Dictionary<string, Image> tileImageCache = new Dictionary<string, Image>();
        private FeedbackReporter _feedbackReporter;
        private string currentViewMode = View.LargeIcon.ToString();
        private List<GameConfig> currentAppOrder = new List<GameConfig>();
        public enum ListSortMode { None, NameAsc, NameDesc, AppIDAsc, AppIDDesc }
        private ListSortMode currentSortMode = ListSortMode.None;
        private int lastSortColumn = -1;
        private bool lastSortAscending = true;
        private bool tileSortAscending = true;
        public enum ListSortField { Name, AppID }
        public enum ListSortDirection { Asc, Desc }

        public SmartGoldbergEmuMainForm()
        {
            InitializeComponent();
            // Set main form title to include assembly version
            string version = VersionHelper.GetDisplayVersion();
            this.Text = $"SmartGoldbergEmu Launcher {version}";
            feedbackProgressBar.Visible = false;

            // Remove padding, margin, and border for ListView
            app_list_view.Margin = new Padding(0);
            app_list_view.Padding = new Padding(0);
            app_list_view.BorderStyle = BorderStyle.None;
            app_list_view.Dock = DockStyle.Fill;

            _image_list.ImageSize = new Size(32, 32);
            _image_list_small.ImageSize = new Size(16, 16);
            _image_list_tile.ImageSize = new Size(256, 119);
            _image_list_tile.ColorDepth = ColorDepth.Depth32Bit;

            _image_list_capsule_tile.ImageSize = new Size(120, 45);
            _image_list_capsule_tile.ColorDepth = ColorDepth.Depth32Bit;

            app_list_view.LargeImageList = _image_list;
            app_list_view.SmallImageList = _image_list_small;
            app_list_view.TileSize = new Size(256, 119);

            app_list_view.AllowColumnReorder = true;

            _feedbackReporter = new FeedbackReporter(feedbackProgressBar, feedbackLabel, this);

            SteamEmulator.Initialize();
            LoadSortedGames();
            this.Opacity = 0; // Hide until ready

            this.app_list_view.ColumnClick += new ColumnClickEventHandler(this.AppListView_ColumnClick);
            // Load persisted sort state
            currentSortMode = (ListSortMode)Properties.Settings.Default.SortMode;
            lastSortColumn = Properties.Settings.Default.DetailsSortColumn;
            lastSortAscending = Properties.Settings.Default.DetailsSortAscending;
            // Load persisted tile sort state
            tileSortAscending = Properties.Settings.Default.TileSortAscending;
        }

        private void ValidateAndFixAppIds()
        {
            bool configChanged = false;
            // Remove duplicates: same AppId and same Path (case-insensitive), keep first occurrence
            var unique = new HashSet<string>();
            for (int i = SteamEmulator.Apps.Count - 1; i >= 0; i--)
            {
                var app = SteamEmulator.Apps[i];
                string key = app.AppId + "|" + (app.Path ?? string.Empty).ToLowerInvariant();
                if (unique.Contains(key))
                {
                    SteamEmulator.Apps.RemoveAt(i);
                    configChanged = true;
                }
                else
                {
                    unique.Add(key);
                }
            }
            // Now validate remaining items
            foreach (var app in SteamEmulator.Apps)
            {
                bool isInvalid = app.AppId == 0;
                if (isInvalid)
                {
                    // Try to auto-detect from steam_appid.txt
                    string folder = string.IsNullOrEmpty(app.StartFolder) ? Path.GetDirectoryName(app.Path) : app.StartFolder;
                    if (!string.IsNullOrEmpty(folder))
                    {
                        string steamAppIdFile = Path.Combine(folder, "steam_appid.txt");
                        if (File.Exists(steamAppIdFile))
                        {
                            string appIdStr = File.ReadAllText(steamAppIdFile).Trim();
                            if (ulong.TryParse(appIdStr, out ulong detectedAppId) && detectedAppId > 0)
                            {
                                app.AppId = detectedAppId;
                                configChanged = true;
                            }
                        }
                    }
                }
                // If still invalid, prompt user
                if (app.AppId == 0)
                {
                    using (var gsform = new GameSettingsForm())
                    {
                        gsform.SetApp(app);
                        MessageBox.Show($"Game '{app.AppName}' is missing a valid AppId. Please set the correct AppId.", "Missing AppId", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        var res = gsform.ShowDialog();
                        if (res == DialogResult.OK)
                        {
                            var modified = gsform.Modified_app;
                            app.AppId = modified.AppId;
                            app.AppName = modified.AppName;
                            app.Path = modified.Path;
                            app.StartFolder = modified.StartFolder;
                            app.Parameters = modified.Parameters;
                            app.UseX64 = modified.UseX64;
                            app.CustomIcon = modified.CustomIcon;
                            // Copy other properties as needed
                            configChanged = true;
                        }
                    }
                }
            }
            if (configChanged)
            {
                SteamEmulator.Save();
            }
        }

        private void LoadSortedGames()
        {
            ValidateAndFixAppIds();
            SteamEmulator.Initialize();
            UpdateCurrentAppOrder();
            app_list_view.Items.Clear();
            _image_list_tile.Images.Clear();

            // Ensure columns are set up if in Details view
            if (app_list_view.View == View.Details)
            {
                SetupDetailsColumns();
            }

            foreach (var app in currentAppOrder)
            {
                LoadIcons(app);
                AddAppToList(app);
            }

            // If in tile view, reload tile images
            if (app_list_view.View == View.Tile)
            {
                if (currentViewMode == "CapsuleTile")
                    CapsuleTileToolStripMenuItem_Click_Handler(null, null);
                else
                    TileToolStripMenuItem_Click_Handler(null, null);
            }

            UpdateSortMenuChecks();
        }

        private void AddGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AskGamePath();
        }

        private void EditGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditGame();
        }

        private void DeleteGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteGame();
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditSettings();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void App_list_view_MouseDoubleClick(object sender, EventArgs e)
        {
            if (app_list_view.FocusedItem == null)
                return;
            if (app_list_view.FocusedItem.Tag is GameConfig app)
            {
                _feedbackReporter.SetMessage($"Launching game: {app.AppName}");
                SteamEmulator.StartGame(app);
                _feedbackReporter.SetMessage($"{app.AppName} launched.");
            }
        }

        public void LoadIcons(GameConfig app)
        {
            string key = app.AppId.ToString();
            try
            {
                if (_image_list.Images.ContainsKey(key))
                    _image_list.Images.RemoveByKey(key);
                if (_image_list_small.Images.ContainsKey(key))
                    _image_list_small.Images.RemoveByKey(key);
                // Don't add to _image_list_tile here, only in tile view

                Image iconImg;
                if (string.IsNullOrEmpty(app.CustomIcon))
                {
                    iconImg = Icon.ExtractAssociatedIcon(app.Path).ToBitmap();
                }
                else
                {
                    if (app.CustomIcon.EndsWith(".exe", StringComparison.OrdinalIgnoreCase))
                    {
                        iconImg = Icon.ExtractAssociatedIcon(app.CustomIcon).ToBitmap();
                    }
                    else
                    {
                        iconImg = new Bitmap(app.CustomIcon);
                    }
                }
                _image_list.Images.Add(key, new Bitmap(iconImg, _image_list.ImageSize));
                _image_list_small.Images.Add(key, new Bitmap(iconImg, _image_list_small.ImageSize));
            }
            catch (Exception)
            {
                try
                {
                    _image_list.Images.Add(key, SystemIcons.Application.ToBitmap());
                    _image_list_small.Images.Add(key, new Bitmap(SystemIcons.Application.ToBitmap(), _image_list_small.ImageSize));
                }
                catch
                {
                    // Silently fail if even this doesn't work
                }
            }
        }

        private delegate void AddAppToListDelegate(GameConfig app);
        private void AddAppToList(GameConfig app)
        {
            string key = app.AppId.ToString();
            ListViewItem item = new ListViewItem
            {
                Text = app.AppName,
                ImageKey = key,
                Tag = app
            };
            // Add subitems for Details view
            item.SubItems.Add(app.AppId.ToString());
            item.SubItems.Add(app.Parameters ?? "");
            item.SubItems.Add(app.Path ?? "");
            app_list_view.Items.Add(item);
        }

        private void AskGamePath()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = (OSDetector.IsWindows() ? "Game executables (*.exe;*.bat)|*.exe;*.bat|All Files|*.*" : "All Files|*.*"),
                FilterIndex = 1,
                Multiselect = false,
                CheckFileExists = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                AddGame(openFileDialog.FileName);
            }
        }

        private async void AddGame(string game_path)
        {
            GameConfig app = new GameConfig
            {
                Path = game_path
            };
            app.AppName = Path.GetFileNameWithoutExtension(app.Path);
            app.StartFolder = Path.GetDirectoryName(game_path);

            string steamAppIdFile = Path.Combine(app.StartFolder, "steam_appid.txt");
            if (File.Exists(steamAppIdFile))
            {
                string appIdStr = File.ReadAllText(steamAppIdFile).Trim();
                if (ulong.TryParse(appIdStr, out ulong appId) && appId > 0)
                {
                    app.AppId = appId;
                }
            }

            string[] files = Directory.GetFiles(app.StartFolder, "steam_api*.dll", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                if (Path.GetFileName(file).Equals("steam_api64.dll", StringComparison.OrdinalIgnoreCase))
                {
                    app.UseX64 = true;
                    break;
                }
                else if (Path.GetFileName(file).Equals("steam_api.dll", StringComparison.OrdinalIgnoreCase))
                {
                    app.UseX64 = false;
                    break;
                }
            }

            // Prevent duplicate: same path and same AppID
            var duplicate = SteamEmulator.Apps.FirstOrDefault(existing =>
                string.Equals(existing.Path, app.Path, StringComparison.OrdinalIgnoreCase) &&
                existing.AppId == app.AppId);
            if (duplicate != null)
            {
                MessageBox.Show("This game is already in your list.", "Duplicate Game", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SteamEmulator.Apps.Remove(duplicate);
            }

            using (GameSettingsForm gsform = new GameSettingsForm())
            {
                gsform.SetApp(app);
                DialogResult res = gsform.ShowDialog();
                if (res != DialogResult.OK)
                    return;

                app = gsform.Modified_app;
            }

            SteamEmulator.AddGame(app);
            LoadSortedGames();

            // Ensure dummy achievement and files (now centralized)
            SteamEmulator.EnsureDummyAchievementAndFiles(app);

            // Always check/generate both achievements and items
            if (!string.IsNullOrWhiteSpace(SteamEmulator.Config.webapi_key))
            {
                string gameFolder = app.GetGameEmuFolder();
                string steamSettings = Path.Combine(gameFolder, "steam_settings");
                string achievementsFile = Path.Combine(steamSettings, "achievements.json");
                string itemsFile = Path.Combine(steamSettings, "items.json");
                bool needAchievements = false;
                bool needItems = false;

                // Check achievements.json
                if (!File.Exists(achievementsFile))
                {
                    needAchievements = true;
                }
                else
                {
                    // Check if it's only the fake achievement
                    try
                    {
                        var json = File.ReadAllText(achievementsFile);
                        var achievements = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CAchievement>>(json);
                        if (achievements != null && achievements.Count == 1 && achievements[0].name == "Fake_Achievement")
                        {
                            needAchievements = true;
                        }
                    }
                    catch { needAchievements = true; }
                }

                // Check items.json
                if (!File.Exists(itemsFile))
                {
                    needItems = true;
                }

                app_list_view.Enabled = false;
                if (needAchievements)
                {
                    feedbackProgressBar.Visible = true;
                    _feedbackReporter.Reset();
                    _feedbackReporter.SetMessage("Generating achievements...");
                    _feedbackReporter.SetProgress(0, 100);
                    await SteamEmulator.AchievementGenerator(app, _feedbackReporter);
                    feedbackProgressBar.Visible = false;
                }
                if (needItems)
                {
                    // Check phase (no progress bar)
                    _feedbackReporter.Reset();
                    _feedbackReporter.SetMessage("Checking items...");
                    _feedbackReporter.SetProgress(0, 100);
                    bool hasWork = await Task.Run(() => SteamEmulator.GenerateGameItems(app, _feedbackReporter));
                    if (hasWork)
                    {
                        // Generation phase (show progress bar and use same message as context menu)
                        feedbackProgressBar.Visible = true;
                        _feedbackReporter.Reset();
                        _feedbackReporter.SetMessage("Generating items...");
                        _feedbackReporter.SetProgress(0, 100);
                        await Task.Run(() => SteamEmulator.GenerateGameItems(app, _feedbackReporter));
                        feedbackProgressBar.Visible = false;
                    }
                }
                app_list_view.Enabled = true;
            }
        }

        private void EditGame()
        {
            if (app_list_view.FocusedItem == null)
                return;
            if (!(app_list_view.FocusedItem.Tag is GameConfig app))
                return;

            using (GameSettingsForm gsform = new GameSettingsForm())
            {
                gsform.SetApp(app);
                DialogResult res = gsform.ShowDialog();
                gsform.Dispose();
                if (res != DialogResult.OK)
                    return;

                // Find the index in SteamEmulator.Apps to update
                int appsIndex = SteamEmulator.Apps.IndexOf(app);
                if (appsIndex >= 0)
                    SteamEmulator.SetGame(appsIndex, gsform.Modified_app);

                LoadSortedGames();
            }
        }

        private void DeleteGame()
        {
            if (app_list_view.FocusedItem == null)
                return;
            if (!(app_list_view.FocusedItem.Tag is GameConfig app))
                return;
            int appsIndex = SteamEmulator.Apps.IndexOf(app);
            if (appsIndex >= 0)
            {
                // Check if this is the last entry for this AppID
                var appId = app.AppId;
                int countWithSameAppId = SteamEmulator.Apps.Count(a => a.AppId == appId && a != app);
                bool isLastWithAppId = countWithSameAppId == 0;
                SteamEmulator.RemoveGame(SteamEmulator.Apps[appsIndex], isLastWithAppId);
            }
            LoadSortedGames();
        }

        private void EditSettings()
        {
            SettingsForm sform = new SettingsForm
            {
                Config = SteamEmulator.Config
            };
            sform.ShowDialog();

            if (sform.DialogResult == DialogResult.OK)
            {
                SteamEmulator.Config = sform.Config;

                SteamEmulator.Save();
                SteamEmulator.SetupEmu(new GameConfig());
            }
        }

        private void App_list_view_MouseUp(object sender, MouseEventArgs me)
        {
            if (me.Button == MouseButtons.Right)
            {
                ListViewHitTestInfo hit = null;
                try
                {
                    hit = app_list_view.HitTest(me.Location);
                }
                catch
                {
                    // Defensive: if HitTest fails, treat as background
                    hit = null;
                }

                if (hit != null && hit.Item != null)
                    capp_contextMenuStrip.Show(app_list_view, me.Location);
                else
                    canvas_contextMenuStrip.Show(app_list_view, me.Location);
            }
        }

        private void PropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditGame();
        }

        private void RemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to remove this game?", "SmartGoldberEmu Launcher", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DeleteGame();
            }
        }

        private async void GenerateAchievementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (app_list_view.FocusedItem == null)
                return;
            if (!(app_list_view.FocusedItem.Tag is GameConfig app))
                return;
            int appsIndex = SteamEmulator.Apps.IndexOf(app);
            if (appsIndex == -1)
                return;

            app_list_view.Enabled = false;
            feedbackProgressBar.Visible = true;
            _feedbackReporter.Reset();
            _feedbackReporter.SetMessage("Generating achievements...");
            _feedbackReporter.SetProgress(0, 100);

            bool success = await SteamEmulator.AchievementGenerator(SteamEmulator.Apps[appsIndex], _feedbackReporter);
            if (!success)
            {
                _feedbackReporter.SetMessage("No achievements to generate.");
            }
            feedbackProgressBar.Visible = false;
            app_list_view.Enabled = true;
        }

        private async void GenerateItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (app_list_view.FocusedItem == null)
                return;
            if (!(app_list_view.FocusedItem.Tag is GameConfig app))
                return;
            int appsIndex = SteamEmulator.Apps.IndexOf(app);
            if (appsIndex == -1)
                return;

            app_list_view.Enabled = false;
            _feedbackReporter.Reset();
            _feedbackReporter.SetMessage("Checking items...");
            _feedbackReporter.SetProgress(0, 100);

            // First, check if there is work to do (without progress bar)
            bool hasWork = await Task.Run(() => SteamEmulator.GenerateGameItems(SteamEmulator.Apps[appsIndex], _feedbackReporter));
            if (hasWork)
            {
                feedbackProgressBar.Visible = true;
                _feedbackReporter.Reset();
                _feedbackReporter.SetMessage("Generating items...");
                _feedbackReporter.SetProgress(0, 100);
                await Task.Run(() => SteamEmulator.GenerateGameItems(SteamEmulator.Apps[appsIndex], _feedbackReporter));
            }
            feedbackProgressBar.Visible = false;
            app_list_view.Enabled = true;
        }

        private void OpenGameEmuFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (app_list_view.FocusedItem == null)
                return;
            if (!(app_list_view.FocusedItem.Tag is GameConfig app))
                return;
            int appsIndex = SteamEmulator.Apps.IndexOf(app);
            if (appsIndex == -1)
                return;

            SteamEmulator.ShowGameEmuFolder(SteamEmulator.Apps[appsIndex]);
        }

        private void OpenGameStoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (app_list_view.SelectedItems.Count > 0)
            {
                var selectedItem = app_list_view.SelectedItems[0];
                if (selectedItem.Tag is GameConfig app && app.AppId > 0)
                {
                    var url = $"https://store.steampowered.com/app/{app.AppId}";
                    System.Diagnostics.Process.Start(url);
                }
                else
                {
                    MessageBox.Show("App ID not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private delegate void EnableFormDelegate(bool enable);

        private void EnableForm(bool enable)
        {
            if (this.InvokeRequired)
                this.Invoke(new EnableFormDelegate(EnableForm), new object[] { enable });
            else
                this.Enabled = enable;
        }

        private void App_list_view_DragDrop(object sender, DragEventArgs e)
        {
            EnableForm(false);

            dragndrop_files = (string[])e.Data.GetData(DataFormats.FileDrop);

            Task.Factory.StartNew(async () =>
            {
                foreach (string file in dragndrop_files)
                {
                    await Task.Run(() => {
                        this.BeginInvoke(new Action<string>(AddGame), file);
                    });
                }
            })
                .ContinueWith(t => EnableForm(true));
        }

        private void App_list_view_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void App_list_view_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                DeleteGame();
        }

        private void SmartGoldbergEmuMainForm_SizeChanged(object sender, EventArgs e)
        {
            app_list_view.Size = this.ClientSize;
            if (this.WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.F1Size = this.Size;
                Properties.Settings.Default.Save();
            }
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutf = new AboutForm();
            aboutf.ShowDialog();
        }

        private void SmartGoldbergEmuMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SteamEmulator.RestoreSteam();
        }

        private void CreateShortcutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!OSDetector.IsWindows())
            {
                MessageBox.Show("This feature is only available on Windows for the moment", "Unsupported", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (app_list_view.FocusedItem == null)
                return;
            if (!(app_list_view.FocusedItem.Tag is GameConfig app))
                return;

            string launcherPath = Path.GetFullPath(Environment.GetCommandLineArgs()[0]);
            string desktopDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + Path.DirectorySeparatorChar;
            string safeAppName = SanitizeFileName(app.AppName);
            string shortcutPath = Path.Combine(desktopDir, safeAppName + ".lnk");

            // Step 1: Create the shortcut with no custom icon (default launcher icon)
            SharpShortcut.Shortcut.Create(
                shortcutPath,
                launcherPath,
                app.GameGuid.ToString(),
                Path.GetDirectoryName(launcherPath),
                $"Starts {app.AppName} with the steam emulator",
                string.Empty,
                null // Do not set IconLocation
            );

            // Step 2: Modify the shortcut to set the icon, only after the file is created
            try
            {
                string iconToSet = null;
                if (!string.IsNullOrEmpty(app.CustomIcon) && File.Exists(app.CustomIcon) && Path.GetExtension(app.CustomIcon).Equals(".ico", StringComparison.OrdinalIgnoreCase))
                {
                    iconToSet = app.CustomIcon + ",0";
                }
                else
                {
                    iconToSet = app.Path + ",0";
                }

                Type shellType = Type.GetTypeFromProgID("WScript.Shell");
                object shell = Activator.CreateInstance(shellType);
                object shortcut = shellType.InvokeMember("CreateShortcut", System.Reflection.BindingFlags.InvokeMethod, null, shell, new object[] { shortcutPath });
                var shortcutType = shortcut.GetType();
                shortcutType.InvokeMember("IconLocation", System.Reflection.BindingFlags.SetProperty, null, shortcut, new object[] { iconToSet });
                shortcutType.InvokeMember("Save", System.Reflection.BindingFlags.InvokeMethod, null, shortcut, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Shortcut created, but failed to set icon: {ex.Message}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private string SanitizeFileName(string fileName)
        {
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                fileName = fileName.Replace(c, ' ');
            }
            return fileName;
        }


        public static void CreateShortcut(GameConfig app, string iconPath)
        {
            string shortcutPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"{app.AppName}.lnk");
            SharpShortcut.Shortcut.Create(shortcutPath, app.Path, app.Parameters, app.StartFolder, app.AppName, null, iconPath);
        }

        private void Zatvaranje(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.F1State = this.WindowState;
            if (this.WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.F1Location = this.Location;
                Properties.Settings.Default.F1Size = this.Size;
            }
            else
            {
                Properties.Settings.Default.F1Location = this.RestoreBounds.Location;
                Properties.Settings.Default.F1Size = this.RestoreBounds.Size;
            }
            // Save ListView mode
            Properties.Settings.Default.ListViewMode = currentViewMode;
            Properties.Settings.Default.Save();
        }

        private async void Otvaranje(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.F1Size.Width == 0) Properties.Settings.Default.Upgrade();
            if (Properties.Settings.Default.F1Size.Width == 0 || Properties.Settings.Default.F1Size.Height == 0)
            {
            }
            else
            {
                this.WindowState = Properties.Settings.Default.F1State;
                if (this.WindowState == FormWindowState.Minimized) this.WindowState = FormWindowState.Normal;
                this.Location = Properties.Settings.Default.F1Location;
                this.Size = Properties.Settings.Default.F1Size;
            }
            // Always load content before restoring view
            currentSortMode = (ListSortMode)Properties.Settings.Default.SortMode;
            // Restore ListView mode
            string mode = Properties.Settings.Default.ListViewMode;
            object viewMode = View.LargeIcon;
            if (!string.IsNullOrEmpty(mode))
            {
                try
                {
                    if (mode == "CapsuleTile")
                        viewMode = "CapsuleTile";
                    else
                        viewMode = (View)Enum.Parse(typeof(View), mode);
                }
                catch { viewMode = View.LargeIcon; }
            }
            // Set the correct view and image lists, and load games after setting view
            switch (viewMode.ToString())
            {
                case nameof(View.LargeIcon):
                    app_list_view.View = View.LargeIcon;
                    LoadSortedGames();
                    break;
                case nameof(View.List):
                    app_list_view.View = View.List;
                    LoadSortedGames();
                    break;
                case nameof(View.Details):
                    app_list_view.View = View.Details;
                    LoadSortedGames();
                    break;
                case nameof(View.Tile):
                    app_list_view.View = View.Tile;
                    await TileToolStripMenuItem_Click(null, null);
                    this.Opacity = 1; // Show form after all is ready
                    return;
                case "CapsuleTile":
                    await CapsuleTileToolStripMenuItem_Click(null, null);
                    this.Opacity = 1;
                    return;
            }
            UpdateViewMenuChecks(viewMode);
            this.Opacity = 1; // Show form after all is ready
        }

        private void ViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Implement view options (e.g., change ListView view mode)
        }

        private void SortByToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Implement sort by options
        }

        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Reload the game list and preserve the current view mode
            UpdateCurrentAppOrder();
            switch (currentViewMode)
            {
                case "LargeIcon":
                    LargeIconsToolStripMenuItem_Click(null, null);
                    break;
                case "List":
                    ListToolStripMenuItem_Click(null, null);
                    break;
                case "Details":
                    DetailsToolStripMenuItem_Click(null, null);
                    break;
                case "CapsuleTile":
                    CapsuleTileToolStripMenuItem_Click_Handler(null, null);
                    break;
                case "Tile":
                default:
                    TileToolStripMenuItem_Click_Handler(null, null);
                    break;
            }
        }

        private void LargeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            app_list_view.View = View.LargeIcon;
            app_list_view.LargeImageList = _image_list;
            app_list_view.SmallImageList = _image_list_small;
            app_list_view.Items.Clear();
            for (int i = 0; i < currentAppOrder.Count; i++)
            {
                var app = currentAppOrder[i];
                LoadIcons(app);
                AddAppToList(app);
            }
            currentViewMode = View.LargeIcon.ToString();
            Properties.Settings.Default.ListViewMode = currentViewMode;
            Properties.Settings.Default.Save();
            UpdateViewMenuChecks(View.LargeIcon);
        }

        private void ListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            app_list_view.View = View.List;
            app_list_view.LargeImageList = _image_list;
            app_list_view.SmallImageList = _image_list_small;
            app_list_view.Items.Clear();
            for (int i = 0; i < currentAppOrder.Count; i++)
            {
                var app = currentAppOrder[i];
                LoadIcons(app);
                AddAppToList(app);
            }
            currentViewMode = View.List.ToString();
            Properties.Settings.Default.ListViewMode = currentViewMode;
            Properties.Settings.Default.Save();
            UpdateViewMenuChecks(View.List);
        }

        private void DetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            app_list_view.View = View.Details;
            app_list_view.SmallImageList = _image_list_small;
            app_list_view.LargeImageList = _image_list;
            SetupDetailsColumns();
            // Clear and re-add all items to ensure subitems match columns
            app_list_view.Items.Clear();
            for (int i = 0; i < currentAppOrder.Count; i++)
            {
                var app = currentAppOrder[i];
                LoadIcons(app);
                AddAppToList(app);
            }
            currentViewMode = View.Details.ToString();
            Properties.Settings.Default.ListViewMode = currentViewMode;
            Properties.Settings.Default.Save();
            UpdateViewMenuChecks(View.Details);
            // Apply persisted sort if valid
            if (lastSortColumn >= 0 && lastSortColumn < app_list_view.Columns.Count)
            {
                app_list_view.ListViewItemSorter = new ListViewItemComparer(lastSortColumn, lastSortAscending);
                app_list_view.Sort();
            }
        }

        private async void TileToolStripMenuItem_Click_Handler(object sender, EventArgs e)
        {
            await TileToolStripMenuItem_Click(sender, e);
        }

        private async Task TileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Ensure the app order is up to date and sorted/cloned
            UpdateCurrentAppOrder();

            // Clear and reload tile images BEFORE assigning to ListView
            _image_list_tile.Images.Clear();

            // Set tile size to 256x122 (119 image + 3px margin at bottom)
            Size tileSize = new Size(256, 122);
            Size imageSize = new Size(256, 119);

            app_list_view.Items.Clear();
            for (int i = 0; i < currentAppOrder.Count; i++)
            {
                var app = currentAppOrder[i];
                LoadIcons(app);
                AddAppToList(app);
            }

            foreach (ListViewItem item in app_list_view.Items)
            {
                if (item.Tag is GameConfig app)
                {
                    string appId = app.AppId.ToString();
                    Image tileImg = await GetTileImageAsync(appId);
                    if (tileImg != null)
                    {
                        // Normalize image to fit within 256x119, maintaining aspect ratio, centered horizontally
                        int targetW = imageSize.Width;
                        int targetH = imageSize.Height;
                        float ratio = Math.Min((float)targetW / tileImg.Width, (float)targetH / tileImg.Height);
                        int drawW = (int)(tileImg.Width * ratio);
                        int drawH = (int)(tileImg.Height * ratio);
                        int offsetX = (targetW - drawW) / 2;
                        int offsetY = (targetH - drawH) / 2;
                        Bitmap tileBitmap = new Bitmap(tileSize.Width, tileSize.Height);
                        using (Graphics g = Graphics.FromImage(tileBitmap))
                        {
                            g.Clear(Color.Transparent);
                            g.DrawImage(tileImg, new Rectangle(offsetX, offsetY, drawW, drawH));
                        }
                        if (!_image_list_tile.Images.ContainsKey(appId))
                            _image_list_tile.Images.Add(appId, tileBitmap);
                        // Ensure UI update is on the main thread
                        if (item.ListView != null && item.ListView.InvokeRequired)
                            item.ListView.Invoke(new Action(() => item.ImageKey = appId));
                        else
                            item.ImageKey = appId;
                    }
                }
            }

            app_list_view.TileSize = tileSize;
            app_list_view.LargeImageList = _image_list_tile;
            app_list_view.SmallImageList = _image_list_tile;
            app_list_view.View = View.Tile;

            // Nudge ListView to force layout update
            var originalSize = app_list_view.Size;
            app_list_view.Size = new Size(originalSize.Width + 1, originalSize.Height);
            app_list_view.Size = originalSize;

            currentViewMode = View.Tile.ToString();
            Properties.Settings.Default.ListViewMode = currentViewMode;
            Properties.Settings.Default.Save();
            UpdateViewMenuChecks(View.Tile);
        }

        private Bitmap GenerateNamePlaceholder(string name, Size size)
        {
            Bitmap bmp = new Bitmap(size.Width, size.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                // Dark background (RGB: 45, 45, 48) - matches the dark theme
                g.Clear(Color.FromArgb(45, 45, 48));
                using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                using (var font = new Font("Segoe UI", Math.Max(10, size.Height / 4), FontStyle.Bold, GraphicsUnit.Pixel))
                // Light gray text (RGB: 200, 200, 200) for better contrast
                using (var brush = new SolidBrush(Color.FromArgb(200, 200, 200)))
                {
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                    g.DrawString(name, font, brush, new RectangleF(0, 0, size.Width, size.Height), sf);
                }
            }
            return bmp;
        }

        private async Task<Image> GetTileImageAsync(string appId)
        {
            string gamesDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "games", appId);
            Directory.CreateDirectory(gamesDir);
            string imageName = "header.jpg";
            string capsuleName = "capsule_sm_120.jpg";
            string localPath = Path.Combine(gamesDir, imageName);
            string localCapsulePath = Path.Combine(gamesDir, capsuleName);
            // Only download if the file does not exist
            if (!File.Exists(localPath))
            {
                string urlPrimary = $"https://cdn.akamai.steamstatic.com/steam/apps/{appId}/{imageName}";
                string urlFallback = $"https://shared.cloudflare.steamstatic.com/store_item_assets/steam/apps/{appId}/{imageName}";
                using (var client = new System.Net.Http.HttpClient())
                {
                    try
                    {
                        var data = await client.GetByteArrayAsync(urlPrimary);
                        File.WriteAllBytes(localPath, data);
                        // Optionally download capsule if not present
                        if (!File.Exists(localCapsulePath))
                        {
                            string capsuleUrl = urlPrimary.Replace(imageName, capsuleName);
                            try
                            {
                                var capsuleData = await client.GetByteArrayAsync(capsuleUrl);
                                File.WriteAllBytes(localCapsulePath, capsuleData);
                            }
                            catch { /* Ignore capsule download errors */ }
                        }
                    }
                    catch
                    {
                        try
                        {
                            var data = await client.GetByteArrayAsync(urlFallback);
                            File.WriteAllBytes(localPath, data);
                            // Optionally download capsule if not present
                            if (!File.Exists(localCapsulePath))
                            {
                                string capsuleUrl = urlFallback.Replace(imageName, capsuleName);
                                try
                                {
                                    var capsuleData = await client.GetByteArrayAsync(capsuleUrl);
                                    File.WriteAllBytes(localCapsulePath, capsuleData);
                                }
                                catch { /* Ignore capsule download errors */ }
                            }
                        }
                        catch { /* Ignore header download errors */ }
                    }
                }
            }
            // Try to load from local file
            if (File.Exists(localPath))
            {
                try
                {
                    using (var img = Image.FromFile(localPath))
                    {
                        return new Bitmap(img);
                    }
                }
                catch { }
            }
            // If missing, generate placeholder with game name
            var app = SteamEmulator.Apps.FirstOrDefault(a => a.AppId.ToString() == appId);
            string name = app?.AppName ?? appId;
            return GenerateNamePlaceholder(name, new Size(256, 119));
        }

        private Task PreloadAllViewsAsync()
        {
            // Preload LargeIcon and List (same images)
            foreach (ListViewItem item in app_list_view.Items)
            {
                if (item.Tag is GameConfig app)
                {
                    string appId = app.AppId.ToString();
                    // Already loaded in _image_list and _image_list_small by LoadIcons
                }
            }
            // Preload Details (same as List)
            // Preload Tile images
            _image_list_tile.Images.Clear();
            var tileTasks = new List<Task>();
            foreach (ListViewItem item in app_list_view.Items)
            {
                if (item.Tag is GameConfig app)
                {
                    string appId = app.AppId.ToString();
                    tileTasks.Add(GetTileImageAsync(appId).ContinueWith(t => {
                        if (!_image_list_tile.Images.ContainsKey(appId))
                        {
                            var tileImg = t.Result;
                            if (tileImg != null)
                                _image_list_tile.Images.Add(appId, tileImg);
                        }
                    }));
                }
            }
            return Task.WhenAll(tileTasks);
        }

        private void UpdateViewMenuChecks(object currentView)
        {
            // Context menu
            largeIconsToolStripMenuItem.Checked = (currentView.ToString() == View.LargeIcon.ToString());
            detailsToolStripMenuItem.Checked = (currentView.ToString() == View.Details.ToString());
            tileToolStripMenuItem.Checked = (currentView.ToString() == View.Tile.ToString());
            if (capsuleTilesViewToolStripMenuItem != null) capsuleTilesViewToolStripMenuItem.Checked = (currentView.ToString() == "CapsuleTile");
            // Menustrip
            if (iconViewToolStripMenuItem != null) iconViewToolStripMenuItem.Checked = (currentView.ToString() == View.LargeIcon.ToString());
            if (detailsToolStripMenuItem2 != null) detailsToolStripMenuItem2.Checked = (currentView.ToString() == View.Details.ToString());
            if (tilesViewToolStripMenuItem != null) tilesViewToolStripMenuItem.Checked = (currentView.ToString() == View.Tile.ToString());
            if (capsuleTilesViewToolStripMenuItem != null) capsuleTilesViewToolStripMenuItem.Checked = (currentView.ToString() == "CapsuleTile");
            if (compactTilesViewToolStripMenuItem != null) compactTilesViewToolStripMenuItem.Checked = (currentView.ToString() == "CapsuleTile");
        }

        private void UpdateSortMenuChecks()
        {
            // Uncheck all
            ascToolStripMenuItem.Checked = false;
            descToolStripMenuItem.Checked = false;
            ascToolStripMenuItem1.Checked = false;
            descToolStripMenuItem1.Checked = false;
            noneToolStripMenuItem.Checked = false;
            // Context menu sort items
            ascToolStripMenuItem2.Checked = false;
            descToolStripMenuItem2.Checked = false;
            ascToolStripMenuItem3.Checked = false;
            descToolStripMenuItem3.Checked = false;
            noneToolStripMenuItem1.Checked = false;
            // Menustrip and context menu (same items, but ensure all are updated)
            if (ascToolStripMenuItem != null) ascToolStripMenuItem.Checked = false;
            if (descToolStripMenuItem != null) descToolStripMenuItem.Checked = false;
            if (ascToolStripMenuItem1 != null) ascToolStripMenuItem1.Checked = false;
            if (descToolStripMenuItem1 != null) descToolStripMenuItem1.Checked = false;
            if (noneToolStripMenuItem != null) noneToolStripMenuItem.Checked = false;
            if (ascToolStripMenuItem2 != null) ascToolStripMenuItem2.Checked = false;
            if (descToolStripMenuItem2 != null) descToolStripMenuItem2.Checked = false;
            if (ascToolStripMenuItem3 != null) ascToolStripMenuItem3.Checked = false;
            if (descToolStripMenuItem3 != null) descToolStripMenuItem3.Checked = false;
            if (noneToolStripMenuItem1 != null) noneToolStripMenuItem1.Checked = false;
            if (nameToolStripMenuItem != null) nameToolStripMenuItem.Checked = false;
            if (appidToolStripMenuItem != null) appidToolStripMenuItem.Checked = false;
            if (sortToolStripMenuItem != null) sortToolStripMenuItem.Checked = false;
            if (nameToolStripMenuItem1 != null) nameToolStripMenuItem1.Checked = false;
            if (appIdToolStripMenuItem1 != null) appIdToolStripMenuItem1.Checked = false;
            if (sortToolStripMenuItem1 != null) sortToolStripMenuItem1.Checked = false;
            // Set checked based on currentSortMode
            switch (currentSortMode)
            {
                case ListSortMode.NameAsc:
                    ascToolStripMenuItem.Checked = true;
                    ascToolStripMenuItem2.Checked = true;
                    if (ascToolStripMenuItem != null) ascToolStripMenuItem.Checked = true;
                    if (ascToolStripMenuItem2 != null) ascToolStripMenuItem2.Checked = true;
                    if (nameToolStripMenuItem != null) nameToolStripMenuItem.Checked = true;
                    if (nameToolStripMenuItem1 != null) nameToolStripMenuItem1.Checked = true;
                    if (sortToolStripMenuItem != null) sortToolStripMenuItem.Checked = true;
                    if (sortToolStripMenuItem1 != null) sortToolStripMenuItem1.Checked = true;
                    break;
                case ListSortMode.NameDesc:
                    descToolStripMenuItem.Checked = true;
                    descToolStripMenuItem2.Checked = true;
                    if (descToolStripMenuItem != null) descToolStripMenuItem.Checked = true;
                    if (descToolStripMenuItem2 != null) descToolStripMenuItem2.Checked = true;
                    if (nameToolStripMenuItem != null) nameToolStripMenuItem.Checked = true;
                    if (nameToolStripMenuItem1 != null) nameToolStripMenuItem1.Checked = true;
                    if (sortToolStripMenuItem != null) sortToolStripMenuItem.Checked = true;
                    if (sortToolStripMenuItem1 != null) sortToolStripMenuItem1.Checked = true;
                    break;
                case ListSortMode.AppIDAsc:
                    ascToolStripMenuItem1.Checked = true;
                    ascToolStripMenuItem3.Checked = true;
                    if (ascToolStripMenuItem1 != null) ascToolStripMenuItem1.Checked = true;
                    if (ascToolStripMenuItem3 != null) ascToolStripMenuItem3.Checked = true;
                    if (appidToolStripMenuItem != null) appidToolStripMenuItem.Checked = true;
                    if (appIdToolStripMenuItem1 != null) appIdToolStripMenuItem1.Checked = true;
                    if (sortToolStripMenuItem != null) sortToolStripMenuItem.Checked = true;
                    if (sortToolStripMenuItem1 != null) sortToolStripMenuItem1.Checked = true;
                    break;
                case ListSortMode.AppIDDesc:
                    descToolStripMenuItem1.Checked = true;
                    descToolStripMenuItem3.Checked = true;
                    if (descToolStripMenuItem1 != null) descToolStripMenuItem1.Checked = true;
                    if (descToolStripMenuItem3 != null) descToolStripMenuItem3.Checked = true;
                    if (appidToolStripMenuItem != null) appidToolStripMenuItem.Checked = true;
                    if (appIdToolStripMenuItem1 != null) appIdToolStripMenuItem1.Checked = true;
                    if (sortToolStripMenuItem != null) sortToolStripMenuItem.Checked = true;
                    if (sortToolStripMenuItem1 != null) sortToolStripMenuItem1.Checked = true;
                    break;
                case ListSortMode.None:
                default:
                    noneToolStripMenuItem.Checked = true;
                    noneToolStripMenuItem1.Checked = true;
                    if (noneToolStripMenuItem != null) noneToolStripMenuItem.Checked = true;
                    if (noneToolStripMenuItem1 != null) noneToolStripMenuItem1.Checked = true;
                    if (sortToolStripMenuItem != null) sortToolStripMenuItem.Checked = true;
                    if (sortToolStripMenuItem1 != null) sortToolStripMenuItem1.Checked = true;
                    break;
            }
        }

        private async Task RefreshTileViewIfNeededAsync()
        {
            if (app_list_view.View == View.Tile)
                await TileToolStripMenuItem_Click(null, null);
        }

        private async void SortByNoneMenuItem_Click(object sender, EventArgs e)
        {
            currentSortMode = ListSortMode.None;
            Properties.Settings.Default.SortMode = (int)currentSortMode;
            Properties.Settings.Default.Save();
            LoadSortedGames();
            await RefreshTileViewIfNeededAsync();
            UpdateSortMenuChecks();
        }
        private async void SortByNameAscMenuItem_Click(object sender, EventArgs e)
        {
            currentSortMode = ListSortMode.NameAsc;
            Properties.Settings.Default.SortMode = (int)currentSortMode;
            Properties.Settings.Default.Save();
            LoadSortedGames();
            await RefreshTileViewIfNeededAsync();
            UpdateSortMenuChecks();
        }
        private async void SortByNameDescMenuItem_Click(object sender, EventArgs e)
        {
            currentSortMode = ListSortMode.NameDesc;
            Properties.Settings.Default.SortMode = (int)currentSortMode;
            Properties.Settings.Default.Save();
            LoadSortedGames();
            await RefreshTileViewIfNeededAsync();
            UpdateSortMenuChecks();
        }
        private async void SortByAppIDAscMenuItem_Click(object sender, EventArgs e)
        {
            currentSortMode = ListSortMode.AppIDAsc;
            Properties.Settings.Default.SortMode = (int)currentSortMode;
            Properties.Settings.Default.Save();
            LoadSortedGames();
            await RefreshTileViewIfNeededAsync();
            UpdateSortMenuChecks();
        }
        private async void SortByAppIDDescMenuItem_Click(object sender, EventArgs e)
        {
            currentSortMode = ListSortMode.AppIDDesc;
            Properties.Settings.Default.SortMode = (int)currentSortMode;
            Properties.Settings.Default.Save();
            LoadSortedGames();
            await RefreshTileViewIfNeededAsync();
            UpdateSortMenuChecks();
        }

        private void AppListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (app_list_view.View != View.Details)
                return;

            if (e.Column == lastSortColumn)
            {
                lastSortAscending = !lastSortAscending;
            }
            else
            {
                lastSortColumn = e.Column;
                lastSortAscending = true;
            }

            // Persist sort state
            Properties.Settings.Default.DetailsSortColumn = lastSortColumn;
            Properties.Settings.Default.DetailsSortAscending = lastSortAscending;
            Properties.Settings.Default.Save();

            app_list_view.ListViewItemSorter = new ListViewItemComparer(e.Column, lastSortAscending);
            app_list_view.Sort();
        }

        private class ListViewItemComparer : System.Collections.IComparer
        {
            private int col;
            private bool ascending;

            public ListViewItemComparer(int column, bool asc)
            {
                col = column;
                ascending = asc;
            }

            public int Compare(object x, object y)
            {
                string a = ((ListViewItem)x).SubItems[col].Text;
                string b = ((ListViewItem)y).SubItems[col].Text;
                int result = 0;
                switch (col)
                {
                    case 0: // Name
                        result = string.Compare(a, b, StringComparison.OrdinalIgnoreCase);
                        break;
                    case 1: // AppID
                        if (long.TryParse(a, out long aId) && long.TryParse(b, out long bId))
                            result = aId.CompareTo(bId);
                        else
                            result = string.Compare(a, b, StringComparison.OrdinalIgnoreCase);
                        break;
                    case 2: // Parameters
                        result = string.Compare(a, b, StringComparison.OrdinalIgnoreCase);
                        break;
                    case 3: // Path
                        result = string.Compare(a, b, StringComparison.OrdinalIgnoreCase);
                        break;
                    default:
                        result = string.Compare(a, b, StringComparison.OrdinalIgnoreCase);
                        break;
                }
                return ascending ? result : -result;
            }
        }

        private void SortTilesAscMenuItem_Click(object sender, EventArgs e)
        {
            tileSortAscending = true;
            Properties.Settings.Default.TileSortAscending = tileSortAscending;
            Properties.Settings.Default.Save();
            if (app_list_view.View == View.Tile)
                LoadSortedGames();
        }
        private void SortTilesDescMenuItem_Click(object sender, EventArgs e)
        {
            tileSortAscending = false;
            Properties.Settings.Default.TileSortAscending = tileSortAscending;
            Properties.Settings.Default.Save();
            if (app_list_view.View == View.Tile)
                LoadSortedGames();
        }

        private void UpdateCurrentAppOrder()
        {
            var apps = SteamEmulator.Apps.ToList();
            switch (currentSortMode)
            {
                case ListSortMode.NameAsc:
                    currentAppOrder = apps.OrderBy(app => app.AppName, StringComparer.OrdinalIgnoreCase).ToList();
                    break;
                case ListSortMode.NameDesc:
                    currentAppOrder = apps.OrderByDescending(app => app.AppName, StringComparer.OrdinalIgnoreCase).ToList();
                    break;
                case ListSortMode.AppIDAsc:
                    currentAppOrder = apps.OrderBy(app => app.AppId).ToList();
                    break;
                case ListSortMode.AppIDDesc:
                    currentAppOrder = apps.OrderByDescending(app => app.AppId).ToList();
                    break;
                case ListSortMode.None:
                default:
                    currentAppOrder = apps;
                    break;
            }
        }

        private void RunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (app_list_view.FocusedItem == null)
                return;
            if (!(app_list_view.FocusedItem.Tag is GameConfig app))
                return;
            _feedbackReporter.SetMessage($"Launching game: {app.AppName}");
            SteamEmulator.StartGame(app);
            _feedbackReporter.SetMessage($"{app.AppName} launched.");
        }

        private void RunWithoutEmuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (app_list_view.FocusedItem == null)
                return;
            if (!(app_list_view.FocusedItem.Tag is GameConfig app))
                return;
            SteamEmulator.RunWithoutEmu(app);
        }

        private void OpenInventoryFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (app_list_view.FocusedItem == null)
                return;
            if (!(app_list_view.FocusedItem.Tag is GameConfig app))
                return;
            string inventoryFile = System.IO.Path.Combine(app.GetGameEmuFolder(), "steam_settings", "items.json");
            if (File.Exists(inventoryFile))
            {
                try
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = inventoryFile,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to open inventory file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Inventory file not found for this game.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CopyGuidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (app_list_view.FocusedItem == null)
                return;
            if (!(app_list_view.FocusedItem.Tag is GameConfig app))
                return;
            try
            {
                Clipboard.SetText(app.GameGuid.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to copy GUID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenCommunityPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (app_list_view.FocusedItem == null)
                return;
            if (!(app_list_view.FocusedItem.Tag is GameConfig app))
                return;
            try
            {
                System.Diagnostics.Process.Start($"https://steamcommunity.com/app/{app.AppId}/");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Steam Community page: {ex.Message}");
            }
        }

        private void OpenSteamWorkshopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (app_list_view.FocusedItem == null)
                return;
            if (!(app_list_view.FocusedItem.Tag is GameConfig app))
                return;
            try
            {
                System.Diagnostics.Process.Start($"https://steamcommunity.com/app/{app.AppId}/workshop/");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Steam Workshop page: {ex.Message}");
            }
        }

        private async void CapsuleTileToolStripMenuItem_Click_Handler(object sender, EventArgs e)
        {
            await CapsuleTileToolStripMenuItem_Click(sender, e);
        }

        private async Task CapsuleTileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateCurrentAppOrder();
            _image_list_capsule_tile.Images.Clear();
            Size tileSize = new Size(120, 48); // 45 image + 3px margin
            Size imageSize = new Size(120, 45);
            app_list_view.Items.Clear();
            for (int i = 0; i < currentAppOrder.Count; i++)
            {
                var app = currentAppOrder[i];
                LoadIcons(app);
                AddAppToList(app);
            }
            foreach (ListViewItem item in app_list_view.Items)
            {
                if (item.Tag is GameConfig app)
                {
                    string appId = app.AppId.ToString();
                    Image capsuleImg = await GetCapsuleTileImageAsync(appId);
                    if (capsuleImg != null)
                    {
                        int targetW = imageSize.Width;
                        int targetH = imageSize.Height;
                        float ratio = Math.Min((float)targetW / capsuleImg.Width, (float)targetH / capsuleImg.Height);
                        int drawW = (int)(capsuleImg.Width * ratio);
                        int drawH = (int)(capsuleImg.Height * ratio);
                        int offsetX = (targetW - drawW) / 2;
                        int offsetY = (targetH - drawH) / 2;
                        Bitmap tileBitmap = new Bitmap(tileSize.Width, tileSize.Height);
                        using (Graphics g = Graphics.FromImage(tileBitmap))
                        {
                            g.Clear(Color.Transparent);
                            g.DrawImage(capsuleImg, new Rectangle(offsetX, offsetY, drawW, drawH));
                        }
                        if (!_image_list_capsule_tile.Images.ContainsKey(appId))
                            _image_list_capsule_tile.Images.Add(appId, tileBitmap);
                        if (item.ListView != null && item.ListView.InvokeRequired)
                            item.ListView.Invoke(new Action(() => item.ImageKey = appId));
                        else
                            item.ImageKey = appId;
                    }
                }
            }
            app_list_view.TileSize = tileSize;
            app_list_view.LargeImageList = _image_list_capsule_tile;
            app_list_view.SmallImageList = _image_list_capsule_tile;
            app_list_view.View = View.Tile;
            var originalSize = app_list_view.Size;
            app_list_view.Size = new Size(originalSize.Width + 1, originalSize.Height);
            app_list_view.Size = originalSize;
            currentViewMode = "CapsuleTile";
            Properties.Settings.Default.ListViewMode = currentViewMode;
            Properties.Settings.Default.Save();
            UpdateViewMenuChecks(currentViewMode);
        }

        private async Task<Image> GetCapsuleTileImageAsync(string appId)
        {
            string gamesDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "games", appId);
            Directory.CreateDirectory(gamesDir);
            string capsuleName = "capsule_231x87.jpg";
            string localCapsulePath = Path.Combine(gamesDir, capsuleName);
            string urlPrimary = $"https://cdn.akamai.steamstatic.com/steam/apps/{appId}/{capsuleName}";
            string urlFallback = $"https://shared.cloudflare.steamstatic.com/store_item_assets/steam/apps/{appId}/{capsuleName}";
            // Only download if the file does not exist
            if (!File.Exists(localCapsulePath))
            {
                using (var client = new System.Net.Http.HttpClient())
                {
                    try
                    {
                        var data = await client.GetByteArrayAsync(urlPrimary);
                        File.WriteAllBytes(localCapsulePath, data);
                    }
                    catch
                    {
                        try
                        {
                            var data = await client.GetByteArrayAsync(urlFallback);
                            File.WriteAllBytes(localCapsulePath, data);
                        }
                        catch
                        {
                            // If download fails, fall through to local file check
                        }
                    }
                }
            }
            // Try to load from local file
            if (File.Exists(localCapsulePath))
            {
                try
                {
                    using (var img = Image.FromFile(localCapsulePath))
                    {
                        return new Bitmap(img);
                    }
                }
                catch { }
            }
            // If missing, generate placeholder with game name
            var app = SteamEmulator.Apps.FirstOrDefault(a => a.AppId.ToString() == appId);
            string name = app?.AppName ?? appId;
            return GenerateNamePlaceholder(name, new Size(120, 45));
        }

        // Add this helper method for setting up Details columns
        private void SetupDetailsColumns()
        {
            app_list_view.Columns.Clear();
            app_list_view.Columns.Add("Name", 200, HorizontalAlignment.Left);
            app_list_view.Columns.Add("App ID", 80, HorizontalAlignment.Left);
            app_list_view.Columns.Add("Launch Parameters", 100, HorizontalAlignment.Left);
            app_list_view.Columns.Add("Path", 250, HorizontalAlignment.Left);
        }
    }
}
