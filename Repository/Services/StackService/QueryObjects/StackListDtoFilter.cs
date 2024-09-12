using Model.Models;
using Repository.FilterModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services.StackService.QueryObjects
{
    public static class StackListDtoFilter
    {
        public static IQueryable<Stack> FilteStackListDataBy(this IQueryable<Stack> data, StackListFilterBy filterBy, string filterValue)
        {
            switch (filterBy)
            {
                case StackListFilterBy.NoFilter:
                    break;
                //case UserListFilterBy.History:
                //    var validHistory = bool.TryParse(filterValue, out bool history);
                //    if (validHistory)
                //        data = data.Where(x => x.Posted != null && x.Posted == history);
                //    break;
                //case UserListFilterBy.UpdatedAtFrom:
                //    var validUpdateStartDate = DateTime.TryParse(filterValue, out DateTime updateStartDate);
                //    if (validUpdateStartDate)
                //        data = data.Where(x => x.UpdatedAt != null && x.UpdatedAt >= updateStartDate);
                //    break;
                case StackListFilterBy.Id:
                    var validId = int.TryParse(filterValue, out int id);
                    if (validId)
                        data = data.Where(x => x.Id == id);
                    break;
                case StackListFilterBy.Name:
                    data = data.Where(x => x.Name != null && (x.Name == filterValue || x.Name.Contains(filterValue)));
                    break;
                case StackListFilterBy.Search:
                    var valid = int.TryParse(filterValue, out int idValue);
                    if (valid)
                        data = data.Where(x => x.Id == idValue);
                    else
                    data = data.Where(x => (x.Name != null && x.Name.Contains(filterValue)));
                    break;
            }
            return data;
        }
    }
}
