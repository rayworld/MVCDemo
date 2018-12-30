using MVCDemo.Areas.Admin.Models;
using System.Collections.Generic;

namespace MVCDemo.Areas.Admin.ViewModels
{
    public class RoleModulePremissionIndexData
    {
        public IEnumerable<RoleModulePremissionEntity> VMRoleModulePremissions{ get; set; }

        public IEnumerable<RoleEntity> VMRoles { get; set; }

        public IEnumerable<ModulePremissionEntity> VMModulePremissions { get; set; }

        public IEnumerable<ModuleEntity> VMModules { get; set; }

        public IEnumerable<PremissionEntity> VMPremissions { get; set; }

    }
}