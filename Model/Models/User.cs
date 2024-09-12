using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string Title { get; set; } = null!;
        public string? Body { get; set; }
    }
}
