using System.Configuration;
using System.Web.Mvc;
using TeslaStockData.Repository;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace TeslaStockData
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            string connectionString = ConfigurationManager.ConnectionStrings["TeslaStockConnection"].ToString();
           
            container.RegisterType<ITeslaRepo, TeslaRepo>(new InjectionConstructor(connectionString));


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}