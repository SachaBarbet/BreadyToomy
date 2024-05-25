using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BreadyToomy.Models
{
    public class OrderProduct : INotifyPropertyChanged
    {
        private int _orderId;
        private int _productId;
        private int _quantity;
        private bool _archived;



        public int OrderId
        {
            get => _orderId;
            set
            {
                _orderId = value;
                OnPropertyChanged();
            }
        }

        public int ProductId
        {
            get => _productId;
            set
            {
                _productId = value;
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

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
