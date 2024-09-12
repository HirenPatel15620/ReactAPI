using Model.Models;
using Repository.FilterModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services.UserService.QueryObjects
{
    public static class UserListDtoFilter
    {
        public static IQueryable<User> FilteUserListDataBy(this IQueryable<User> data, UserListFilterBy filterBy, string filterValue, List<int> additionalContactNoList = null)
        {
            switch (filterBy)
            {
                case UserListFilterBy.NoFilter:
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
                case UserListFilterBy.UserId:
                    var validUserId = int.TryParse(filterValue, out int userId);
                    if (validUserId)
                        data = data.Where(x => x.UserId == userId);
                    break;
                case UserListFilterBy.Title:
                    data = data.Where(x => x.Title != null && (x.Title == filterValue || x.Title.Contains(filterValue)));
                    break;
                case UserListFilterBy.Search:
                    var valid = int.TryParse(filterValue, out int userIdValue);
                    if (valid)
                        data = data.Where(x => x.UserId == userIdValue);
                    else
                    data = data.Where(x => (x.Title != null && x.Title.Contains(filterValue)) || (x.Body != null && x.Body.Contains(filterValue)));
                    break;
                case UserListFilterBy.Body:
                    data = data.Where(x => x.Body != null && (x.Body == filterValue || x.Body.Contains(filterValue)));
                    break;
            }
            return data;
        }
    }
}
