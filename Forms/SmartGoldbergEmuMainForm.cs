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

namespace SmartGoldbergEmu
{
    public partial class SmartGoldbergEmuMainForm : Form
    {
        private ImageList _image_list = new ImageList();
        SavedConf crnilo = new SavedConf();
        private string[] dragndrop_files;
        private Dictionary<int, int> listViewToAppsIndexMap = new Dictionary<int, int>();

        public SmartGoldbergEmuMainForm()
        {
            InitializeComponent();

            _image_list.ImageSize = new Size(32, 32);

            app_list_view.LargeImageList = _image_list;
            app_list_view.SmallImageList = _image_list;

            LoadSortedGames();
        }

        private void LoadSortedGames()
        {
            app_list_view.Items.Clear();
            listViewToAppsIndexMap.Clear();

            var indexedApps = SteamEmulator.Apps
                .Select((app, index) => new { App = app, OriginalIndex = index })
                .OrderBy(item => item.App.AppName, StringComparer.OrdinalIgnoreCase)
                .ToList();

            for (int i = 0; i < indexedApps.Count; i++)
            {
                var item = indexedApps[i];
                listViewToAppsIndexMap[i] = item.OriginalIndex;
                LoadIcons(item.App);
                AddAppToList(item.App);
            }
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
            int listViewIndex = app_list_view.Items.IndexOf(app_list_view.FocusedItem);
            if (listViewIndex == -1)
                return;

            int appsIndex = listViewToAppsIndexMap[listViewIndex];
            GameConfig app = SteamEmulator.Apps[appsIndex];
            SteamEmulator.StartGame(app);
        }

