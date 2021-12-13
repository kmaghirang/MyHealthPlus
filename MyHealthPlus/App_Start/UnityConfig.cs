using System;
using MyHealthPlus.DAL.Models;
using MyHealthPlus.DAL.UnitOfWork;
using MyHealthPlus.Services.Login.LoginService;
using MyHealthPlus.Services.Login.RegistrationService;
using MyHealthPlus.Services.Main.AppointmentsService;
using MyHealthPlus.Services.Manage.CheckUpTypesService;
using MyHealthPlus.Services.Manage.RolesService;
using MyHealthPlus.Services.Manage.StatusService;
using MyHealthPlus.Services.Manage.TimeRangeListService;
using MyHealthPlus.Services.Manage.UsersService;
using Unity;

namespace MyHealthPlus
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
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();

            // Context
            container.RegisterType<MyHealthPlusDbContext, MyHealthPlusDbContext>();

            // Unit of Work
            container.RegisterType<IMyHealthPlusUnitOfWork, MyHealthPlusUnitOfWork>();

            // Services
            container.RegisterType<IRegistrationService, RegistrationService>();
            container.RegisterType<ILoginService, LoginService>();
            container.RegisterType<ICheckUpTypesService, CheckUpTypesService>();
            container.RegisterType<IAppointmentsService, AppointmentsService>();
            container.RegisterType<ITimeRangeListService, TimeRangeListService>();
            container.RegisterType<IStatusService, StatusService>();
            container.RegisterType<IUsersService, UsersService>();
            container.RegisterType<IRolesService, RolesService>();
        }
    }
}