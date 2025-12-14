using System;
using System.IO;
using System.Media;
using SmartGoldbergEmu; // For SteamEmulator
// EmuConfig.SavedConf is accessed via SteamEmulator.GetConfiguration()

namespace SmartGoldbergEmu.Helpers
{
    /// <summary>
    /// Manages sound file operations including Steam default sound detection,
    /// custom sound setup, playback, and configuration persistence.
    /// Sound files for playback are copied to a dedicated AppData folder.
    /// The configuration stores the *original* path to the user-selected sound.
    /// </summary>
    public static class SoundManager
    {
        // Path to Steam's default UI sounds
        private static readonly string SteamSoundsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "Steam", "steamui", "sounds");
        
        // Dedicated path for storing copies of sounds used by the application
        private static readonly string AppDataSoundsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GSE Saves", "settings", "sounds");

        // Standardized filenames for sounds in AppDataSoundsPath
        private const string OverlayAchievementSoundFile = "overlay_achievement_notification.wav";
        private const string OverlayFriendSoundFile = "overlay_friend_notification.wav";

        // Steam default sound file names (original names in Steam directory)
        private const string SteamFriendSoundOriginalFile = "ui_steam_smoother_friend_online.m4a";
        private const string SteamAchievementSoundOriginalFile = "desktop_toast_default.wav";

        /// <summary>
        /// Ensures the directory for storing app-specific sound files in AppData exists.
        /// </summary>
        private static void EnsureAppDataSoundsDirectoryExists()
        {
            try
            {
                if (!Directory.Exists(AppDataSoundsPath))
                {
                    Directory.CreateDirectory(AppDataSoundsPath);
                }
            }
            catch (Exception ex)
            {
                // Log or handle directory creation failure
                Console.WriteLine($"Error creating AppData sound directory: {ex.Message}");
                // Potentially throw or notify the user, depending on desired error handling
            }
        }

        /// <summary>
        /// Gets the full path to the standardized overlay sound file in the AppData directory.
        /// </summary>
        /// <param name="soundType">"friend" or "achievement"</param>
        /// <returns>The full path to the overlay sound file.</returns>
        private static string GetAppDataOverlaySoundPath(string soundType)
        {
            if (soundType == "friend") return Path.Combine(AppDataSoundsPath, OverlayFriendSoundFile);
            if (soundType == "achievement") return Path.Combine(AppDataSoundsPath, OverlayAchievementSoundFile);
            throw new ArgumentException("Invalid sound type specified for AppData path", nameof(soundType));
        }
        
        /// <summary>
        /// Gets the original Steam sound filename for the specified type.
        /// </summary>
        private static string GetSteamSoundOriginalFileName(string soundType)
        {
            if (soundType == "friend") return SteamFriendSoundOriginalFile;
            if (soundType == "achievement") return SteamAchievementSoundOriginalFile;
            throw new ArgumentException("Invalid sound type specified for Steam filename", nameof(soundType));
        }

