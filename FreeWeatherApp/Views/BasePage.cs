using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FreeWeatherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public abstract class BasePage : ContentPage
    {
        #region Bindable properties

        public static readonly BindableProperty ScreenWidthProperty = BindableProperty.Create(
            nameof(ScreenWidth),
            typeof(double),
            typeof(BasePage));

        public double ScreenWidth
        {
            get => (double) GetValue(ScreenWidthProperty);
            private set => SetValue(ScreenWidthProperty, value);
        }

        public static readonly BindableProperty ScreenHeightProperty = BindableProperty.Create(
            nameof(ScreenHeight),
            typeof(double),
            typeof(BasePage));

        public double ScreenHeight
        {
            get => (double) GetValue(ScreenHeightProperty);
            private set => SetValue(ScreenHeightProperty, value);
        }

        #endregion Bindable properties

        protected BasePage()
        {
            var deviceDisplay = DeviceDisplay.MainDisplayInfo;
            ScreenWidth = deviceDisplay.Width / deviceDisplay.Density;
            ScreenHeight = deviceDisplay.Height / deviceDisplay.Density;
        }
    }
}