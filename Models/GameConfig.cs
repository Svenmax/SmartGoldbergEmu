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

// Represents the configuration of a game and its associated settings for emulation.
using SmartGoldbergEmu;
using System.Collections.Generic;
using System.Diagnostics;
using System;

public class GameConfig
{
    public EmuConfig Config { get; set; }
    public string StartFolder { get; set; }
    public string AppName { get; set; }
    public ulong AppId { get; set; }
    public string Parameters { get; set; }
    public bool UseX64 { get; set; }
    public bool DisableOverlay { get; set; }
    public bool DisableNetworking { get; set; }
    public bool DisableLANOnly { get; set; }
    public bool EnableHTTP { get; set; }
    public bool DisableAvatar { get; set; }
    public bool DisableSQuery { get; set; }
    public bool DisableAchNotif { get; set; }
    public bool DisableFriendNotif { get; set; }
    public bool SteamDeck { get; set; }
    public bool AchBypass { get; set; }
    public bool Offline { get; set; }

    // Stats-related settings
    public bool UnknownStats { get; set; }
    public bool SaveHigherStat { get; set; }
    public bool GameserverStat { get; set; }
    public bool DisableStatShare { get; set; }
    public bool UnlockAllDLC { get; set; }

    // New added settings
    public bool DisLobbyCreation { get; set; }
    public bool ShareLeaderboard { get; set; }
    public bool UnknownLeaderboard { get; set; }
    public bool ActualType { get; set; }
    public bool MatchmakeSource { get; set; }
    public bool HttpSuccess { get; set; }

    public string LocalSave { get; set; }
    public string CustomIcon { get; set; }
    public List<string> CustomBroadcasts { get; set; }
    public List<string> EnvVars { get; set; }
    public Guid GameGuid { get; set; }

    private string path;

    public GameConfig()
    {
        StartFolder = AppName = Parameters = path = LocalSave = string.Empty;
        CustomIcon = string.Empty;
        GameGuid = Guid.NewGuid();  
        AppId = 0;

        UseX64 = true;
        DisableOverlay = false;
        DisableLANOnly = false;
        Offline = false;
        DisableNetworking = false;
        EnableHTTP = false;
        DisableAvatar = false;
        DisableSQuery = false;
        DisableAchNotif = false;
        DisableFriendNotif = false;
        SteamDeck = false;
        AchBypass = false;
        UnlockAllDLC = false;
        UnknownStats = false;
        SaveHigherStat = true;
        GameserverStat = false;
        DisableStatShare = false;
        DisLobbyCreation = false;
        ShareLeaderboard = false;
        UnknownLeaderboard = false;
        ActualType = false;
        MatchmakeSource = false;
        HttpSuccess = false;

        CustomBroadcasts = new List<string>();
        EnvVars = new List<string>();
    }

    public string Path
    {
        get { return path; }
        set
        {
            try
            {
                this.path = System.IO.Path.GetFullPath(value);
            }
            catch (ArgumentException argEx)
            {
                Debug.WriteLine($"Invalid path provided: {argEx.Message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error setting path: {ex.Message}");
            }
        }
    }

    public GameConfig Clone()
    {
        GameConfig copy = new GameConfig
        {
            StartFolder = this.StartFolder,
            AppName = this.AppName,
            AppId = this.AppId,
            Parameters = this.Parameters,
            UseX64 = this.UseX64,
            DisableOverlay = this.DisableOverlay,
            DisableNetworking = this.DisableNetworking,
            Offline = this.Offline,
            DisableLANOnly = this.DisableLANOnly,
            EnableHTTP = this.EnableHTTP,
            DisableAvatar = this.DisableAvatar,
            DisableSQuery = this.DisableSQuery,
            DisableAchNotif = this.DisableAchNotif,
            DisableFriendNotif = this.DisableFriendNotif,
            SteamDeck = this.SteamDeck,
            AchBypass = this.AchBypass,
            UnlockAllDLC = this.UnlockAllDLC,
            UnknownStats = this.UnknownStats,
            SaveHigherStat = this.SaveHigherStat,
            GameserverStat = this.GameserverStat,
            DisableStatShare = this.DisableStatShare,
            DisLobbyCreation = this.DisLobbyCreation,
            ShareLeaderboard = this.ShareLeaderboard,
            UnknownLeaderboard = this.UnknownLeaderboard,
            ActualType = this.ActualType,
            MatchmakeSource = this.MatchmakeSource,
            HttpSuccess = this.HttpSuccess,

            CustomBroadcasts = new List<string>(this.CustomBroadcasts),
            EnvVars = new List<string>(this.EnvVars),
            GameGuid = this.GameGuid
        };

        return copy;
    }

    public string GetGameEmuFolder()
    {
        return System.IO.Path.Combine(System.IO.Path.GetFullPath("."), "games", AppId.ToString());
    }
}