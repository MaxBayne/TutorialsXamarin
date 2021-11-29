using Autofac;
using TutorialsXamarin.Caching.Interfaces;
using TutorialsXamarin.Caching.Services;
using TutorialsXamarin.ViewModels;

namespace TutorialsXamarin.DependencyInjection.Modules
{
    public class ViewModelsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MvvmViewModel>().As<IMvvmViewModel>();
            builder.RegisterType<ViewCustomerViewModel>().As<IViewCustomerViewModel>();
        }
    }
}