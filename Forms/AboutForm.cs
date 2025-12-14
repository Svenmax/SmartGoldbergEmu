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
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using SmartGoldbergEmu.Helpers;

namespace SmartGoldbergEmu
{
    public partial class AboutForm : Form
    {
        private Label lblVersion = new Label { Text = "Version: ...", AutoSize = true };

        public AboutForm()
        {
            InitializeComponent();
            // Use project resources for icon and logo
            this.Icon = Properties.Resources.steel_steam_32;
            this.picLogo.Image = Properties.Resources.steel_steam_128;
            // Set project name without version
            this.lblTitle.Text = "SmartGoldbergEmu Launcher";
            // Use VersionHelper for version string
            string version = VersionHelper.GetDisplayVersion();
            // Set the version label to match the project name font
            this.lblVersion.Text = version;
            this.lblVersion.Font = this.lblTitle.Font;
            this.lblVersion.Location = new System.Drawing.Point(132, 32);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.TabIndex = 99;
            this.Controls.Add(this.lblVersion);
            this.lblDescription.Text = "Streamlines and automates the configuration process for the Goldberg Steam Emulator.";
            this.lblContributors.Text = "Contributors: Nemirtingas, Kola124, GivenToFly.";
            this.linkNemirtingas.Text = "Nemirtingas (SmartSteamEmu)";
            this.linkKola124.Text = "Kola124 (GoldbergEmu)";
            this.linkRev22b.Text = "GivenToFly (Release Info)";
            this.Text = "About SmartGoldbergEmu";
            // Wire up link click events with correct URLs
            this.linkNemirtingas.LinkClicked += (s, e) => Process.Start("https://cs.rin.ru/forum/viewtopic.php?f=29&t=62935");
            this.linkKola124.LinkClicked += (s, e) => Process.Start("https://github.com/Kola124/SmartGoldbergEmu");
            this.linkRev22b.LinkClicked += (s, e) => Process.Start("https://cs.rin.ru/forum/viewtopic.php?p=3221424#p3221424");
        }
    }
}
