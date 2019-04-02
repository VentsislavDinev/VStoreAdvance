using Abp.Modules;
using Abp.Reflection.Extensions;
using System.Collections.Generic;
using System.Reflection;
using VStoreAdvance.Infrastructure.Core;

namespace VStoreAdvance.Data.Dapper
{
    public class DapperModule : AbpModule
    {
        public override void Initialize()
        {

            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            DapperExtensions.DapperExtensions.SetMappingAssemblies(new List<Assembly> { typeof(VStoreAdvanceCoreModule).GetAssembly() });
        }
    }
}
