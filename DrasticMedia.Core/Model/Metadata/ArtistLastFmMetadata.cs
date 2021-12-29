﻿// <copyright file="ArtistLastFmMetadata.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrasticMedia.Core.Model.Metadata
{
    public class ArtistLastFmMetadata : IArtistMetadata
    {
        public ArtistLastFmMetadata()
        {
            this.LastUpdated = DateTime.Now;
        }

        public ArtistLastFmMetadata(int artistId, Hqub.Lastfm.Entities.Artist artist)
        {
            if (artistId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(artistId), "Must be higher than 0");
            }

            this.MBID = artist.MBID;
            this.Name = artist.Name;
            this.Biography = artist.Biography.Content;
            this.BiographyPublished = artist.Biography.Published;
            this.ArtistItemId = artistId;
            this.LastUpdated = DateTime.UtcNow;
        }

        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Image { get; set; }

        public string? Biography { get; set; }

        public string? BiographyPublished { get; set; }

        public string? MBID { get; set; }

        public DateTime? LastUpdated { get; set; }

        public int ArtistItemId { get; set; }

        public virtual ArtistItem? ArtistItem { get; set; }
    }
}
