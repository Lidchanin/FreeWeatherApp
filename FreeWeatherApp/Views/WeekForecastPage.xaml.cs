namespace FreeWeatherApp.Views
{
    public partial class WeekForecastPage
    {
        public WeekForecastPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewModel.GetWeekForecast();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}