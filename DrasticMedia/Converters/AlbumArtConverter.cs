﻿// <copyright file="AlbumArtConverter.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrasticMedia.Core.Model;
using DrasticMedia.Core.Utilities;

namespace DrasticMedia.Converters
{
    /// <summary>
    /// Album Art Converter.
    /// </summary>
    public class AlbumArtConverter : IValueConverter
    {
        /// <inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string pathToArt && !string.IsNullOrEmpty(pathToArt))
            {
                var imageSource = ImageSource.FromFile(pathToArt);
                return imageSource;
            }

            return "album.png";
        }

        /// <inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
