using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class Stack
    {
        public Stack()
        {
            StackDetails = new HashSet<StackDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<StackDetail> StackDetails { get; set; }
    }
}
