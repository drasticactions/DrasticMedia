﻿// <copyright file="NativeMediaService.Android.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Media;
using DrasticMedia.Native.Activity;

namespace DrasticMedia.Core.Services
{
    /// <summary>
    /// Native Media Service.
    /// </summary>
    public partial class NativeMediaService
    {
        private IMediaActivity? instance;

        /// <summary>
        /// Initializes a new instance of the <see cref="NativeMediaService"/> class.
        /// </summary>
        /// <param name="activity">Android Activity.</param>
        public NativeMediaService(IMediaActivity activity)
        {
            this.instance = activity;
            if (this.MediaPlayerService != null)
            {
                this.MediaPlayerService.Playing += this.MediaPlayerService_Playing;
                this.MediaPlayerService.StatusChanged += MediaPlayerService_StatusChanged;
            }
        }

        private void MediaPlayerService_StatusChanged(object sender, EventArgs e)
        {
            this.RaiseCanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        private void MediaPlayerService_Playing(object sender, EventArgs e)
        {
            this.RaiseCanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <inheritdoc/>
        public float CurrentPosition
        {
            get { return this.MediaPlayer?.CurrentPosition / 1000 ?? 0; }
            set { this.MediaPlayer?.SeekTo((int)value); }
        }

        /// <inheritdoc/>
        public bool IsPlaying => this.MediaPlayer?.IsPlaying ?? false;

        /// <inheritdoc/>
        public Task PauseAsync()
        {
            this.MediaPlayer?.Pause();
            this.RaiseCanExecuteChanged?.Invoke(this, new EventArgs());
            return Task.CompletedTask;
        }

        /// <inheritdoc/>
        public Task PlayAsync(double position = 0, bool fromPosition = false)
        {
            this.MediaPlayer?.Start();
            this.RaiseCanExecuteChanged?.Invoke(this, new EventArgs());
            return Task.CompletedTask;
        }

        /// <inheritdoc/>
        public Task ResumeAsync()
        {
            this.MediaPlayer?.Start();
            this.RaiseCanExecuteChanged?.Invoke(this, new EventArgs());
            return Task.CompletedTask;
        }

        /// <inheritdoc/>
        public Task<string> GetArtworkUrl() => this.GetMetadata();

        /// <inheritdoc/>
        public Task SkipAhead(double amount = 0)
        {
            this.RaiseCanExecuteChanged?.Invoke(this, new EventArgs());
            return Task.CompletedTask;
        }

        /// <inheritdoc/>
        public Task SkipBack(double amount = 0)
        {
            this.RaiseCanExecuteChanged?.Invoke(this, new EventArgs());
            return Task.CompletedTask;
        }

        /// <inheritdoc/>
        public Task StopAsync()
        {
            this.MediaPlayer?.Stop();
            this.RaiseCanExecuteChanged?.Invoke(this, new EventArgs());
            return Task.CompletedTask;
        }

        /// <summary>
        /// Set current media native.
        /// </summary>
        internal void SetCurrentMediaNative()
        {
        }

        private MediaPlayerService? MediaPlayerService => this.instance?.Binder.GetMediaPlayerService();

        private MediaPlayer? MediaPlayer => this.MediaPlayerService != null ?
            this.MediaPlayerService.mediaPlayer : null;

        private async Task<string> GetMetadata()
        {
            return string.Empty;
        }
    }
}