﻿using Android.Util;
using GalaxyBlox.Static;
using GalaxyBlox.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Xml.Serialization;

namespace GalaxyBlox.Static
{
    public static class Settings
    {
        /// <summary>
        /// Vital settings of the game.
        /// </summary>
        public static class Game
        {
            private static IsolatedStorageFile dataFile = IsolatedStorageFile.GetUserStoreForDomain();
            private const string settingsPath = "settings.xml";
            private const string highscoresPath = "highscores.xml";
            public const int MaxHighscoresPerGameMod = 1;

            public static readonly Size WindowSize = new Size(480, 800); // new Size(720, 1200);
            public static readonly Size ArenaSize = new Size(12, 20);

            public static UserSettings UserSettings;
            public static Highscores Highscores;

            public static void LoadAll()
            {
                LoadUserSettings();
                LoadHighscores();
            }

            public static void SaveAll()
            {
                SaveUserSettings();
                SaveHighscores();
            }

            public static void LoadUserSettings()
            {
                var tmpUserSettings = new UserSettings();
                if (!Utils.Xml.TryDeserialize(out tmpUserSettings, settingsPath))
                    tmpUserSettings = new UserSettings() { Indicator = SettingOptions.Indicator.Shape };

                UserSettings = tmpUserSettings;
            }

            public static void SaveUserSettings()
            {
                Utils.Xml.Serialize(UserSettings, settingsPath);
            }

            public static void LoadHighscores()
            {
                var tmpHighscores = new Highscores();
                if (!Utils.Xml.TryDeserialize(out tmpHighscores, highscoresPath))
                    tmpHighscores = new Highscores();

                Highscores = tmpHighscores;
            }

            public static void SaveHighscores()
            {
                Utils.Xml.Serialize(Highscores, highscoresPath);
            }
        }

        [XmlRoot]
        public class Highscores
        {
            [XmlElement]
            public SerializableDictionary<string, List<long>> Items = new SerializableDictionary<string, List<long>>();

            // METHODS
            public void SaveHighScore(string gameMode, List<long> scores)
            {
                if (Items == null)
                    Items = new SerializableDictionary<string, List<long>>();

                if (Items.ContainsKey(gameMode))
                    Items[gameMode] = scores;
                else
                    Items.Add(gameMode, scores);
            }
        }

        [XmlRoot]
        public class UserSettings
        {
            [XmlElement]
            public SettingOptions.Indicator Indicator = SettingOptions.Indicator.None;
        }
    }
}