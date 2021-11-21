using System;
using Xamarin.Forms;

namespace TutorialsXamarin.Interfaces
{
    public interface INavigationService
    {
        /// <summary>
        /// Main Page For Application
        /// </summary>
        Page MainPage { get; }


        /// <summary>
        /// Insert View inside Views List
        /// </summary>
        /// <param name="view"></param>
        /// <param name="type"></param>
        void Register(string view, Type type);


        /// <summary>
        /// Go Back To Previous View
        /// </summary>
        void GoBack();


        /// <summary>
        /// Navigate To Special View as Page
        /// </summary>
        /// <param name="view"></param>
        /// <param name="parameter"></param>
        void NavigateToPage(string view, object parameter = null);


        /// <summary>
        /// Navigate To Special View as Page
        /// </summary>
        /// <param name="type"></param>
        /// <param name="parameter"></param>
        void NavigateToPage(Type type, object parameter = null);


        /// <summary>
        /// Navigate To Special View as Model
        /// </summary>
        /// <param name="view"></param>
        /// <param name="parameter"></param>
        void NavigateToModel(string view, object parameter = null);

        /// <summary>
        /// Navigate To Special View as Model
        /// </summary>
        /// <param name="type"></param>
        /// <param name="parameter"></param>
        void NavigateToModel(Type type, object parameter = null);

        /// <summary>
        /// Create Page Instance From Page Type
        /// </summary>
        /// <param name="type"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        Page CreatePage(Type type, object parameter = null);

        /// <summary>
        /// Create Page Instance From Page Name
        /// </summary>
        /// <param name="view"></param>
        /// <param name="parameter"></param>
        Page CreatePage(string view, object parameter = null);


        /// <summary>
        /// Create Navigation Page Instance From Page Type
        /// </summary>
        /// <param name="type"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        NavigationPage CreateNavigationPage(Type type, object parameter = null);

        /// <summary>
        /// Create Navigation Page Instance From Page Name
        /// </summary>
        /// <param name="view"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        NavigationPage CreateNavigationPage(string view, object parameter = null);
    }
}