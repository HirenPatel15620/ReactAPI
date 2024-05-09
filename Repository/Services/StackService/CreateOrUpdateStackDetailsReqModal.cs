using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services.StackService
{
    public class CreateOrUpdateStackDetailsReqModal
    {
        public string Title {  get; set; }
        public List<CreateOrUpdateStackDetailsModal> StackDetailsList { get; set; } = new();
    }
}

