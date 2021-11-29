using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TutorialsXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShellPage : ContentPage
    {
        public ShellPage()
        {
            InitializeComponent();
        }

        public ICommand ShellDetailCommand;
    }
}