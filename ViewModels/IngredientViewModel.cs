using BreadyToomy.Models;
using BreadyToomys.Services;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace BreadyToomy.ViewModels
{
    public class IngredientViewModel : BaseViewModel
    {
        public ObservableCollection<Ingredient> Items { get; set; } = new ObservableCollection<Ingredient>();
        private HashSet<Ingredient> _editedIngredients = new HashSet<Ingredient>();
        private Collection<Ingredient> _addedIngredients = new Collection<Ingredient>();

        public RelayCommand SaveIngredientCommand => new RelayCommand(execute => SaveItem(), canExecute => CanSave()); // Unlock le bouton save si une modification est apporté (canExecute)
        public RelayCommand ReloadIngredientCommand => new RelayCommand(execute => RefreshItems(), canExecute => true); // Unlock le bouton save si une modification est apporté (canExecute)

        public IngredientViewModel()
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

        private bool CanSave()
        {
            return _editedIngredients.Count > 0 || _addedIngredients.Count > 0;
        }

        private void SaveItem()
        {
            if (_editedIngredients.Count > 0)
            {
                // delete if items found 2 times in _editedIngredients.

                foreach (Ingredient item in _editedIngredients)
                {
                    Database db = Database.GetInstance();
                    db.queryWithValues("UPDATE ingredient SET name = @0, quantity = @1, archived = @2 WHERE id = @3", new object[] { item.Name, item.Quantity, item.Archived, item.Id });
                    db.close();
                }
            }
            
            if (_addedIngredients.Count > 0)
            {
                foreach (Ingredient item in _addedIngredients)
                {
                    Database db = Database.GetInstance();
                    db.queryWithValues("INSERT INTO ingredient (name, quantity, archived) VALUES (@0, @1, @2)", new object[] { item.Name, item.Quantity, item.Archived });
                    db.close();
                }
            }
        }

        internal void AddItem(Ingredient item)
        {
            Items.Add(item);
            _addedIngredients.Add(item);
        }
    }
}
