﻿using Xamarin.Forms;

namespace FreeWeatherApp.Controls
{
    public class GradientColorView : BoxView
    {
        #region Bindable Properties

        public static readonly BindableProperty GradientStartColorProperty = BindableProperty.Create(
            nameof(GradientStartColor),
            typeof(Color),
            typeof(GradientColorView),
            Color.Transparent);

        public Color GradientStartColor
        {
            get => (Color) GetValue(GradientStartColorProperty);
            set => SetValue(GradientStartColorProperty, value);
        }

        public static readonly BindableProperty GradientEndColorProperty = BindableProperty.Create(
            nameof(GradientEndColor),
            typeof(Color),
            typeof(GradientColorView),
            Color.Transparent);

        public Color GradientEndColor
        {
            get => (Color) GetValue(GradientEndColorProperty);
            set => SetValue(GradientEndColorProperty, value);
        }

        public static readonly BindableProperty GradientOrientationProperty = BindableProperty.Create(
            nameof(GradientOrientation),
            typeof(Orientation),
            typeof(GradientColorView),
            Orientation.Vertical);

        public Orientation GradientOrientation
        {
            get => (Orientation) GetValue(GradientOrientationProperty);
            set => SetValue(GradientOrientationProperty, value);
        }

        public enum Orientation
        {
            Horizontal,
            Vertical
        }

        #endregion Bindable Properties
    }
}