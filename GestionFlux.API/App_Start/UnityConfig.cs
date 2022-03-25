using GestionFlux.API.Controllers;
using GestionFlux.Service.Auth;
using GestionFlux.Service.Messaging;
using GestionFlux.Service.Marketing;
using GestionFlux.Service.Logistic;
using System.Web.Http;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using GestionFlux.Core.Service;
using GestionFlux.Repository;
using GestionFlux.Domain.Models;
using GestionFlux.Core.Repository;

namespace GestionFlux.API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));    
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);

            container.RegisterType<IAuthService, AuthService>();
            container.RegisterType<IMessagingService, MessagingService>();
            container.RegisterType<ILogisticService, LogisticService>();
            container.RegisterType<IMarketingService, MarketingService>();

            container.RegisterType<IService<Resource, FluxDbContext>, GenericService<Resource, FluxDbContext>>();
            container.RegisterType<IRepository<Resource, FluxDbContext>, BaseRepository<Resource, FluxDbContext>>();
            //container.RegisterType<UsersController>(new InjectionConstructor(typeof(IUserService)));

            container.RegisterInstance(typeof (HttpConfiguration), GlobalConfiguration.Configuration);
        }
    }
}