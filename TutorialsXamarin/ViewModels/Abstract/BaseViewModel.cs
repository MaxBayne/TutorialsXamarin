using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TutorialsXamarin.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region INotifyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Parameters

        public virtual void InitializeParameter(object parameter) {}

        #endregion
    }
}
