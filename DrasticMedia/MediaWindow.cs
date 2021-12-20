﻿// <copyright file="MediaWindow.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrasticMedia.Core.Events;
using DrasticMedia.Core.Services;
using DrasticMedia.Overlays;
using DrasticMedia.Services;
using DrasticMedia.Utilities;

namespace DrasticMedia
{
    /// <summary>
    /// Media Window.
    /// </summary>
    public class MediaWindow : Window, IVisualTreeElement
    {
        private IErrorHandlerService errorHandler;
        private IServiceProvider serviceProvider;
        private DragAndDropOverlay dragAndDropOverlay;
        private PageOverlay miniPlayerOverlay;
        private PageOverlay playerOverlay;
        private PlayerService player;
        private PlayerPage playerPage;

        public MediaWindow(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            this.errorHandler = serviceProvider.GetService<IErrorHandlerService>();
            this.player = serviceProvider.GetService<PlayerService>();
            this.dragAndDropOverlay = new DragAndDropOverlay(this);
            this.miniPlayerOverlay = new PageOverlay(this);
            this.playerOverlay = new PageOverlay(this);
            this.dragAndDropOverlay.Drop += DragAndDropOverlay_Drop;
            this.dragAndDropOverlay.SizeChanged += DragAndDropOverlay_SizeChanged;
        }

        public event EventHandler<WindowOnSizeChangedEventArgs>? SizeChanged;

        /// <inheritdoc/>
        public IReadOnlyList<IVisualTreeElement> GetVisualChildren()
        {
            var elements = new List<IVisualTreeElement>();
            if (this.Page != null && this.Page is IVisualTreeElement element)
            {
                elements.AddRange(element.GetVisualChildren());
            }

            var overlays = this.Overlays.Where(n => n is IVisualTreeElement).Cast<IVisualTreeElement>();
            elements.AddRange(overlays);

            return elements;
        }

        /// <inheritdoc/>
        public IVisualTreeElement? GetVisualParent() => App.Current;

        /// <inheritdoc/>
        protected override void OnCreated()
        {
            this.AddOverlay(this.dragAndDropOverlay);
            this.AddOverlay(this.playerOverlay);
            this.AddOverlay(this.miniPlayerOverlay);
            this.playerOverlay.SetPage(this.playerPage = new PlayerPage(this.serviceProvider), zindex: 101);
            this.miniPlayerOverlay.SetPage(new MiniPlayerPage(this.playerPage, this.serviceProvider), zindex: 100);
            base.OnCreated();
        }

        private void DragAndDropOverlay_Drop(object sender, DragAndDropOverlayTappedEventArgs e)
        {
            if (e != null && e.Files.Any())
            {
                this.player.AddMedia(e?.Files[0], true).FireAndForgetSafeAsync(this.errorHandler);

                if (e.Files.Count > 1)
                {
                    for (var i = 1; i < e.Files.Count; i++)
                    {
                        this.player.AddMedia(e?.Files[i], false).FireAndForgetSafeAsync(this.errorHandler);
                    }
                }
            }
        }

        private void DragAndDropOverlay_SizeChanged(object? sender, WindowOnSizeChangedEventArgs e) => this.SizeChanged?.Invoke(this, e);
    }
}
