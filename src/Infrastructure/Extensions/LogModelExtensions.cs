﻿using System;
using System.Collections.Generic;

namespace NiuX.LogPanel.Infrastructure.Extensions
{
    public static class LogModelExtensions
    {
        private static readonly Dictionary<string, string> LevelDict;

        static LogModelExtensions()
        {
            LevelDict = new Dictionary<string, string>()
            {
                { "INFORMATION","INFO"},
                { "INF","INFO" },
                { "ERR","ERROR" },
                { "DEB","DEBUG" },
                { "WARNING","WARN"},
                { "WAR" ,"WARN" },
                { "FAT","FATAL" }
            };
        }

        public static void AddLevelFormat(string key, string value)
        {
            LevelDict.Add(key, value);
        }

        public static string FormatLevel(this string level)
        {
            if (level.IsNullOrWhiteSpace() || !LevelDict.ContainsKey(level))
            {
                return level;
            }

            return LevelDict[level];

        }
    }
}
