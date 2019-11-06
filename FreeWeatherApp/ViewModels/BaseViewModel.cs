using FreeWeatherApp.Services.DarkSky;
using System.ComponentModel;

namespace FreeWeatherApp.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected static IDarkSkyApiService DarkSkyApiService => DarkSkyApiServiceImpl.Instance;
    }
}