using FFImageLoading.Cache;
using FFImageLoading.Forms;
using FreeWeatherApp.Helpers;
using System;
using Xamarin.Forms;

namespace FreeWeatherApp.Controls
{
    public partial class AnimateGradientPageBackgroundView
    {
        #region Bindable Properties

        #region GradientStartColor Property

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

        #endregion GradientStartColor Property

        #region GradientEndColor Property

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

        #endregion GradientEndColor Property

        #region GradientOrientation Property 

        public static readonly BindableProperty GradientOrientationProperty = BindableProperty.Create(
            nameof(GradientOrientation),
            typeof(GradientColorView.Orientation),
            typeof(GradientColorView),
            GradientColorView.Orientation.Vertical);

        public GradientColorView.Orientation GradientOrientation
        {
            get => (GradientColorView.Orientation) GetValue(GradientOrientationProperty);
            set => SetValue(GradientOrientationProperty, value);
        }

        #endregion GradientOrientation Property 

        #endregion Bindable Properties

        private readonly double _screenHeight;
        private readonly double _screenWidth;

        public AnimateGradientPageBackgroundView()
        {
            InitializeComponent();

            var displayInfo = Xamarin.Essentials.DeviceDisplay.MainDisplayInfo;

            _screenHeight = displayInfo.Height / displayInfo.Density;
            _screenWidth = displayInfo.Width / displayInfo.Density;
        }

        public void StartAnimation()
        {
            CreateAndStartCloudsAnimation();
            CreateAndStartDayNightAnimation();
        }

        public void CancelAnimation()
        {
            ViewExtensions.CancelAnimations(this);
            AnimationContainer.Children.Clear();
        }

        private void CreateAndStartDayNightAnimation()
        {
            var dayView = CreateView(
                FilenameHelper.Weather.ClearDayColorIcon,
                80,
                LayoutOptions.Center,
                LayoutOptions.Center);
            var nightView = CreateView(
                FilenameHelper.Weather.ClearNightColorIcon,
                80,
                LayoutOptions.Center,
                LayoutOptions.Center);

            var dayRotateAnimation = CreateRotateAnimation(dayView);
            var dayScaleUpAnimation = CreateScaleUpAnimation(dayView);
            var dayScaleDownAnimation = CreateScaleDownAnimation(dayView);
            var dayLeftParabolaAnimation = CreateLeftParabolaAnimation(dayView, _screenWidth);
            var dayRightParabolaAnimation = CreateRightParabolaAnimation(dayView, _screenWidth);

            var nightRotateAnimation = CreateRotateAnimation(nightView);
            var nightScaleUpAnimation = CreateScaleUpAnimation(nightView);
            var nightScaleDownAnimation = CreateScaleDownAnimation(nightView);
            var nightLeftParabolaAnimation = CreateLeftParabolaAnimation(nightView, _screenWidth);
            var nightRightParabolaAnimation = CreateRightParabolaAnimation(nightView, _screenWidth);

            var finalAnimation = new Animation
            {
                {0, 1, dayRotateAnimation},
                {0, 0.5, dayScaleUpAnimation},
                {0.5, 1, dayScaleDownAnimation},
                {0, 0.5, dayLeftParabolaAnimation},
                {0.5, 1, dayRightParabolaAnimation},

                {0, 1, nightRotateAnimation},
                {0, 0.5, nightScaleDownAnimation},
                {0.5, 1, nightScaleUpAnimation},
                {0, 0.5, nightRightParabolaAnimation},
                {0.5, 1, nightLeftParabolaAnimation}
            };

            finalAnimation.Commit(this, "dayNightAnimation", 500, 5000, null, null, () => true);

            AnimationContainer.Children.Add(dayView);
            AnimationContainer.Children.Add(nightView);
        }

