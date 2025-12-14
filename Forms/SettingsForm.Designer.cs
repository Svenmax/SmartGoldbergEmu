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

namespace SmartGoldbergEmu
{
    partial class SettingsForm
    {
        // Required designer variable.
        private System.ComponentModel.IContainer components = null;

        // Clean up any resources being used.
        // <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.components = new System.ComponentModel.Container();
            this.settings_Save_bttn = new System.Windows.Forms.Button();
            this.general_GetApiKey_bttn = new System.Windows.Forms.Button();
            this.settings_Cancel_bttn = new System.Windows.Forms.Button();
            this.sounds_notification = new System.Windows.Forms.TabControl();
            this.general_tab = new System.Windows.Forms.TabPage();
            this.ramoveAvatar_bttn = new System.Windows.Forms.Button();
            this.setting_randomizePort_bttn = new System.Windows.Forms.Button();
            this.general_webApiKey_box = new System.Windows.Forms.TextBox();
            this.general_avatar_bttn = new System.Windows.Forms.Button();
            this.general_webApiKey_label = new System.Windows.Forms.Label();
            this.general_avatar_frame = new System.Windows.Forms.PictureBox();
            this.general_port_label = new System.Windows.Forms.Label();
            this.general_language_label = new System.Windows.Forms.Label();
            this.general_language_box = new System.Windows.Forms.ComboBox();
            this.general_port_box = new System.Windows.Forms.TextBox();
            this.general_steamId_box = new System.Windows.Forms.TextBox();
            this.general_username_box = new System.Windows.Forms.TextBox();
            this.general_steamId_label = new System.Windows.Forms.Label();
            this.general_username_label = new System.Windows.Forms.Label();
            this.appearance_tab = new System.Windows.Forms.TabPage();
            this.appearance_chatPos_label = new System.Windows.Forms.Label();
            this.appearance_invPos_label = new System.Windows.Forms.Label();
            this.appearance_achPos_label = new System.Windows.Forms.Label();
            this.appearance_achPos_box = new System.Windows.Forms.ComboBox();
            this.appearance_invPos_box = new System.Windows.Forms.ComboBox();
            this.appearance_chatPos_box = new System.Windows.Forms.ComboBox();
            this.appearance_imageSize_box = new System.Windows.Forms.TextBox();
            this.appearance_imageSize_label = new System.Windows.Forms.Label();
            this.appearance_fontSize_box = new System.Windows.Forms.TextBox();
            this.appearance_fontSize_label = new System.Windows.Forms.Label();
            this.appearance_active_label1 = new System.Windows.Forms.Label();
            this.appearance_active_label = new System.Windows.Forms.Label();
            this.appearance_active_box = new System.Windows.Forms.TextBox();
            this.appearance_hover_label1 = new System.Windows.Forms.Label();
            this.appearance_hover_label = new System.Windows.Forms.Label();
            this.appearance_hover_box = new System.Windows.Forms.TextBox();
            this.appearance_element_label1 = new System.Windows.Forms.Label();
            this.appearance_element_label = new System.Windows.Forms.Label();
            this.appearance_element_box = new System.Windows.Forms.TextBox();
            this.appearance_background_label1 = new System.Windows.Forms.Label();
            this.appearance_background_label = new System.Windows.Forms.Label();
            this.appearance_background_box = new System.Windows.Forms.TextBox();
            this.appearance_notification_label1 = new System.Windows.Forms.Label();
            this.appearance_notification_label = new System.Windows.Forms.Label();
            this.appearance_notification_box = new System.Windows.Forms.TextBox();
            this.sound_tab = new System.Windows.Forms.TabPage();
            this.sounds_fontSpacingY_label = new System.Windows.Forms.Label();
            this.sounds_fontSpacingX_label = new System.Windows.Forms.Label();
            this.sounds_fontSpacingY_box = new System.Windows.Forms.TextBox();
            this.sounds_fontSpacingX_box = new System.Windows.Forms.TextBox();
            this.sounds_deleteFont_bttn = new System.Windows.Forms.Button();
            this.sounds_changeFont_bttn = new System.Windows.Forms.Button();
            this.sounds_font_label = new System.Windows.Forms.Label();
            this.sounds_deleteAlertSound_bttn = new System.Windows.Forms.Button();
            this.sounds_deleteFriendSound_bttn = new System.Windows.Forms.Button();
            this.sounds_changeAlertSound_bttn = new System.Windows.Forms.Button();
            this.sounds_changeFriendSound_bttn = new System.Windows.Forms.Button();
            this.sound_alert_label = new System.Windows.Forms.Label();
            this.sounds_friend_label = new System.Windows.Forms.Label();
            this.notification_tab = new System.Windows.Forms.TabPage();
            this.notification_inviteDuration_label = new System.Windows.Forms.Label();
            this.notification_inviteDuration_box = new System.Windows.Forms.TextBox();
            this.notification_chatDuration_box = new System.Windows.Forms.TextBox();
            this.notification_progressDuration_box = new System.Windows.Forms.TextBox();
            this.notification_achDuration_box = new System.Windows.Forms.TextBox();
            this.notification_marginY_box = new System.Windows.Forms.TextBox();
            this.notification_marginX_box = new System.Windows.Forms.TextBox();
            this.notification_animation_box = new System.Windows.Forms.TextBox();
            this.notification_rounding_box = new System.Windows.Forms.TextBox();
            this.notification_achDuration_label = new System.Windows.Forms.Label();
            this.notification_chatDuration_label = new System.Windows.Forms.Label();
            this.notification_progressDuration_label = new System.Windows.Forms.Label();
            this.notification_animation_label = new System.Windows.Forms.Label();
            this.notification_marginY_label = new System.Windows.Forms.Label();
            this.notification_marginX_label = new System.Windows.Forms.Label();
            this.notification_rounding_label = new System.Windows.Forms.Label();
            this.getApiKey = new System.Windows.Forms.ToolTip(this.components);
            this.randomizePort = new System.Windows.Forms.ToolTip(this.components);
            this.removeAvatarBttn = new System.Windows.Forms.ToolTip(this.components);
            this.setAvatarBttn = new System.Windows.Forms.ToolTip(this.components);
            this.sounds_notification.SuspendLayout();
            this.general_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.general_avatar_frame)).BeginInit();
            this.appearance_tab.SuspendLayout();
            this.sound_tab.SuspendLayout();
            this.notification_tab.SuspendLayout();
            this.SuspendLayout();
            // 
            // settings_Save_bttn
            // 
            this.settings_Save_bttn.Location = new System.Drawing.Point(300, 178);
            this.settings_Save_bttn.Name = "settings_Save_bttn";
            this.settings_Save_bttn.Size = new System.Drawing.Size(75, 23);
            this.settings_Save_bttn.TabIndex = 98;
            this.settings_Save_bttn.Text = "Save";
            this.settings_Save_bttn.UseVisualStyleBackColor = true;
            this.settings_Save_bttn.Click += new System.EventHandler(this.Save_button_Click);
            // 
            // general_GetApiKey_bttn
            // 
            this.general_GetApiKey_bttn.Location = new System.Drawing.Point(398, 86);
            this.general_GetApiKey_bttn.Name = "general_GetApiKey_bttn";
            this.general_GetApiKey_bttn.Size = new System.Drawing.Size(22, 23);
            this.general_GetApiKey_bttn.TabIndex = 8;
            this.general_GetApiKey_bttn.Text = "🔑";
            this.getApiKey.SetToolTip(this.general_GetApiKey_bttn, "Get API key from Steam.");
            this.general_GetApiKey_bttn.UseVisualStyleBackColor = true;
            this.general_GetApiKey_bttn.Click += new System.EventHandler(this.ApiKeyBttn_Click);
            // 
            // settings_Cancel_bttn
            // 
            this.settings_Cancel_bttn.Location = new System.Drawing.Point(381, 178);
            this.settings_Cancel_bttn.Name = "settings_Cancel_bttn";
            this.settings_Cancel_bttn.Size = new System.Drawing.Size(75, 23);
            this.settings_Cancel_bttn.TabIndex = 99;
            this.settings_Cancel_bttn.Text = "Cancel";
            this.settings_Cancel_bttn.UseVisualStyleBackColor = true;
            this.settings_Cancel_bttn.Click += new System.EventHandler(this.Cancel_button_Click);
            // 
            // sounds_notification
            // 
            this.sounds_notification.Controls.Add(this.general_tab);
            this.sounds_notification.Controls.Add(this.appearance_tab);
            this.sounds_notification.Controls.Add(this.sound_tab);
            this.sounds_notification.Controls.Add(this.notification_tab);
            this.sounds_notification.Location = new System.Drawing.Point(13, 5);
            this.sounds_notification.Name = "sounds_notification";
            this.sounds_notification.SelectedIndex = 0;
            this.sounds_notification.Size = new System.Drawing.Size(447, 167);
            this.sounds_notification.TabIndex = 1;
            // 
            // general_tab
            // 
            this.general_tab.BackColor = System.Drawing.SystemColors.Control;
            this.general_tab.Controls.Add(this.ramoveAvatar_bttn);
            this.general_tab.Controls.Add(this.setting_randomizePort_bttn);
            this.general_tab.Controls.Add(this.general_webApiKey_box);
            this.general_tab.Controls.Add(this.general_avatar_bttn);
            this.general_tab.Controls.Add(this.general_webApiKey_label);
            this.general_tab.Controls.Add(this.general_avatar_frame);
            this.general_tab.Controls.Add(this.general_port_label);
            this.general_tab.Controls.Add(this.general_language_label);
            this.general_tab.Controls.Add(this.general_GetApiKey_bttn);
            this.general_tab.Controls.Add(this.general_language_box);
            this.general_tab.Controls.Add(this.general_port_box);
            this.general_tab.Controls.Add(this.general_steamId_box);
            this.general_tab.Controls.Add(this.general_username_box);
            this.general_tab.Controls.Add(this.general_steamId_label);
            this.general_tab.Controls.Add(this.general_username_label);
            this.general_tab.Location = new System.Drawing.Point(4, 22);
            this.general_tab.Name = "general_tab";
            this.general_tab.Padding = new System.Windows.Forms.Padding(3);
            this.general_tab.Size = new System.Drawing.Size(439, 141);
            this.general_tab.TabIndex = 0;
            this.general_tab.Text = "General";
            // 
            // ramoveAvatar_bttn
            // 
            this.ramoveAvatar_bttn.Location = new System.Drawing.Point(83, 110);
            this.ramoveAvatar_bttn.Name = "ramoveAvatar_bttn";
            this.ramoveAvatar_bttn.Size = new System.Drawing.Size(17, 24);
            this.ramoveAvatar_bttn.TabIndex = 3;
            this.ramoveAvatar_bttn.Text = "❌";
            this.removeAvatarBttn.SetToolTip(this.ramoveAvatar_bttn, "Set avatar to default image.");
            this.ramoveAvatar_bttn.UseVisualStyleBackColor = true;
            this.ramoveAvatar_bttn.Click += new System.EventHandler(this.ramoveAvatar_bttn_Click);
            // 
            // setting_randomizePort_bttn
            // 
            this.setting_randomizePort_bttn.Location = new System.Drawing.Point(225, 112);
            this.setting_randomizePort_bttn.Name = "setting_randomizePort_bttn";
            this.setting_randomizePort_bttn.Size = new System.Drawing.Size(22, 23);
            this.setting_randomizePort_bttn.TabIndex = 10;
            this.setting_randomizePort_bttn.Text = "♻️";
            this.randomizePort.SetToolTip(this.setting_randomizePort_bttn, "Randomize port.");
            this.setting_randomizePort_bttn.UseVisualStyleBackColor = true;
            this.setting_randomizePort_bttn.Click += new System.EventHandler(this.setting_randomizePort_bttn_Click);
            // 
            // general_webApiKey_box
            // 
            this.general_webApiKey_box.Location = new System.Drawing.Point(175, 88);
            this.general_webApiKey_box.MaxLength = 32;
            this.general_webApiKey_box.Name = "general_webApiKey_box";
            this.general_webApiKey_box.Size = new System.Drawing.Size(217, 20);
            this.general_webApiKey_box.TabIndex = 7;
            this.general_webApiKey_box.TextChanged += new System.EventHandler(this.webapi_key_edit_TextChanged);
            // 
            // general_avatar_bttn
            // 
            this.general_avatar_bttn.Location = new System.Drawing.Point(6, 110);
            this.general_avatar_bttn.Name = "general_avatar_bttn";
            this.general_avatar_bttn.Size = new System.Drawing.Size(76, 24);
            this.general_avatar_bttn.TabIndex = 2;
            this.general_avatar_bttn.Text = "Set Avatar";
            this.setAvatarBttn.SetToolTip(this.general_avatar_bttn, "Select avatar image.");
            this.general_avatar_bttn.UseVisualStyleBackColor = true;
            this.general_avatar_bttn.Click += new System.EventHandler(this.AvatarChange_Click);
            // 
            // general_webApiKey_label
            // 
            this.general_webApiKey_label.AutoSize = true;
            this.general_webApiKey_label.Location = new System.Drawing.Point(103, 91);
            this.general_webApiKey_label.Name = "general_webApiKey_label";
            this.general_webApiKey_label.Size = new System.Drawing.Size(74, 13);
            this.general_webApiKey_label.TabIndex = 27;
            this.general_webApiKey_label.Text = "Web API Key:";
            // 
            // general_avatar_frame
            // 
            this.general_avatar_frame.Image = global::SmartGoldbergEmu.Properties.Resources.account_avatar;
            this.general_avatar_frame.ImageLocation = "";
            this.general_avatar_frame.Location = new System.Drawing.Point(6, 14);
            this.general_avatar_frame.Name = "general_avatar_frame";
            this.general_avatar_frame.Size = new System.Drawing.Size(94, 94);
            this.general_avatar_frame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.general_avatar_frame.TabIndex = 26;
            this.general_avatar_frame.TabStop = false;
            // 
            // general_port_label
            // 
            this.general_port_label.AutoSize = true;
            this.general_port_label.Location = new System.Drawing.Point(103, 117);
            this.general_port_label.Name = "general_port_label";
            this.general_port_label.Size = new System.Drawing.Size(29, 13);
            this.general_port_label.TabIndex = 18;
            this.general_port_label.Text = "Port:";
            // 
            // general_language_label
            // 
            this.general_language_label.AutoSize = true;
            this.general_language_label.Location = new System.Drawing.Point(103, 64);
            this.general_language_label.Name = "general_language_label";
            this.general_language_label.Size = new System.Drawing.Size(58, 13);
            this.general_language_label.TabIndex = 17;
            this.general_language_label.Text = "Language:";
            // 
            // general_language_box
            // 
            this.general_language_box.FormattingEnabled = true;
            this.general_language_box.Location = new System.Drawing.Point(175, 61);
            this.general_language_box.Name = "general_language_box";
            this.general_language_box.Size = new System.Drawing.Size(245, 21);
            this.general_language_box.TabIndex = 6;
            // 
            // general_port_box
            // 
            this.general_port_box.Location = new System.Drawing.Point(175, 114);
            this.general_port_box.MaxLength = 5;
            this.general_port_box.Name = "general_port_box";
            this.general_port_box.Size = new System.Drawing.Size(44, 20);
            this.general_port_box.TabIndex = 9;
            // 
            // general_steamId_box
            // 
            this.general_steamId_box.Location = new System.Drawing.Point(175, 35);
            this.general_steamId_box.Name = "general_steamId_box";
            this.general_steamId_box.Size = new System.Drawing.Size(245, 20);
            this.general_steamId_box.TabIndex = 5;
            // 
            // general_username_box
            // 
            this.general_username_box.Location = new System.Drawing.Point(175, 9);
            this.general_username_box.MaxLength = 32;
            this.general_username_box.Name = "general_username_box";
            this.general_username_box.Size = new System.Drawing.Size(245, 20);
            this.general_username_box.TabIndex = 4;
            // 
            // general_steamId_label
            // 
            this.general_steamId_label.AutoSize = true;
            this.general_steamId_label.Location = new System.Drawing.Point(103, 38);
            this.general_steamId_label.Name = "general_steamId_label";
            this.general_steamId_label.Size = new System.Drawing.Size(51, 13);
            this.general_steamId_label.TabIndex = 16;
            this.general_steamId_label.Text = "SteamID:";
            // 
            // general_username_label
            // 
            this.general_username_label.AccessibleName = "Username";
            this.general_username_label.AutoSize = true;
            this.general_username_label.Location = new System.Drawing.Point(103, 12);
            this.general_username_label.Name = "general_username_label";
            this.general_username_label.Size = new System.Drawing.Size(58, 13);
            this.general_username_label.TabIndex = 15;
            this.general_username_label.Text = "Username:";
            // 
            // appearance_tab
            // 
            this.appearance_tab.BackColor = System.Drawing.SystemColors.Control;
            this.appearance_tab.Controls.Add(this.appearance_chatPos_label);
            this.appearance_tab.Controls.Add(this.appearance_invPos_label);
            this.appearance_tab.Controls.Add(this.appearance_achPos_label);
            this.appearance_tab.Controls.Add(this.appearance_achPos_box);
            this.appearance_tab.Controls.Add(this.appearance_invPos_box);
            this.appearance_tab.Controls.Add(this.appearance_chatPos_box);
            this.appearance_tab.Controls.Add(this.appearance_imageSize_box);
            this.appearance_tab.Controls.Add(this.appearance_imageSize_label);
            this.appearance_tab.Controls.Add(this.appearance_fontSize_box);
            this.appearance_tab.Controls.Add(this.appearance_fontSize_label);
            this.appearance_tab.Controls.Add(this.appearance_active_label1);
            this.appearance_tab.Controls.Add(this.appearance_active_label);
            this.appearance_tab.Controls.Add(this.appearance_active_box);
            this.appearance_tab.Controls.Add(this.appearance_hover_label1);
            this.appearance_tab.Controls.Add(this.appearance_hover_label);
            this.appearance_tab.Controls.Add(this.appearance_hover_box);
            this.appearance_tab.Controls.Add(this.appearance_element_label1);
            this.appearance_tab.Controls.Add(this.appearance_element_label);
            this.appearance_tab.Controls.Add(this.appearance_element_box);
            this.appearance_tab.Controls.Add(this.appearance_background_label1);
            this.appearance_tab.Controls.Add(this.appearance_background_label);
            this.appearance_tab.Controls.Add(this.appearance_background_box);
            this.appearance_tab.Controls.Add(this.appearance_notification_label1);
            this.appearance_tab.Controls.Add(this.appearance_notification_label);
            this.appearance_tab.Controls.Add(this.appearance_notification_box);
            this.appearance_tab.Location = new System.Drawing.Point(4, 22);
            this.appearance_tab.Name = "appearance_tab";
            this.appearance_tab.Padding = new System.Windows.Forms.Padding(3);
            this.appearance_tab.Size = new System.Drawing.Size(439, 141);
            this.appearance_tab.TabIndex = 1;
            this.appearance_tab.Text = "Appearance";
            // 
            // appearance_chatPos_label
            // 
            this.appearance_chatPos_label.AutoSize = true;
            this.appearance_chatPos_label.Location = new System.Drawing.Point(296, 117);
            this.appearance_chatPos_label.Name = "appearance_chatPos_label";
            this.appearance_chatPos_label.Size = new System.Drawing.Size(69, 13);
            this.appearance_chatPos_label.TabIndex = 61;
            this.appearance_chatPos_label.Text = "Chat Position";
            // 
            // appearance_invPos_label
            // 
            this.appearance_invPos_label.AutoSize = true;
            this.appearance_invPos_label.Location = new System.Drawing.Point(296, 91);
            this.appearance_invPos_label.Name = "appearance_invPos_label";
            this.appearance_invPos_label.Size = new System.Drawing.Size(62, 13);
            this.appearance_invPos_label.TabIndex = 60;
            this.appearance_invPos_label.Text = "Inv Position";
            // 
            // appearance_achPos_label
            // 
            this.appearance_achPos_label.AutoSize = true;
            this.appearance_achPos_label.Location = new System.Drawing.Point(296, 65);
            this.appearance_achPos_label.Name = "appearance_achPos_label";
            this.appearance_achPos_label.Size = new System.Drawing.Size(66, 13);
            this.appearance_achPos_label.TabIndex = 59;
            this.appearance_achPos_label.Text = "Ach Position";
            // 
            // appearance_achPos_box
            // 
            this.appearance_achPos_box.FormattingEnabled = true;
            this.appearance_achPos_box.Items.AddRange(new object[] {
            "top_left",
            "top_center",
            "top_right",
            "bot_left",
            "bot_center",
            "bot_right"});
            this.appearance_achPos_box.Location = new System.Drawing.Point(368, 62);
            this.appearance_achPos_box.Name = "appearance_achPos_box";
            this.appearance_achPos_box.Size = new System.Drawing.Size(65, 21);
            this.appearance_achPos_box.TabIndex = 9;
            // 
            // appearance_invPos_box
            // 
            this.appearance_invPos_box.FormattingEnabled = true;
            this.appearance_invPos_box.Items.AddRange(new object[] {
            "top_left",
            "top_center",
            "top_right",
            "bot_left",
            "bot_center",
            "bot_right"});
            this.appearance_invPos_box.Location = new System.Drawing.Point(368, 87);
            this.appearance_invPos_box.Name = "appearance_invPos_box";
            this.appearance_invPos_box.Size = new System.Drawing.Size(65, 21);
            this.appearance_invPos_box.TabIndex = 10;
            // 
            // appearance_chatPos_box
            // 
            this.appearance_chatPos_box.FormattingEnabled = true;
            this.appearance_chatPos_box.Items.AddRange(new object[] {
            "top_left",
            "top_center",
            "top_right",
            "bot_left",
            "bot_center",
            "bot_right"});
            this.appearance_chatPos_box.Location = new System.Drawing.Point(368, 113);
            this.appearance_chatPos_box.Name = "appearance_chatPos_box";
            this.appearance_chatPos_box.Size = new System.Drawing.Size(65, 21);
            this.appearance_chatPos_box.TabIndex = 11;
            this.appearance_chatPos_box.SelectedIndexChanged += new System.EventHandler(this.PosMsg_Dropdown_SelectedIndexChanged);
            // 
            // appearance_imageSize_box
            // 
            this.appearance_imageSize_box.Location = new System.Drawing.Point(368, 36);
            this.appearance_imageSize_box.Name = "appearance_imageSize_box";
            this.appearance_imageSize_box.Size = new System.Drawing.Size(38, 20);
            this.appearance_imageSize_box.TabIndex = 8;
            // 
            // appearance_imageSize_label
            // 
            this.appearance_imageSize_label.AutoSize = true;
            this.appearance_imageSize_label.Location = new System.Drawing.Point(303, 39);
            this.appearance_imageSize_label.Name = "appearance_imageSize_label";
            this.appearance_imageSize_label.Size = new System.Drawing.Size(59, 13);
            this.appearance_imageSize_label.TabIndex = 44;
            this.appearance_imageSize_label.Text = "Image Size";
            // 
            // appearance_fontSize_box
            // 
            this.appearance_fontSize_box.Location = new System.Drawing.Point(368, 10);
            this.appearance_fontSize_box.Name = "appearance_fontSize_box";
            this.appearance_fontSize_box.Size = new System.Drawing.Size(38, 20);
            this.appearance_fontSize_box.TabIndex = 7;
            // 
            // appearance_fontSize_label
            // 
            this.appearance_fontSize_label.AutoSize = true;
            this.appearance_fontSize_label.Location = new System.Drawing.Point(311, 13);
            this.appearance_fontSize_label.Name = "appearance_fontSize_label";
            this.appearance_fontSize_label.Size = new System.Drawing.Size(51, 13);
            this.appearance_fontSize_label.TabIndex = 42;
            this.appearance_fontSize_label.Text = "Font Size";
            // 
            // appearance_active_label1
            // 
            this.appearance_active_label1.AutoSize = true;
            this.appearance_active_label1.Location = new System.Drawing.Point(123, 117);
            this.appearance_active_label1.Name = "appearance_active_label1";
            this.appearance_active_label1.Size = new System.Drawing.Size(46, 13);
            this.appearance_active_label1.TabIndex = 41;
            this.appearance_active_label1.Text = "R,G,B,A";
            // 
            // appearance_active_label
            // 
            this.appearance_active_label.AutoSize = true;
            this.appearance_active_label.Location = new System.Drawing.Point(16, 117);
            this.appearance_active_label.Name = "appearance_active_label";
            this.appearance_active_label.Size = new System.Drawing.Size(78, 13);
            this.appearance_active_label.TabIndex = 40;
            this.appearance_active_label.Text = "Element Active";
            // 
            // appearance_active_box
            // 
            this.appearance_active_box.Location = new System.Drawing.Point(175, 114);
            this.appearance_active_box.Name = "appearance_active_box";
            this.appearance_active_box.Size = new System.Drawing.Size(117, 20);
            this.appearance_active_box.TabIndex = 6;
            // 
            // appearance_hover_label1
            // 
            this.appearance_hover_label1.AutoSize = true;
            this.appearance_hover_label1.Location = new System.Drawing.Point(123, 91);
            this.appearance_hover_label1.Name = "appearance_hover_label1";
            this.appearance_hover_label1.Size = new System.Drawing.Size(46, 13);
            this.appearance_hover_label1.TabIndex = 32;
            this.appearance_hover_label1.Text = "R,G,B,A";
            // 
            // appearance_hover_label
            // 
            this.appearance_hover_label.AutoSize = true;
            this.appearance_hover_label.Location = new System.Drawing.Point(16, 91);
            this.appearance_hover_label.Name = "appearance_hover_label";
            this.appearance_hover_label.Size = new System.Drawing.Size(89, 13);
            this.appearance_hover_label.TabIndex = 31;
            this.appearance_hover_label.Text = "Element Hovered";
            // 
            // appearance_hover_box
            // 
            this.appearance_hover_box.Location = new System.Drawing.Point(175, 88);
            this.appearance_hover_box.Name = "appearance_hover_box";
            this.appearance_hover_box.Size = new System.Drawing.Size(117, 20);
            this.appearance_hover_box.TabIndex = 5;
            // 
            // appearance_element_label1
            // 
            this.appearance_element_label1.AutoSize = true;
            this.appearance_element_label1.Location = new System.Drawing.Point(123, 65);
            this.appearance_element_label1.Name = "appearance_element_label1";
            this.appearance_element_label1.Size = new System.Drawing.Size(46, 13);
            this.appearance_element_label1.TabIndex = 23;
            this.appearance_element_label1.Text = "R,G,B,A";
            // 
            // appearance_element_label
            // 
            this.appearance_element_label.AutoSize = true;
            this.appearance_element_label.Location = new System.Drawing.Point(16, 65);
            this.appearance_element_label.Name = "appearance_element_label";
            this.appearance_element_label.Size = new System.Drawing.Size(45, 13);
            this.appearance_element_label.TabIndex = 22;
            this.appearance_element_label.Text = "Element";
            // 
            // appearance_element_box
            // 
            this.appearance_element_box.Location = new System.Drawing.Point(175, 62);
            this.appearance_element_box.Name = "appearance_element_box";
            this.appearance_element_box.Size = new System.Drawing.Size(117, 20);
            this.appearance_element_box.TabIndex = 4;
            // 
            // appearance_background_label1
            // 
            this.appearance_background_label1.AutoSize = true;
            this.appearance_background_label1.Location = new System.Drawing.Point(123, 39);
            this.appearance_background_label1.Name = "appearance_background_label1";
            this.appearance_background_label1.Size = new System.Drawing.Size(46, 13);
            this.appearance_background_label1.TabIndex = 14;
            this.appearance_background_label1.Text = "R,G,B,A";
            // 
            // appearance_background_label
            // 
            this.appearance_background_label.AutoSize = true;
            this.appearance_background_label.Location = new System.Drawing.Point(16, 39);
            this.appearance_background_label.Name = "appearance_background_label";
            this.appearance_background_label.Size = new System.Drawing.Size(65, 13);
            this.appearance_background_label.TabIndex = 13;
            this.appearance_background_label.Text = "Background";
            // 
            // appearance_background_box
            // 
            this.appearance_background_box.Location = new System.Drawing.Point(175, 36);
            this.appearance_background_box.Name = "appearance_background_box";
            this.appearance_background_box.Size = new System.Drawing.Size(117, 20);
            this.appearance_background_box.TabIndex = 3;
            this.appearance_background_box.TextChanged += new System.EventHandler(this.appearance_background_box_TextChanged);
            // 
            // appearance_notification_label1
            // 
            this.appearance_notification_label1.AutoSize = true;
            this.appearance_notification_label1.Location = new System.Drawing.Point(123, 13);
            this.appearance_notification_label1.Name = "appearance_notification_label1";
            this.appearance_notification_label1.Size = new System.Drawing.Size(46, 13);
            this.appearance_notification_label1.TabIndex = 5;
            this.appearance_notification_label1.Text = "R,G,B,A";
            // 
            // appearance_notification_label
            // 
            this.appearance_notification_label.AutoSize = true;
            this.appearance_notification_label.Location = new System.Drawing.Point(16, 13);
            this.appearance_notification_label.Name = "appearance_notification_label";
            this.appearance_notification_label.Size = new System.Drawing.Size(60, 13);
            this.appearance_notification_label.TabIndex = 4;
            this.appearance_notification_label.Text = "Notification";
            // 
            // appearance_notification_box
            // 
            this.appearance_notification_box.Location = new System.Drawing.Point(175, 10);
            this.appearance_notification_box.Name = "appearance_notification_box";
            this.appearance_notification_box.Size = new System.Drawing.Size(117, 20);
            this.appearance_notification_box.TabIndex = 2;
            // 
            // sound_tab
            // 
            this.sound_tab.BackColor = System.Drawing.SystemColors.Control;
            this.sound_tab.Controls.Add(this.sounds_fontSpacingY_label);
            this.sound_tab.Controls.Add(this.sounds_fontSpacingX_label);
            this.sound_tab.Controls.Add(this.sounds_fontSpacingY_box);
            this.sound_tab.Controls.Add(this.sounds_fontSpacingX_box);
            this.sound_tab.Controls.Add(this.sounds_deleteFont_bttn);
            this.sound_tab.Controls.Add(this.sounds_changeFont_bttn);
            this.sound_tab.Controls.Add(this.sounds_font_label);
            this.sound_tab.Controls.Add(this.sounds_deleteAlertSound_bttn);
            this.sound_tab.Controls.Add(this.sounds_deleteFriendSound_bttn);
            this.sound_tab.Controls.Add(this.sounds_changeAlertSound_bttn);
            this.sound_tab.Controls.Add(this.sounds_changeFriendSound_bttn);
            this.sound_tab.Controls.Add(this.sound_alert_label);
            this.sound_tab.Controls.Add(this.sounds_friend_label);
            this.sound_tab.Location = new System.Drawing.Point(4, 22);
            this.sound_tab.Name = "sound_tab";
            this.sound_tab.Size = new System.Drawing.Size(439, 141);
            this.sound_tab.TabIndex = 2;
            this.sound_tab.Text = "Sound and Font";
            this.sound_tab.Click += new System.EventHandler(this.setting_sound_tab_Click);
            // 
            // sounds_fontSpacingY_label
            // 
            this.sounds_fontSpacingY_label.AutoSize = true;
            this.sounds_fontSpacingY_label.Location = new System.Drawing.Point(235, 106);
            this.sounds_fontSpacingY_label.Name = "sounds_fontSpacingY_label";
            this.sounds_fontSpacingY_label.Size = new System.Drawing.Size(83, 13);
            this.sounds_fontSpacingY_label.TabIndex = 36;
            this.sounds_fontSpacingY_label.Text = "Font Spacing Y:";
            // 
            // sounds_fontSpacingX_label
            // 
            this.sounds_fontSpacingX_label.AutoSize = true;
            this.sounds_fontSpacingX_label.Location = new System.Drawing.Point(235, 79);
            this.sounds_fontSpacingX_label.Name = "sounds_fontSpacingX_label";
            this.sounds_fontSpacingX_label.Size = new System.Drawing.Size(83, 13);
            this.sounds_fontSpacingX_label.TabIndex = 35;
            this.sounds_fontSpacingX_label.Text = "Font Spacing X:";
            // 
            // sounds_fontSpacingY_box
            // 
            this.sounds_fontSpacingY_box.Location = new System.Drawing.Point(329, 102);
            this.sounds_fontSpacingY_box.Name = "sounds_fontSpacingY_box";
            this.sounds_fontSpacingY_box.Size = new System.Drawing.Size(86, 20);
            this.sounds_fontSpacingY_box.TabIndex = 10;
            this.sounds_fontSpacingY_box.TextChanged += new System.EventHandler(this.fontSpacingY_settings_sound_edit_TextChanged);
            // 
            // sounds_fontSpacingX_box
            // 
            this.sounds_fontSpacingX_box.Location = new System.Drawing.Point(329, 76);
            this.sounds_fontSpacingX_box.Name = "sounds_fontSpacingX_box";
            this.sounds_fontSpacingX_box.Size = new System.Drawing.Size(86, 20);
            this.sounds_fontSpacingX_box.TabIndex = 9;
            this.sounds_fontSpacingX_box.TextChanged += new System.EventHandler(this.sounds_fontSpacingX_box_TextChanged);
            // 
            // sounds_deleteFont_bttn
            // 
            this.sounds_deleteFont_bttn.Location = new System.Drawing.Point(322, 29);
            this.sounds_deleteFont_bttn.Name = "sounds_deleteFont_bttn";
            this.sounds_deleteFont_bttn.Size = new System.Drawing.Size(94, 31);
            this.sounds_deleteFont_bttn.TabIndex = 8;
            this.sounds_deleteFont_bttn.Text = "Clear Font";
            this.sounds_deleteFont_bttn.UseVisualStyleBackColor = true;
            this.sounds_deleteFont_bttn.Click += new System.EventHandler(this.DelFontButton_Click);
            // 
            // sounds_changeFont_bttn
            // 
            this.sounds_changeFont_bttn.Location = new System.Drawing.Point(222, 29);
            this.sounds_changeFont_bttn.Name = "sounds_changeFont_bttn";
            this.sounds_changeFont_bttn.Size = new System.Drawing.Size(94, 31);
            this.sounds_changeFont_bttn.TabIndex = 7;
            this.sounds_changeFont_bttn.Text = "Set Font";
            this.sounds_changeFont_bttn.UseVisualStyleBackColor = true;
            this.sounds_changeFont_bttn.Click += new System.EventHandler(this.AddFontButton_Click);
            // 
            // sounds_font_label
            // 
            this.sounds_font_label.AutoSize = true;
            this.sounds_font_label.Location = new System.Drawing.Point(219, 13);
            this.sounds_font_label.Name = "sounds_font_label";
            this.sounds_font_label.Size = new System.Drawing.Size(28, 13);
            this.sounds_font_label.TabIndex = 30;
            this.sounds_font_label.Text = "Font";
            // 
            // sounds_deleteAlertSound_bttn
            // 
            this.sounds_deleteAlertSound_bttn.Location = new System.Drawing.Point(119, 90);
            this.sounds_deleteAlertSound_bttn.Name = "sounds_deleteAlertSound_bttn";
            this.sounds_deleteAlertSound_bttn.Size = new System.Drawing.Size(94, 29);
            this.sounds_deleteAlertSound_bttn.TabIndex = 6;
            this.sounds_deleteAlertSound_bttn.Text = "Clear Sound";
            this.sounds_deleteAlertSound_bttn.UseVisualStyleBackColor = true;
            this.sounds_deleteAlertSound_bttn.Click += new System.EventHandler(this.DelAchSoundButton_Click);
            // 
            // sounds_deleteFriendSound_bttn
            // 
            this.sounds_deleteFriendSound_bttn.Location = new System.Drawing.Point(119, 29);
            this.sounds_deleteFriendSound_bttn.Name = "sounds_deleteFriendSound_bttn";
            this.sounds_deleteFriendSound_bttn.Size = new System.Drawing.Size(94, 31);
            this.sounds_deleteFriendSound_bttn.TabIndex = 3;
            this.sounds_deleteFriendSound_bttn.Text = "Clear Sound";
            this.sounds_deleteFriendSound_bttn.UseVisualStyleBackColor = true;
            this.sounds_deleteFriendSound_bttn.Click += new System.EventHandler(this.DelFriendSundButton_Click);
            // 
            // sounds_changeAlertSound_bttn
            // 
            this.sounds_changeAlertSound_bttn.Location = new System.Drawing.Point(19, 90);
            this.sounds_changeAlertSound_bttn.Name = "sounds_changeAlertSound_bttn";
            this.sounds_changeAlertSound_bttn.Size = new System.Drawing.Size(94, 29);
            this.sounds_changeAlertSound_bttn.TabIndex = 4;
            this.sounds_changeAlertSound_bttn.Text = "Set Sound";
            this.sounds_changeAlertSound_bttn.UseVisualStyleBackColor = true;
            this.sounds_changeAlertSound_bttn.Click += new System.EventHandler(this.AddAchSoundButton_Click);
            // 
            // sounds_changeFriendSound_bttn
            // 
            this.sounds_changeFriendSound_bttn.AccessibleDescription = "Change Sound bttn 1";
            this.sounds_changeFriendSound_bttn.AccessibleName = "Change Sound bttn 2";
            this.sounds_changeFriendSound_bttn.Location = new System.Drawing.Point(19, 29);
            this.sounds_changeFriendSound_bttn.Name = "sounds_changeFriendSound_bttn";
            this.sounds_changeFriendSound_bttn.Size = new System.Drawing.Size(94, 31);
            this.sounds_changeFriendSound_bttn.TabIndex = 2;
            this.sounds_changeFriendSound_bttn.Text = "Set Sound";
            this.sounds_changeFriendSound_bttn.UseVisualStyleBackColor = true;
            this.sounds_changeFriendSound_bttn.Click += new System.EventHandler(this.addfriendsoundbutton_Click);
            // 
            // sound_alert_label
            // 
            this.sound_alert_label.AutoSize = true;
            this.sound_alert_label.Location = new System.Drawing.Point(16, 74);
            this.sound_alert_label.Name = "sound_alert_label";
            this.sound_alert_label.Size = new System.Drawing.Size(125, 13);
            this.sound_alert_label.TabIndex = 6;
            this.sound_alert_label.Text = "Achievement Notification";
            // 
            // sounds_friend_label
            // 
            this.sounds_friend_label.AutoSize = true;
            this.sounds_friend_label.Location = new System.Drawing.Point(16, 13);
            this.sounds_friend_label.Name = "sounds_friend_label";
            this.sounds_friend_label.Size = new System.Drawing.Size(92, 13);
            this.sounds_friend_label.TabIndex = 5;
            this.sounds_friend_label.Text = "Friend Notification";
            // 
            // notification_tab
            // 
            this.notification_tab.BackColor = System.Drawing.SystemColors.Control;
            this.notification_tab.Controls.Add(this.notification_inviteDuration_label);
            this.notification_tab.Controls.Add(this.notification_inviteDuration_box);
            this.notification_tab.Controls.Add(this.notification_chatDuration_box);
            this.notification_tab.Controls.Add(this.notification_progressDuration_box);
            this.notification_tab.Controls.Add(this.notification_achDuration_box);
            this.notification_tab.Controls.Add(this.notification_marginY_box);
            this.notification_tab.Controls.Add(this.notification_marginX_box);
            this.notification_tab.Controls.Add(this.notification_animation_box);
            this.notification_tab.Controls.Add(this.notification_rounding_box);
            this.notification_tab.Controls.Add(this.notification_achDuration_label);
            this.notification_tab.Controls.Add(this.notification_chatDuration_label);
            this.notification_tab.Controls.Add(this.notification_progressDuration_label);
            this.notification_tab.Controls.Add(this.notification_animation_label);
            this.notification_tab.Controls.Add(this.notification_marginY_label);
            this.notification_tab.Controls.Add(this.notification_marginX_label);
            this.notification_tab.Controls.Add(this.notification_rounding_label);
            this.notification_tab.Location = new System.Drawing.Point(4, 22);
            this.notification_tab.Name = "notification_tab";
            this.notification_tab.Size = new System.Drawing.Size(439, 141);
            this.notification_tab.TabIndex = 3;
            this.notification_tab.Text = "Notifications";
            // 
            // notification_inviteDuration_label
            // 
            this.notification_inviteDuration_label.AutoSize = true;
            this.notification_inviteDuration_label.Location = new System.Drawing.Point(195, 65);
            this.notification_inviteDuration_label.Name = "notification_inviteDuration_label";
            this.notification_inviteDuration_label.Size = new System.Drawing.Size(76, 13);
            this.notification_inviteDuration_label.TabIndex = 52;
            this.notification_inviteDuration_label.Text = "Invite Duration";
            // 
            // notification_inviteDuration_box
            // 
            this.notification_inviteDuration_box.Location = new System.Drawing.Point(313, 62);
            this.notification_inviteDuration_box.Name = "notification_inviteDuration_box";
            this.notification_inviteDuration_box.Size = new System.Drawing.Size(38, 20);
            this.notification_inviteDuration_box.TabIndex = 8;
            this.notification_inviteDuration_box.TextChanged += new System.EventHandler(this.inviteduration_text_TextChanged);
            // 
            // notification_chatDuration_box
            // 
            this.notification_chatDuration_box.Location = new System.Drawing.Point(313, 88);
            this.notification_chatDuration_box.Name = "notification_chatDuration_box";
            this.notification_chatDuration_box.Size = new System.Drawing.Size(38, 20);
            this.notification_chatDuration_box.TabIndex = 9;
            // 
            // notification_progressDuration_box
            // 
            this.notification_progressDuration_box.Location = new System.Drawing.Point(313, 36);
            this.notification_progressDuration_box.Name = "notification_progressDuration_box";
            this.notification_progressDuration_box.Size = new System.Drawing.Size(38, 20);
            this.notification_progressDuration_box.TabIndex = 7;
            // 
            // notification_achDuration_box
            // 
            this.notification_achDuration_box.Location = new System.Drawing.Point(313, 10);
            this.notification_achDuration_box.Name = "notification_achDuration_box";
            this.notification_achDuration_box.Size = new System.Drawing.Size(38, 20);
            this.notification_achDuration_box.TabIndex = 6;
            // 
            // notification_marginY_box
            // 
            this.notification_marginY_box.Location = new System.Drawing.Point(131, 88);
            this.notification_marginY_box.Name = "notification_marginY_box";
            this.notification_marginY_box.Size = new System.Drawing.Size(38, 20);
            this.notification_marginY_box.TabIndex = 5;
            // 
            // notification_marginX_box
            // 
            this.notification_marginX_box.Location = new System.Drawing.Point(131, 62);
            this.notification_marginX_box.Name = "notification_marginX_box";
            this.notification_marginX_box.Size = new System.Drawing.Size(38, 20);
            this.notification_marginX_box.TabIndex = 4;
            // 
            // notification_animation_box
            // 
            this.notification_animation_box.Location = new System.Drawing.Point(131, 36);
            this.notification_animation_box.Name = "notification_animation_box";
            this.notification_animation_box.Size = new System.Drawing.Size(38, 20);
            this.notification_animation_box.TabIndex = 3;
            // 
            // notification_rounding_box
            // 
            this.notification_rounding_box.Location = new System.Drawing.Point(131, 10);
            this.notification_rounding_box.Name = "notification_rounding_box";
            this.notification_rounding_box.Size = new System.Drawing.Size(38, 20);
            this.notification_rounding_box.TabIndex = 2;
            // 
            // notification_achDuration_label
            // 
            this.notification_achDuration_label.AutoSize = true;
            this.notification_achDuration_label.Location = new System.Drawing.Point(195, 13);
            this.notification_achDuration_label.Name = "notification_achDuration_label";
            this.notification_achDuration_label.Size = new System.Drawing.Size(112, 13);
            this.notification_achDuration_label.TabIndex = 11;
            this.notification_achDuration_label.Text = "Achievement Duration";
            // 
            // notification_chatDuration_label
            // 
            this.notification_chatDuration_label.AutoSize = true;
            this.notification_chatDuration_label.Location = new System.Drawing.Point(195, 91);
            this.notification_chatDuration_label.Name = "notification_chatDuration_label";
            this.notification_chatDuration_label.Size = new System.Drawing.Size(72, 13);
            this.notification_chatDuration_label.TabIndex = 10;
            this.notification_chatDuration_label.Text = "Chat Duration";
            // 
            // notification_progressDuration_label
            // 
            this.notification_progressDuration_label.AutoSize = true;
            this.notification_progressDuration_label.Location = new System.Drawing.Point(195, 39);
            this.notification_progressDuration_label.Name = "notification_progressDuration_label";
            this.notification_progressDuration_label.Size = new System.Drawing.Size(91, 13);
            this.notification_progressDuration_label.TabIndex = 9;
            this.notification_progressDuration_label.Text = "Progress Duration";
            // 
            // notification_animation_label
            // 
            this.notification_animation_label.AutoSize = true;
            this.notification_animation_label.Location = new System.Drawing.Point(16, 39);
            this.notification_animation_label.Name = "notification_animation_label";
            this.notification_animation_label.Size = new System.Drawing.Size(109, 13);
            this.notification_animation_label.TabIndex = 8;
            this.notification_animation_label.Text = "Notification Animation";
            // 
            // notification_marginY_label
            // 
            this.notification_marginY_label.AutoSize = true;
            this.notification_marginY_label.Location = new System.Drawing.Point(16, 91);
            this.notification_marginY_label.Name = "notification_marginY_label";
            this.notification_marginY_label.Size = new System.Drawing.Size(105, 13);
            this.notification_marginY_label.TabIndex = 7;
            this.notification_marginY_label.Text = "Notification Margin Y";
            // 
            // notification_marginX_label
            // 
            this.notification_marginX_label.AutoSize = true;
            this.notification_marginX_label.Location = new System.Drawing.Point(16, 65);
            this.notification_marginX_label.Name = "notification_marginX_label";
            this.notification_marginX_label.Size = new System.Drawing.Size(105, 13);
            this.notification_marginX_label.TabIndex = 6;
            this.notification_marginX_label.Text = "Notification Margin X";
            // 
            // notification_rounding_label
            // 
            this.notification_rounding_label.AutoSize = true;
            this.notification_rounding_label.Location = new System.Drawing.Point(16, 13);
            this.notification_rounding_label.Name = "notification_rounding_label";
            this.notification_rounding_label.Size = new System.Drawing.Size(109, 13);
            this.notification_rounding_label.TabIndex = 5;
            this.notification_rounding_label.Text = "Notification Rounding";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 205);
            this.Controls.Add(this.sounds_notification);
            this.Controls.Add(this.settings_Cancel_bttn);
            this.Controls.Add(this.settings_Save_bttn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "SmartGoldbergEmu Launcher";
            this.sounds_notification.ResumeLayout(false);
            this.general_tab.ResumeLayout(false);
            this.general_tab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.general_avatar_frame)).EndInit();
            this.appearance_tab.ResumeLayout(false);
            this.appearance_tab.PerformLayout();
            this.sound_tab.ResumeLayout(false);
            this.sound_tab.PerformLayout();
            this.notification_tab.ResumeLayout(false);
            this.notification_tab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button general_GetApiKey_bttn;
        private System.Windows.Forms.Button settings_Save_bttn;
        private System.Windows.Forms.Button settings_Cancel_bttn;
        private System.Windows.Forms.TabControl sounds_notification;
        private System.Windows.Forms.TabPage general_tab;
        private System.Windows.Forms.PictureBox general_avatar_frame;
        private System.Windows.Forms.Button general_avatar_bttn;
        private System.Windows.Forms.ComboBox general_language_box;
        private System.Windows.Forms.TextBox general_webApiKey_box;
        private System.Windows.Forms.TextBox general_port_box;
        private System.Windows.Forms.TextBox general_steamId_box;
        private System.Windows.Forms.TextBox general_username_box;
        private System.Windows.Forms.Label general_port_label;
        private System.Windows.Forms.Label general_language_label;
        private System.Windows.Forms.Label general_steamId_label;
        private System.Windows.Forms.Label general_username_label;
        private System.Windows.Forms.TabPage sound_tab;
        private System.Windows.Forms.Button sounds_deleteAlertSound_bttn;
        private System.Windows.Forms.Button sounds_deleteFriendSound_bttn;
        private System.Windows.Forms.Button sounds_changeFriendSound_bttn;
        private System.Windows.Forms.Label sound_alert_label;
        private System.Windows.Forms.Label sounds_friend_label;
        private System.Windows.Forms.Button sounds_deleteFont_bttn;
        private System.Windows.Forms.Button sounds_changeFont_bttn;
        private System.Windows.Forms.Label sounds_font_label;
        private System.Windows.Forms.Label sounds_fontSpacingY_label;
        private System.Windows.Forms.Label sounds_fontSpacingX_label;
        private System.Windows.Forms.TextBox sounds_fontSpacingY_box;
        private System.Windows.Forms.TextBox sounds_fontSpacingX_box;
        private System.Windows.Forms.TabPage notification_tab;
        private System.Windows.Forms.TextBox notification_animation_box;
        private System.Windows.Forms.TextBox notification_rounding_box;
        private System.Windows.Forms.Label notification_achDuration_label;
        private System.Windows.Forms.Label notification_chatDuration_label;
        private System.Windows.Forms.Label notification_progressDuration_label;
        private System.Windows.Forms.Label notification_animation_label;
        private System.Windows.Forms.Label notification_marginY_label;
        private System.Windows.Forms.Label notification_marginX_label;
        private System.Windows.Forms.Label notification_rounding_label;
        private System.Windows.Forms.TextBox notification_marginX_box;
        private System.Windows.Forms.TextBox notification_chatDuration_box;
        private System.Windows.Forms.TextBox notification_progressDuration_box;
        private System.Windows.Forms.TextBox notification_achDuration_box;
        private System.Windows.Forms.TextBox notification_marginY_box;
        private System.Windows.Forms.Label notification_inviteDuration_label;
        private System.Windows.Forms.TextBox notification_inviteDuration_box;
        private System.Windows.Forms.Label general_webApiKey_label;
        private System.Windows.Forms.Button sounds_changeAlertSound_bttn;
        private System.Windows.Forms.TabPage appearance_tab;
        private System.Windows.Forms.Label appearance_chatPos_label;
        private System.Windows.Forms.Label appearance_invPos_label;
        private System.Windows.Forms.Label appearance_achPos_label;
        private System.Windows.Forms.ComboBox appearance_achPos_box;
        private System.Windows.Forms.ComboBox appearance_invPos_box;
        private System.Windows.Forms.ComboBox appearance_chatPos_box;
        private System.Windows.Forms.TextBox appearance_imageSize_box;
        private System.Windows.Forms.Label appearance_imageSize_label;
        private System.Windows.Forms.TextBox appearance_fontSize_box;
        private System.Windows.Forms.Label appearance_fontSize_label;
        private System.Windows.Forms.Label appearance_active_label1;
        private System.Windows.Forms.Label appearance_active_label;
        private System.Windows.Forms.TextBox appearance_active_box;
        private System.Windows.Forms.Label appearance_hover_label1;
        private System.Windows.Forms.Label appearance_hover_label;
        private System.Windows.Forms.TextBox appearance_hover_box;
        private System.Windows.Forms.Label appearance_element_label1;
        private System.Windows.Forms.Label appearance_element_label;
        private System.Windows.Forms.TextBox appearance_element_box;
        private System.Windows.Forms.Label appearance_background_label1;
        private System.Windows.Forms.Label appearance_background_label;
        private System.Windows.Forms.TextBox appearance_background_box;
        private System.Windows.Forms.Label appearance_notification_label1;
        private System.Windows.Forms.Label appearance_notification_label;
        private System.Windows.Forms.TextBox appearance_notification_box;
        private System.Windows.Forms.Button setting_randomizePort_bttn;
        private System.Windows.Forms.ToolTip getApiKey;
        private System.Windows.Forms.ToolTip randomizePort;
        private System.Windows.Forms.Button ramoveAvatar_bttn;
        private System.Windows.Forms.ToolTip removeAvatarBttn;
        private System.Windows.Forms.ToolTip setAvatarBttn;
    }
}