        public void LoadIcons(GameConfig app)
        {
            try
            {
                if (_image_list.Images.ContainsKey(app.Path))
                    _image_list.Images.RemoveByKey(app.Path);

                if (string.IsNullOrEmpty(app.CustomIcon))
                {
                    Image result = Icon.ExtractAssociatedIcon(app.Path).ToBitmap();
                    _image_list.Images.Add(app.Path, result);
                }
                else
                {
                    if (app.CustomIcon.EndsWith(".exe", StringComparison.OrdinalIgnoreCase))
                    {
                        Image result = Icon.ExtractAssociatedIcon(app.CustomIcon).ToBitmap();
                        _image_list.Images.Add(app.Path, result);
                    }
                    else
                    {
                        Bitmap bmp = new Bitmap(app.CustomIcon);
                        _image_list.Images.Add(app.Path, bmp);
                    }
                }
            }
            catch (Exception)
            {
                try
                {
                    _image_list.Images.Add(app.Path, SystemIcons.Application.ToBitmap());
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
            ListViewItem item = new ListViewItem
            {
                Text = app.AppName,
                ImageKey = app.Path,
                Tag = app.AppId.ToString()
            };

            /*if (app_list_view.InvokeRequired)
                app_list_view.Invoke(new AddAppToListDelegate(AddAppToList), new object[] { app });
            else*/
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

            string gameFolder = app.GetGameEmuFolder();
            string achievementsFile = Path.Combine(gameFolder, "steam_settings", "achievements.json");
            if (!File.Exists(achievementsFile))
            {
                var fakeAchievements = new List<CAchievement>
                {
                    new CAchievement
                    {
                        name = "Fake_Achievement",
                        displayName = "No achievements are available for this game, or they failed to generate.",
                        description = "Still, this fake achievement was generated to prevent a crash when you click the Test achievement button.",
                        icon = "", icongray = "", icon_gray = ""
                    }
                };
                Directory.CreateDirectory(Path.Combine(gameFolder, "steam_settings"));
                File.WriteAllText(achievementsFile, Newtonsoft.Json.JsonConvert.SerializeObject(fakeAchievements, Newtonsoft.Json.Formatting.Indented));
            }

            if (!string.IsNullOrWhiteSpace(SteamEmulator.Config.webapi_key))
            {
                this.Enabled = false;
                await SteamEmulator.AchievementGenerator(app);
                this.Enabled = true;
            }
        }

        private async void EditGame()
        {
            int listViewIndex = app_list_view.Items.IndexOf(app_list_view.FocusedItem);
            if (listViewIndex == -1)
                return;

            int appsIndex = listViewToAppsIndexMap[listViewIndex];
            GameConfig app = SteamEmulator.Apps[appsIndex];

            using (GameSettingsForm gsform = new GameSettingsForm())
            {
                gsform.SetApp(app);
                DialogResult res = gsform.ShowDialog();
                gsform.Dispose();
                if (res != DialogResult.OK)
                    return;

                SteamEmulator.SetGame(appsIndex, gsform.Modified_app);

                LoadSortedGames();

                if (!string.IsNullOrWhiteSpace(SteamEmulator.Config.webapi_key))
                {
                    string game_emu_folder = app.GetGameEmuFolder();
                    if (!File.Exists(Path.Combine(game_emu_folder, "steam_settings", "achievements.json")))
                    {
                        this.Enabled = false;
                        await SteamEmulator.AchievementGenerator(app);
                        this.Enabled = true;
                    }
                }
            }
        }

        private void DeleteGame()
        {
            int listViewIndex = app_list_view.Items.IndexOf(app_list_view.FocusedItem);
            if (listViewIndex == -1)
                return;

            int appsIndex = listViewToAppsIndexMap[listViewIndex];
            SteamEmulator.RemoveGame(SteamEmulator.Apps[appsIndex]);

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

        private void App_list_view_Click(object sender, MouseEventArgs me)
        {
            if (me.Button == MouseButtons.Right)
            {
                if (app_list_view.FocusedItem != null && app_list_view.FocusedItem.Bounds.Contains(me.Location))
                {
                    capp_contextMenuStrip.Show(Cursor.Position);
                }
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
            int listViewIndex = app_list_view.Items.IndexOf(app_list_view.FocusedItem);
            if (listViewIndex == -1)
                return;

            int appsIndex = listViewToAppsIndexMap[listViewIndex];

            this.Enabled = false;
            await SteamEmulator.AchievementGenerator(SteamEmulator.Apps[appsIndex]);
            this.Enabled = true;
        }

        private void GenerateItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int listViewIndex = app_list_view.Items.IndexOf(app_list_view.FocusedItem);
            if (listViewIndex == -1)
                return;

            int appsIndex = listViewToAppsIndexMap[listViewIndex];

            this.Enabled = false;
            SteamEmulator.GenerateGameItems(SteamEmulator.Apps[appsIndex]);
            this.Enabled = true;
        }

        private void OpenGameEmuFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int listViewIndex = app_list_view.Items.IndexOf(app_list_view.FocusedItem);
            if (listViewIndex == -1)
                return;

            int appsIndex = listViewToAppsIndexMap[listViewIndex];

            SteamEmulator.ShowGameEmuFolder(SteamEmulator.Apps[appsIndex]);
        }

        private void OpenGameStoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (app_list_view.SelectedItems.Count > 0)
            {
                var selectedItem = app_list_view.SelectedItems[0];
                var appId = selectedItem.Tag as string;
                if (!string.IsNullOrEmpty(appId))
                {
                    var url = $"https://store.steampowered.com/app/{appId}";
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

            int listViewIndex = app_list_view.Items.IndexOf(app_list_view.FocusedItem);
            if (listViewIndex == -1)
                return;

            int appsIndex = listViewToAppsIndexMap[listViewIndex];
            GameConfig app = SteamEmulator.Apps[appsIndex];

            string launcherPath = Path.GetFullPath(Environment.GetCommandLineArgs()[0]);
            string desktopDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + Path.DirectorySeparatorChar;

            string iconPath = string.Empty;
            if (!string.IsNullOrEmpty(app.CustomIcon) && File.Exists(app.CustomIcon))
            {
                string ext = Path.GetExtension(app.CustomIcon).ToLower();
                if (ext == ".png" || ext == ".jpg" || ext == ".jpeg")
                {
                    string gameFolder = Path.GetDirectoryName(app.Path);
                    string exeNameWithoutExtension = Path.GetFileNameWithoutExtension(app.Path);
                    string icoPath = Path.Combine(gameFolder, exeNameWithoutExtension + ".ico");
                    ConvertImageToIcon(app.CustomIcon, icoPath);
                    iconPath = icoPath + ",0";
                }
                else
                {
                    iconPath = app.CustomIcon + ",0";
                }
            }
            else
            {
                iconPath = app.Path + ",0";
            }

            string safeAppName = SanitizeFileName(app.AppName);

            SharpShortcut.Shortcut.Create(
                desktopDir + safeAppName + ".lnk",
                launcherPath,
                app.GameGuid.ToString(),
                Path.GetDirectoryName(launcherPath),
                "Starts " + app.AppName + " with the steam emulator",
                string.Empty,
                iconPath
            );
        }

        private void ConvertImageToIcon(string imagePath, string iconPath)
        {
            using (Bitmap bitmap = new Bitmap(imagePath))
            {
                using (Bitmap iconBitmap = new Bitmap(bitmap, new Size(64, 64)))
                {
                    using (Icon icon = IconFromBitmap(iconBitmap))
                    {
                        using (FileStream stream = new FileStream(iconPath, FileMode.Create))
                        {
                            icon.Save(stream);
                        }
                    }
                }
            }
        }

        private Icon IconFromBitmap(Bitmap bitmap)
        {
            IntPtr hIcon = bitmap.GetHicon();
            Icon tempIcon = Icon.FromHandle(hIcon);
            Icon clonedIcon = (Icon)tempIcon.Clone();
            DestroyIcon(hIcon);
            return clonedIcon;
        }

        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern bool DestroyIcon(IntPtr handle);

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
            Properties.Settings.Default.Save();
        }

        private void Otvaranje(object sender, EventArgs e)
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
        }
    }
}
