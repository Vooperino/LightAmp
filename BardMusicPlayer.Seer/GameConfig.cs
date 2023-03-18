﻿/*
 * Copyright(c) 2023 MoogleTroupe, trotlinebeercan, GiR-Zippo
 * Licensed under the GPL v3 license. See https://github.com/BardMusicPlayer/BardMusicPlayer/blob/develop/LICENSE for full license information.
 */

#region

using System;
using System.IO;
using System.Text.RegularExpressions;

#endregion

namespace BardMusicPlayer.Seer
{
    public sealed partial class Game
    {
        /// <summary>
        ///     Return true if low settings
        /// </summary>
        /// <returns></returns>
        private bool CheckIfGfxIsLow()
        {
            var number = 5;
            if (!File.Exists(ConfigPath + "FFXIV.cfg")) return false;

            using (var sr = File.OpenText(ConfigPath + "FFXIV.cfg"))
            {
                while (sr.ReadLine() is { } s)
                {
                    if (s.Contains("DisplayObjectLimitType")) number -= GetCfgIntSetting(s);

                    if (s.Contains("WaterWet_DX11")) number -= GetCfgIntSetting(s);

                    if (s.Contains("OcclusionCulling_DX11")) number -= GetCfgIntSetting(s);

                    if (s.Contains("ReflectionType_DX11")) number -= GetCfgIntSetting(s);

                    if (s.Contains("GrassQuality_DX11")) number -= GetCfgIntSetting(s);

                    if (s.Contains("SSAO_DX11")) number -= GetCfgIntSetting(s);
                }
            }

            return number == 0;
        }

        private static int GetCfgIntSetting(string SettingsString)
        {
            var resultString = Convert.ToInt32(Regex.Replace(SettingsString.Split('\t')[1], "[^.0-9]", ""));
            return resultString;
        }
    }
}