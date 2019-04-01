using Abp.AutoMapper;
using Abp.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VStoreAdvance.Infrastructure.Core;

namespace VStoreAdvance.Web.Common
{
    [DependsOn(typeof(VStoreAdvanceCoreModule), typeof(AbpAutoMapperModule))]
    public class WebCommonModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
