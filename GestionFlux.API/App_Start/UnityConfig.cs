using GestionFlux.API.Controllers;
using GestionFlux.Service.Interfaces;
using GestionFlux.Service.Services;
using System.Web.Http;
using System.Web.Mvc;
using Unity;
using Unity.Injection;

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

            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IMessageService, MessageService>();
            container.RegisterType<IEquipmentService, EquipmentService>();
            //container.RegisterType<UsersController>(new InjectionConstructor(typeof(IUserService)));

            container.RegisterInstance(typeof (HttpConfiguration), GlobalConfiguration.Configuration);
        }
    }
}