        private void CreateAndStartCloudsAnimation()
        {
            var random = new Random();

            for (var i = 0; i < 10; i++)
            {
                var index = i;

                var cloudView = CreateView(
                    FilenameHelper.Weather.CloudyColorIcon,
                    random.Next(50, 150),
                    LayoutOptions.Center,
                    LayoutOptions.Start);

                var translateAnimation = new Animation();

                var leftAnimation = CreateLeftSinusoidAnimation(
                    cloudView,
                    _screenWidth,
                    _screenHeight / 10 * index,
                    25,
                    0.025,
                    0);

                var rightAnimation = CreateRightSinusoidAnimation(
                    cloudView,
                    _screenWidth,
                    _screenHeight / 10 * index,
                    25,
                    0.025,
                    0);

                if (i % 2 == 0)
                {
                    translateAnimation.Add(0, 0.5, leftAnimation);
                    translateAnimation.Add(0.5, 1, rightAnimation);
                }
                else
                {
                    translateAnimation.Add(0, 0.5, rightAnimation);
                    translateAnimation.Add(0.5, 1, leftAnimation);
                }

                translateAnimation.Commit(
                    this,
                    $"cloudAnimation{index}",
                    500,
                    (uint)
                    random.Next(5000, 15000),
                    null,
                    null,
                    () => true);

                AnimationContainer.Children.Add(cloudView);
            }
        }

        private static CachedImage CreateView(
            string filename,
            double size,
            LayoutOptions horizontalOptions,
            LayoutOptions verticalOptions)
        {
            var image = new CachedImage
            {
                CacheType = CacheType.All,
                Source = filename,
                HeightRequest = size,
                WidthRequest = size,
                HorizontalOptions = horizontalOptions,
                VerticalOptions = verticalOptions
            };

            return image;
        }

        #region Animations

        private static Animation CreateRotateAnimation(VisualElement element)
        {
            return new Animation(
                rotation => { element.Rotation = rotation; },
                0,
                360,
                Easing.Linear);
        }

        private static Animation CreateScaleUpAnimation(VisualElement element)
        {
            return new Animation(
                x => { element.Scale = x; },
                1,
                2,
                Easing.Linear);
        }

        private static Animation CreateScaleDownAnimation(VisualElement element)
        {
            return new Animation(
                x => { element.Scale = x; },
                2,
                1,
                Easing.Linear);
        }

        private static Animation CreateLeftParabolaAnimation(
            VisualElement element,
            double screenWidth)
        {
            return new Animation(
                x =>
                {
                    element.TranslationX = x;
                    element.TranslationY = x * x * 0.005;
                },
                -(screenWidth + element.WidthRequest) / 2,
                0,
                Easing.Linear);
        }

        private static Animation CreateRightParabolaAnimation(
            VisualElement element,
            double screenWidth)
        {
            return new Animation(
                x =>
                {
                    element.TranslationX = x;
                    element.TranslationY = x * x * 0.005;
                },
                0,
                (screenWidth + element.WidthRequest) / 2,
                Easing.Linear);
        }

        private static Animation CreateSinusoidAnimation(
            VisualElement element,
            double screenWidth,
            double a,
            double b,
            double c,
            double d)
        {
            return new Animation(
                x =>
                {
                    element.TranslationX = x;
                    element.TranslationY = a + b * Math.Sin(c * x + d);
                },
                -element.WidthRequest,
                screenWidth,
                Easing.Linear);
        }

        private static Animation CreateLeftSinusoidAnimation(
            VisualElement element,
            double screenWidth,
            double a,
            double b,
            double c,
            double d)
        {
            return new Animation(
                x =>
                {
                    element.TranslationX = x;
                    element.TranslationY = a + b * Math.Sin(c * x + d);
                },
                -(screenWidth + element.WidthRequest) / 2,
                0,
                Easing.Linear);
        }

        private static Animation CreateRightSinusoidAnimation(
            VisualElement element,
            double screenWidth,
            double a,
            double b,
            double c,
            double d)
        {
            return new Animation(
                x =>
                {
                    element.TranslationX = x;
                    element.TranslationY = a + b * Math.Sin(c * x + d);
                },
                0,
                (screenWidth + element.WidthRequest) / 2,
                Easing.Linear);
        }

        #endregion Animations
    }
}