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

namespace SmartGoldbergEmu
{
    partial class GameSettingsForm
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
            this.components = new System.ComponentModel.Container();
            this.gameSettings_save_bttn = new System.Windows.Forms.Button();
            this.gameSettings_cancel_bttn = new System.Windows.Forms.Button();
            this.broadcast_tab = new System.Windows.Forms.TabPage();
            this.broadcast_getMods_bttn = new System.Windows.Forms.Button();
            this.broadcast_createDllFolder_bttn = new System.Windows.Forms.Button();
            this.broadcast_createModsFolder_bttn = new System.Windows.Forms.Button();
            this.broadcast_clearEnvList_bttn = new System.Windows.Forms.Button();
            this.broadcast_removeEnv_bttn = new System.Windows.Forms.Button();
            this.broadcast_addEnv_bttn = new System.Windows.Forms.Button();
            this.broadcast_envKey_box = new CueTextBox();
            this.broadcast_envName_box = new CueTextBox();
            this.broadcast_custom_box = new CueTextBox();
            this.broadcast_envList_box = new System.Windows.Forms.ListBox();
            this.broadcast_customEnv_label = new System.Windows.Forms.Label();
            this.broadcast_customClear_bttn = new System.Windows.Forms.Button();
            this.broadcast_customRemove_bttn = new System.Windows.Forms.Button();
            this.broadcast_customAdd_bttn = new System.Windows.Forms.Button();
            this.broadcast_ipList_box = new System.Windows.Forms.ListBox();
            this.broadcast_custom_label = new System.Windows.Forms.Label();
            this.advanced_tab = new System.Windows.Forms.TabPage();
            this.advanced_installedApps_label = new System.Windows.Forms.Label();
            this.advanced_installedApps_box = new System.Windows.Forms.TextBox();
            this.advanced_customDepots_box = new System.Windows.Forms.TextBox();
            this.advanced_subscribedGroups_box = new System.Windows.Forms.TextBox();
            this.advanced_customPaths_box = new System.Windows.Forms.TextBox();
            this.advanced_custmDepots_label = new System.Windows.Forms.Label();
            this.advanced_subscribedGroups_label = new System.Windows.Forms.Label();
            this.advanced_customPaths_label = new System.Windows.Forms.Label();
            this.stats_tab = new System.Windows.Forms.TabPage();
            this.stats_disbleStatsShare_checkbox = new System.Windows.Forms.CheckBox();
            this.stats_serverStats_checkbox = new System.Windows.Forms.CheckBox();
            this.stats_bestScoreSaveOnly_checkbox = new System.Windows.Forms.CheckBox();
            this.stats_allowUnkStats_checkbox = new System.Windows.Forms.CheckBox();
            this.stats_getStats_bttn = new System.Windows.Forms.Button();
            this.stats_custom_label = new System.Windows.Forms.Label();
            this.stats_custom_box = new System.Windows.Forms.TextBox();
            this.ServerBrowser = new System.Windows.Forms.TabPage();
            this.server_history_box = new System.Windows.Forms.TextBox();
            this.server_favorites_box = new System.Windows.Forms.TextBox();
            this.server_spectate_box = new System.Windows.Forms.TextBox();
            this.server_history_label = new System.Windows.Forms.Label();
            this.server_favorites_label = new System.Windows.Forms.Label();
            this.server_spectate_label = new System.Windows.Forms.Label();
            this.dlc_tab = new System.Windows.Forms.TabPage();
            this.dlc_disable_desc = new System.Windows.Forms.Label();
            this.dlc_unlockAllDlc_bttn = new System.Windows.Forms.CheckBox();
            this.dlc_generateList_bttn = new System.Windows.Forms.Button();
            this.dlc_customList_label = new System.Windows.Forms.Label();
            this.dlc_list_box = new System.Windows.Forms.TextBox();
            this.other_tab = new System.Windows.Forms.TabPage();
            this.other_forceIp_label = new System.Windows.Forms.Label();
            this.other_forceIp_box = new System.Windows.Forms.TextBox();
            this.other_betaBranch_box = new System.Windows.Forms.TextBox();
            this.other_forceSteamId_box = new System.Windows.Forms.TextBox();
            this.other_forcePort_box = new System.Windows.Forms.TextBox();
            this.other_forceLanguage_box = new System.Windows.Forms.TextBox();
            this.other_forceAccName_box = new System.Windows.Forms.TextBox();
            this.other_localSaveName_box = new System.Windows.Forms.TextBox();
            this.other_disableUknLeaderboard_checkbox = new System.Windows.Forms.CheckBox();
            this.other_mmActualType_checkbox = new System.Windows.Forms.CheckBox();
            this.other_mmSourceQuery_checkbox = new System.Windows.Forms.CheckBox();
            this.other_shareLeaderboard_checkbox = new System.Windows.Forms.CheckBox();
            this.other_disableLobbyCreate_checkbox = new System.Windows.Forms.CheckBox();
            this.other_forceHttpSuccess_checkbox = new System.Windows.Forms.CheckBox();
            this.other_disableSourceQuery_checkbox = new System.Windows.Forms.CheckBox();
            this.other_disableAvatar_checkbox = new System.Windows.Forms.CheckBox();
            this.other_disableFriendPop_checkbox = new System.Windows.Forms.CheckBox();
            this.other_disableAchPop_checkbox = new System.Windows.Forms.CheckBox();
            this.other_achBypass_checkbox = new System.Windows.Forms.CheckBox();
            this.other_betaBranch_label = new System.Windows.Forms.Label();
            this.other_forceSteamDeck_checkbox = new System.Windows.Forms.CheckBox();
            this.other_forceSteamId_label = new System.Windows.Forms.Label();
            this.other_forcePort_label = new System.Windows.Forms.Label();
            this.other_forceLanguage_label = new System.Windows.Forms.Label();
            this.other_forceAccName_label = new System.Windows.Forms.Label();
            this.other_localSaveName_label = new System.Windows.Forms.Label();
            this.game_setting_tab = new System.Windows.Forms.TabPage();
            this.game_getName_bttn = new System.Windows.Forms.Button();
            this.fetchGameId = new System.Windows.Forms.Button();
            this.game_customIconClear_bttn = new System.Windows.Forms.Button();
            this.game_customIcon_bttn = new System.Windows.Forms.Button();
            this.game_customIcon_box = new System.Windows.Forms.TextBox();
            this.game_clanTag_box = new System.Windows.Forms.TextBox();
            this.game_appid_box = new System.Windows.Forms.TextBox();
            this.game_folder_box = new System.Windows.Forms.TextBox();
            this.game_params_box = new System.Windows.Forms.TextBox();
            this.game_gameExe_box = new System.Windows.Forms.TextBox();
            this.game_name_box = new System.Windows.Forms.TextBox();
            this.game_customIcon_label = new System.Windows.Forms.Label();
            this.game_clanTag_label = new System.Windows.Forms.Label();
            this.game_enableHttp_checkbox = new System.Windows.Forms.CheckBox();
            this.game_offline_checkbox = new System.Windows.Forms.CheckBox();
            this.game_disableNetwork_checkbox = new System.Windows.Forms.CheckBox();
            this.game_disableLan_checkbox = new System.Windows.Forms.CheckBox();
            this.game_disableOverlay_checkbox = new System.Windows.Forms.CheckBox();
            this.browse_start_folder = new System.Windows.Forms.Button();
            this.game_gameExe_bttn = new System.Windows.Forms.Button();
            this.game_x64_checkbox = new System.Windows.Forms.CheckBox();
            this.game_appId_label = new System.Windows.Forms.Label();
            this.game_folder_label = new System.Windows.Forms.Label();
            this.game_params_label = new System.Windows.Forms.Label();
            this.game_gameExe_label = new System.Windows.Forms.Label();
            this.game_name_label = new System.Windows.Forms.Label();
            this.navigation_tab = new System.Windows.Forms.TabControl();
            this.getAppid = new System.Windows.Forms.ToolTip(this.components);
            this.GetName = new System.Windows.Forms.ToolTip(this.components);
            this.unlockAllDlc = new System.Windows.Forms.ToolTip(this.components);
            this.x64x32 = new System.Windows.Forms.ToolTip(this.components);
            this.openFolder = new System.Windows.Forms.ToolTip(this.components);
            this.openGameExe = new System.Windows.Forms.ToolTip(this.components);
            this.customIcon = new System.Windows.Forms.ToolTip(this.components);
            this.custoInconClear = new System.Windows.Forms.ToolTip(this.components);
            this.broadcast_tab.SuspendLayout();
            this.advanced_tab.SuspendLayout();
            this.stats_tab.SuspendLayout();
            this.ServerBrowser.SuspendLayout();
            this.dlc_tab.SuspendLayout();
            this.other_tab.SuspendLayout();
            this.game_setting_tab.SuspendLayout();
            this.navigation_tab.SuspendLayout();
            this.SuspendLayout();
            // 
            // gameSettings_save_bttn
            // 
            this.gameSettings_save_bttn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.gameSettings_save_bttn.Location = new System.Drawing.Point(464, 415);
            this.gameSettings_save_bttn.Name = "gameSettings_save_bttn";
            this.gameSettings_save_bttn.Size = new System.Drawing.Size(75, 23);
            this.gameSettings_save_bttn.TabIndex = 98;
            this.gameSettings_save_bttn.Text = "&Save";
            this.gameSettings_save_bttn.UseVisualStyleBackColor = true;
            this.gameSettings_save_bttn.Click += new System.EventHandler(this.Save_Click);
            // 
            // gameSettings_cancel_bttn
            // 
            this.gameSettings_cancel_bttn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.gameSettings_cancel_bttn.Location = new System.Drawing.Point(545, 415);
            this.gameSettings_cancel_bttn.Name = "gameSettings_cancel_bttn";
            this.gameSettings_cancel_bttn.Size = new System.Drawing.Size(75, 23);
            this.gameSettings_cancel_bttn.TabIndex = 99;
            this.gameSettings_cancel_bttn.Text = "&Cancel";
            this.gameSettings_cancel_bttn.UseVisualStyleBackColor = true;
            this.gameSettings_cancel_bttn.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // broadcast_tab
            // 
            this.broadcast_tab.Controls.Add(this.broadcast_getMods_bttn);
            this.broadcast_tab.Controls.Add(this.broadcast_createDllFolder_bttn);
            this.broadcast_tab.Controls.Add(this.broadcast_createModsFolder_bttn);
            this.broadcast_tab.Controls.Add(this.broadcast_clearEnvList_bttn);
            this.broadcast_tab.Controls.Add(this.broadcast_removeEnv_bttn);
            this.broadcast_tab.Controls.Add(this.broadcast_addEnv_bttn);
            this.broadcast_tab.Controls.Add(this.broadcast_envKey_box);
            this.broadcast_tab.Controls.Add(this.broadcast_envName_box);
            this.broadcast_tab.Controls.Add(this.broadcast_custom_box);
            this.broadcast_tab.Controls.Add(this.broadcast_envList_box);
            this.broadcast_tab.Controls.Add(this.broadcast_customEnv_label);
            this.broadcast_tab.Controls.Add(this.broadcast_customClear_bttn);
            this.broadcast_tab.Controls.Add(this.broadcast_customRemove_bttn);
            this.broadcast_tab.Controls.Add(this.broadcast_customAdd_bttn);
            this.broadcast_tab.Controls.Add(this.broadcast_ipList_box);
            this.broadcast_tab.Controls.Add(this.broadcast_custom_label);
            this.broadcast_tab.Location = new System.Drawing.Point(4, 22);
            this.broadcast_tab.Name = "broadcast_tab";
            this.broadcast_tab.Padding = new System.Windows.Forms.Padding(3);
            this.broadcast_tab.Size = new System.Drawing.Size(604, 371);
            this.broadcast_tab.TabIndex = 1;
            this.broadcast_tab.Text = "Broadcast";
            this.broadcast_tab.UseVisualStyleBackColor = true;
            // 
            // broadcast_getMods_bttn
            // 
            this.broadcast_getMods_bttn.Location = new System.Drawing.Point(157, 61);
            this.broadcast_getMods_bttn.Name = "broadcast_getMods_bttn";
            this.broadcast_getMods_bttn.Size = new System.Drawing.Size(135, 23);
            this.broadcast_getMods_bttn.TabIndex = 4;
            this.broadcast_getMods_bttn.Text = "Get Mods From Folder";
            this.broadcast_getMods_bttn.UseVisualStyleBackColor = true;
            this.broadcast_getMods_bttn.Click += new System.EventHandler(this.ModFolderButton_Click);
            // 
            // broadcast_createDllFolder_bttn
            // 
            this.broadcast_createDllFolder_bttn.Location = new System.Drawing.Point(10, 32);
            this.broadcast_createDllFolder_bttn.Name = "broadcast_createDllFolder_bttn";
            this.broadcast_createDllFolder_bttn.Size = new System.Drawing.Size(135, 23);
            this.broadcast_createDllFolder_bttn.TabIndex = 2;
            this.broadcast_createDllFolder_bttn.Text = "Create DLL Folder";
            this.broadcast_createDllFolder_bttn.UseVisualStyleBackColor = true;
            this.broadcast_createDllFolder_bttn.Click += new System.EventHandler(this.DLLfold_Click);
            // 
            // broadcast_createModsFolder_bttn
            // 
            this.broadcast_createModsFolder_bttn.Location = new System.Drawing.Point(157, 32);
            this.broadcast_createModsFolder_bttn.Name = "broadcast_createModsFolder_bttn";
            this.broadcast_createModsFolder_bttn.Size = new System.Drawing.Size(135, 23);
            this.broadcast_createModsFolder_bttn.TabIndex = 3;
            this.broadcast_createModsFolder_bttn.Text = "Create Mods Folder";
            this.broadcast_createModsFolder_bttn.UseVisualStyleBackColor = true;
            this.broadcast_createModsFolder_bttn.Click += new System.EventHandler(this.Mods_Click);
            // 
            // broadcast_clearEnvList_bttn
            // 
            this.broadcast_clearEnvList_bttn.Location = new System.Drawing.Point(514, 338);
            this.broadcast_clearEnvList_bttn.Name = "broadcast_clearEnvList_bttn";
            this.broadcast_clearEnvList_bttn.Size = new System.Drawing.Size(80, 23);
            this.broadcast_clearEnvList_bttn.TabIndex = 15;
            this.broadcast_clearEnvList_bttn.Text = "Clear";
            this.broadcast_clearEnvList_bttn.UseVisualStyleBackColor = true;
            this.broadcast_clearEnvList_bttn.Click += new System.EventHandler(this.Button_clear_env_var_Click);
            // 
            // broadcast_removeEnv_bttn
            // 
            this.broadcast_removeEnv_bttn.Location = new System.Drawing.Point(428, 338);
            this.broadcast_removeEnv_bttn.Name = "broadcast_removeEnv_bttn";
            this.broadcast_removeEnv_bttn.Size = new System.Drawing.Size(80, 23);
            this.broadcast_removeEnv_bttn.TabIndex = 14;
            this.broadcast_removeEnv_bttn.Text = "Remove";
            this.broadcast_removeEnv_bttn.UseVisualStyleBackColor = true;
            this.broadcast_removeEnv_bttn.Click += new System.EventHandler(this.Button_remove_env_var_Click);
            // 
            // broadcast_addEnv_bttn
            // 
            this.broadcast_addEnv_bttn.Location = new System.Drawing.Point(340, 338);
            this.broadcast_addEnv_bttn.Name = "broadcast_addEnv_bttn";
            this.broadcast_addEnv_bttn.Size = new System.Drawing.Size(80, 23);
            this.broadcast_addEnv_bttn.TabIndex = 13;
            this.broadcast_addEnv_bttn.Text = "Add";
            this.broadcast_addEnv_bttn.UseVisualStyleBackColor = true;
            this.broadcast_addEnv_bttn.Click += new System.EventHandler(this.Button_add_env_var_Click);
            // 
            // broadcast_envKey_box
            // 
            this.broadcast_envKey_box.Cue = "Key";
            this.broadcast_envKey_box.Location = new System.Drawing.Point(459, 116);
            this.broadcast_envKey_box.Name = "broadcast_envKey_box";
            this.broadcast_envKey_box.Size = new System.Drawing.Size(135, 20);
            this.broadcast_envKey_box.TabIndex = 11;
            // 
            // broadcast_envName_box
            // 
            this.broadcast_envName_box.Cue = "Name";
            this.broadcast_envName_box.Location = new System.Drawing.Point(312, 116);
            this.broadcast_envName_box.Name = "broadcast_envName_box";
            this.broadcast_envName_box.Size = new System.Drawing.Size(135, 20);
            this.broadcast_envName_box.TabIndex = 10;
            // 
            // broadcast_custom_box
            // 
            this.broadcast_custom_box.Cue = "127.0.0.1";
            this.broadcast_custom_box.Location = new System.Drawing.Point(203, 116);
            this.broadcast_custom_box.Name = "broadcast_custom_box";
            this.broadcast_custom_box.Size = new System.Drawing.Size(89, 20);
            this.broadcast_custom_box.TabIndex = 5;
            this.broadcast_custom_box.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ip_textBox_KeyDown);
            // 
            // broadcast_envList_box
            // 
            this.broadcast_envList_box.FormattingEnabled = true;
            this.broadcast_envList_box.Location = new System.Drawing.Point(312, 142);
            this.broadcast_envList_box.Name = "broadcast_envList_box";
            this.broadcast_envList_box.Size = new System.Drawing.Size(282, 186);
            this.broadcast_envList_box.TabIndex = 12;
            // 
            // broadcast_customEnv_label
            // 
            this.broadcast_customEnv_label.AutoSize = true;
            this.broadcast_customEnv_label.Location = new System.Drawing.Point(309, 100);
            this.broadcast_customEnv_label.Name = "broadcast_customEnv_label";
            this.broadcast_customEnv_label.Size = new System.Drawing.Size(111, 13);
            this.broadcast_customEnv_label.TabIndex = 28;
            this.broadcast_customEnv_label.Text = "Custom Env var name";
            // 
            // broadcast_customClear_bttn
            // 
            this.broadcast_customClear_bttn.Location = new System.Drawing.Point(212, 338);
            this.broadcast_customClear_bttn.Name = "broadcast_customClear_bttn";
            this.broadcast_customClear_bttn.Size = new System.Drawing.Size(80, 23);
            this.broadcast_customClear_bttn.TabIndex = 9;
            this.broadcast_customClear_bttn.Text = "Clear";
            this.broadcast_customClear_bttn.UseVisualStyleBackColor = true;
            this.broadcast_customClear_bttn.Click += new System.EventHandler(this.Clear_broadcast_button_Click);
            // 
            // broadcast_customRemove_bttn
            // 
            this.broadcast_customRemove_bttn.Location = new System.Drawing.Point(126, 338);
            this.broadcast_customRemove_bttn.Name = "broadcast_customRemove_bttn";
            this.broadcast_customRemove_bttn.Size = new System.Drawing.Size(80, 23);
            this.broadcast_customRemove_bttn.TabIndex = 8;
            this.broadcast_customRemove_bttn.Text = "Remove";
            this.broadcast_customRemove_bttn.UseVisualStyleBackColor = true;
            this.broadcast_customRemove_bttn.Click += new System.EventHandler(this.Remove_broadcast_button_Click);
            // 
            // broadcast_customAdd_bttn
            // 
            this.broadcast_customAdd_bttn.Location = new System.Drawing.Point(40, 338);
            this.broadcast_customAdd_bttn.Name = "broadcast_customAdd_bttn";
            this.broadcast_customAdd_bttn.Size = new System.Drawing.Size(80, 23);
            this.broadcast_customAdd_bttn.TabIndex = 7;
            this.broadcast_customAdd_bttn.Text = "Add";
            this.broadcast_customAdd_bttn.UseVisualStyleBackColor = true;
            this.broadcast_customAdd_bttn.Click += new System.EventHandler(this.Add_broadcast_button_Click);
            // 
            // broadcast_ipList_box
            // 
            this.broadcast_ipList_box.FormattingEnabled = true;
            this.broadcast_ipList_box.Location = new System.Drawing.Point(10, 142);
            this.broadcast_ipList_box.Name = "broadcast_ipList_box";
            this.broadcast_ipList_box.Size = new System.Drawing.Size(282, 186);
            this.broadcast_ipList_box.TabIndex = 6;
            this.broadcast_ipList_box.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ip_listBox_KeyDown);
            // 
            // broadcast_custom_label
            // 
            this.broadcast_custom_label.AutoSize = true;
            this.broadcast_custom_label.Location = new System.Drawing.Point(101, 119);
            this.broadcast_custom_label.Name = "broadcast_custom_label";
            this.broadcast_custom_label.Size = new System.Drawing.Size(96, 13);
            this.broadcast_custom_label.TabIndex = 0;
            this.broadcast_custom_label.Text = "Custom Broadcast:";
            // 
            // advanced_tab
            // 
            this.advanced_tab.Controls.Add(this.advanced_installedApps_label);
            this.advanced_tab.Controls.Add(this.advanced_installedApps_box);
            this.advanced_tab.Controls.Add(this.advanced_customDepots_box);
            this.advanced_tab.Controls.Add(this.advanced_subscribedGroups_box);
            this.advanced_tab.Controls.Add(this.advanced_customPaths_box);
            this.advanced_tab.Controls.Add(this.advanced_custmDepots_label);
            this.advanced_tab.Controls.Add(this.advanced_subscribedGroups_label);
            this.advanced_tab.Controls.Add(this.advanced_customPaths_label);
            this.advanced_tab.Location = new System.Drawing.Point(4, 22);
            this.advanced_tab.Name = "advanced_tab";
            this.advanced_tab.Padding = new System.Windows.Forms.Padding(3);
            this.advanced_tab.Size = new System.Drawing.Size(604, 371);
            this.advanced_tab.TabIndex = 6;
            this.advanced_tab.Text = "Advanced";
            this.advanced_tab.UseVisualStyleBackColor = true;
            // 
            // advanced_installedApps_label
            // 
            this.advanced_installedApps_label.AutoSize = true;
            this.advanced_installedApps_label.Location = new System.Drawing.Point(308, 246);
            this.advanced_installedApps_label.Name = "advanced_installedApps_label";
            this.advanced_installedApps_label.Size = new System.Drawing.Size(88, 13);
            this.advanced_installedApps_label.TabIndex = 16;
            this.advanced_installedApps_label.Text = "Instaled App IDs:";
            // 
            // advanced_installedApps_box
            // 
            this.advanced_installedApps_box.AcceptsReturn = true;
            this.advanced_installedApps_box.AcceptsTab = true;
            this.advanced_installedApps_box.Location = new System.Drawing.Point(311, 262);
            this.advanced_installedApps_box.Multiline = true;
            this.advanced_installedApps_box.Name = "advanced_installedApps_box";
            this.advanced_installedApps_box.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.advanced_installedApps_box.Size = new System.Drawing.Size(260, 95);
            this.advanced_installedApps_box.TabIndex = 5;
            this.advanced_installedApps_box.TabStop = false;
            // 
            // advanced_customDepots_box
            // 
            this.advanced_customDepots_box.AcceptsReturn = true;
            this.advanced_customDepots_box.AcceptsTab = true;
            this.advanced_customDepots_box.Location = new System.Drawing.Point(30, 262);
            this.advanced_customDepots_box.Multiline = true;
            this.advanced_customDepots_box.Name = "advanced_customDepots_box";
            this.advanced_customDepots_box.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.advanced_customDepots_box.Size = new System.Drawing.Size(260, 95);
            this.advanced_customDepots_box.TabIndex = 4;
            this.advanced_customDepots_box.TabStop = false;
            // 
            // advanced_subscribedGroups_box
            // 
            this.advanced_subscribedGroups_box.AcceptsReturn = true;
            this.advanced_subscribedGroups_box.AcceptsTab = true;
            this.advanced_subscribedGroups_box.Location = new System.Drawing.Point(30, 148);
            this.advanced_subscribedGroups_box.Multiline = true;
            this.advanced_subscribedGroups_box.Name = "advanced_subscribedGroups_box";
            this.advanced_subscribedGroups_box.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.advanced_subscribedGroups_box.Size = new System.Drawing.Size(541, 95);
            this.advanced_subscribedGroups_box.TabIndex = 3;
            this.advanced_subscribedGroups_box.TabStop = false;
            // 
            // advanced_customPaths_box
            // 
            this.advanced_customPaths_box.AcceptsReturn = true;
            this.advanced_customPaths_box.AcceptsTab = true;
            this.advanced_customPaths_box.Location = new System.Drawing.Point(30, 34);
            this.advanced_customPaths_box.Multiline = true;
            this.advanced_customPaths_box.Name = "advanced_customPaths_box";
            this.advanced_customPaths_box.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.advanced_customPaths_box.Size = new System.Drawing.Size(541, 95);
            this.advanced_customPaths_box.TabIndex = 2;
            this.advanced_customPaths_box.TabStop = false;
            // 
            // advanced_custmDepots_label
            // 
            this.advanced_custmDepots_label.AutoSize = true;
            this.advanced_custmDepots_label.Location = new System.Drawing.Point(27, 246);
            this.advanced_custmDepots_label.Name = "advanced_custmDepots_label";
            this.advanced_custmDepots_label.Size = new System.Drawing.Size(82, 13);
            this.advanced_custmDepots_label.TabIndex = 13;
            this.advanced_custmDepots_label.Text = "Custom Depots:";
            // 
            // advanced_subscribedGroups_label
            // 
            this.advanced_subscribedGroups_label.AutoSize = true;
            this.advanced_subscribedGroups_label.Location = new System.Drawing.Point(27, 132);
            this.advanced_subscribedGroups_label.Name = "advanced_subscribedGroups_label";
            this.advanced_subscribedGroups_label.Size = new System.Drawing.Size(153, 13);
            this.advanced_subscribedGroups_label.TabIndex = 11;
            this.advanced_subscribedGroups_label.Text = "Custom Subscribed Groups list:";
            // 
            // advanced_customPaths_label
            // 
            this.advanced_customPaths_label.AutoSize = true;
            this.advanced_customPaths_label.Location = new System.Drawing.Point(27, 18);
            this.advanced_customPaths_label.Name = "advanced_customPaths_label";
            this.advanced_customPaths_label.Size = new System.Drawing.Size(112, 13);
            this.advanced_customPaths_label.TabIndex = 10;
            this.advanced_customPaths_label.Text = "Custom App Paths list:";
            // 
            // stats_tab
            // 
            this.stats_tab.Controls.Add(this.stats_disbleStatsShare_checkbox);
            this.stats_tab.Controls.Add(this.stats_serverStats_checkbox);
            this.stats_tab.Controls.Add(this.stats_bestScoreSaveOnly_checkbox);
            this.stats_tab.Controls.Add(this.stats_allowUnkStats_checkbox);
            this.stats_tab.Controls.Add(this.stats_getStats_bttn);
            this.stats_tab.Controls.Add(this.stats_custom_label);
            this.stats_tab.Controls.Add(this.stats_custom_box);
            this.stats_tab.Location = new System.Drawing.Point(4, 22);
            this.stats_tab.Name = "stats_tab";
            this.stats_tab.Padding = new System.Windows.Forms.Padding(3);
            this.stats_tab.Size = new System.Drawing.Size(604, 371);
            this.stats_tab.TabIndex = 3;
            this.stats_tab.Text = "Stats";
            this.stats_tab.UseVisualStyleBackColor = true;
            // 
            // stats_disbleStatsShare_checkbox
            // 
            this.stats_disbleStatsShare_checkbox.AutoSize = true;
            this.stats_disbleStatsShare_checkbox.Location = new System.Drawing.Point(342, 122);
            this.stats_disbleStatsShare_checkbox.Name = "stats_disbleStatsShare_checkbox";
            this.stats_disbleStatsShare_checkbox.Size = new System.Drawing.Size(127, 17);
            this.stats_disbleStatsShare_checkbox.TabIndex = 5;
            this.stats_disbleStatsShare_checkbox.Text = "Disable Stats Sharing";
            this.stats_disbleStatsShare_checkbox.UseVisualStyleBackColor = true;
            // 
            // stats_serverStats_checkbox
            // 
            this.stats_serverStats_checkbox.AutoSize = true;
            this.stats_serverStats_checkbox.Location = new System.Drawing.Point(342, 99);
            this.stats_serverStats_checkbox.Name = "stats_serverStats_checkbox";
            this.stats_serverStats_checkbox.Size = new System.Drawing.Size(115, 17);
            this.stats_serverStats_checkbox.TabIndex = 4;
            this.stats_serverStats_checkbox.Text = "Game Server Stats";
            this.stats_serverStats_checkbox.UseVisualStyleBackColor = true;
            // 
            // stats_bestScoreSaveOnly_checkbox
            // 
            this.stats_bestScoreSaveOnly_checkbox.AutoSize = true;
            this.stats_bestScoreSaveOnly_checkbox.Location = new System.Drawing.Point(342, 76);
            this.stats_bestScoreSaveOnly_checkbox.Name = "stats_bestScoreSaveOnly_checkbox";
            this.stats_bestScoreSaveOnly_checkbox.Size = new System.Drawing.Size(175, 17);
            this.stats_bestScoreSaveOnly_checkbox.TabIndex = 3;
            this.stats_bestScoreSaveOnly_checkbox.Text = "Save Only Higher Stat Progress";
            this.stats_bestScoreSaveOnly_checkbox.UseVisualStyleBackColor = true;
            // 
            // stats_allowUnkStats_checkbox
            // 
            this.stats_allowUnkStats_checkbox.AutoSize = true;
            this.stats_allowUnkStats_checkbox.Location = new System.Drawing.Point(342, 53);
            this.stats_allowUnkStats_checkbox.Name = "stats_allowUnkStats_checkbox";
            this.stats_allowUnkStats_checkbox.Size = new System.Drawing.Size(127, 17);
            this.stats_allowUnkStats_checkbox.TabIndex = 2;
            this.stats_allowUnkStats_checkbox.Text = "Allow Unknown Stats";
            this.stats_allowUnkStats_checkbox.UseVisualStyleBackColor = true;
            // 
            // stats_getStats_bttn
            // 
            this.stats_getStats_bttn.Location = new System.Drawing.Point(342, 174);
            this.stats_getStats_bttn.Name = "stats_getStats_bttn";
            this.stats_getStats_bttn.Size = new System.Drawing.Size(139, 23);
            this.stats_getStats_bttn.TabIndex = 11;
            this.stats_getStats_bttn.Text = "Get Stats";
            this.stats_getStats_bttn.UseVisualStyleBackColor = true;
            this.stats_getStats_bttn.Click += new System.EventHandler(this.GetStats_Click);
            // 
            // stats_custom_label
            // 
            this.stats_custom_label.AutoSize = true;
            this.stats_custom_label.Location = new System.Drawing.Point(27, 23);
            this.stats_custom_label.Name = "stats_custom_label";
            this.stats_custom_label.Size = new System.Drawing.Size(72, 13);
            this.stats_custom_label.TabIndex = 10;
            this.stats_custom_label.Text = "Custom Stats:";
            // 
            // stats_custom_box
            // 
            this.stats_custom_box.AcceptsReturn = true;
            this.stats_custom_box.AcceptsTab = true;
            this.stats_custom_box.Location = new System.Drawing.Point(30, 53);
            this.stats_custom_box.Multiline = true;
            this.stats_custom_box.Name = "stats_custom_box";
            this.stats_custom_box.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.stats_custom_box.Size = new System.Drawing.Size(260, 287);
            this.stats_custom_box.TabIndex = 6;
            this.stats_custom_box.TabStop = false;
            // 
            // ServerBrowser
            // 
            this.ServerBrowser.Controls.Add(this.server_history_box);
            this.ServerBrowser.Controls.Add(this.server_favorites_box);
            this.ServerBrowser.Controls.Add(this.server_spectate_box);
            this.ServerBrowser.Controls.Add(this.server_history_label);
            this.ServerBrowser.Controls.Add(this.server_favorites_label);
            this.ServerBrowser.Controls.Add(this.server_spectate_label);
            this.ServerBrowser.Location = new System.Drawing.Point(4, 22);
            this.ServerBrowser.Name = "ServerBrowser";
            this.ServerBrowser.Padding = new System.Windows.Forms.Padding(3);
            this.ServerBrowser.Size = new System.Drawing.Size(604, 371);
            this.ServerBrowser.TabIndex = 8;
            this.ServerBrowser.Text = "Server Browser";
            this.ServerBrowser.UseVisualStyleBackColor = true;
            // 
            // server_history_box
            // 
            this.server_history_box.AcceptsReturn = true;
            this.server_history_box.AcceptsTab = true;
            this.server_history_box.Location = new System.Drawing.Point(30, 262);
            this.server_history_box.Multiline = true;
            this.server_history_box.Name = "server_history_box";
            this.server_history_box.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.server_history_box.Size = new System.Drawing.Size(541, 95);
            this.server_history_box.TabIndex = 4;
            this.server_history_box.TabStop = false;
            // 
            // server_favorites_box
            // 
            this.server_favorites_box.AcceptsReturn = true;
            this.server_favorites_box.AcceptsTab = true;
            this.server_favorites_box.Location = new System.Drawing.Point(30, 148);
            this.server_favorites_box.Multiline = true;
            this.server_favorites_box.Name = "server_favorites_box";
            this.server_favorites_box.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.server_favorites_box.Size = new System.Drawing.Size(541, 95);
            this.server_favorites_box.TabIndex = 3;
            this.server_favorites_box.TabStop = false;
            // 
            // server_spectate_box
            // 
            this.server_spectate_box.AcceptsReturn = true;
            this.server_spectate_box.AcceptsTab = true;
            this.server_spectate_box.Location = new System.Drawing.Point(30, 34);
            this.server_spectate_box.Multiline = true;
            this.server_spectate_box.Name = "server_spectate_box";
            this.server_spectate_box.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.server_spectate_box.Size = new System.Drawing.Size(541, 95);
            this.server_spectate_box.TabIndex = 2;
            this.server_spectate_box.TabStop = false;
            // 
            // server_history_label
            // 
            this.server_history_label.AutoSize = true;
            this.server_history_label.Location = new System.Drawing.Point(27, 246);
            this.server_history_label.Name = "server_history_label";
            this.server_history_label.Size = new System.Drawing.Size(64, 13);
            this.server_history_label.TabIndex = 19;
            this.server_history_label.Text = "History Tab:";
            // 
            // server_favorites_label
            // 
            this.server_favorites_label.AutoSize = true;
            this.server_favorites_label.Location = new System.Drawing.Point(27, 132);
            this.server_favorites_label.Name = "server_favorites_label";
            this.server_favorites_label.Size = new System.Drawing.Size(75, 13);
            this.server_favorites_label.TabIndex = 17;
            this.server_favorites_label.Text = "Favorites Tab:";
            // 
            // server_spectate_label
            // 
            this.server_spectate_label.AutoSize = true;
            this.server_spectate_label.Location = new System.Drawing.Point(27, 18);
            this.server_spectate_label.Name = "server_spectate_label";
            this.server_spectate_label.Size = new System.Drawing.Size(140, 13);
            this.server_spectate_label.TabIndex = 16;
            this.server_spectate_label.Text = "Internet and Spectate Tabs:";
            // 
            // dlc_tab
            // 
            this.dlc_tab.Controls.Add(this.dlc_disable_desc);
            this.dlc_tab.Controls.Add(this.dlc_unlockAllDlc_bttn);
            this.dlc_tab.Controls.Add(this.dlc_generateList_bttn);
            this.dlc_tab.Controls.Add(this.dlc_customList_label);
            this.dlc_tab.Controls.Add(this.dlc_list_box);
            this.dlc_tab.Location = new System.Drawing.Point(4, 22);
            this.dlc_tab.Name = "dlc_tab";
            this.dlc_tab.Padding = new System.Windows.Forms.Padding(3);
            this.dlc_tab.Size = new System.Drawing.Size(604, 371);
            this.dlc_tab.TabIndex = 2;
            this.dlc_tab.Text = "DLC";
            this.dlc_tab.UseVisualStyleBackColor = true;
            // 
            // dlc_disable_desc
            // 
            this.dlc_disable_desc.AutoSize = true;
            this.dlc_disable_desc.Location = new System.Drawing.Point(27, 347);
            this.dlc_disable_desc.Name = "dlc_disable_desc";
            this.dlc_disable_desc.Size = new System.Drawing.Size(280, 13);
            this.dlc_disable_desc.TabIndex = 4;
            this.dlc_disable_desc.Text = "*Disable any DLC by adding # to the beginning of the line.";
            // 
            // dlc_unlockAllDlc_bttn
            // 
            this.dlc_unlockAllDlc_bttn.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.dlc_unlockAllDlc_bttn.AutoSize = true;
            this.dlc_unlockAllDlc_bttn.Location = new System.Drawing.Point(472, 346);
            this.dlc_unlockAllDlc_bttn.Name = "dlc_unlockAllDlc_bttn";
            this.dlc_unlockAllDlc_bttn.Size = new System.Drawing.Size(98, 17);
            this.dlc_unlockAllDlc_bttn.TabIndex = 3;
            this.dlc_unlockAllDlc_bttn.Text = "Unlock All DLC";
            this.unlockAllDlc.SetToolTip(this.dlc_unlockAllDlc_bttn, "Select this option to ignore the custom DLC list and unlock all available DLC.");
            this.dlc_unlockAllDlc_bttn.UseVisualStyleBackColor = true;
            this.dlc_unlockAllDlc_bttn.CheckedChanged += new System.EventHandler(this.dlc_unlockAllDlc_bttn_CheckedChanged);
            // 
            // dlc_generateList_bttn
            // 
            this.dlc_generateList_bttn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.dlc_generateList_bttn.Location = new System.Drawing.Point(472, 18);
            this.dlc_generateList_bttn.Name = "dlc_generateList_bttn";
            this.dlc_generateList_bttn.Size = new System.Drawing.Size(98, 23);
            this.dlc_generateList_bttn.TabIndex = 2;
            this.dlc_generateList_bttn.Text = "Find DLCs";
            this.dlc_generateList_bttn.UseVisualStyleBackColor = true;
            this.dlc_generateList_bttn.Click += new System.EventHandler(this.DlcFinder);
            // 
            // dlc_customList_label
            // 
            this.dlc_customList_label.AutoSize = true;
            this.dlc_customList_label.Location = new System.Drawing.Point(27, 23);
            this.dlc_customList_label.Name = "dlc_customList_label";
            this.dlc_customList_label.Size = new System.Drawing.Size(116, 13);
            this.dlc_customList_label.TabIndex = 2;
            this.dlc_customList_label.Text = "Custom DLC unlock list\r\n";
            this.dlc_customList_label.Click += new System.EventHandler(this.DLC_desc_Click);
            // 
            // dlc_list_box
            // 
            this.dlc_list_box.AcceptsReturn = true;
            this.dlc_list_box.AcceptsTab = true;
            this.dlc_list_box.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.dlc_list_box.Location = new System.Drawing.Point(30, 53);
            this.dlc_list_box.Multiline = true;
            this.dlc_list_box.Name = "dlc_list_box";
            this.dlc_list_box.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.dlc_list_box.Size = new System.Drawing.Size(541, 287);
            this.dlc_list_box.TabIndex = 3;
            this.dlc_list_box.TabStop = false;
            this.dlc_list_box.TextChanged += new System.EventHandler(this.DLC_add_TextChanged);
            // 
            // other_tab
            // 
            this.other_tab.Controls.Add(this.other_forceIp_label);
            this.other_tab.Controls.Add(this.other_forceIp_box);
            this.other_tab.Controls.Add(this.other_betaBranch_box);
            this.other_tab.Controls.Add(this.other_forceSteamId_box);
            this.other_tab.Controls.Add(this.other_forcePort_box);
            this.other_tab.Controls.Add(this.other_forceLanguage_box);
            this.other_tab.Controls.Add(this.other_forceAccName_box);
            this.other_tab.Controls.Add(this.other_localSaveName_box);
            this.other_tab.Controls.Add(this.other_disableUknLeaderboard_checkbox);
            this.other_tab.Controls.Add(this.other_mmActualType_checkbox);
            this.other_tab.Controls.Add(this.other_mmSourceQuery_checkbox);
            this.other_tab.Controls.Add(this.other_shareLeaderboard_checkbox);
            this.other_tab.Controls.Add(this.other_disableLobbyCreate_checkbox);
            this.other_tab.Controls.Add(this.other_forceHttpSuccess_checkbox);
            this.other_tab.Controls.Add(this.other_disableSourceQuery_checkbox);
            this.other_tab.Controls.Add(this.other_disableAvatar_checkbox);
            this.other_tab.Controls.Add(this.other_disableFriendPop_checkbox);
            this.other_tab.Controls.Add(this.other_disableAchPop_checkbox);
            this.other_tab.Controls.Add(this.other_achBypass_checkbox);
            this.other_tab.Controls.Add(this.other_betaBranch_label);
            this.other_tab.Controls.Add(this.other_forceSteamDeck_checkbox);
            this.other_tab.Controls.Add(this.other_forceSteamId_label);
            this.other_tab.Controls.Add(this.other_forcePort_label);
            this.other_tab.Controls.Add(this.other_forceLanguage_label);
            this.other_tab.Controls.Add(this.other_forceAccName_label);
            this.other_tab.Controls.Add(this.other_localSaveName_label);
            this.other_tab.Location = new System.Drawing.Point(4, 22);
            this.other_tab.Name = "other_tab";
            this.other_tab.Padding = new System.Windows.Forms.Padding(3);
            this.other_tab.Size = new System.Drawing.Size(604, 371);
            this.other_tab.TabIndex = 7;
            this.other_tab.Text = "Other Settings";
            this.other_tab.UseVisualStyleBackColor = true;
            // 
            // other_forceIp_label
            // 
            this.other_forceIp_label.AutoSize = true;
            this.other_forceIp_label.Location = new System.Drawing.Point(301, 103);
            this.other_forceIp_label.Name = "other_forceIp_label";
            this.other_forceIp_label.Size = new System.Drawing.Size(89, 13);
            this.other_forceIp_label.TabIndex = 61;
            this.other_forceIp_label.Text = "Force IP Country:";
            // 
            // other_forceIp_box
            // 
            this.other_forceIp_box.Location = new System.Drawing.Point(396, 100);
            this.other_forceIp_box.Name = "other_forceIp_box";
            this.other_forceIp_box.Size = new System.Drawing.Size(131, 20);
            this.other_forceIp_box.TabIndex = 6;
            // 
            // other_betaBranch_box
            // 
            this.other_betaBranch_box.Location = new System.Drawing.Point(170, 152);
            this.other_betaBranch_box.Name = "other_betaBranch_box";
            this.other_betaBranch_box.Size = new System.Drawing.Size(357, 20);
            this.other_betaBranch_box.TabIndex = 8;
            // 
            // other_forceSteamId_box
            // 
            this.other_forceSteamId_box.Location = new System.Drawing.Point(170, 48);
            this.other_forceSteamId_box.Name = "other_forceSteamId_box";
            this.other_forceSteamId_box.Size = new System.Drawing.Size(357, 20);
            this.other_forceSteamId_box.TabIndex = 3;
            // 
            // other_forcePort_box
            // 
            this.other_forcePort_box.Location = new System.Drawing.Point(170, 100);
            this.other_forcePort_box.Name = "other_forcePort_box";
            this.other_forcePort_box.Size = new System.Drawing.Size(106, 20);
            this.other_forcePort_box.TabIndex = 5;
            // 
            // other_forceLanguage_box
            // 
            this.other_forceLanguage_box.Location = new System.Drawing.Point(170, 74);
            this.other_forceLanguage_box.Name = "other_forceLanguage_box";
            this.other_forceLanguage_box.Size = new System.Drawing.Size(357, 20);
            this.other_forceLanguage_box.TabIndex = 4;
            // 
            // other_forceAccName_box
            // 
            this.other_forceAccName_box.Location = new System.Drawing.Point(170, 22);
            this.other_forceAccName_box.Name = "other_forceAccName_box";
            this.other_forceAccName_box.Size = new System.Drawing.Size(357, 20);
            this.other_forceAccName_box.TabIndex = 2;
            // 
            // other_localSaveName_box
            // 
            this.other_localSaveName_box.Location = new System.Drawing.Point(170, 126);
            this.other_localSaveName_box.Name = "other_localSaveName_box";
            this.other_localSaveName_box.Size = new System.Drawing.Size(357, 20);
            this.other_localSaveName_box.TabIndex = 7;
            // 
            // other_disableUknLeaderboard_checkbox
            // 
            this.other_disableUknLeaderboard_checkbox.AutoSize = true;
            this.other_disableUknLeaderboard_checkbox.Location = new System.Drawing.Point(233, 292);
            this.other_disableUknLeaderboard_checkbox.Name = "other_disableUknLeaderboard_checkbox";
            this.other_disableUknLeaderboard_checkbox.Size = new System.Drawing.Size(173, 17);
            this.other_disableUknLeaderboard_checkbox.TabIndex = 18;
            this.other_disableUknLeaderboard_checkbox.Text = "Disable Unknown Leaderboard";
            this.other_disableUknLeaderboard_checkbox.UseVisualStyleBackColor = true;
            // 
            // other_mmActualType_checkbox
            // 
            this.other_mmActualType_checkbox.AutoSize = true;
            this.other_mmActualType_checkbox.Location = new System.Drawing.Point(430, 200);
            this.other_mmActualType_checkbox.Name = "other_mmActualType_checkbox";
            this.other_mmActualType_checkbox.Size = new System.Drawing.Size(142, 17);
            this.other_mmActualType_checkbox.TabIndex = 19;
            this.other_mmActualType_checkbox.Text = "Matchmake Actual Type";
            this.other_mmActualType_checkbox.UseVisualStyleBackColor = true;
            // 
            // other_mmSourceQuery_checkbox
            // 
            this.other_mmSourceQuery_checkbox.AutoSize = true;
            this.other_mmSourceQuery_checkbox.Location = new System.Drawing.Point(430, 223);
            this.other_mmSourceQuery_checkbox.Name = "other_mmSourceQuery_checkbox";
            this.other_mmSourceQuery_checkbox.Size = new System.Drawing.Size(153, 17);
            this.other_mmSourceQuery_checkbox.TabIndex = 20;
            this.other_mmSourceQuery_checkbox.Text = "Matchmake Source Querry";
            this.other_mmSourceQuery_checkbox.UseVisualStyleBackColor = true;
            // 
            // other_shareLeaderboard_checkbox
            // 
            this.other_shareLeaderboard_checkbox.AutoSize = true;
            this.other_shareLeaderboard_checkbox.Location = new System.Drawing.Point(233, 269);
            this.other_shareLeaderboard_checkbox.Name = "other_shareLeaderboard_checkbox";
            this.other_shareLeaderboard_checkbox.Size = new System.Drawing.Size(191, 17);
            this.other_shareLeaderboard_checkbox.TabIndex = 17;
            this.other_shareLeaderboard_checkbox.Text = "Share Leaderboards Over Network";
            this.other_shareLeaderboard_checkbox.UseVisualStyleBackColor = true;
            // 
            // other_disableLobbyCreate_checkbox
            // 
            this.other_disableLobbyCreate_checkbox.AutoSize = true;
            this.other_disableLobbyCreate_checkbox.Location = new System.Drawing.Point(233, 246);
            this.other_disableLobbyCreate_checkbox.Name = "other_disableLobbyCreate_checkbox";
            this.other_disableLobbyCreate_checkbox.Size = new System.Drawing.Size(135, 17);
            this.other_disableLobbyCreate_checkbox.TabIndex = 16;
            this.other_disableLobbyCreate_checkbox.Text = "Disable Lobby Creation";
            this.other_disableLobbyCreate_checkbox.UseVisualStyleBackColor = true;
            // 
            // other_forceHttpSuccess_checkbox
            // 
            this.other_forceHttpSuccess_checkbox.AutoSize = true;
            this.other_forceHttpSuccess_checkbox.Location = new System.Drawing.Point(233, 200);
            this.other_forceHttpSuccess_checkbox.Name = "other_forceHttpSuccess_checkbox";
            this.other_forceHttpSuccess_checkbox.Size = new System.Drawing.Size(120, 17);
            this.other_forceHttpSuccess_checkbox.TabIndex = 14;
            this.other_forceHttpSuccess_checkbox.Text = "Force Http Success";
            this.other_forceHttpSuccess_checkbox.UseVisualStyleBackColor = true;
            // 
            // other_disableSourceQuery_checkbox
            // 
            this.other_disableSourceQuery_checkbox.AutoSize = true;
            this.other_disableSourceQuery_checkbox.Location = new System.Drawing.Point(233, 223);
            this.other_disableSourceQuery_checkbox.Name = "other_disableSourceQuery_checkbox";
            this.other_disableSourceQuery_checkbox.Size = new System.Drawing.Size(129, 17);
            this.other_disableSourceQuery_checkbox.TabIndex = 15;
            this.other_disableSourceQuery_checkbox.Text = "Disable Source Query";
            this.other_disableSourceQuery_checkbox.UseVisualStyleBackColor = true;
            // 
            // other_disableAvatar_checkbox
            // 
            this.other_disableAvatar_checkbox.AutoSize = true;
            this.other_disableAvatar_checkbox.Location = new System.Drawing.Point(45, 292);
            this.other_disableAvatar_checkbox.Name = "other_disableAvatar_checkbox";
            this.other_disableAvatar_checkbox.Size = new System.Drawing.Size(95, 17);
            this.other_disableAvatar_checkbox.TabIndex = 13;
            this.other_disableAvatar_checkbox.Text = "Disable Avatar";
            this.other_disableAvatar_checkbox.UseVisualStyleBackColor = true;
            // 
            // other_disableFriendPop_checkbox
            // 
            this.other_disableFriendPop_checkbox.AutoSize = true;
            this.other_disableFriendPop_checkbox.Location = new System.Drawing.Point(45, 269);
            this.other_disableFriendPop_checkbox.Name = "other_disableFriendPop_checkbox";
            this.other_disableFriendPop_checkbox.Size = new System.Drawing.Size(149, 17);
            this.other_disableFriendPop_checkbox.TabIndex = 12;
            this.other_disableFriendPop_checkbox.Text = "Disable Friend Notification";
            this.other_disableFriendPop_checkbox.UseVisualStyleBackColor = true;
            // 
            // other_disableAchPop_checkbox
            // 
            this.other_disableAchPop_checkbox.AutoSize = true;
            this.other_disableAchPop_checkbox.Location = new System.Drawing.Point(45, 246);
            this.other_disableAchPop_checkbox.Name = "other_disableAchPop_checkbox";
            this.other_disableAchPop_checkbox.Size = new System.Drawing.Size(182, 17);
            this.other_disableAchPop_checkbox.TabIndex = 11;
            this.other_disableAchPop_checkbox.Text = "Disable Achievement Notification";
            this.other_disableAchPop_checkbox.UseVisualStyleBackColor = true;
            // 
            // other_achBypass_checkbox
            // 
            this.other_achBypass_checkbox.AutoSize = true;
            this.other_achBypass_checkbox.Location = new System.Drawing.Point(45, 223);
            this.other_achBypass_checkbox.Name = "other_achBypass_checkbox";
            this.other_achBypass_checkbox.Size = new System.Drawing.Size(130, 17);
            this.other_achBypass_checkbox.TabIndex = 10;
            this.other_achBypass_checkbox.Text = "Achievements Bypass";
            this.other_achBypass_checkbox.UseVisualStyleBackColor = true;
            // 
            // other_betaBranch_label
            // 
            this.other_betaBranch_label.AutoSize = true;
            this.other_betaBranch_label.Location = new System.Drawing.Point(42, 155);
            this.other_betaBranch_label.Name = "other_betaBranch_label";
            this.other_betaBranch_label.Size = new System.Drawing.Size(69, 13);
            this.other_betaBranch_label.TabIndex = 48;
            this.other_betaBranch_label.Text = "Beta Branch:";
            // 
            // other_forceSteamDeck_checkbox
            // 
            this.other_forceSteamDeck_checkbox.AutoSize = true;
            this.other_forceSteamDeck_checkbox.Location = new System.Drawing.Point(45, 200);
            this.other_forceSteamDeck_checkbox.Name = "other_forceSteamDeck_checkbox";
            this.other_forceSteamDeck_checkbox.Size = new System.Drawing.Size(115, 17);
            this.other_forceSteamDeck_checkbox.TabIndex = 9;
            this.other_forceSteamDeck_checkbox.Text = "Force Steam Deck";
            this.other_forceSteamDeck_checkbox.UseVisualStyleBackColor = true;
            // 
            // other_forceSteamId_label
            // 
            this.other_forceSteamId_label.AutoSize = true;
            this.other_forceSteamId_label.Location = new System.Drawing.Point(42, 51);
            this.other_forceSteamId_label.Name = "other_forceSteamId_label";
            this.other_forceSteamId_label.Size = new System.Drawing.Size(81, 13);
            this.other_forceSteamId_label.TabIndex = 45;
            this.other_forceSteamId_label.Text = "Force SteamID:";
            // 
            // other_forcePort_label
            // 
            this.other_forcePort_label.AutoSize = true;
            this.other_forcePort_label.Location = new System.Drawing.Point(42, 103);
            this.other_forcePort_label.Name = "other_forcePort_label";
            this.other_forcePort_label.Size = new System.Drawing.Size(90, 13);
            this.other_forcePort_label.TabIndex = 43;
            this.other_forcePort_label.Text = "Force Listen Port:";
            // 
            // other_forceLanguage_label
            // 
            this.other_forceLanguage_label.AutoSize = true;
            this.other_forceLanguage_label.Location = new System.Drawing.Point(42, 77);
            this.other_forceLanguage_label.Name = "other_forceLanguage_label";
            this.other_forceLanguage_label.Size = new System.Drawing.Size(88, 13);
            this.other_forceLanguage_label.TabIndex = 41;
            this.other_forceLanguage_label.Text = "Force Language:";
            // 
            // other_forceAccName_label
            // 
            this.other_forceAccName_label.AutoSize = true;
            this.other_forceAccName_label.Location = new System.Drawing.Point(42, 25);
            this.other_forceAccName_label.Name = "other_forceAccName_label";
            this.other_forceAccName_label.Size = new System.Drawing.Size(111, 13);
            this.other_forceAccName_label.TabIndex = 39;
            this.other_forceAccName_label.Text = "Force Account Name:";
            // 
            // other_localSaveName_label
            // 
            this.other_localSaveName_label.AutoSize = true;
            this.other_localSaveName_label.Location = new System.Drawing.Point(42, 129);
            this.other_localSaveName_label.Name = "other_localSaveName_label";
            this.other_localSaveName_label.Size = new System.Drawing.Size(95, 13);
            this.other_localSaveName_label.TabIndex = 36;
            this.other_localSaveName_label.Text = "Local Save Name:";
            // 
            // game_setting_tab
            // 
            this.game_setting_tab.Controls.Add(this.game_getName_bttn);
            this.game_setting_tab.Controls.Add(this.fetchGameId);
            this.game_setting_tab.Controls.Add(this.game_customIconClear_bttn);
            this.game_setting_tab.Controls.Add(this.game_customIcon_bttn);
            this.game_setting_tab.Controls.Add(this.game_customIcon_box);
            this.game_setting_tab.Controls.Add(this.game_clanTag_box);
            this.game_setting_tab.Controls.Add(this.game_appid_box);
            this.game_setting_tab.Controls.Add(this.game_folder_box);
            this.game_setting_tab.Controls.Add(this.game_params_box);
            this.game_setting_tab.Controls.Add(this.game_gameExe_box);
            this.game_setting_tab.Controls.Add(this.game_name_box);
            this.game_setting_tab.Controls.Add(this.game_customIcon_label);
            this.game_setting_tab.Controls.Add(this.game_clanTag_label);
            this.game_setting_tab.Controls.Add(this.game_enableHttp_checkbox);
            this.game_setting_tab.Controls.Add(this.game_offline_checkbox);
            this.game_setting_tab.Controls.Add(this.game_disableNetwork_checkbox);
            this.game_setting_tab.Controls.Add(this.game_disableLan_checkbox);
            this.game_setting_tab.Controls.Add(this.game_disableOverlay_checkbox);
            this.game_setting_tab.Controls.Add(this.browse_start_folder);
            this.game_setting_tab.Controls.Add(this.game_gameExe_bttn);
            this.game_setting_tab.Controls.Add(this.game_x64_checkbox);
            this.game_setting_tab.Controls.Add(this.game_appId_label);
            this.game_setting_tab.Controls.Add(this.game_folder_label);
            this.game_setting_tab.Controls.Add(this.game_params_label);
            this.game_setting_tab.Controls.Add(this.game_gameExe_label);
            this.game_setting_tab.Controls.Add(this.game_name_label);
            this.game_setting_tab.Location = new System.Drawing.Point(4, 22);
            this.game_setting_tab.Name = "game_setting_tab";
            this.game_setting_tab.Padding = new System.Windows.Forms.Padding(3);
            this.game_setting_tab.Size = new System.Drawing.Size(604, 371);
            this.game_setting_tab.TabIndex = 0;
            this.game_setting_tab.Text = "Game Settings";
            this.game_setting_tab.UseVisualStyleBackColor = true;
            // 
            // game_getName_bttn
            // 
            this.game_getName_bttn.Location = new System.Drawing.Point(515, 61);
            this.game_getName_bttn.Name = "game_getName_bttn";
            this.game_getName_bttn.Size = new System.Drawing.Size(44, 20);
            this.game_getName_bttn.TabIndex = 5;
            this.game_getName_bttn.Text = "✏️";
            this.GetName.SetToolTip(this.game_getName_bttn, "Retrieve the proper name from the Steam Store.");
            this.game_getName_bttn.UseVisualStyleBackColor = true;
            this.game_getName_bttn.Click += new System.EventHandler(this.FeachNameFromAppid);
            // 
            // fetchGameId
            // 
            this.fetchGameId.Location = new System.Drawing.Point(233, 35);
            this.fetchGameId.Name = "fetchGameId";
            this.fetchGameId.Size = new System.Drawing.Size(44, 20);
            this.fetchGameId.TabIndex = 3;
            this.fetchGameId.Text = "♻️";
            this.getAppid.SetToolTip(this.fetchGameId, "Retrieve the app ID from the steam_appid.txt file.");
            this.fetchGameId.UseVisualStyleBackColor = true;
            this.fetchGameId.Click += new System.EventHandler(this.FetchAppidFromTxt);
            // 
            // game_customIconClear_bttn
            // 
            this.game_customIconClear_bttn.Location = new System.Drawing.Point(565, 139);
            this.game_customIconClear_bttn.Name = "game_customIconClear_bttn";
            this.game_customIconClear_bttn.Size = new System.Drawing.Size(22, 20);
            this.game_customIconClear_bttn.TabIndex = 12;
            this.game_customIconClear_bttn.Text = "❌";
            this.customIcon.SetToolTip(this.game_customIconClear_bttn, "Clear custom icon path.");
            this.game_customIconClear_bttn.UseVisualStyleBackColor = true;
            this.game_customIconClear_bttn.Click += new System.EventHandler(this.game_customIconClear_bttn_Click);
            // 
            // game_customIcon_bttn
            // 
            this.game_customIcon_bttn.Location = new System.Drawing.Point(515, 139);
            this.game_customIcon_bttn.Name = "game_customIcon_bttn";
            this.game_customIcon_bttn.Size = new System.Drawing.Size(44, 20);
            this.game_customIcon_bttn.TabIndex = 11;
            this.game_customIcon_bttn.Text = "🖼️";
            this.customIcon.SetToolTip(this.game_customIcon_bttn, "Browse for icon files.");
            this.game_customIcon_bttn.UseVisualStyleBackColor = true;
            this.game_customIcon_bttn.Click += new System.EventHandler(this.browse_custom_icon_Click);
            // 
            // game_customIcon_box
            // 
            this.game_customIcon_box.Location = new System.Drawing.Point(153, 139);
            this.game_customIcon_box.Name = "game_customIcon_box";
            this.game_customIcon_box.Size = new System.Drawing.Size(356, 20);
            this.game_customIcon_box.TabIndex = 10;
            // 
            // game_clanTag_box
            // 
            this.game_clanTag_box.Location = new System.Drawing.Point(153, 190);
            this.game_clanTag_box.Name = "game_clanTag_box";
            this.game_clanTag_box.Size = new System.Drawing.Size(124, 20);
            this.game_clanTag_box.TabIndex = 14;
            this.game_clanTag_box.TextChanged += new System.EventHandler(this.clan_tag_add_TextChanged);
            // 
            // game_appid_box
            // 
            this.game_appid_box.Location = new System.Drawing.Point(153, 35);
            this.game_appid_box.Name = "game_appid_box";
            this.game_appid_box.Size = new System.Drawing.Size(74, 20);
            this.game_appid_box.TabIndex = 2;
            // 
            // game_folder_box
            // 
            this.game_folder_box.Location = new System.Drawing.Point(153, 87);
            this.game_folder_box.Name = "game_folder_box";
            this.game_folder_box.Size = new System.Drawing.Size(357, 20);
            this.game_folder_box.TabIndex = 6;
            // 
            // game_params_box
            // 
            this.game_params_box.Location = new System.Drawing.Point(153, 165);
            this.game_params_box.Name = "game_params_box";
            this.game_params_box.Size = new System.Drawing.Size(357, 20);
            this.game_params_box.TabIndex = 13;
            // 
            // game_gameExe_box
            // 
            this.game_gameExe_box.Location = new System.Drawing.Point(153, 113);
            this.game_gameExe_box.Name = "game_gameExe_box";
            this.game_gameExe_box.Size = new System.Drawing.Size(357, 20);
            this.game_gameExe_box.TabIndex = 8;
            // 
            // game_name_box
            // 
            this.game_name_box.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.game_name_box.Location = new System.Drawing.Point(153, 61);
            this.game_name_box.Name = "game_name_box";
            this.game_name_box.Size = new System.Drawing.Size(357, 20);
            this.game_name_box.TabIndex = 4;
            // 
            // game_customIcon_label
            // 
            this.game_customIcon_label.AutoSize = true;
            this.game_customIcon_label.Location = new System.Drawing.Point(32, 142);
            this.game_customIcon_label.Name = "game_customIcon_label";
            this.game_customIcon_label.Size = new System.Drawing.Size(74, 13);
            this.game_customIcon_label.TabIndex = 44;
            this.game_customIcon_label.Text = "Shortcut Icon:";
            // 
            // game_clanTag_label
            // 
            this.game_clanTag_label.AutoSize = true;
            this.game_clanTag_label.Location = new System.Drawing.Point(32, 193);
            this.game_clanTag_label.Name = "game_clanTag_label";
            this.game_clanTag_label.Size = new System.Drawing.Size(53, 13);
            this.game_clanTag_label.TabIndex = 37;
            this.game_clanTag_label.Text = "Clan Tag:";
            // 
            // game_enableHttp_checkbox
            // 
            this.game_enableHttp_checkbox.AutoSize = true;
            this.game_enableHttp_checkbox.Location = new System.Drawing.Point(323, 256);
            this.game_enableHttp_checkbox.Name = "game_enableHttp_checkbox";
            this.game_enableHttp_checkbox.Size = new System.Drawing.Size(236, 17);
            this.game_enableHttp_checkbox.TabIndex = 19;
            this.game_enableHttp_checkbox.Text = "Enable HTTP (Disable lan only has to be on)";
            this.game_enableHttp_checkbox.UseVisualStyleBackColor = true;
            // 
            // game_offline_checkbox
            // 
            this.game_offline_checkbox.AutoSize = true;
            this.game_offline_checkbox.Location = new System.Drawing.Point(153, 279);
            this.game_offline_checkbox.Name = "game_offline_checkbox";
            this.game_offline_checkbox.Size = new System.Drawing.Size(86, 17);
            this.game_offline_checkbox.TabIndex = 17;
            this.game_offline_checkbox.Text = "Offline Mode";
            this.game_offline_checkbox.UseVisualStyleBackColor = true;
            // 
            // game_disableNetwork_checkbox
            // 
            this.game_disableNetwork_checkbox.AutoSize = true;
            this.game_disableNetwork_checkbox.Location = new System.Drawing.Point(323, 279);
            this.game_disableNetwork_checkbox.Name = "game_disableNetwork_checkbox";
            this.game_disableNetwork_checkbox.Size = new System.Drawing.Size(118, 17);
            this.game_disableNetwork_checkbox.TabIndex = 20;
            this.game_disableNetwork_checkbox.Text = "Disable Networking";
            this.game_disableNetwork_checkbox.UseVisualStyleBackColor = true;
            // 
            // game_disableLan_checkbox
            // 
            this.game_disableLan_checkbox.AutoSize = true;
            this.game_disableLan_checkbox.Location = new System.Drawing.Point(323, 233);
            this.game_disableLan_checkbox.Name = "game_disableLan_checkbox";
            this.game_disableLan_checkbox.Size = new System.Drawing.Size(109, 17);
            this.game_disableLan_checkbox.TabIndex = 18;
            this.game_disableLan_checkbox.Text = "Disable LAN Only";
            this.game_disableLan_checkbox.UseVisualStyleBackColor = true;
            // 
            // game_disableOverlay_checkbox
            // 
            this.game_disableOverlay_checkbox.AutoSize = true;
            this.game_disableOverlay_checkbox.Location = new System.Drawing.Point(153, 256);
            this.game_disableOverlay_checkbox.Name = "game_disableOverlay_checkbox";
            this.game_disableOverlay_checkbox.Size = new System.Drawing.Size(100, 17);
            this.game_disableOverlay_checkbox.TabIndex = 16;
            this.game_disableOverlay_checkbox.Text = "Disable Overlay";
            this.game_disableOverlay_checkbox.UseVisualStyleBackColor = true;
            // 
            // browse_start_folder
            // 
            this.browse_start_folder.Location = new System.Drawing.Point(515, 87);
            this.browse_start_folder.Name = "browse_start_folder";
            this.browse_start_folder.Size = new System.Drawing.Size(44, 20);
            this.browse_start_folder.TabIndex = 7;
            this.browse_start_folder.Text = "📂";
            this.openFolder.SetToolTip(this.browse_start_folder, "Open game´s root folder.");
            this.browse_start_folder.UseVisualStyleBackColor = true;
            this.browse_start_folder.Click += new System.EventHandler(this.Browse_start_folder_Click);
            // 
            // game_gameExe_bttn
            // 
            this.game_gameExe_bttn.Location = new System.Drawing.Point(515, 113);
            this.game_gameExe_bttn.Name = "game_gameExe_bttn";
            this.game_gameExe_bttn.Size = new System.Drawing.Size(44, 20);
            this.game_gameExe_bttn.TabIndex = 9;
            this.game_gameExe_bttn.Text = "🔎";
            this.openGameExe.SetToolTip(this.game_gameExe_bttn, "Open game.exe file folder.");
            this.game_gameExe_bttn.UseVisualStyleBackColor = true;
            this.game_gameExe_bttn.Click += new System.EventHandler(this.Browse_game_exe_Click);
            // 
            // game_x64_checkbox
            // 
            this.game_x64_checkbox.AutoSize = true;
            this.game_x64_checkbox.Enabled = false;
            this.game_x64_checkbox.Location = new System.Drawing.Point(153, 233);
            this.game_x64_checkbox.Name = "game_x64_checkbox";
            this.game_x64_checkbox.Size = new System.Drawing.Size(79, 17);
            this.game_x64_checkbox.TabIndex = 15;
            this.game_x64_checkbox.Text = "Use 64-bits";
            this.x64x32.SetToolTip(this.game_x64_checkbox, "This value is automatically set based on your game\'s DLL files.");
            this.game_x64_checkbox.UseVisualStyleBackColor = true;
            // 
            // game_appId_label
            // 
            this.game_appId_label.AutoSize = true;
            this.game_appId_label.Location = new System.Drawing.Point(32, 38);
            this.game_appId_label.Name = "game_appId_label";
            this.game_appId_label.Size = new System.Drawing.Size(71, 13);
            this.game_appId_label.TabIndex = 10;
            this.game_appId_label.Text = "Game AppID:";
            // 
            // game_folder_label
            // 
            this.game_folder_label.AutoSize = true;
            this.game_folder_label.Location = new System.Drawing.Point(32, 90);
            this.game_folder_label.Name = "game_folder_label";
            this.game_folder_label.Size = new System.Drawing.Size(70, 13);
            this.game_folder_label.TabIndex = 7;
            this.game_folder_label.Text = "Game Folder:";
            // 
            // game_params_label
            // 
            this.game_params_label.AutoSize = true;
            this.game_params_label.Location = new System.Drawing.Point(32, 168);
            this.game_params_label.Name = "game_params_label";
            this.game_params_label.Size = new System.Drawing.Size(102, 13);
            this.game_params_label.TabIndex = 5;
            this.game_params_label.Text = "Launch Parameters:";
            // 
            // game_gameExe_label
            // 
            this.game_gameExe_label.AutoSize = true;
            this.game_gameExe_label.Location = new System.Drawing.Point(32, 116);
            this.game_gameExe_label.Name = "game_gameExe_label";
            this.game_gameExe_label.Size = new System.Drawing.Size(94, 13);
            this.game_gameExe_label.TabIndex = 3;
            this.game_gameExe_label.Text = "Game Executable:";
            // 
            // game_name_label
            // 
            this.game_name_label.AutoSize = true;
            this.game_name_label.Location = new System.Drawing.Point(32, 64);
            this.game_name_label.Name = "game_name_label";
            this.game_name_label.Size = new System.Drawing.Size(69, 13);
            this.game_name_label.TabIndex = 1;
            this.game_name_label.Text = "Game Name:";
            // 
            // navigation_tab
            // 
            this.navigation_tab.Controls.Add(this.game_setting_tab);
            this.navigation_tab.Controls.Add(this.other_tab);
            this.navigation_tab.Controls.Add(this.dlc_tab);
            this.navigation_tab.Controls.Add(this.ServerBrowser);
            this.navigation_tab.Controls.Add(this.stats_tab);
            this.navigation_tab.Controls.Add(this.advanced_tab);
            this.navigation_tab.Controls.Add(this.broadcast_tab);
            this.navigation_tab.Location = new System.Drawing.Point(12, 12);
            this.navigation_tab.Name = "navigation_tab";
            this.navigation_tab.SelectedIndex = 0;
            this.navigation_tab.Size = new System.Drawing.Size(612, 397);
            this.navigation_tab.TabIndex = 1;
            // 
            // GameSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 450);
            this.Controls.Add(this.navigation_tab);
            this.Controls.Add(this.gameSettings_cancel_bttn);
            this.Controls.Add(this.gameSettings_save_bttn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameSettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "SmartGoldbergEmu Launcher";
            this.Load += new System.EventHandler(this.GameSettingsForm_Load);
            this.broadcast_tab.ResumeLayout(false);
            this.broadcast_tab.PerformLayout();
            this.advanced_tab.ResumeLayout(false);
            this.advanced_tab.PerformLayout();
            this.stats_tab.ResumeLayout(false);
            this.stats_tab.PerformLayout();
            this.ServerBrowser.ResumeLayout(false);
            this.ServerBrowser.PerformLayout();
            this.dlc_tab.ResumeLayout(false);
            this.dlc_tab.PerformLayout();
            this.other_tab.ResumeLayout(false);
            this.other_tab.PerformLayout();
            this.game_setting_tab.ResumeLayout(false);
            this.game_setting_tab.PerformLayout();
            this.navigation_tab.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.Button gameSettings_save_bttn;
        private System.Windows.Forms.Button gameSettings_cancel_bttn;
        private System.Windows.Forms.TabPage broadcast_tab;
        private System.Windows.Forms.Button broadcast_getMods_bttn;
        private System.Windows.Forms.Button broadcast_createDllFolder_bttn;
        private System.Windows.Forms.Button broadcast_createModsFolder_bttn;
        private System.Windows.Forms.Button broadcast_clearEnvList_bttn;
        private System.Windows.Forms.Button broadcast_removeEnv_bttn;
        private System.Windows.Forms.Button broadcast_addEnv_bttn;
        private CueTextBox broadcast_envKey_box;
        private CueTextBox broadcast_envName_box;
        private CueTextBox broadcast_custom_box;
        private System.Windows.Forms.ListBox broadcast_envList_box;
        private System.Windows.Forms.Label broadcast_customEnv_label;
        private System.Windows.Forms.Button broadcast_customClear_bttn;
        private System.Windows.Forms.Button broadcast_customRemove_bttn;
        private System.Windows.Forms.Button broadcast_customAdd_bttn;
        private System.Windows.Forms.ListBox broadcast_ipList_box;
        private System.Windows.Forms.Label broadcast_custom_label;
        private System.Windows.Forms.TabPage advanced_tab;
        private System.Windows.Forms.Label advanced_installedApps_label;
        private System.Windows.Forms.TextBox advanced_installedApps_box;
        private System.Windows.Forms.TextBox advanced_customDepots_box;
        private System.Windows.Forms.TextBox advanced_subscribedGroups_box;
        private System.Windows.Forms.TextBox advanced_customPaths_box;
        private System.Windows.Forms.Label advanced_custmDepots_label;
        private System.Windows.Forms.Label advanced_subscribedGroups_label;
        private System.Windows.Forms.Label advanced_customPaths_label;
        private System.Windows.Forms.TabPage stats_tab;
        private System.Windows.Forms.CheckBox stats_disbleStatsShare_checkbox;
        private System.Windows.Forms.CheckBox stats_serverStats_checkbox;
        private System.Windows.Forms.CheckBox stats_bestScoreSaveOnly_checkbox;
        private System.Windows.Forms.CheckBox stats_allowUnkStats_checkbox;
        private System.Windows.Forms.Button stats_getStats_bttn;
        private System.Windows.Forms.Label stats_custom_label;
        private System.Windows.Forms.TextBox stats_custom_box;
        private System.Windows.Forms.TabPage ServerBrowser;
        private System.Windows.Forms.TextBox server_history_box;
        private System.Windows.Forms.TextBox server_favorites_box;
        private System.Windows.Forms.TextBox server_spectate_box;
        private System.Windows.Forms.Label server_history_label;
        private System.Windows.Forms.Label server_favorites_label;
        private System.Windows.Forms.Label server_spectate_label;
        private System.Windows.Forms.TabPage dlc_tab;
        private System.Windows.Forms.CheckBox dlc_unlockAllDlc_bttn;
        private System.Windows.Forms.Button dlc_generateList_bttn;
        private System.Windows.Forms.Label dlc_customList_label;
        private System.Windows.Forms.TextBox dlc_list_box;
        private System.Windows.Forms.TabPage other_tab;
        private System.Windows.Forms.Label other_forceIp_label;
        private System.Windows.Forms.TextBox other_forceIp_box;
        private System.Windows.Forms.TextBox other_betaBranch_box;
        private System.Windows.Forms.TextBox other_forceSteamId_box;
        private System.Windows.Forms.TextBox other_forcePort_box;
        private System.Windows.Forms.TextBox other_forceLanguage_box;
        private System.Windows.Forms.TextBox other_forceAccName_box;
        private System.Windows.Forms.TextBox other_localSaveName_box;
        private System.Windows.Forms.CheckBox other_disableUknLeaderboard_checkbox;
        private System.Windows.Forms.CheckBox other_mmActualType_checkbox;
        private System.Windows.Forms.CheckBox other_mmSourceQuery_checkbox;
        private System.Windows.Forms.CheckBox other_shareLeaderboard_checkbox;
        private System.Windows.Forms.CheckBox other_disableLobbyCreate_checkbox;
        private System.Windows.Forms.CheckBox other_forceHttpSuccess_checkbox;
        private System.Windows.Forms.CheckBox other_disableSourceQuery_checkbox;
        private System.Windows.Forms.CheckBox other_disableAvatar_checkbox;
        private System.Windows.Forms.CheckBox other_disableFriendPop_checkbox;
        private System.Windows.Forms.CheckBox other_disableAchPop_checkbox;
        private System.Windows.Forms.CheckBox other_achBypass_checkbox;
        private System.Windows.Forms.Label other_betaBranch_label;
        private System.Windows.Forms.CheckBox other_forceSteamDeck_checkbox;
        private System.Windows.Forms.Label other_forceSteamId_label;
        private System.Windows.Forms.Label other_forcePort_label;
        private System.Windows.Forms.Label other_forceLanguage_label;
        private System.Windows.Forms.Label other_forceAccName_label;
        private System.Windows.Forms.Label other_localSaveName_label;
        private System.Windows.Forms.TabPage game_setting_tab;
        private System.Windows.Forms.Button game_customIcon_bttn;
        private System.Windows.Forms.TextBox game_customIcon_box;
        private System.Windows.Forms.TextBox game_clanTag_box;
        private System.Windows.Forms.TextBox game_appid_box;
        private System.Windows.Forms.TextBox game_folder_box;
        private System.Windows.Forms.TextBox game_params_box;
        private System.Windows.Forms.TextBox game_gameExe_box;
        private System.Windows.Forms.TextBox game_name_box;
        private System.Windows.Forms.Label game_customIcon_label;
        private System.Windows.Forms.Label game_clanTag_label;
        private System.Windows.Forms.CheckBox game_enableHttp_checkbox;
        private System.Windows.Forms.CheckBox game_offline_checkbox;
        private System.Windows.Forms.CheckBox game_disableNetwork_checkbox;
        private System.Windows.Forms.CheckBox game_disableLan_checkbox;
        private System.Windows.Forms.CheckBox game_disableOverlay_checkbox;
        private System.Windows.Forms.Button browse_start_folder;
        private System.Windows.Forms.Button game_gameExe_bttn;
        private System.Windows.Forms.CheckBox game_x64_checkbox;
        private System.Windows.Forms.Label game_appId_label;
        private System.Windows.Forms.Label game_folder_label;
        private System.Windows.Forms.Label game_params_label;
        private System.Windows.Forms.Label game_gameExe_label;
        private System.Windows.Forms.Label game_name_label;
        private System.Windows.Forms.TabControl navigation_tab;
        private System.Windows.Forms.Label dlc_disable_desc;
        private System.Windows.Forms.ToolTip getAppid;
        private System.Windows.Forms.ToolTip GetName;
        private System.Windows.Forms.ToolTip unlockAllDlc;
        private System.Windows.Forms.ToolTip x64x32;
        private System.Windows.Forms.Button game_customIconClear_bttn;
        private System.Windows.Forms.Button fetchGameId;
        private System.Windows.Forms.Button game_getName_bttn;
        private System.Windows.Forms.ToolTip openFolder;
        private System.Windows.Forms.ToolTip openGameExe;
        private System.Windows.Forms.ToolTip customIcon;
        private System.Windows.Forms.ToolTip custoInconClear;
    }
}