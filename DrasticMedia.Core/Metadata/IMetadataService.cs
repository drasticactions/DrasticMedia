﻿// <copyright file="IMetadataService.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrasticMedia.Core.Model;
using DrasticMedia.Core.Model.Metadata;

namespace DrasticMedia.Core.Metadata
{
    /// <summary>
    /// Metadata Service.
    /// </summary>
    public interface IMetadataService
    {
        /// <summary>
        /// Gets the base metadata location for where to store parsed files.
        /// </summary>
        string BaseMetadataLocation { get; }

        /// <summary>
        /// Get Aritst Metadata.
        /// </summary>
        /// <param name="artist">Artist Item.</param>
        /// <returns><see cref="IArtistMetadata"/>.</returns>
        Task<IArtistMetadata> GetArtistMetadataAsync(ArtistItem artist);

        /// <summary>
        /// Get Album Metadata.
        /// </summary>
        /// <param name="album">Album Item.</param>
        /// <param name="artistName">Artist Name.</param>
        /// <returns><see cref="IAlbumMetadata"/>.</returns>
        Task<IAlbumMetadata> GetAlbumMetadataAsync(AlbumItem album, string? artistName = null);
    }
}
