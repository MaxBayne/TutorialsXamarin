using Autofac;
using TutorialsXamarin.Data.Interfaces;
using TutorialsXamarin.Data.Services;

namespace TutorialsXamarin.DependencyInjection.Modules
{
    public class CustomersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomersService>().As<ICustomersService>();
        }
    }
}