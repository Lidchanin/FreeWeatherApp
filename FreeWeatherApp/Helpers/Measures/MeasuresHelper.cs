using FreeWeatherApp.Enums;

namespace FreeWeatherApp.Helpers.Measures
{
    public static class MeasuresHelper
    {
        public static MeasurementUnit Current { get; private set; } = GetMeasurementUnit();

        public static void SetMeasurementUnit(MeasurementUnit measurementUnit)
        {
            PreferencesHelper.SetMeasurementUnit(measurementUnit);
            Current = GetMeasurementUnit();
        }

        private static MeasurementUnit GetMeasurementUnit()
        {
            var measurementUnit = PreferencesHelper.GetMeasurementUnit();
            if (measurementUnit == MeasurementUnit.None)
            {
                measurementUnit = MeasurementUnit.Us;
            }

            return measurementUnit;
        }
    }
}