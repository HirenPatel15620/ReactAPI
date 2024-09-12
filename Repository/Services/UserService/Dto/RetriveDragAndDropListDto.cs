using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services.UserService.Dto
{
    public class RetriveDragAndDropListDto
    {
        public RetriveDragAndDropListDto(int totalRows, int pageSize, List<DragAndDrop> dragAndDropData)
        {
            TotalRows = totalRows;
            MaxPage = (int)decimal.Ceiling(totalRows / (pageSize == 0 ? 100 : pageSize));
            DragAndDropData = dragAndDropData;
        }

        public int TotalRows { get; private set; }
        public int MaxPage { get; private set; }
        public List<DragAndDrop> DragAndDropData { get; init; } = null!;
    }
}
