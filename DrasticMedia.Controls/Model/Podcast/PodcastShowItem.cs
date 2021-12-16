﻿// <copyright file="PodcastShowItem.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrasticMedia.Core.Model
{
    /// <summary>
    /// Podcast Show Item.
    /// </summary>
    public class PodcastShowItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PodcastShowItem"/> class.
        /// </summary>
        public PodcastShowItem()
        {
        }

        public PodcastShowItem(
            Uri podcastUri,
            string author,
            string description,
            string email,
            string language,
            string title,
            string link,
            string image,
            string copyright,
            DateTime updated)
        {
            this.PodcastFeed = podcastUri;
            this.Author = author;
            this.Description = description;
            this.Email = email;
            this.Language = language;
            this.Title = title;
            this.Copyright = copyright;
            this.SiteUri = !string.IsNullOrEmpty(link) ? new Uri(link) : null;
            this.Image = !string.IsNullOrEmpty(image) ? new Uri(image) : null;
            this.Updated = updated;
        }

        /// <summary>
        /// Gets or sets the Id of the Podcast.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the podcast.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the email of the podcast.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets the language of the podcast.
        /// </summary>
        public string? Language { get; set; }

        /// <summary>
        /// Gets or sets the site uri of the podcast.
        /// </summary>
        public Uri? SiteUri { get; set; }

        /// <summary>
        /// Gets or sets the author of the podcast.
        /// </summary>
        public string? Author { get; set; }

        /// <summary>
        /// Gets or sets the description of the podcast.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the URI for the podcast.
        /// </summary>
        public Uri? PodcastFeed { get; set; }

        /// <summary>
        /// Gets or sets the Image URI for the podcast.
        /// </summary>
        public Uri? Image { get; set; }

        /// <summary>
        /// Gets or sets the podcast copyright.
        /// </summary>
        public string? Copyright { get; set; }

        /// <summary>
        /// Gets or sets the updated date.
        /// </summary>
        public DateTime? Updated { get; set; }

        /// <summary>
        /// Gets or sets a list of episodes for this show.
        /// </summary>
        public virtual List<PodcastEpisodeItem> Episodes { get; set; } = new List<PodcastEpisodeItem>();
    }
}
