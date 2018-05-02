using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace bbs.AppTemplate.Services
{
    public abstract class DbTableService : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name)); }
        protected void SetValue<T>(T backField, T newValue, [CallerMemberName] string name = null)
        {
            if (EqualityComparer<T>.Default.Equals(backField, newValue))
                return;

            backField = newValue;
            OnPropertyChanged(name);
        }

        public abstract int GetID();
    }
}
