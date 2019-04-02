using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.Web.Mvc;
using Abp.Web.Mvc.Configuration;
using Abp.Web.SignalR;
using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using VEducaVStoreAdvancetionAppServiceBaseWebApi;
using VStoreAdvance.Data.Dapper;
using VStoreAdvance.Data.EntityFramework;
using VStoreAdvance.Data.NHibernate;
using VStoreAdvance.Infrastructure.Core;
using VStoreAdvance.Service;
using VStoreAdvance.Service.Store;
using VStoreAdvance.Web.Common;
using VStoreAdvance.Web.Service;

namespace VStyoreAdvace.Web.WebApi.Server.App_Start
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
      typeof(AbpWebSignalRModule)
      )]
    public class VStoreAdvanceServerWebApiModule : AbpModule
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

            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
               .ForAll<IApplicationService>(typeof(VStoreAdvanceCoreModule).Assembly, "app")
               .Build();

            ConfigureSwaggerUi();


            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }


        private void ConfigureSwaggerUi()
        {
            Configuration.Modules.AbpWebApi().HttpConfiguration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "VStyoreAdvace.Web.WebApi.Server");
                    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                })
                .EnableSwaggerUi(c =>
                {
                    c.DocExpansion(DocExpansion.List);
                    c.BooleanValues(new[] { "0", "1" });

                    c.InjectJavaScript(Assembly.GetAssembly(typeof(VStoreAdvanceCoreModule)), "VStyoreAdvace.Web.WebApi.Server.Scripts.Swagger-Custom.js");
                });
        }
    }
}