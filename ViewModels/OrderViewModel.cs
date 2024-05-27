
﻿using BreadyToomy.Models;
using BreadyToomy.Services;
using BreadyToomys.Services;
using Npgsql;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace BreadyToomy.ViewModels


{
    public class OrderViewModel : BaseViewModel
    {
        public ObservableCollection<Order> Items { get; set; } = new ObservableCollection<Order>();
        public ObservableCollection<int> OrderNumbers { get; set; } = new ObservableCollection<int>(); 

        private HashSet<Order> _editedOrders = new HashSet<Order>();
        private Collection<Order> _addedOrders = new Collection<Order>();

        public RelayCommand SaveCommand => new RelayCommand(execute => SaveItem(), canExecute => CanSave());

        public OrderViewModel()
        {
            RefreshItems();
            FetchOrderNumbers(); 
        }

        private Order _selectedItem;

        public Order SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                _editedOrders.Add(value);
                OnPropertyChanged();
            }
        }

        private int _selectedOrderNumber;
        public int SelectedOrderNumber
        {
            get => _selectedOrderNumber;
            set
            {
                _selectedOrderNumber = value;
                OnPropertyChanged();
            }
        }

        private void RefreshItems()
        {
            Database database = Database.GetInstance();
            Items.Clear();
            _editedOrders.Clear();
            _addedOrders.Clear();
            NpgsqlDataReader result = database.query("SELECT id, number, type, state FROM \"Order\"").ExecuteReader();
            while (result.Read())
            {
                Items.Add(new Order
                {
                    Id = result.GetInt32(0),
                    Number = result.GetInt32(1),
                    Type = result.GetString(2),
                    State = result.GetString(3),
                });
            }
            database.close();
        }

        private void FetchOrderNumbers()
        {
            Database database = Database.GetInstance();
            OrderNumbers.Clear();
            NpgsqlDataReader result = database.query("SELECT number FROM \"Order\"").ExecuteReader();
            while (result.Read())
            {
                OrderNumbers.Add(result.GetInt32(0));
            }
            database.close();
        }

        private bool CanSave()
        {
            return _editedOrders.Count > 0 || _addedOrders.Count > 0;
        }

        private void SaveItem()
        {
            if (_editedOrders.Count > 0)
            {
                foreach (Order item in _editedOrders)
                {
                    Database db = Database.GetInstance();
                    db.queryWithValues("UPDATE \"Order\" SET number = @0, type = @1, state = @2 WHERE id = @3", new object[] { item.Number, item.Type, item.State, item.Id });
                    db.close();
                }
            }

            if (_addedOrders.Count > 0)
            {
                foreach (Order item in _addedOrders)
                {
                    Database db = Database.GetInstance();
                    db.queryWithValues("INSERT INTO \"Order\" (number, type, state) VALUES (@0, @1, @2)", new object[] { item.Number, item.Type, item.State });
                    db.close();
                }
            }
        }

        internal void AddItem(Order item)
        {
            Items.Add(item);
            _addedOrders.Add(item);
        }
    }
}
