using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BreadyToomy.Models
{
    public class RecipeStep : INotifyPropertyChanged
    {
        private int _id;
        private int _recipeId;
        private int _index;
        private string _stepDetails;
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

        public int RecipeId
        {
            get => _recipeId;
            set
            {
                _recipeId = value;
                OnPropertyChanged();
            }
        }

        public int Index
        {
            get => _index;
            set
            {
                _index = value;
                OnPropertyChanged();
            }
        }

        public string StepDetails
        {
            get => _stepDetails;
            set
            {
                _stepDetails = value;
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
