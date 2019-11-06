using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FFImageLoading.Cache;
using FFImageLoading.Forms;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FreeWeatherApp.Views
{
    public partial class TestPage : BasePage
    {
        private List<VisualElement> _elements = new List<VisualElement>();

        private bool _starsAdded = false;
        private bool _initialized = false;
        private List<VisualElement> _stars = new List<VisualElement>();

        public TestPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (!_initialized)
            {
                PositionElement();
                RotateElements();

                _initialized = true;
            }
        }

        private async void PositionElement()
        {
            var random = new Random();

            for (int elementGroupIndex = 0; elementGroupIndex < 3; elementGroupIndex++)
            {
                var elementGroup = new Grid();

                for (int elementIndex = 0; elementIndex < 60; elementIndex++)
                {
                    var size = random.Next(20, 80);

                    var element = new CachedImage
                    {
                        CacheType = CacheType.All,
                        Source = "icon_cloudy.png",
                        HeightRequest = size,
                        WidthRequest = size,
                        HorizontalOptions = LayoutOptions.Start,
                        VerticalOptions = LayoutOptions.Start,
                        TranslationX = random.Next(0, (int) ScreenWidth),
                        TranslationY = random.Next(0, (int) ScreenHeight),
                    };

                    elementGroup.Children.Add(element);
                }

                _elements.Add(elementGroup);
                MainGrid.Children.Add(elementGroup);
            }
        }

        private async Task RotateElements()
        {
            var rotateTasks = new List<Task>();
            var random = new Random();

            for (var i = 0; i < _elements.Count; i++)
            {
                var element = _elements[i];
                var rate = random.Next(240000, 300000);

                if (i % 2 == 0)
                {
                    rotateTasks.Add(RotateElement(element, (uint) rate, new CancellationToken(), true));
                }
                else
                {
                    rotateTasks.Add(RotateElement(element, (uint) rate, new CancellationToken(), false));
                }
            }

            await Task.WhenAll(rotateTasks);
        }

        protected async Task RotateElement(VisualElement element, uint duration, CancellationToken cancellation,
            bool clockwise = true)
        {
            while (!cancellation.IsCancellationRequested)
            {
                if (clockwise)
                {
                    await element.RotateTo(360, duration, Easing.Linear);
                    await element.RotateTo(0, 0); // reset to initial position
                }
                else
                {
                    await element.RotateTo(0, 0); // reset to initial position
                    await element.RotateTo(360, duration, Easing.Linear);
                }
            }
        }
    }
}