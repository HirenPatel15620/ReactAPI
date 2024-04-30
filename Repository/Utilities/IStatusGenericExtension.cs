using StatusGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Utilities
{
    public static class IStatusGenericExtension
    {
        public static IStatusGenericAdapter AddState(this IStatusGeneric<object> result, StatusGenericState state)
        {
            return new IStatusGenericAdapter()
            {
                State = state,
                StatusGeneric = result
            };
        }
           
    }
}
