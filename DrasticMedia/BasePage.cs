﻿// <copyright file="BasePage.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrasticMedia.ViewModels;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace DrasticMedia
{
    /// <summary>
    /// Base Page.
    /// </summary>
    public class BasePage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BasePage"/> class.
        /// </summary>
        /// <param name="services">IServiceProvider.</param>
        public BasePage(IServiceProvider services)
        {
            this.Services = services;
            this.BackgroundColor = Colors.Transparent;
        }

        /// <summary>
        /// Gets or sets the View Model.
        /// </summary>
        internal BaseViewModel ViewModel { get; set; }

        /// <summary>
        /// Gets or sets the IServiceProvider.
        /// </summary>
        internal IServiceProvider Services { get; set; }

        /// <inheritdoc/>
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (this.ViewModel != null)
            {
                await this.ViewModel.LoadAsync();
            }
        }
    }
}
