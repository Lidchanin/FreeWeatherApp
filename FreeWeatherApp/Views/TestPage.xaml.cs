namespace FreeWeatherApp.Views
{
    public partial class TestPage
    {
        public TestPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            PageBackgroundView.StartAnimation();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            PageBackgroundView.CancelAnimation();
        }
    }
}