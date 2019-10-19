using System;
using FreeWeatherApp.Enums;
using FreeWeatherApp.Helpers.Localization;

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

            App.Current.MainPage = new AppShell();
            await AppShell.Current.GoToAsync("//settings");
        }


        private async void Button_OnClicked2(object sender, EventArgs e)
        {
            LocalizationHelper.SetLanguage(LanguageCode.En);

            App.Current.MainPage = new AppShell();
            await AppShell.Current.GoToAsync("//settings");
        }
    }
}