using System.Collections.ObjectModel;
using TutorialsXamarin.Business.Models;

namespace TutorialsXamarin.ViewModels
{
    public class FirstPageViewModel : BaseViewModel
    {
        public ObservableCollection<Pie> Pies { get; set; }

        private string _message;
        public string Message
        {
            get => _message; 
            set
            {
                if (_message != value)
                {
                    _message = value;
                    OnPropertyChanged();
                }
                
            }
        }

    }
}
