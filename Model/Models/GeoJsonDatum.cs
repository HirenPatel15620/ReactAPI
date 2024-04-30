using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class GeoJsonDatum
    {
        public int Id { get; set; }
        public string? GeoJsonString { get; set; }
        public int? SuburbId { get; set; }
    }
}
