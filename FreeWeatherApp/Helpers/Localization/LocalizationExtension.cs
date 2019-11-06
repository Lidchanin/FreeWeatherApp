using System;
using System.Reflection;
using Xamarin.Forms.Xaml;

namespace FreeWeatherApp.Helpers.Localization
{
    public class LocalizationExtension : IMarkupExtension<string>
    {
        public string PropertyName { get; set; }

        public string ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrEmpty(PropertyName))
            {
                throw new InvalidOperationException($"{nameof(PropertyName)} isn't set.");
            }

            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            var propertyInfo = LocalizationHelper.Current.GetType().GetRuntimeProperty(PropertyName);

            return propertyInfo?.GetValue(LocalizationHelper.Current)?.ToString() ??
                   throw new ArgumentException($"{nameof(PropertyName)} {PropertyName} isn't exists.");
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => 
            (this as IMarkupExtension<string>).ProvideValue(serviceProvider);
    }
}