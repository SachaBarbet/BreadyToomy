using BreadyToomy.Models;
using BreadyToomys.Services;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BreadyToomy.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        public ObservableCollection<Product> Items { get; set; } = new ObservableCollection<Product>();
        private HashSet<Product> _editedProducts = new HashSet<Product>();
        private Collection<Product> _addedProducts = new Collection<Product>();

        public string[] ProductTypeList = new string[] { "MEAL", "DESSERT", "DRINK", "MENU" }; // Liste des types de produits pour le combobox dans la vue
        public string ComboBoxSelectedValue { get; set; } // Valeur sélectionnée dans le combobox

        public RelayCommand DeleteCommand => new RelayCommand(execute => DeleteItem(), canExecute => SelectedItem != null); // Unlock le bouton delete si un item est sélectionné (canExecute)
        public RelayCommand SaveCommand => new RelayCommand(execute => SaveItem(), canExecute => CanSave()); // Unlock le bouton save si une modification est apporté (canExecute)

        public ProductViewModel()
        {
            RefreshItems();
        }

        private Product _selectedItem;

        public Product SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                _editedProducts.Add(value);
                OnPropertyChanged();
            }
        }

        private void RefreshItems()
        {
            Database database = Database.GetInstance();
            Items.Clear();
            _editedProducts.Clear();
            _addedProducts.Clear();
            NpgsqlDataReader result = database.query("SELECT id, name, description, type, price, archived FROM product").ExecuteReader();
            while (result.Read())
            {
                Items.Add(new Product
                {
                    Id = result.GetInt32(0),
                    Name = result.GetString(1),
                    Description = result.GetString(2),
                    Type = result.GetString(3),
                    Price = result.GetDecimal(4),
                    Archived = result.GetBoolean(5),
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
            return _editedProducts.Count > 0 || _addedProducts.Count > 0;
        }

        private void SaveItem()
        {
            foreach (Product item in _editedProducts)
            {
                Database db = Database.GetInstance();
                db.queryWithValues("UPDATE product SET name = @0, description = @1, type = @2, price = @3, archived = @4 WHERE id = @5", new object[] { item.Name, item.Description, item.Type, item.Price, item.Archived, item.Id });
                db.close();
            }

            foreach (Product item in _addedProducts)
            {
                Database db = Database.GetInstance();
                db.queryWithValues("INSERT INTO product (name, description, type, price, archived) VALUES (@0, @1, @2, @3, @4)", new object[] { item.Name, item.Description, item.Type, item.Price, item.Archived });
                db.close();
            }
        }

        internal void AddItem(Product item)
        {
            _addedProducts.Add(item);
            Items.Add(item);
        }
    }
}
