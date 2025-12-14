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
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.about_ok_bttn = new System.Windows.Forms.Button();
            this.about_x32folder_bttn = new System.Windows.Forms.Button();
            this.about_x64folder_brrn = new System.Windows.Forms.Button();
            this.about_image_frame = new System.Windows.Forms.PictureBox();
            this.about_title_label = new System.Windows.Forms.Label();
            this.about_nemirtingas_link = new System.Windows.Forms.LinkLabel();
            this.about_kola124_link = new System.Windows.Forms.LinkLabel();
            this.about_description_label = new System.Windows.Forms.Label();
            this.about_kola124_label = new System.Windows.Forms.Label();
            this.about_nemirtingas_label = new System.Windows.Forms.Label();
            this.GivenToFly_Label = new System.Windows.Forms.Label();
            this.rev22b_label = new System.Windows.Forms.Label();
            this.about_rev22b_label = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.about_image_frame)).BeginInit();
            this.SuspendLayout();
            // 
            // about_ok_bttn
            // 
            this.about_ok_bttn.Location = new System.Drawing.Point(473, 197);
            this.about_ok_bttn.Name = "about_ok_bttn";
            this.about_ok_bttn.Size = new System.Drawing.Size(75, 23);
            this.about_ok_bttn.TabIndex = 97;
            this.about_ok_bttn.Text = "OK";
            this.about_ok_bttn.UseVisualStyleBackColor = true;
            this.about_ok_bttn.Click += new System.EventHandler(this.Ok_button_Click);
            // 
            // about_x32folder_bttn
            // 
            this.about_x32folder_bttn.AccessibleName = "x32_button";
            this.about_x32folder_bttn.Location = new System.Drawing.Point(150, 139);
            this.about_x32folder_bttn.Name = "about_x32folder_bttn";
            this.about_x32folder_bttn.Size = new System.Drawing.Size(300, 23);
            this.about_x32folder_bttn.TabIndex = 3;
            this.about_x32folder_bttn.Text = "x32 Goldberg\'s steamclient.dll folder";
            this.about_x32folder_bttn.UseVisualStyleBackColor = true;
            this.about_x32folder_bttn.Click += new System.EventHandler(this.Steamapi_dll_folder_Click);
            // 
            // about_x64folder_brrn
            // 
            this.about_x64folder_brrn.AccessibleName = "x64_button";
            this.about_x64folder_brrn.Location = new System.Drawing.Point(150, 168);
            this.about_x64folder_brrn.Name = "about_x64folder_brrn";
            this.about_x64folder_brrn.Size = new System.Drawing.Size(300, 23);
            this.about_x64folder_brrn.TabIndex = 4;
            this.about_x64folder_brrn.Text = "x64 Goldberg\'s steamclient64.dll folder";
            this.about_x64folder_brrn.UseVisualStyleBackColor = true;
            this.about_x64folder_brrn.Click += new System.EventHandler(this.Steamapi64_dll_folder_Click);
            // 
            // about_image_frame
            // 
            this.about_image_frame.Image = global::SmartGoldbergEmu.Properties.Resources.steel_steam_128;
            this.about_image_frame.Location = new System.Drawing.Point(12, 40);
            this.about_image_frame.Name = "about_image_frame";
            this.about_image_frame.Size = new System.Drawing.Size(128, 128);
            this.about_image_frame.TabIndex = 3;
            this.about_image_frame.TabStop = false;
            // 
            // about_title_label
            // 
            this.about_title_label.AccessibleName = "About_title";
            this.about_title_label.AutoSize = true;
            this.about_title_label.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.about_title_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.about_title_label.Location = new System.Drawing.Point(189, 9);
            this.about_title_label.Name = "about_title_label";
            this.about_title_label.Size = new System.Drawing.Size(254, 17);
            this.about_title_label.TabIndex = 4;
            this.about_title_label.TabStop = true;
            this.about_title_label.Text = "SmartGoldbergEmu Launcher (rev2.2f)";
            this.about_title_label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // about_nemirtingas_link
            // 
            this.about_nemirtingas_link.AccessibleName = "Nemirtingas_link";
            this.about_nemirtingas_link.AutoSize = true;
            this.about_nemirtingas_link.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.about_nemirtingas_link.Location = new System.Drawing.Point(254, 79);
            this.about_nemirtingas_link.Name = "about_nemirtingas_link";
            this.about_nemirtingas_link.Size = new System.Drawing.Size(139, 13);
            this.about_nemirtingas_link.TabIndex = 1;
            this.about_nemirtingas_link.TabStop = true;
            this.about_nemirtingas_link.Text = "SmartSteamEmu @ cs.rin.ru";
            this.about_nemirtingas_link.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.NemirtingasUrl_Clicked);
            // 
            // about_kola124_link
            // 
            this.about_kola124_link.AccessibleName = "Kola124_link";
            this.about_kola124_link.AutoSize = true;
            this.about_kola124_link.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.about_kola124_link.Location = new System.Drawing.Point(254, 97);
            this.about_kola124_link.Name = "about_kola124_link";
            this.about_kola124_link.Size = new System.Drawing.Size(179, 13);
            this.about_kola124_link.TabIndex = 2;
            this.about_kola124_link.TabStop = true;
            this.about_kola124_link.Text = "SmartGoldbergEmu @ Kola\'s GitHub";
            this.about_kola124_link.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.KolasUrl_Clicked);
            // 
            // about_description_label
            // 
            this.about_description_label.AccessibleName = "about_description";
            this.about_description_label.AutoSize = true;
            this.about_description_label.Location = new System.Drawing.Point(147, 40);
            this.about_description_label.Name = "about_description_label";
            this.about_description_label.Size = new System.Drawing.Size(314, 13);
            this.about_description_label.TabIndex = 99;
            this.about_description_label.TabStop = true;
            this.about_description_label.Text = "By Kola124, inspired in Nemirtingas \"SmartSteamEmu Launcher\".";
            this.about_description_label.Click += new System.EventHandler(this.about_description_label_Click);
            // 
            // about_kola124_label
            // 
            this.about_kola124_label.AccessibleName = "Kola124_label";
            this.about_kola124_label.AutoSize = true;
            this.about_kola124_label.Location = new System.Drawing.Point(183, 97);
            this.about_kola124_label.Name = "about_kola124_label";
            this.about_kola124_label.Size = new System.Drawing.Size(49, 13);
            this.about_kola124_label.TabIndex = 101;
            this.about_kola124_label.TabStop = true;
            this.about_kola124_label.Text = "Kola124:";
            // 
            // about_nemirtingas_label
            // 
            this.about_nemirtingas_label.AccessibleName = "Nemirtingas_label";
            this.about_nemirtingas_label.AutoSize = true;
            this.about_nemirtingas_label.Location = new System.Drawing.Point(183, 79);
            this.about_nemirtingas_label.Name = "about_nemirtingas_label";
            this.about_nemirtingas_label.Size = new System.Drawing.Size(65, 13);
            this.about_nemirtingas_label.TabIndex = 102;
            this.about_nemirtingas_label.TabStop = true;
            this.about_nemirtingas_label.Text = "Nemirtingas:";
            // 
            // GivenToFly_Label
            // 
            this.GivenToFly_Label.AccessibleName = "about_description";
            this.GivenToFly_Label.AutoSize = true;
            this.GivenToFly_Label.Location = new System.Drawing.Point(147, 55);
            this.GivenToFly_Label.Name = "GivenToFly_Label";
            this.GivenToFly_Label.Size = new System.Drawing.Size(122, 13);
            this.GivenToFly_Label.TabIndex = 103;
            this.GivenToFly_Label.TabStop = true;
            this.GivenToFly_Label.Text = "Rev 2.2f by GivenToFly.";
            // 
            // rev22b_label
            // 
            this.rev22b_label.AccessibleName = "Nemirtingas_label";
            this.rev22b_label.AutoSize = true;
            this.rev22b_label.Location = new System.Drawing.Point(183, 115);
            this.rev22b_label.Name = "rev22b_label";
            this.rev22b_label.Size = new System.Drawing.Size(61, 13);
            this.rev22b_label.TabIndex = 105;
            this.rev22b_label.TabStop = true;
            this.rev22b_label.Text = "GivenToFly";
            // 
            // about_rev22b_label
            // 
            this.about_rev22b_label.AccessibleName = "Nemirtingas_link";
            this.about_rev22b_label.AutoSize = true;
            this.about_rev22b_label.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.about_rev22b_label.Location = new System.Drawing.Point(253, 115);
            this.about_rev22b_label.Name = "about_rev22b_label";
            this.about_rev22b_label.Size = new System.Drawing.Size(118, 13);
            this.about_rev22b_label.TabIndex = 104;
            this.about_rev22b_label.TabStop = true;
            this.about_rev22b_label.Text = "This release @ cs.rin.ru";
            this.about_rev22b_label.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GivenToFlysUrl_Clicked);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(554, 230);
            this.Controls.Add(this.rev22b_label);
            this.Controls.Add(this.about_rev22b_label);
            this.Controls.Add(this.GivenToFly_Label);
            this.Controls.Add(this.about_nemirtingas_label);
            this.Controls.Add(this.about_kola124_label);
            this.Controls.Add(this.about_description_label);
            this.Controls.Add(this.about_kola124_link);
            this.Controls.Add(this.about_nemirtingas_link);
            this.Controls.Add(this.about_title_label);
            this.Controls.Add(this.about_image_frame);
            this.Controls.Add(this.about_x64folder_brrn);
            this.Controls.Add(this.about_x32folder_bttn);
            this.Controls.Add(this.about_ok_bttn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "SmartGoldbergEmu Launcher";
            ((System.ComponentModel.ISupportInitialize)(this.about_image_frame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button about_ok_bttn;
        private System.Windows.Forms.Button about_x32folder_bttn;
        private System.Windows.Forms.Button about_x64folder_brrn;
        private System.Windows.Forms.PictureBox about_image_frame;
        private System.Windows.Forms.Label about_title_label;
        private System.Windows.Forms.LinkLabel about_nemirtingas_link;
        private System.Windows.Forms.LinkLabel about_kola124_link;
        private Label about_description_label;
        private Label about_kola124_label;
        private Label about_nemirtingas_label;
        private Label GivenToFly_Label;
        private Label rev22b_label;
        private LinkLabel about_rev22b_label;
    }
}