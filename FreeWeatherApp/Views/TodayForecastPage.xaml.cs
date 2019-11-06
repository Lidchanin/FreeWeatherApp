namespace FreeWeatherApp.Views
{
    public partial class TodayForecastPage
    {
        public TodayForecastPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await ViewModel.GetForecast();
        }
    }
}