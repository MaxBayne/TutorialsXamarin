using Autofac;
using TutorialsXamarin.Interfaces;
using TutorialsXamarin.Services;
using Xamarin.Forms;

namespace TutorialsXamarin.DependencyInjection.Modules
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MessagingService>().As<IMessagingCenter>();
            builder.RegisterType<NavigationService>().As<INavigationService>();

            
        }
    }
}