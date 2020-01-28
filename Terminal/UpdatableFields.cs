using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace Terminal
{
    class UpdatableFields : INotifyPropertyChanged
    {
        private string errorString = "";
        public string ErrorString
        {
            get { return errorString; }
            set
            {
                if(errorString.Equals(value))
                {
                    return;
                }
                errorString = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        
        private void OnPropertyChanged([CallerMemberName] string PropertyName = "")
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
