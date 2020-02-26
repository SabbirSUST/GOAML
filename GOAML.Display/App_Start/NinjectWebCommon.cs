using GOAML.DomainModels.Models;
using  GOAML.Repository.IRepositories;
using  GOAML.Repository.Repositories;
using RepositoryCloud.IRepositories;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(GOAML.Display.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(GOAML.Display.App_Start.NinjectWebCommon), "Stop")]

namespace GOAML.Display.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
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
                kernel.Bind<GOAMLEntities>().To<GOAMLEntities>();
                kernel.Bind<IAccountInfoUpdateRepository>().To<AccountInfoUpdateRepository>();
                kernel.Bind<IBusinessInfoRepository>().To<BusinessInfoRepository>();
                kernel.Bind<IDirectorInformationRepository>().To<DirectorInformationRepository>();
                kernel.Bind<IDirectorRepository>().To<DirectorRepository>();
                kernel.Bind<IIndividualInformationRepository>().To<IndividualInformationRepository>();
                kernel.Bind<IPersonIdentificationRepository>().To<PersonIdentificationRepository>();
                kernel.Bind<IPhoneInformationRepository>().To<PhoneInformationRepository>();
                kernel.Bind<IRoleTypeRepository>().To<RoleTypeRepository>();
                kernel.Bind<ISignatoryInfoRepository>().To<SignatoryInfoRepository>();
                kernel.Bind<ITAccountMyClientRepository>().To<TaccountMyClientRepository>();
                kernel.Bind<ITaddressRepository>().To<TaddressRepository>();
                kernel.Bind<ITEntityRepository>().To<TentityRepository>();
                kernel.Bind<ITpersonMyClientRepository>().To<TpersonMyClientRepository>();
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
        }        
    }
}
