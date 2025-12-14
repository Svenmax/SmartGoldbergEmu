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
using System.IO;
using OSUtility;

namespace SmartGoldbergEmu
{
    public static class OSFuncs
    {
        public static string GetWindowsEmuApiFolder(bool x64)
        {
            return PrepareRootApiFolder("win", x64);
        }

        public static string GetLinuxEmuApiFolder(bool x64)
        {
            return PrepareRootApiFolder("linux", x64);
        }

        public static string GetMacOSEmuApiFolder(bool x64)
        {
            return Path.Combine(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]), "macosx") + Path.DirectorySeparatorChar;
        }

        private static string PrepareRootApiFolder(string OsSpecificFolder, bool x64)
        {
            return Path.Combine(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]), OsSpecificFolder + (x64 ? "64" : "32")) + Path.DirectorySeparatorChar;
        }

        public static string GetEmuApiFolder(bool x64)
        {
            if (OSDetector.IsWindows())
            {
                return GetWindowsEmuApiFolder(x64);
            }
            else if (OSDetector.IsLinux())
            {
                return GetLinuxEmuApiFolder(x64);
            }
            else if (OSDetector.IsMacOS())
            {
                return GetMacOSEmuApiFolder(x64);
            }

            return Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + Path.DirectorySeparatorChar;
        }

        static public string GetWindowsSteamAPIName(bool x64)
        {
            return x64 ? "steamclient64.dll" : "steamclient.dll";
        }
        static public string GetWindowsSteamAPICompanion(bool x64)
        {
            return x64 ? "GameOverlayRenderer64.dll" : "GameOverlayRenderer.dll";
        }

        static public string GetLinuxSteamAPIName(bool x64)
        {
            return "steamclient.so";
        }

        static public string GetMacOSSteamAPIName(bool x64)
        {
            return "steamclient.dylib";
        }

        static public string GetSteamAPIName(bool x64)
        {
            string game_api = string.Empty;

            if (OSDetector.IsWindows())
            {
                return GetWindowsSteamAPIName(x64);
            }
            else if (OSDetector.IsLinux())
            {
                return GetLinuxSteamAPIName(x64);
            }
            else if (OSDetector.IsMacOS())
            {
                return GetMacOSSteamAPIName(x64);
            }

            return game_api;
        }
        static public string GetSteamAPICompanion(bool x64)
        {
            string game_api = string.Empty;

            if (OSDetector.IsWindows())
            {
                return GetWindowsSteamAPICompanion(x64);
            }

            return game_api;
        }
    }
}
