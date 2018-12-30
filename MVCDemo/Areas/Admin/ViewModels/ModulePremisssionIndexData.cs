using MVCDemo.Areas.Admin.Models;
using System.Collections.Generic;

namespace MVCDemo.Areas.Admin.ViewModels
{
    public class ModulePremissionIndexData
    {
        public IEnumerable<ModuleEntity> VMModules { get; set; }

        public IEnumerable<PremissionEntity> VMPremissions { get; set; }

        public IEnumerable<ModulePremissionEntity> VMModulePremissions { get; set; }
    }
}