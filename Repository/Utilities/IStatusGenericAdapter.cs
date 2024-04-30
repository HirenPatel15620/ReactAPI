using Microsoft.EntityFrameworkCore.Migrations.Operations;
using StatusGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Utilities
{
    public class IStatusGenericAdapter
    {
        public StatusGenericState State { get; set; }

        public IStatusGeneric<object> StatusGeneric { get; set; } = null!;
    }

    public enum StatusGenericState
    {
        None,
        Unmodified,
        Modified,
        Created,
        Deleted,
    }
}
