using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MetaWeather.Common
{
    public class BindableBase : INotifyPropertyChanged, IChangeTracking
    {
        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return false;
            }
            else
            {
                storage = value;
                RaisePropertyChanged(propertyName);
                IsChanged = true;
                return true;
            }
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            PropertyChanged?.Invoke(this, args);
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region IChangeTracking Members
        public bool IsChanged { get; protected set; }

        public void AcceptChanges() => IsChanged = false;
        #endregion
    }
}
