using MVCDemo.Areas.Admin.Models;
using System.Collections.Generic;

namespace MVCDemo.Areas.Admin.ViewModels
{
    public class UserRoleIndexData
    {
        public IEnumerable<UserEntity>VMUsers { get; set; }

        public IEnumerable<RoleEntity> VMRoles { get; set; }

        public IEnumerable<UserRoleEntity> VMUserRoles { get; set; }
    }
}