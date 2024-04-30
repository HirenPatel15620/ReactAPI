using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class Suburb
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int StateId { get; set; }
        public int PostalCode { get; set; }
    }
}
