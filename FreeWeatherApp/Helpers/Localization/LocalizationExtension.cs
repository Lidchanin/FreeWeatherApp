using System;
using System.Reflection;
using Xamarin.Forms.Xaml;

namespace FreeWeatherApp.Helpers.Localization
{
    public class LocalizationExtension : IMarkupExtension<string>
    {
        public string TextPropertyName { get; set; }

        public string ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrEmpty(TextPropertyName))
            {
                throw new InvalidOperationException($"{nameof(TextPropertyName)} isn't set.");
            }

            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            var propertyInfo = LocalizationHelper.Current.GetType().GetRuntimeProperty(TextPropertyName);

            return propertyInfo?.GetValue(LocalizationHelper.Current)?.ToString() ??
                   throw new ArgumentException($"{nameof(TextPropertyName)} {TextPropertyName} isn't exists.");
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return (this as IMarkupExtension<string>).ProvideValue(serviceProvider);
        }
    }
}