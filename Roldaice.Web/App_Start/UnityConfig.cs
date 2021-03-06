using AutoMapper;
using Roldaice.Dal.Context;
using Roldaice.Dal.Dal.Base;
using Roldaice.Helpers.Logger;
using Roldaice.Web.App_Start;
using System;
using System.Linq;
using System.Reflection;
using Unity;
using Unity.Lifetime;
using Unity.RegistrationByConvention;
namespace Roldaice.Web
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            //Regiter types by convention (For exemple, Cat is registered for ICat)
            container.RegisterTypes(
                AllClasses.FromLoadedAssemblies(),
                WithMappings.FromAllInterfaces,
                WithName.Default,
                WithLifetime.ContainerControlled,
                overwriteExistingMappings: true);

            container
                .RegisterType<RoldaiceContext>(new HierarchicalLifetimeManager())
                .RegisterInstance(AutoMapperConfig.RegisterAutoMapper())
                .RegisterType<ILogger, Logger>(new ContainerControlledLifetimeManager())
            ;
        }

        public static ILogger GetLogger()
        {
            return Container.Resolve<Logger>();
        }
    }
}