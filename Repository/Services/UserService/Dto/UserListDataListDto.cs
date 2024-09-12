using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Services.UserService.Dto
{
    public class UserListDataListDto
    {
        public UserListDataListDto(int totalRows, int pageSize, List<User> userListData)
        {
            TotalRows = totalRows;
            MaxPage = (int)decimal.Ceiling(totalRows / (pageSize == 0 ? 100 : pageSize));
            UserListData = userListData;
        }

        public int TotalRows { get; private set; }
        public int MaxPage { get; private set; }
        public List<User> UserListData { get; init; } = null!;
    }
}