using FFImageLoading.Cache;
using FFImageLoading.Forms;
using FFImageLoading.Transformations;
using FFImageLoading.Work;
using FreeWeatherApp.Helpers;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FreeWeatherApp.Views
{
    public partial class TestPage
    {
        private bool _initialized;

        public TestPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (!_initialized)
            {
                StartAnimations();

                _initialized = true;
            }
        }

        void StartAnimations()
        {
            var views = new List<View>();

            for (var i = 0; i < 2; i++)
            {
                if (i == 0)
                {
                    views.Add(CreateView(FilenameHelper.Weather.ClearDayIcon));
                }
                else
                {
                    views.Add(CreateView(FilenameHelper.Weather.ClearNightIcon));
                }

                MainGrid.Children.Add(views[i]);
            }

            for (var i = 0; i < views.Count; i++)
            {
                var index = i;

                #region rotation

                var rotateAnimations = new Animation(
                    rotation => { views[index].Rotation = rotation; },
                    0,
                    360,
                    Easing.Linear);

                #endregion

                #region scaling

                var scaleUpAnimation = new Animation(
                    x => { views[index].Scale = x; },
                    1,
                    2,
                    Easing.Linear);

                var scaleDownAnimation = new Animation(
                    x => { views[index].Scale = x; },
                    2,
                    1,
                    Easing.Linear);

                #endregion

                #region translation

                var translateXUpAnimation = new Animation(
                    x => { views[index].TranslationX = x; },
                    -80, ScreenWidth, Easing.Linear);

                var translateXDownAnimation = new Animation(
                    x => { views[index].TranslationX = x; },
                    ScreenWidth, -80, Easing.Linear);

                var translateYUpAnimation = new Animation(
                    y => { views[index].TranslationY = y; },
                    0, ScreenWidth - 80, Easing.Linear);

                var translateYDownAnimation = new Animation(
                    y => { views[index].TranslationY = y; },
                    ScreenWidth - 80, 0, Easing.Linear);

                #endregion

                #region translation 2

                var translate2_1Animation = new Animation(
                    x =>
                    {
                        views[index].TranslationX = x;
                        views[index].TranslationY = x * x * 0.005;
                    },
                    -(ScreenWidth + views[index].WidthRequest) / 2, 0, Easing.Linear);

                var translate2_2Animation = new Animation(
                    x =>
                    {
                        views[index].TranslationX = x;
                        views[index].TranslationY = x * x * 0.005;
                    },
                    0, (ScreenWidth + views[index].WidthRequest) / 2, Easing.Linear);

                #endregion

                var parentAnimations = new Animation();

                parentAnimations.Add(0, 1, rotateAnimations);

                //parentAnimations.Add(0, 0.5, translateXUpAnimation);
                //parentAnimations.Add(0.5, 1, translateXDownAnimation);
                //parentAnimations.Add(0, 0.5, translateYUpAnimation);
                //parentAnimations.Add(0.5, 1, translateYDownAnimation);

                if (i == 1)
                {
                    parentAnimations.Add(0, 0.5, scaleUpAnimation);
                    parentAnimations.Add(0.5, 1, scaleDownAnimation);

                    parentAnimations.Add(0, 0.5, translate2_1Animation);
                    parentAnimations.Add(0.5, 1, translate2_2Animation);
                }
                else
                {
                    parentAnimations.Add(0, 0.5, scaleDownAnimation);
                    parentAnimations.Add(0.5, 1, scaleUpAnimation);

                    parentAnimations.Add(0, 0.5, translate2_2Animation);
                    parentAnimations.Add(0.5, 1, translate2_1Animation);
                }

                parentAnimations.Commit(this, $"ChildrenAnimations{i}", 100, 5000, null, null, () => true);
            }
        }

        private static View CreateView(string filename)
        {
            //var random = new Random();

            //var size = random.Next(80, 160);

            var image = new CachedImage
            {
                CacheType = CacheType.All,
                Source = filename,
                //HeightRequest = size,
                //WidthRequest = size,
                HeightRequest = 80,
                WidthRequest= 80,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Transformations = new List<ITransformation>
                {
                    new TintTransformation {HexColor = "#FFFFFF", EnableSolidColor = true}
                }
            };

            return image;
        }
    }
}