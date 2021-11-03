using System.Collections.ObjectModel;
using TutorialsXamarin.Common.Models;

namespace TutorialsXamarin.ViewModels
{
    public class PieListViewModel : BaseViewModel
    {

        public ObservableCollection<Pie> Pies { get; set; }

        private Pie _selecedItem;
        public Pie SelectedItem
        {
            get => _selecedItem; 
            set
            {
                if (_selecedItem != value)
                {
                    _selecedItem = value;
                    OnPropertyChanged();
                }
            }
        }

    }
}
