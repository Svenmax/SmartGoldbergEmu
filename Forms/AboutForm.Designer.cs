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
   <http://www.gnu.org/licenses/>.  */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmartGoldbergEmu
{
    partial class AboutForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.linkNemirtingas = new System.Windows.Forms.LinkLabel();
            this.linkKola124 = new System.Windows.Forms.LinkLabel();
            this.linkRev22b = new System.Windows.Forms.LinkLabel();
            this.lblContributors = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(11, 16);
            this.picLogo.Margin = new System.Windows.Forms.Padding(2);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(110, 110);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(131, 11);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(234, 21);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "SmartGoldbergEmu Launcher";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDescription.Location = new System.Drawing.Point(132, 62);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDescription.MaximumSize = new System.Drawing.Size(250, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(248, 30);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Streamlines and automates the configuration process for the Goldberg Steam Emulat" +
    "or.";
            // 
            // linkNemirtingas
            // 
            this.linkNemirtingas.AutoSize = true;
            this.linkNemirtingas.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.linkNemirtingas.LinkArea = new System.Windows.Forms.LinkArea(0, 27);
            this.linkNemirtingas.Location = new System.Drawing.Point(133, 103);
            this.linkNemirtingas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkNemirtingas.Name = "linkNemirtingas";
            this.linkNemirtingas.Size = new System.Drawing.Size(171, 15);
            this.linkNemirtingas.TabIndex = 3;
            this.linkNemirtingas.TabStop = true;
            this.linkNemirtingas.Text = "Nemirtingas (SmartSteamEmu)";
            // 
            // linkKola124
            // 
            this.linkKola124.AutoSize = true;
            this.linkKola124.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.linkKola124.LinkArea = new System.Windows.Forms.LinkArea(0, 21);
            this.linkKola124.Location = new System.Drawing.Point(133, 120);
            this.linkKola124.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkKola124.Name = "linkKola124";
            this.linkKola124.Size = new System.Drawing.Size(132, 15);
            this.linkKola124.TabIndex = 4;
            this.linkKola124.TabStop = true;
            this.linkKola124.Text = "Kola124 (GoldbergEmu)";
            // 
            // linkRev22b
            // 
            this.linkRev22b.AutoSize = true;
            this.linkRev22b.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.linkRev22b.LinkArea = new System.Windows.Forms.LinkArea(0, 25);
            this.linkRev22b.Location = new System.Drawing.Point(133, 136);
            this.linkRev22b.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkRev22b.Name = "linkRev22b";
            this.linkRev22b.Size = new System.Drawing.Size(138, 15);
            this.linkRev22b.TabIndex = 5;
            this.linkRev22b.TabStop = true;
            this.linkRev22b.Text = "GivenToFly (Release Info)";
            // 
            // lblContributors
            // 
            this.lblContributors.AutoSize = true;
            this.lblContributors.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblContributors.Location = new System.Drawing.Point(133, 171);
            this.lblContributors.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblContributors.Name = "lblContributors";
            this.lblContributors.Size = new System.Drawing.Size(234, 13);
            this.lblContributors.TabIndex = 6;
            this.lblContributors.Text = "Contributors: Nemirtingas, Kola124, GivenToFly.";
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 224);
            this.Controls.Add(this.lblContributors);
            this.Controls.Add(this.linkRev22b);
            this.Controls.Add(this.linkKola124);
            this.Controls.Add(this.linkNemirtingas);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.picLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About SmartGoldbergEmu";
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.LinkLabel linkNemirtingas;
        private System.Windows.Forms.LinkLabel linkKola124;
        private System.Windows.Forms.LinkLabel linkRev22b;
        private System.Windows.Forms.Label lblContributors;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}