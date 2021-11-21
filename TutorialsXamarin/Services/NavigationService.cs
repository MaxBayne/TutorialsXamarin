using System;
using System.Collections.Generic;
using TutorialsXamarin.Extensions;
using TutorialsXamarin.Interfaces;
using TutorialsXamarin.ViewModels;
using Xamarin.Forms;

namespace TutorialsXamarin.Services
{
    public class NavigationService: INavigationService
    {
        private Dictionary<string, Type> ViewsList { get; }= new Dictionary<string, Type>();


        //Main Page For Application
        public Page MainPage => Application.Current.MainPage;



        //Insert View inside Views List
        public void Register(string view, Type type) => ViewsList[view] = type;
        



        //Go Back To Previous View
        public async void GoBack() => await MainPage.Navigation.PopAsync();



        //Navigate To Special View as Page
        public async void NavigateToPage(string view, object parameter=null)
        {
            if (ViewsList.TryGetValue(view,out Type viewType))
            {
                if (MainPage is FlyoutPage)
                {
                    if (MainPage is FlyoutPage flyOutPage)
                    {
                        var page = CreateNavigationPage(view);

                        if (parameter != null)
                        {
                            page.SetNavigationArguments(parameter);
                            (page.BindingContext as BaseViewModel)?.InitializeParameter(parameter);
                        }
                            

                        flyOutPage.Detail = page;
                    }
                }
                else
                {
                    var page = Activator.CreateInstance(viewType) as Page;

                    if (parameter != null)
                    {
                        page.SetNavigationArguments(parameter);
                        (page?.BindingContext as BaseViewModel)?.InitializeParameter(parameter);
                    }

                    await MainPage.Navigation.PushAsync(new NavigationPage(page));
                }
                
            }

        }

        //Navigate To Special View as Page
        public async void NavigateToPage(Type viewType, object parameter = null)
        {
            if (MainPage is FlyoutPage)
            {
                if (MainPage is FlyoutPage flyOutPage)
                {
                    var page = CreateNavigationPage(viewType);

                    if (parameter != null)
                    {
                        page.SetNavigationArguments(parameter);
                        (page.BindingContext as BaseViewModel)?.InitializeParameter(parameter);
                    }

                    flyOutPage.Detail = page;
                }
            }
            else
            {
                var page = Activator.CreateInstance(viewType) as Page;

                if (parameter != null)
                {
                    page.SetNavigationArguments(parameter);
                    (page?.BindingContext as BaseViewModel)?.InitializeParameter(parameter);
                }

                await MainPage.Navigation.PushAsync(new NavigationPage(page));
            }


            
        }



        //Navigate To Special View as Model
        public async void NavigateToModel(string view, object parameter = null)
        {
            if (ViewsList.TryGetValue(view, out Type viewType))
            {
                var page = Activator.CreateInstance(viewType) as Page;

                if (parameter != null)
                {
                    page.SetNavigationArguments(parameter);
                    (page?.BindingContext as BaseViewModel)?.InitializeParameter(parameter);
                }

                await MainPage.Navigation.PushModalAsync(page);
            }
        }

        //Navigate To Special View as Model
        public async void NavigateToModel(Type viewType, object parameter = null)
        {
            var page = Activator.CreateInstance(viewType) as Page;

            if (parameter != null)
            {
                page.SetNavigationArguments(parameter);
                (page?.BindingContext as BaseViewModel)?.InitializeParameter(parameter);
            }

            await MainPage.Navigation.PushModalAsync(page);
        }

        public Page CreatePage(Type type, object parameter = null)
        {
            return Activator.CreateInstance(type) as Page;
        }
        public Page CreatePage(string view, object parameter = null)
        {
            if (ViewsList.TryGetValue(view, out Type viewType))
            {
                return Activator.CreateInstance(viewType) as Page;
            }

            return null;
        }

        public NavigationPage CreateNavigationPage(Type type, object parameter = null)
        {

            return new NavigationPage(Activator.CreateInstance(type) as Page);
        }
        public NavigationPage CreateNavigationPage(string view, object parameter = null)
        {

            if (ViewsList.TryGetValue(view, out Type viewType))
            {
                return new NavigationPage(Activator.CreateInstance(viewType) as Page);
            }

            return null;
        }

    }
}
