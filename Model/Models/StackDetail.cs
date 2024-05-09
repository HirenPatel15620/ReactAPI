using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class StackDetail
    {
        public int Id { get; set; }
        public int? StackId { get; set; }
        public string? Name { get; set; }

        public virtual Stack? Stack { get; set; }
    }
}
