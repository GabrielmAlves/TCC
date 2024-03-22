using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PlayerClassifier.WPF.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged; //avisa binding clients que uma property mudou e os valores precisam ser reavaliados

        public void OnPropertyChanged (string propertyName) //cria o evento quando uma property mudou
        {
            PropertyChanged?.Invoke (this, new PropertyChangedEventArgs (propertyName));
        }
    }
}
