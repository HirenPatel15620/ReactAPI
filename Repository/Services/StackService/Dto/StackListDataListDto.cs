using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Services.StackService.Dto
{
    public class StackListDataListDto
    {
        public StackListDataListDto(int totalRows, int pageSize, List<Stack> stackListData)
        {
            TotalRows = totalRows;
            MaxPage = (int)decimal.Ceiling(totalRows / (pageSize == 0 ? 100 : pageSize));
            StackListData = stackListData;
        }

        public int TotalRows { get; private set; }
        public int MaxPage { get; private set; }
        public List<Stack> StackListData { get; init; } = null!;
    }
}