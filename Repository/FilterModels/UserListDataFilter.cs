using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.FilterModels
{
    public class UserListDataFilter
    {
        public List<UserListFilterBy> FilterBys { get; init; } = new List<UserListFilterBy> { UserListFilterBy.NoFilter };
        public List<string> FilterValues { get; init; } = new List<string> { string.Empty };
        public UserListOrderByOptions OrderBy { get; init; } = UserListOrderByOptions.UserIdDesc;
        public bool PaginationEnabled { get; init; }
        public int PageNumber { get; init; } = 0;
        public int PageSize { get; init; } = 50;
    }


    public enum UserListOrderByOptions
    {
        [Display(Name = "Sort by User Id Desc")] UserIdDesc,
        [Display(Name = "Sort by UserId")] UserId,
        [Display(Name = "Sort by Title Desc")] TitleDesc,
        [Display(Name = "Sort by Title")] Title,
        [Display(Name = "Sort by Body Desc")] BodyDesc,
        [Display(Name = "Sort by Body")] Body,
       
    }

    public enum UserListFilterBy
    {
        [Display(Name = "All")] NoFilter = 0,
        [Display(Name = "User Id")] UserId,
        [Display(Name = "Title")] Title,
        [Display(Name = "Body")] Body,
        
    }
}
