using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorialsXamarin.Extensions;
using TutorialsXamarin.Utilities;
using TutorialsXamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TutorialsXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCustomer : ContentPage
    {
        public AddCustomer()
        {
            InitializeComponent();

            App.MessagingService.Subscribe<MvvmViewModel,string>(this,MessagesNames.Notification, (sender,args) =>
            {
                LblContent.Text = args;
            });
        }
        
    }
}