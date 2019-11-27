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

            PageBackgroundView.StartAnimation();

            await ViewModel.LoadData();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            PageBackgroundView.CancelAnimation();
        }
    }
}