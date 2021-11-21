using TutorialsXamarin.Utilities;
using TutorialsXamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TutorialsXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewCustomer : ContentPage
    {
        public ViewCustomer()
        {
            InitializeComponent();

            App.MessagingService.Subscribe<MvvmViewModel, string>(this, MessagesNames.Notification, (sender, args) =>
            {
                LblContent.Text = args;
            });
        }
    }
}