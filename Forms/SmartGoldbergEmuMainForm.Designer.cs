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

namespace SmartGoldbergEmu
{
    partial class SmartGoldbergEmuMainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SmartGoldbergEmuMainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tilesViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compactTilesViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iconViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailsToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.sortToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nameToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ascToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.descToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.appIdToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ascToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.descToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.noneToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.capsuleTilesViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ascToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appidToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ascToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.descToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.noneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.largeIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.app_list_view = new System.Windows.Forms.ListView();
            this.capp_contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runWithoutEmuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorRun = new System.Windows.Forms.ToolStripSeparator();
            this.generateAchievementsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorGen = new System.Windows.Forms.ToolStripSeparator();
            this.openGameEmuFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openInventoryFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorSettings = new System.Windows.Forms.ToolStripSeparator();
            this.openGameStoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openCommunityPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSteamWorkshopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorSteam = new System.Windows.Forms.ToolStripSeparator();
            this.createShortcutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyGuidToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorProps = new System.Windows.Forms.ToolStripSeparator();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.feedbackProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.feedbackLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.canvas_contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.iconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.capp_contextMenuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.canvas_contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem2,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(371, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addGameToolStripMenuItem,
            this.editGameToolStripMenuItem,
            this.deleteGameToolStripMenuItem,
            this.toolStripMenuItem2,
            this.settingsToolStripMenuItem,
            this.toolStripMenuItem3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // addGameToolStripMenuItem
            // 
            this.addGameToolStripMenuItem.Name = "addGameToolStripMenuItem";
            this.addGameToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.addGameToolStripMenuItem.Text = "Add Game";
            this.addGameToolStripMenuItem.Click += new System.EventHandler(this.AddGameToolStripMenuItem_Click);
            // 
            // editGameToolStripMenuItem
            // 
            this.editGameToolStripMenuItem.Name = "editGameToolStripMenuItem";
            this.editGameToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.editGameToolStripMenuItem.Text = "Edit Game";
            this.editGameToolStripMenuItem.Click += new System.EventHandler(this.EditGameToolStripMenuItem_Click);
            // 
            // deleteGameToolStripMenuItem
            // 
            this.deleteGameToolStripMenuItem.Name = "deleteGameToolStripMenuItem";
            this.deleteGameToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.deleteGameToolStripMenuItem.Text = "Delete Game";
            this.deleteGameToolStripMenuItem.Click += new System.EventHandler(this.DeleteGameToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(138, 6);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(138, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem2
            // 
            this.viewToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tilesViewToolStripMenuItem,
            this.compactTilesViewToolStripMenuItem,
            this.iconViewToolStripMenuItem,
            this.detailsToolStripMenuItem2,
            this.toolStripSeparator6,
            this.sortToolStripMenuItem1,
            this.toolStripSeparator7,
            this.refreshToolStripMenuItem1});
            this.viewToolStripMenuItem2.Name = "viewToolStripMenuItem2";
            this.viewToolStripMenuItem2.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem2.Text = "View";
            // 
            // tilesViewToolStripMenuItem
            // 
            this.tilesViewToolStripMenuItem.Name = "tilesViewToolStripMenuItem";
            this.tilesViewToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.tilesViewToolStripMenuItem.Text = "Tiles";
            this.tilesViewToolStripMenuItem.Click += new System.EventHandler(this.TileToolStripMenuItem_Click_Handler);
            // 
            // compactTilesViewToolStripMenuItem
            // 
            this.compactTilesViewToolStripMenuItem.Name = "compactTilesViewToolStripMenuItem";
            this.compactTilesViewToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.compactTilesViewToolStripMenuItem.Text = "Compact Tiles";
            this.compactTilesViewToolStripMenuItem.Click += new System.EventHandler(this.CapsuleTileToolStripMenuItem_Click_Handler);
            // 
            // iconViewToolStripMenuItem
            // 
            this.iconViewToolStripMenuItem.Name = "iconViewToolStripMenuItem";
            this.iconViewToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.iconViewToolStripMenuItem.Text = "Icons";
            this.iconViewToolStripMenuItem.Click += new System.EventHandler(this.LargeIconsToolStripMenuItem_Click);
            // 
            // detailsToolStripMenuItem2
            // 
            this.detailsToolStripMenuItem2.Name = "detailsToolStripMenuItem2";
            this.detailsToolStripMenuItem2.Size = new System.Drawing.Size(149, 22);
            this.detailsToolStripMenuItem2.Text = "Details";
            this.detailsToolStripMenuItem2.Click += new System.EventHandler(this.DetailsToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(146, 6);
            // 
            // sortToolStripMenuItem1
            // 
            this.sortToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nameToolStripMenuItem1,
            this.appIdToolStripMenuItem1,
            this.toolStripSeparator8,
            this.noneToolStripMenuItem1});
            this.sortToolStripMenuItem1.Name = "sortToolStripMenuItem1";
            this.sortToolStripMenuItem1.Size = new System.Drawing.Size(149, 22);
            this.sortToolStripMenuItem1.Text = "Sort";
            // 
            // nameToolStripMenuItem1
            // 
            this.nameToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ascToolStripMenuItem2,
            this.descToolStripMenuItem2});
            this.nameToolStripMenuItem1.Name = "nameToolStripMenuItem1";
            this.nameToolStripMenuItem1.Size = new System.Drawing.Size(106, 22);
            this.nameToolStripMenuItem1.Text = "Name";
            // 
            // ascToolStripMenuItem2
            // 
            this.ascToolStripMenuItem2.Name = "ascToolStripMenuItem2";
            this.ascToolStripMenuItem2.Size = new System.Drawing.Size(99, 22);
            this.ascToolStripMenuItem2.Text = "Asc";
            this.ascToolStripMenuItem2.Click += new System.EventHandler(this.SortByNameAscMenuItem_Click);
            // 
            // descToolStripMenuItem2
            // 
            this.descToolStripMenuItem2.Name = "descToolStripMenuItem2";
            this.descToolStripMenuItem2.Size = new System.Drawing.Size(99, 22);
            this.descToolStripMenuItem2.Text = "Desc";
            this.descToolStripMenuItem2.Click += new System.EventHandler(this.SortByNameDescMenuItem_Click);
            // 
            // appIdToolStripMenuItem1
            // 
            this.appIdToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ascToolStripMenuItem3,
            this.descToolStripMenuItem3});
            this.appIdToolStripMenuItem1.Name = "appIdToolStripMenuItem1";
            this.appIdToolStripMenuItem1.Size = new System.Drawing.Size(106, 22);
            this.appIdToolStripMenuItem1.Text = "AppId";
            // 
            // ascToolStripMenuItem3
            // 
            this.ascToolStripMenuItem3.Name = "ascToolStripMenuItem3";
            this.ascToolStripMenuItem3.Size = new System.Drawing.Size(99, 22);
            this.ascToolStripMenuItem3.Text = "Asc";
            this.ascToolStripMenuItem3.Click += new System.EventHandler(this.SortByAppIDAscMenuItem_Click);
            // 
            // descToolStripMenuItem3
            // 
            this.descToolStripMenuItem3.Name = "descToolStripMenuItem3";
            this.descToolStripMenuItem3.Size = new System.Drawing.Size(99, 22);
            this.descToolStripMenuItem3.Text = "Desc";
            this.descToolStripMenuItem3.Click += new System.EventHandler(this.SortByAppIDDescMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(103, 6);
            // 
            // noneToolStripMenuItem1
            // 
            this.noneToolStripMenuItem1.Name = "noneToolStripMenuItem1";
            this.noneToolStripMenuItem1.Size = new System.Drawing.Size(106, 22);
            this.noneToolStripMenuItem1.Text = "None";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(146, 6);
            // 
            // refreshToolStripMenuItem1
            // 
            this.refreshToolStripMenuItem1.Name = "refreshToolStripMenuItem1";
            this.refreshToolStripMenuItem1.Size = new System.Drawing.Size(149, 22);
            this.refreshToolStripMenuItem1.Text = "Refresh";
            this.refreshToolStripMenuItem1.Click += new System.EventHandler(this.RefreshToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // capsuleTilesViewToolStripMenuItem
            // 
            this.capsuleTilesViewToolStripMenuItem.Name = "capsuleTilesViewToolStripMenuItem";
            this.capsuleTilesViewToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.capsuleTilesViewToolStripMenuItem.Text = "Compact Tiles";
            this.capsuleTilesViewToolStripMenuItem.Click += new System.EventHandler(this.CapsuleTileToolStripMenuItem_Click_Handler);
            // 
            // sortToolStripMenuItem
            // 
            this.sortToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nameToolStripMenuItem,
            this.appidToolStripMenuItem,
            this.toolStripSeparator5,
            this.noneToolStripMenuItem});
            this.sortToolStripMenuItem.Name = "sortToolStripMenuItem";
            this.sortToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.sortToolStripMenuItem.Text = "Sort";
            // 
            // nameToolStripMenuItem
            // 
            this.nameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ascToolStripMenuItem,
            this.descToolStripMenuItem});
            this.nameToolStripMenuItem.Name = "nameToolStripMenuItem";
            this.nameToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.nameToolStripMenuItem.Text = "Name";
            // 
            // ascToolStripMenuItem
            // 
            this.ascToolStripMenuItem.Name = "ascToolStripMenuItem";
            this.ascToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.ascToolStripMenuItem.Text = "Asc";
            this.ascToolStripMenuItem.Click += new System.EventHandler(this.SortByNameAscMenuItem_Click);
            // 
            // descToolStripMenuItem
            // 
            this.descToolStripMenuItem.Name = "descToolStripMenuItem";
            this.descToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.descToolStripMenuItem.Text = "Desc";
            this.descToolStripMenuItem.Click += new System.EventHandler(this.SortByNameDescMenuItem_Click);
            // 
            // appidToolStripMenuItem
            // 
            this.appidToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ascToolStripMenuItem1,
            this.descToolStripMenuItem1});
            this.appidToolStripMenuItem.Name = "appidToolStripMenuItem";
            this.appidToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.appidToolStripMenuItem.Text = "Appid";
            // 
            // ascToolStripMenuItem1
            // 
            this.ascToolStripMenuItem1.Name = "ascToolStripMenuItem1";
            this.ascToolStripMenuItem1.Size = new System.Drawing.Size(99, 22);
            this.ascToolStripMenuItem1.Text = "Asc";
            this.ascToolStripMenuItem1.Click += new System.EventHandler(this.SortByAppIDAscMenuItem_Click);
            // 
            // descToolStripMenuItem1
            // 
            this.descToolStripMenuItem1.Name = "descToolStripMenuItem1";
            this.descToolStripMenuItem1.Size = new System.Drawing.Size(99, 22);
            this.descToolStripMenuItem1.Text = "Desc";
            this.descToolStripMenuItem1.Click += new System.EventHandler(this.SortByAppIDDescMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(103, 6);
            // 
            // noneToolStripMenuItem
            // 
            this.noneToolStripMenuItem.Name = "noneToolStripMenuItem";
            this.noneToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.noneToolStripMenuItem.Text = "None";
            this.noneToolStripMenuItem.Click += new System.EventHandler(this.SortByNoneMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(110, 6);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tileToolStripMenuItem,
            this.capsuleTilesViewToolStripMenuItem,
            this.largeIconsToolStripMenuItem,
            this.detailsToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // tileToolStripMenuItem
            // 
            this.tileToolStripMenuItem.Name = "tileToolStripMenuItem";
            this.tileToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.tileToolStripMenuItem.Text = "Tile";
            this.tileToolStripMenuItem.Click += new System.EventHandler(this.TileToolStripMenuItem_Click_Handler);
            // 
            // largeIconsToolStripMenuItem
            // 
            this.largeIconsToolStripMenuItem.Name = "largeIconsToolStripMenuItem";
            this.largeIconsToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.largeIconsToolStripMenuItem.Text = "Icons";
            this.largeIconsToolStripMenuItem.Click += new System.EventHandler(this.LargeIconsToolStripMenuItem_Click);
            // 
            // detailsToolStripMenuItem
            // 
            this.detailsToolStripMenuItem.Name = "detailsToolStripMenuItem";
            this.detailsToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.detailsToolStripMenuItem.Text = "Details";
            this.detailsToolStripMenuItem.Click += new System.EventHandler(this.DetailsToolStripMenuItem_Click);
            // 
            // app_list_view
            // 
            this.app_list_view.AllowDrop = true;
            this.app_list_view.Dock = System.Windows.Forms.DockStyle.Fill;
            this.app_list_view.HideSelection = false;
            this.app_list_view.Location = new System.Drawing.Point(0, 24);
            this.app_list_view.Name = "app_list_view";
            this.app_list_view.Size = new System.Drawing.Size(371, 365);
            this.app_list_view.TabIndex = 1;
            this.app_list_view.UseCompatibleStateImageBehavior = false;
            this.app_list_view.View = System.Windows.Forms.View.Details;
            this.app_list_view.DragDrop += new System.Windows.Forms.DragEventHandler(this.App_list_view_DragDrop);
            this.app_list_view.DragEnter += new System.Windows.Forms.DragEventHandler(this.App_list_view_DragEnter);
            this.app_list_view.DoubleClick += new System.EventHandler(this.App_list_view_MouseDoubleClick);
            this.app_list_view.KeyUp += new System.Windows.Forms.KeyEventHandler(this.App_list_view_KeyUp);
            this.app_list_view.MouseUp += new System.Windows.Forms.MouseEventHandler(this.App_list_view_MouseUp);
            // 
            // capp_contextMenuStrip
            // 
            this.capp_contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runToolStripMenuItem,
            this.runWithoutEmuToolStripMenuItem,
            this.toolStripSeparatorRun,
            this.generateAchievementsToolStripMenuItem,
            this.generateItemsToolStripMenuItem,
            this.toolStripSeparatorGen,
            this.openGameEmuFolderToolStripMenuItem,
            this.openInventoryFileToolStripMenuItem,
            this.toolStripSeparatorSettings,
            this.openGameStoreToolStripMenuItem,
            this.openCommunityPageToolStripMenuItem,
            this.openSteamWorkshopToolStripMenuItem,
            this.toolStripSeparatorSteam,
            this.createShortcutToolStripMenuItem,
            this.copyGuidToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.toolStripSeparatorProps,
            this.propertiesToolStripMenuItem});
            this.capp_contextMenuStrip.Name = "capp_contextMenuStrip";
            this.capp_contextMenuStrip.Size = new System.Drawing.Size(204, 320);
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.runToolStripMenuItem.Text = "Run";
            this.runToolStripMenuItem.Click += new System.EventHandler(this.RunToolStripMenuItem_Click);
            // 
            // runWithoutEmuToolStripMenuItem
            // 
            this.runWithoutEmuToolStripMenuItem.Name = "runWithoutEmuToolStripMenuItem";
            this.runWithoutEmuToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.runWithoutEmuToolStripMenuItem.Text = "Run Without Emulator";
            this.runWithoutEmuToolStripMenuItem.Click += new System.EventHandler(this.RunWithoutEmuToolStripMenuItem_Click);
            // 
            // toolStripSeparatorRun
            // 
            this.toolStripSeparatorRun.Name = "toolStripSeparatorRun";
            this.toolStripSeparatorRun.Size = new System.Drawing.Size(200, 6);
            // 
            // generateAchievementsToolStripMenuItem
            // 
            this.generateAchievementsToolStripMenuItem.Name = "generateAchievementsToolStripMenuItem";
            this.generateAchievementsToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.generateAchievementsToolStripMenuItem.Text = "Generate Achievements";
            this.generateAchievementsToolStripMenuItem.Click += new System.EventHandler(this.GenerateAchievementsToolStripMenuItem_Click);
            // 
            // generateItemsToolStripMenuItem
            // 
            this.generateItemsToolStripMenuItem.Name = "generateItemsToolStripMenuItem";
            this.generateItemsToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.generateItemsToolStripMenuItem.Text = "Generate Items";
            this.generateItemsToolStripMenuItem.Click += new System.EventHandler(this.GenerateItemsToolStripMenuItem_Click);
            // 
            // toolStripSeparatorGen
            // 
            this.toolStripSeparatorGen.Name = "toolStripSeparatorGen";
            this.toolStripSeparatorGen.Size = new System.Drawing.Size(200, 6);
            // 
            // openGameEmuFolderToolStripMenuItem
            // 
            this.openGameEmuFolderToolStripMenuItem.Name = "openGameEmuFolderToolStripMenuItem";
            this.openGameEmuFolderToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.openGameEmuFolderToolStripMenuItem.Text = "Settings Folder";
            this.openGameEmuFolderToolStripMenuItem.Click += new System.EventHandler(this.OpenGameEmuFolderToolStripMenuItem_Click);
            // 
            // openInventoryFileToolStripMenuItem
            // 
            this.openInventoryFileToolStripMenuItem.Name = "openInventoryFileToolStripMenuItem";
            this.openInventoryFileToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.openInventoryFileToolStripMenuItem.Text = "Open Inventory File";
            this.openInventoryFileToolStripMenuItem.Click += new System.EventHandler(this.OpenInventoryFileToolStripMenuItem_Click);
            // 
            // toolStripSeparatorSettings
            // 
            this.toolStripSeparatorSettings.Name = "toolStripSeparatorSettings";
            this.toolStripSeparatorSettings.Size = new System.Drawing.Size(200, 6);
            // 
            // openGameStoreToolStripMenuItem
            // 
            this.openGameStoreToolStripMenuItem.Name = "openGameStoreToolStripMenuItem";
            this.openGameStoreToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.openGameStoreToolStripMenuItem.Text = "Steam Store Page";
            this.openGameStoreToolStripMenuItem.Click += new System.EventHandler(this.OpenGameStoreToolStripMenuItem_Click);
            // 
            // openCommunityPageToolStripMenuItem
            // 
            this.openCommunityPageToolStripMenuItem.Name = "openCommunityPageToolStripMenuItem";
            this.openCommunityPageToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.openCommunityPageToolStripMenuItem.Text = "Steam Community Page";
            this.openCommunityPageToolStripMenuItem.Click += new System.EventHandler(this.OpenCommunityPageToolStripMenuItem_Click);
            // 
            // openSteamWorkshopToolStripMenuItem
            // 
            this.openSteamWorkshopToolStripMenuItem.Name = "openSteamWorkshopToolStripMenuItem";
            this.openSteamWorkshopToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.openSteamWorkshopToolStripMenuItem.Text = "Steam Workshop Page";
            this.openSteamWorkshopToolStripMenuItem.Click += new System.EventHandler(this.OpenSteamWorkshopToolStripMenuItem_Click);
            // 
            // toolStripSeparatorSteam
            // 
            this.toolStripSeparatorSteam.Name = "toolStripSeparatorSteam";
            this.toolStripSeparatorSteam.Size = new System.Drawing.Size(200, 6);
            // 
            // createShortcutToolStripMenuItem
            // 
            this.createShortcutToolStripMenuItem.Name = "createShortcutToolStripMenuItem";
            this.createShortcutToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.createShortcutToolStripMenuItem.Text = "Create Shortcut";
            this.createShortcutToolStripMenuItem.Click += new System.EventHandler(this.CreateShortcutToolStripMenuItem_Click);
            // 
            // copyGuidToolStripMenuItem
            // 
            this.copyGuidToolStripMenuItem.Name = "copyGuidToolStripMenuItem";
            this.copyGuidToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.copyGuidToolStripMenuItem.Text = "Copy GUID";
            this.copyGuidToolStripMenuItem.Click += new System.EventHandler(this.CopyGuidToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.RemoveToolStripMenuItem_Click);
            // 
            // toolStripSeparatorProps
            // 
            this.toolStripSeparatorProps.Name = "toolStripSeparatorProps";
            this.toolStripSeparatorProps.Size = new System.Drawing.Size(200, 6);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.propertiesToolStripMenuItem.Text = "Properties";
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.PropertiesToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.feedbackProgressBar,
            this.feedbackLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 389);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(371, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip";
            // 
            // feedbackProgressBar
            // 
            this.feedbackProgressBar.Name = "feedbackProgressBar";
            this.feedbackProgressBar.Size = new System.Drawing.Size(80, 16);
            // 
            // feedbackLabel
            // 
            this.feedbackLabel.Name = "feedbackLabel";
            this.feedbackLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // canvas_contextMenuStrip
            // 
            this.canvas_contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sortToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolStripSeparator4,
            this.refreshToolStripMenuItem});
            this.canvas_contextMenuStrip.Name = "canvas_contextMenuStrip";
            this.canvas_contextMenuStrip.Size = new System.Drawing.Size(114, 76);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.RefreshToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem1
            // 
            this.viewToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iconsToolStripMenuItem,
            this.detailsToolStripMenuItem1});
            this.viewToolStripMenuItem1.Name = "viewToolStripMenuItem1";
            this.viewToolStripMenuItem1.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem1.Text = "View";
            // 
            // iconsToolStripMenuItem
            // 
            this.iconsToolStripMenuItem.Name = "iconsToolStripMenuItem";
            this.iconsToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.iconsToolStripMenuItem.Text = "Icon view";
            // 
            // detailsToolStripMenuItem1
            // 
            this.detailsToolStripMenuItem1.Name = "detailsToolStripMenuItem1";
            this.detailsToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.detailsToolStripMenuItem1.Text = "Details";
            // 
            // SmartGoldbergEmuMainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 411);
            this.Controls.Add(this.app_list_view);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(160, 150);
            this.Name = "SmartGoldbergEmuMainForm";
            this.Text = "SmartGoldbergEmu Launcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Zatvaranje);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SmartGoldbergEmuMainForm_FormClosed);
            this.Load += new System.EventHandler(this.Otvaranje);
            this.SizeChanged += new System.EventHandler(this.SmartGoldbergEmuMainForm_SizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.capp_contextMenuStrip.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.canvas_contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ListView app_list_view;
        private System.Windows.Forms.ContextMenuStrip capp_contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateAchievementsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateItemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openGameEmuFolderToolStripMenuItem;
        //private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem createShortcutToolStripMenuItem;
        //private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem openGameStoreToolStripMenuItem;
        //private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar feedbackProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel feedbackLabel;
        private System.Windows.Forms.ContextMenuStrip canvas_contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem largeIconsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem iconsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem tilesViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iconViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem sortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ascToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem descToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appidToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ascToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem descToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem noneToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runWithoutEmuToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorRun;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorGen;
        private System.Windows.Forms.ToolStripMenuItem openInventoryFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorSettings;
        private System.Windows.Forms.ToolStripMenuItem copyGuidToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorSteam;
        private System.Windows.Forms.ToolStripMenuItem openCommunityPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openSteamWorkshopToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorProps;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem sortToolStripMenuItem1;
        private ToolStripMenuItem nameToolStripMenuItem1;
        private ToolStripMenuItem ascToolStripMenuItem2;
        private ToolStripMenuItem descToolStripMenuItem2;
        private ToolStripMenuItem appIdToolStripMenuItem1;
        private ToolStripMenuItem ascToolStripMenuItem3;
        private ToolStripMenuItem descToolStripMenuItem3;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripMenuItem noneToolStripMenuItem1;
        private ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem capsuleTilesViewToolStripMenuItem;
        private ToolStripMenuItem compactTilesViewToolStripMenuItem;
    }
}

