using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.FilterModels
{
    public class StackListDataFilter
    {
        public List<StackListFilterBy> FilterBys { get; init; } = new List<StackListFilterBy> { StackListFilterBy.NoFilter };
        public List<string> FilterValues { get; init; } = new List<string> { string.Empty };
        public StackListOrderByOptions OrderBy { get; init; } = StackListOrderByOptions.IdDesc;
        public bool PaginationEnabled { get; init; } = true;
        public int PageNumber { get; init; } = 0;
        public int PageSize { get; init; } = 10;
    }


    public enum StackListOrderByOptions
    {
        [Display(Name = "Sort by  Id Desc")] IdDesc,
        [Display(Name = "Sort by Id")] Id,
        [Display(Name = "Sort by Name Desc")] NameDesc,
        [Display(Name = "Sort by Name")] Name
    }

    public enum StackListFilterBy
    {
        [Display(Name = "All")] NoFilter = 0,
        [Display(Name = "Search")] Search,
        [Display(Name = "Id")] Id,
        [Display(Name = "Name")] Name,
    }
}
