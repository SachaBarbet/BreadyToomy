using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BreadyToomy.Models
{
    public class Ingredient : INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private int _quantity;
        private bool _archived;

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public bool Archived
        {
            get => _archived;
            set
            {
                _archived = value;
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
