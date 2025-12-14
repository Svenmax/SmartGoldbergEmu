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
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

using OSUtility;

namespace SmartGoldbergEmu
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();

        }

        private void Ok_button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void NemirtingasUrl_Clicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://cs.rin.ru/forum/viewtopic.php?f=29&t=62935",
                UseShellExecute = true
            });
        }
        private void KolasUrl_Clicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/Kola124/SmartGoldbergEmu",
                UseShellExecute = true
            });
        }
        private void GivenToFlysUrl_Clicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://cs.rin.ru/forum/viewtopic.php?p=3221424#p3221424",
                    UseShellExecute = true
                });
            }
        }

        private void ShowEmuFolder(GameConfig app)
        {
            string emu_folder = OSFuncs.GetEmuApiFolder(app.UseX64);

            if (!Directory.Exists(emu_folder))
                Directory.CreateDirectory(emu_folder);

            try
            {
                if (OSDetector.IsWindows())
                    Process.Start("explorer.exe", emu_folder);
                else if (OSDetector.IsLinux())
                    Process.Start("nautilus", emu_folder);
            }
            catch
            {
                MessageBox.Show("Folder: " + emu_folder, "Folder", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Steamapi_dll_folder_Click(object sender, EventArgs e)
        {
            GameConfig app = new GameConfig
            {
                UseX64 = false
            };
            ShowEmuFolder(app);
        }

        private void Steamapi64_dll_folder_Click(object sender, EventArgs e)
        {
            GameConfig app = new GameConfig
            {
                UseX64 = true
            };
            ShowEmuFolder(app);
        }

        private void about_description_label_Click(object sender, EventArgs e)
        {

        }
    }
}
