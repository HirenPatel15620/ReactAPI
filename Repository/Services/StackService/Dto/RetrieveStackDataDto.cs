using Repository.Services.StackService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Services.StackService.Dto
{
    public class RetrieveStackDataDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public List<RetrieveStackDetailsDataDto> stackDetailsDataList { get; set; }

    }
}