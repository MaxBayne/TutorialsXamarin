using Autofac;
using TutorialsXamarin.DependencyInjection.Modules;
using TutorialsXamarin.Views;

namespace TutorialsXamarin.DependencyInjection.Services
{
    public class DependencyInjectionService
    {

        //using (var scope = Program.Container.BeginLifetimeScope())
        //{
        //var cacheService = scope.Resolve<ICacheService>();
        //var exist = await cacheService.LocalCache.IsExistAsync("Test");
        //}


        /// <summary>
        /// Create Builder and Register Components and Modules and Build the Container
        /// </summary>
        /// <param name="container"></param>
        // ReSharper disable once RedundantAssignment
        public static void ConfigureDependency(ref IContainer container)
        {
            //Create Builder
            var builder = new ContainerBuilder();


            builder.RegisterType<MvvmPage>();

            //Register Modules
            builder.RegisterModule<CachingModule>();
            builder.RegisterModule<ServicesModule>();
            builder.RegisterModule<CustomersModule>();
            builder.RegisterModule<ViewModelsModule>();


            //Create Container
            container = builder.Build();
        }
    }
}