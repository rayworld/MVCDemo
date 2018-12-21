using MVCDemo.Areas.Admin.Models;
using System.Collections.Generic;

namespace MVCDemo.Areas.Admin.ViewModels
{
    public class UserRoleIndexData
    {
        public IEnumerable<TUser> TUsers { get; set; }

        public IEnumerable<TRole> TRoles { get; set; }

        public IEnumerable<TUserRole> TUserRoles { get; set; }
    }
}