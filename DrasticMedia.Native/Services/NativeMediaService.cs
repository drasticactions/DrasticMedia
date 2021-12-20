﻿// <copyright file="NativeMediaService.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrasticMedia.Core.Model;

namespace DrasticMedia.Core.Services
{
    /// <summary>
    /// Native Media Service.
    /// </summary>
    public partial class NativeMediaService : IMediaService
    {
        private System.Threading.Timer positionTimer;

        private Model.MediaItem? media;

        /// <inheritdoc/>
        public event EventHandler<MediaPlayerPositionChangedEventArgs>? PositionChanged;

        /// <inheritdoc/>
        public event EventHandler<EventArgs>? EndCurrentItemReached;

        /// <inheritdoc/>
        public event EventHandler<EventArgs>? RaiseCanExecuteChanged;

        /// <inheritdoc/>
        public event EventHandler<EventArgs>? MediaChanged;

        /// <inheritdoc/>
        public Model.MediaItem? CurrentMedia { get { return this.media; } set { this.media = value; this.SetCurrentMedia(); } }

        internal void PositionTimerElapsed(object? state)
        {
            this.PositionChanged?.Invoke(this, new MediaPlayerPositionChangedEventArgs(this.CurrentPosition));
        }

        private void SetCurrentMedia()
        {
            var path = this.CurrentMedia?.Path ?? this.CurrentMedia?.OnlinePath?.ToString();

            if (path == null)
            {
                throw new NullReferenceException(nameof(this.CurrentMedia));
            }

            this.SetCurrentMediaNative();
            this.RaiseCanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}