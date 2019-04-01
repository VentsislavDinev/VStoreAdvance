using Abp.AutoMapper;
using Abp.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VStoreAdvance.Infrastructure.Core;

namespace VStoreAdvance.Service.Store
{
    [DependsOn(typeof(VStoreAdvanceCoreModule), typeof(AbpAutoMapperModule))]

    public class StoreServiceModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
