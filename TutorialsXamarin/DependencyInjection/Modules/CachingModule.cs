using Autofac;
using TutorialsXamarin.Caching.Interfaces;
using TutorialsXamarin.Caching.Services;

namespace TutorialsXamarin.DependencyInjection.Modules
{
    public class CachingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CachingService>().As<ICacheService>();
        }
    }
}