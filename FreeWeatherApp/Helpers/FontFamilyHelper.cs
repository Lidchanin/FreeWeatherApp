using System;
using Xamarin.Forms;

namespace FreeWeatherApp.Helpers
{
    public static class FontFamilyHelper
    {
        public static class Comfortaa
        {
            public static string Bold
            {
                get
                {
                    switch (Device.RuntimePlatform)
                    {
                        case Device.Android:
                            return "Comfortaa-Bold.ttf#Comfortaa Bold";
                        case Device.iOS:
                            return "Comfortaa-Bold";
                        default:
                            throw new NotImplementedException($"Font not implemented.");
                    }
                }
            }

            public static string Light
            {
                get
                {
                    switch (Device.RuntimePlatform)
                    {
                        case Device.Android:
                            return "Comfortaa-Light.ttf#Comfortaa Light";
                        case Device.iOS:
                            return "Comfortaa-Light";
                        default:
                            throw new NotImplementedException($"Font not implemented.");
                    }
                }
            }

            public static string Medium
            {
                get
                {
                    switch (Device.RuntimePlatform)
                    {
                        case Device.Android:
                            return "Comfortaa-Medium.ttf#Comfortaa Medium";
                        case Device.iOS:
                            return "Comfortaa-Medium";
                        default:
                            throw new NotImplementedException($"Font not implemented.");
                    }
                }
            }

            public static string Regular
            {
                get
                {
                    switch (Device.RuntimePlatform)
                    {
                        case Device.Android:
                            return "Comfortaa-Regular.ttf#Comfortaa Regular";
                        case Device.iOS:
                            return "Comfortaa-Regular";
                        default:
                            throw new NotImplementedException($"Font not implemented.");
                    }
                }
            }

            public static string SemiBold
            {
                get
                {
                    switch (Device.RuntimePlatform)
                    {
                        case Device.Android:
                            return "Comfortaa-SemiBold.ttf#Comfortaa SemiBold";
                        case Device.iOS:
                            return "Comfortaa-SemiBold";
                        default:
                            throw new NotImplementedException($"Font not implemented.");
                    }
                }
            }
        }
    }
}