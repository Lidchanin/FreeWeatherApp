using FreeWeatherApp.Helpers;
using FreeWeatherApp.Helpers.Localization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FreeWeatherApp.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomEmptyView
    {
        #region Bindable Properties

        #region LoadingAnimation Property

        public static readonly BindableProperty LoadingAnimationProperty = BindableProperty.Create(
            nameof(LoadingAnimation),
            typeof(string),
            typeof(CustomEmptyView),
            FilenameHelper.LottieFiles.Thermometer);

        public string LoadingAnimation
        {
            get => (string) GetValue(LoadingAnimationProperty);
            set => SetValue(LoadingAnimationProperty, value);
        }

        #endregion LoadingAnimation Property

        #region NoDataAnimations Property

        public static readonly BindableProperty NoDataAnimationProperty = BindableProperty.Create(
            nameof(NoDataAnimation),
            typeof(string),
            typeof(CustomEmptyView),
            FilenameHelper.LottieFiles.NoData);

        public string NoDataAnimation
        {
            get => (string) GetValue(NoDataAnimationProperty);
            set => SetValue(NoDataAnimationProperty, value);
        }

        #endregion NoDataAnimations Property

        #region LoadingText Property

        public static readonly BindableProperty LoadingTextProperty = BindableProperty.Create(
            nameof(LoadingText),
            typeof(string),
            typeof(CustomEmptyView),
            LocalizationHelper.Current.Loading);

        public string LoadingText
        {
            get => (string) GetValue(LoadingTextProperty);
            set => SetValue(LoadingTextProperty, value);
        }

        #endregion LoadingText Property

        #region NoDataText Property

        public static readonly BindableProperty NoDataTextProperty = BindableProperty.Create(
            nameof(NoDataText),
            typeof(string),
            typeof(CustomEmptyView),
            LocalizationHelper.Current.NoData);

        public string NoDataText
        {
            get => (string) GetValue(NoDataTextProperty);
            set => SetValue(NoDataTextProperty, value);
        }

        #endregion NoDataText Property

        #region IsDataLoaded Property

        public static readonly BindableProperty IsDataLoadedProperty = BindableProperty.Create(
            nameof(IsDataLoaded),
            typeof(bool),
            typeof(CustomEmptyView),
            true);

        public bool IsDataLoaded
        {
            get => (bool) GetValue(IsDataLoadedProperty);
            set => SetValue(IsDataLoadedProperty, value);
        }

        #endregion IsDataLoaded Property

        #endregion Bindable Properties

        public CustomEmptyView()
        {
            InitializeComponent();
        }
    }
}