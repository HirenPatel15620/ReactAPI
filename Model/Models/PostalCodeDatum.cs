using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class PostalCodeDatum
    {
        public int? PostalCode { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public double? Altitude { get; set; }
        public string? Descriptio { get; set; }
        public string? AltitudeMode { get; set; }
        public string? Type { get; set; }
    }
}
