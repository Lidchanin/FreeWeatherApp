using FreeWeatherApp.Enums;
using FreeWeatherApp.Helpers.Localization;
using FreeWeatherApp.Helpers.Measures;
using System;
using Xamarin.Forms;

namespace FreeWeatherApp.Views
{
    public partial class SettingsPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            LocalizationHelper.SetLanguage(LanguageCode.Ru);

            Application.Current.MainPage = new AppShell();
            await Shell.Current.GoToAsync("//settings");
        }


        private async void Button_OnClicked2(object sender, EventArgs e)
        {
            LocalizationHelper.SetLanguage(LanguageCode.En);

            Application.Current.MainPage = new AppShell();
            await Shell.Current.GoToAsync("//settings");
        }

        private async void Button_OnClicked3(object sender, EventArgs e)
        {
            MeasuresHelper.SetMeasurementUnit(MeasurementUnit.Us);
            
            Application.Current.MainPage = new AppShell();
            await Shell.Current.GoToAsync("//settings");
        }

        private async void Button_OnClicked4(object sender, EventArgs e)
        {
            MeasuresHelper.SetMeasurementUnit(MeasurementUnit.Si);
            
            Application.Current.MainPage = new AppShell();
            await Shell.Current.GoToAsync("//settings");
        }
    }
}