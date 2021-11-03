using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorialsXamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TutorialsXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CommandBindingPage : ContentPage
    {
        public CommandBindingPage()
        {
            InitializeComponent();
            BindingContext = new CommandsViewModel();
        }
    }
}