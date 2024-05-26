using BreadyToomy.Models;
using BreadyToomys.Services;
using Npgsql;
using System;
using System.Collections.ObjectModel;

namespace BreadyToomy.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        public ObservableCollection<Ingredient> Items { get; set; } = new ObservableCollection<Ingredient>();
        private Collection<Ingredient> _deletedIngredients = new Collection<Ingredient>();
        private Collection<Ingredient> _editedIngredients = new Collection<Ingredient>();
        private Collection<Ingredient> _addedIngredients = new Collection<Ingredient>();

        public RelayCommand DeleteCommand => new RelayCommand(execute => DeleteItem(), canExecute => SelectedItem != null); // Unlock le bouton delete si un item est sélectionné (canExecute)
        public RelayCommand SaveCommand => new RelayCommand(execute => SaveItem(), canExecute => CanSave()); // Unlock le bouton save si une modification est apporté (canExecute)

        public ProductViewModel()
        {
            RefreshItems();
        }

        private Ingredient _selectedItem;

        public Ingredient SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                _editedIngredients.Add(value);
                OnPropertyChanged();
            }
        }

        private void RefreshItems()
        {
            Database database = Database.GetInstance();
            Items.Clear();
            _editedIngredients.Clear();
            _deletedIngredients.Clear();
            _addedIngredients.Clear();
            NpgsqlDataReader result = database.query("SELECT id, name, quantity, archived FROM ingredient").ExecuteReader();
            while (result.Read())
            {
                Items.Add(new Ingredient
                {
                    Id = result.GetInt32(0),
                    Name = result.GetString(1),
                    Quantity = result.GetInt32(2),
                    Archived = result.GetBoolean(3),
                });
            }
            database.close();
        }

        private void DeleteItem()
        {
            Items.Remove(SelectedItem);
        }

        private bool CanSave()
        {
            return _editedIngredients.Count > 0 || _deletedIngredients.Count > 0 || _addedIngredients.Count > 0;
        }

        private void SaveItem()
        {
            foreach (Ingredient item in _deletedIngredients)
            {
                Database db = Database.GetInstance();
                db.queryWithValues("DELETE FROM ingredient WHERE id = @0", new object[] { item.Id });
                db.close();
            }

            foreach (Ingredient item in _editedIngredients)
            {
                Database db = Database.GetInstance();
                db.queryWithValues("UPDATE ingredient SET name = @0, quantity = @1, archived = @2 WHERE id = @3", new object[] { item.Name, item.Quantity, item.Archived, item.Id });
                db.close();
            }

            foreach (Ingredient item in _addedIngredients)
            {
                Database db = Database.GetInstance();
                db.queryWithValues("INSERT INTO ingredient (name, quantity, archived) VALUES (@0, @1, @2)", new object[] { item.Name, item.Quantity, item.Archived });
                db.close();
            }
        }

        internal void AddItem()
        {
            throw new NotImplementedException();
        }
    }
}
