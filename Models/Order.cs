using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BreadyToomy.Models
{
    public class Order : INotifyPropertyChanged
    {
        private int _id;
        private int _number;
        private string _type;
        private string _state;



        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        public int Number
        {
            get => _number;
            set
            {
                _number = value;
                OnPropertyChanged();
            }
        }

        public string Type
        {
            get => _type;
            set
            {
                _type = value;
                OnPropertyChanged();
            }
        }

        public string State
        {
            get => _state;
            set
            {
                _state = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
