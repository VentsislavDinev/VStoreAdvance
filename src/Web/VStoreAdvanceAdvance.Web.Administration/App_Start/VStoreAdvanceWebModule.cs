using Abp.Modules;
using Abp.Web.Mvc;
using Abp.Web.Mvc.Configuration;
using Abp.Web.SignalR;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using VEducaVStoreAdvancetionAppServiceBaseWebApi;
using VStoreAdvance.Data.Dapper;
using VStoreAdvance.Data.EntityFramework;
using VStoreAdvance.Infrastructure.Core;
using VStoreAdvance.Service;
using VStoreAdvance.Service.Store;
using VStoreAdvance.Web.App_Start;
using VStoreAdvance.Web.Common;
using VStoreAdvance.Web.Service;
using VStoreAdvanceAdvance.Web.Administration;

namespace VStoreAdvances.Web.App_Start
{
    [DependsOn(
      typeof(VStoreAdvanceDataModule),
      typeof(VStoreAdvanceServiceCoreModule),
      typeof(VStoreAdvanceCoreModule),
      typeof(StoreServiceModule),
      typeof(WebServiceModule),
      typeof(DapperModule),
      typeof(WebCommonModule),
      typeof(VStoreAdvanceWebApiModule),
      typeof(AbpWebMvcModule),
      typeof(AbpWebSignalRModule) //Add AbpWebSignalRModule dependency
                                  //typeof(AbpHangfireModule)
      )]
    public class VStoreAdvanceWebModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Enable database based localization
            //Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();
            //Configuration.Localization.Languages.Add(new LanguageInfo("en", "English", "famfamfam-flag-england", true));
            //Configuration.Localization.Languages.Add(new LanguageInfo("tr", "Türkçe", "famfamfam-flag-tr"));
            //Configuration.Localization.Languages.Add(new LanguageInfo("zh-CN", "简体中文", "famfamfam-flag-cn"));
            Configuration.Modules.AbpMvc().IsValidationEnabledForControllers = false;


            //Configure navigation/menu
            Configuration.Navigation.Providers.Add<VStoreAdvanceNavigationProvider>();

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false; //Can disable job manager to not process jobs.

            //Configuration.BackgroundJobs.UseHangfire(
            //    configuration => //Configure to use hangfire for background jobs.
            //        {
            //            configuration.GlobalConfiguration.UseSqlServerStorage("Default"); //Set database connection
            //        });

            // var lang = IocManager.Resolve<ILanguageManager>().CurrentLanguage;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

        }
    }
}