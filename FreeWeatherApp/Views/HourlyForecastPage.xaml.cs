namespace FreeWeatherApp.Views
{
    public partial class HourlyForecastPage
    {
        public HourlyForecastPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await ViewModel.GetHourlyForecast();
        }
    }
}