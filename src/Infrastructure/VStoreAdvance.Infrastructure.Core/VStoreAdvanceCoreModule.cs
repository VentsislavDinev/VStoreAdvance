using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VStoreAdvance.Infrastructure.Core.Timing;
using VStoreAdvance.Infrastructure.Core.Users;
using VStoreAdvance.Infrastructure.Core.Authorization;
using VStoreAdvance.Infrastructure.Core.Authorization.Roles;

namespace VStoreAdvance.Infrastructure.Core
{

    [DependsOn(typeof(AbpZeroCoreModule))]
    public class VStoreAdvanceCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Declare entity types
            //Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            Configuration.Localization.Sources.Add(
                           new DictionaryBasedLocalizationSource(
                               VStoreAdvanceConsts.LocalizationSourceName,
                               new XmlEmbeddedFileLocalizationDictionaryProvider(
                                   Assembly.GetExecutingAssembly(),
                                   "VStoreAdvance.Infrastructure.Core.Localization.Source"
                                   )
                               )
                           );            // Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);



            Configuration.Authorization.Providers.Add<VStoreAdvanceAuthorizationProvider>();

        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(VStoreAdvanceCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}