        /// <summary>
        /// Checks if the default Steam sound file for the specified type is available in the Steam directory.
        /// </summary>
        public static bool IsSteamSoundAvailable(string soundType)
        {
            try
            {
                string steamSoundFileName = GetSteamSoundOriginalFileName(soundType);
                string steamSoundFullPath = Path.Combine(SteamSoundsPath, steamSoundFileName);
                return File.Exists(steamSoundFullPath);
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Sets a custom sound file. Copies the file to AppData for playback and saves the original path to config.
        /// </summary>
        /// <param name="soundType">"friend" or "achievement"</param>
        /// <param name="originalFilePath">The absolute path to the user-selected custom sound file.</param>
        public static void SetCustomSound(string soundType, string originalFilePath)
        {
            var config = SteamEmulator.GetConfiguration();
            if (config == null || string.IsNullOrEmpty(originalFilePath) || !File.Exists(originalFilePath)) return;

            EnsureAppDataSoundsDirectoryExists();
            string targetAppDataPath = GetAppDataOverlaySoundPath(soundType);

            try
            {
                File.Copy(originalFilePath, targetAppDataPath, true); // True to overwrite if exists
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error copying custom sound to AppData: {ex.Message}");
                // Optionally, don't update config if copy fails, or notify user
                return; // Exit if copy failed
            }

            if (soundType == "friend")
            {
                config.friend_sound_path = originalFilePath;
                config.friend_sound_is_steam_default = false;
            }
            else if (soundType == "achievement")
            {
                config.achievement_sound_path = originalFilePath;
                config.achievement_sound_is_steam_default = false;
            }
            else
            {
                throw new ArgumentException("Invalid sound type specified for custom sound", nameof(soundType));
            }
            SteamEmulator.Save();
        }

        /// <summary>
        /// Clears the sound configuration. Deletes the sound file from AppData and updates config.
        /// </summary>
        public static void ClearSound(string soundType)
        {
            var config = SteamEmulator.GetConfiguration();
            if (config == null) return;

            string appDataSoundPath = GetAppDataOverlaySoundPath(soundType);
            try
            {
                if (File.Exists(appDataSoundPath))
                {
                    File.Delete(appDataSoundPath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting sound from AppData: {ex.Message}");
                // Decide if config should still be cleared or not
            }

            if (soundType == "friend")
            {
                config.friend_sound_path = string.Empty;
                config.friend_sound_is_steam_default = false;
            }
            else if (soundType == "achievement")
            {
                config.achievement_sound_path = string.Empty;
                config.achievement_sound_is_steam_default = false;
            }
            else
            {
                throw new ArgumentException("Invalid sound type specified for clearing sound", nameof(soundType));
            }
            SteamEmulator.Save();
        }

        /// <summary>
        /// Sets the sound to the Steam default. Copies the Steam sound to AppData and updates config.
        /// </summary>
        /// <returns>True if set successfully, false otherwise (e.g., Steam sound not available).</returns>
        public static bool SetToSteamDefault(string soundType)
        {
            var config = SteamEmulator.GetConfiguration();
            if (config == null || !IsSteamSoundAvailable(soundType)) return false;

            EnsureAppDataSoundsDirectoryExists();
            string steamSoundOriginalFileName = GetSteamSoundOriginalFileName(soundType);
            string originalSteamSoundFullPath = Path.Combine(SteamSoundsPath, steamSoundOriginalFileName);
            string targetAppDataPath = GetAppDataOverlaySoundPath(soundType);

            try
            {
                File.Copy(originalSteamSoundFullPath, targetAppDataPath, true); // True to overwrite
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error copying Steam default sound to AppData: {ex.Message}");
                return false; // Exit if copy failed
            }
            
            if (soundType == "friend")
            {
                config.friend_sound_path = originalSteamSoundFullPath; // Store original Steam path
                config.friend_sound_is_steam_default = true;
            }
            else if (soundType == "achievement")
            {
                config.achievement_sound_path = originalSteamSoundFullPath; // Store original Steam path
                config.achievement_sound_is_steam_default = true;
            }
            else
            {
                throw new ArgumentException("Invalid sound type specified for Steam default", nameof(soundType));
            }
            SteamEmulator.Save();
            return true;
        }

        /// <summary>
        /// Gets the display name for the sound (filename of the original selected sound).
        /// </summary>
        public static string GetSoundDisplayName(string soundType)
        {
            var config = SteamEmulator.GetConfiguration();
            if (config == null) return "Error: Config not loaded";

            string configuredOriginalPath = string.Empty;
            if (soundType == "friend")
            {
                configuredOriginalPath = config.friend_sound_path;
            }
            else if (soundType == "achievement")
            {
                configuredOriginalPath = config.achievement_sound_path;
            }
            else
            {
                throw new ArgumentException("Invalid sound type for display name", nameof(soundType));
            }

            if (!string.IsNullOrEmpty(configuredOriginalPath))
            {
                // Check if the AppData file actually exists, if not, the display might be misleading
                // For simplicity here, we just return the configured name.
                // A more robust version might check File.Exists(GetAppDataOverlaySoundPath(soundType))
                // and alter display if the AppData file is missing despite configuration.
                return Path.GetFileName(configuredOriginalPath);
            }
            
            // Scenario: No custom sound set, but Steam default might be available and *could* be used implicitly
            // However, per requirements, if nothing is *explicitly* set (custom or default), it's "No sound set"
            // unless the UI logic for "Default" button handles auto-setting it.
            // For display, we rely on what's in config.
            return "No sound set";
        }
        
        /// <summary>
        /// Gets the configured *original* sound path (user selection or Steam default original path).
        /// </summary>
        public static string GetConfiguredOriginalSoundPath(string soundType)
        {
            var config = SteamEmulator.GetConfiguration();
            if (config == null) return string.Empty;

            if (soundType == "friend") return config.friend_sound_path;
            if (soundType == "achievement") return config.achievement_sound_path;
            
            throw new ArgumentException("Invalid sound type for configured path", nameof(soundType));
        }

        /// <summary>
        /// Checks if the currently configured sound is marked as a Steam default in the config.
        /// </summary>
        public static bool IsSoundMarkedAsSteamDefault(string soundType)
        {
            var config = SteamEmulator.GetConfiguration();
            if (config == null) return false;

            if (soundType == "friend") return config.friend_sound_is_steam_default;
            if (soundType == "achievement") return config.achievement_sound_is_steam_default;

            throw new ArgumentException("Invalid sound type for Steam default check", nameof(soundType));
        }

        /// <summary>
        /// Internal method to play a sound based on its type. Plays from AppData.
        /// </summary>
        private static void PlaySoundInternal(string soundType)
        {
            string soundToPlayPath = GetAppDataOverlaySoundPath(soundType);
            try
            {
                if (File.Exists(soundToPlayPath))
                {
                    // System.Media.SoundPlayer only supports .wav files.
                    // The copy mechanism renames to .wav, assuming compatibility.
                    SoundPlayer player = new SoundPlayer(soundToPlayPath);
                    player.Play();
                }
                else
                {
                    // Config might point to an original file, but the AppData copy is missing.
                    // This could happen if AppData was cleared or copy failed.
                    // Check if we should try to restore it from config or play Steam default if applicable.
                    // For now, just log.
                    Console.WriteLine($"Sound file not found in AppData: {soundToPlayPath}. Attempting to restore or use default.");

                    var config = SteamEmulator.GetConfiguration();
                    if (config == null) return;

                    string originalPath = (soundType == "friend") ? config.friend_sound_path : config.achievement_sound_path;
                    bool isSteamDefault = (soundType == "friend") ? config.friend_sound_is_steam_default : config.achievement_sound_is_steam_default;

                    if (!string.IsNullOrEmpty(originalPath) && File.Exists(originalPath))
                    {
                        Console.WriteLine($"Restoring sound from original path: {originalPath}");
                        EnsureAppDataSoundsDirectoryExists(); // Ensure dir exists before copying
                        File.Copy(originalPath, soundToPlayPath, true);
                        SoundPlayer player = new SoundPlayer(soundToPlayPath);
                        player.Play();
                    }
                    else if (IsSteamSoundAvailable(soundType)) // Fallback to live Steam default if original is gone AND it was/could be a steam default
                    {
                        Console.WriteLine($"Original/Custom sound missing. Attempting to play live Steam default for {soundType}.");
                        string steamOriginalFile = GetSteamSoundOriginalFileName(soundType);
                        string steamOriginalPath = Path.Combine(SteamSoundsPath, steamOriginalFile);
                        
                        // We need to copy it to appdata with the .wav extension for SoundPlayer
                        EnsureAppDataSoundsDirectoryExists();
                        File.Copy(steamOriginalPath, soundToPlayPath, true); // Copy and rename to .wav
                        SoundPlayer player = new SoundPlayer(soundToPlayPath);
                        player.Play();

                        // Optionally, update config to reflect this auto-fallback if desired
                        // if (soundType == "friend") { config.friend_sound_path = steamOriginalPath; config.friend_sound_is_steam_default = true; }
                        // else { config.achievement_sound_path = steamOriginalPath; config.achievement_sound_is_steam_default = true; }
                        // SteamEmulator.Save(); 
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error playing sound ({soundType}): {ex.Message}");
            }
        }

        /// <summary>
        /// Plays the configured friend sound.
        /// </summary>
        public static void PlayFriendSound()
        {
            PlaySoundInternal("friend");
        }

        /// <summary>
        /// Plays the configured achievement sound.
        /// </summary>
        public static void PlayAchievementSound()
        {
            PlaySoundInternal("achievement");
        }
    }
}
