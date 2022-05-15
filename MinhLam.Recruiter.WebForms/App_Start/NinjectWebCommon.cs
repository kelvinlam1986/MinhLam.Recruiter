[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MinhLam.Recruiter.WebForms.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(MinhLam.Recruiter.WebForms.App_Start.NinjectWebCommon), "Stop")]

namespace MinhLam.Recruiter.WebForms.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using MinhLam.Framework;
    using MinhLam.Recruiter.Application;
    using MinhLam.Recruiter.Application.Query;
    using MinhLam.Recruiter.Domain;
    using MinhLam.Recruiter.Infrastructure;
    using MinhLam.Recruiter.Infrastructure.Applications;
    using MinhLam.Recruiter.Infrastructure.Applications.Query;
    using MinhLam.Recruiter.Infrastructure.Configuration;
    using MinhLam.Recruiter.Infrastructure.Domains;
    using MinhLam.Recruiter.Infrastructure.Repositories;
    using MinhLam.Recruiter.Infrastructure.Sessions;
    using MinhLam.Recruiter.Infrastructure.Utilities;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application.
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IApplicationSettings>().To<WebConfigApplicationSettings>();
            kernel.Bind<JobContext>().ToSelf().InRequestScope();
            kernel.Bind<IWebContext>().To<WebContext>();
            kernel.Bind<IUserSession>().To<UserSession>();
            kernel.Bind<IUserCookie>().To<UserCookie>();
            kernel.Bind<IMembershipService>().To<MembershipService>();
            kernel.Bind<IJobPostingService>().To<JobPostingService>();
            kernel.Bind<IFolderService>().To<FolderService>();
            kernel.Bind<IRCAccountRepository>().To<RCAccountRepository>();
            kernel.Bind<IRCJobPostingRepository>().To<RCJobPostingRepository>();
            kernel.Bind<IRCFolderRepository>().To<RCFolderRepository>();
            kernel.Bind<ISalesPackageRepository>().To<SalesPackageRepository>();
            kernel.Bind<ICheckExisting>().To<CheckExisting>();
            kernel.Bind<IGetData>().To<GetData>();
            kernel.Bind<IViewRCAccountQuery>().To<ViewRCAccountQuery>();
            kernel.Bind<IFolderQuery>().To<FolderQuery>();
            kernel.Bind<IJobPostingQuery>().To<JobPostingQuery>();
            kernel.Bind<IJobPurchaseQuery>().To<JobPurchaseQuery>();
            kernel.Bind<ISalesPackagesViewQuery>().To<SalesPackageViewQuery>();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            kernel.Bind<IHashedPassword>().To<HashedPassword>();
            kernel.Bind<ISendEmail>().To<SendEmail>();
            kernel.Bind<IRedirector>().To<Redirector>();
        }
    }
}