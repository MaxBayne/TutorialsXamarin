using System;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace TutorialsXamarin.Extensions
{
    public static class NavigationExtensions
    {
        public static ConditionalWeakTable<Page, Object> Arguments = new ConditionalWeakTable<Page, object>();

        public static object GetNavigationArguments(this Page page)
        {
            Arguments.TryGetValue(page, out var args);

            return args;
        }

        public static void SetNavigationArguments(this Page page, object args) => Arguments.Add(page, args);

    }
}
