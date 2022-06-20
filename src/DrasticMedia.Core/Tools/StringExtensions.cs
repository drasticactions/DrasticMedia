﻿// <copyright file="StringExtensions.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrasticMedia.Core.Utilities
{
    /// <summary>
    /// String Extensions.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Is Path Uri.
        /// </summary>
        /// <param name="path">Path.</param>
        /// <returns>Boolean.</returns>
        public static bool IsPathUri(this string path)
        {
            if (File.Exists(path))
            {
                return false;
            }

            try
            {
                Uri uri = new Uri(path);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static List<char> InvalidPathCharacters()
        {
            var list = new List<char>();
            list.AddRange(Path.GetInvalidPathChars());
            list.Add('?');
            list.Add(':');
            return list;
        }

        /// <summary>
        /// Generate a clean path.
        /// </summary>
        /// <param name="path">Path.</param>
        /// <returns>String.</returns>
        public static string CleanPath(this string path) => string.Join("_", path.Split(Path.GetInvalidFileNameChars()));
    }
}
