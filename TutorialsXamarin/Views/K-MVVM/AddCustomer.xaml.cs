using TutorialsXamarin.Utilities;
using TutorialsXamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TutorialsXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCustomer : ContentPage
    {
        public AddCustomer(IMessagingCenter messagingService)
        {
            InitializeComponent();

            messagingService.Subscribe<MvvmViewModel,string>(this,MessagesNames.Notification, (sender,args) =>
            {
                LblContent.Text = args;
            });
        }
        
    }
}