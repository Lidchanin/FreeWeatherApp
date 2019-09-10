using System;
using System.Collections.Generic;
using FreeWeatherApp.Enums;

namespace FreeWeatherApp.Models.DarkSky
{
    public class OptionalParameters
    {
        public List<ExclusionBlock> DataBlocksToExclude { get; set; }

        public bool? ExtendHourly { get; set; }

        public DateTime? ForecastDateTime { get; set; }

        public LanguageCode LanguageCode { get; set; }

        public MeasurementUnit MeasurementUnit { get; set; }
    }
}