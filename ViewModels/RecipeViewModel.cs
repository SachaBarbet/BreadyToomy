using BreadyToomy.Models;
using BreadyToomys.Services;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace BreadyToomy.ViewModels
{
    public class RecipeViewModel : BaseViewModel
    {
        public ObservableCollection<Recipe> Items { get; set; } = new ObservableCollection<Recipe>();
        public ObservableCollection<int> RecipeIds { get; set; } = new ObservableCollection<int>(); 

        private HashSet<Recipe> _editedRecipes = new HashSet<Recipe>();
        private Collection<Recipe> _addedRecipes = new Collection<Recipe>();

        public RelayCommand SaveCommand => new RelayCommand(execute => SaveItem(), canExecute => CanSave()); 

        public RecipeViewModel()
        {
            RefreshItems();
            FetchRecipeIds(); 
        }

        private Recipe _selectedItem;

        public Recipe SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                _editedRecipes.Add(value);
                OnPropertyChanged();
            }
        }

        private void RefreshItems()
        {
            Database database = Database.GetInstance();
            Items.Clear();
            _editedRecipes.Clear();
            _addedRecipes.Clear();
            NpgsqlDataReader result = database.query("SELECT id, difficulty, cook_time, archived FROM recipe").ExecuteReader();
            while (result.Read())
            {
                Items.Add(new Recipe
                {
                    Id = result.GetInt32(0),
                    Difficulty = result.GetString(1),
                    CookTime = result.GetInt32(2),
                    Archived = result.GetBoolean(3),
                });
            }
            database.close();
        }

        private void FetchRecipeIds()
        {
            Database database = Database.GetInstance();
            RecipeIds.Clear();
            NpgsqlDataReader result = database.query("SELECT id FROM recipe").ExecuteReader();
            while (result.Read())
            {
                RecipeIds.Add(result.GetInt32(0));
            }
            database.close();
        }

        private bool CanSave()
        {
            return _editedRecipes.Count > 0 || _addedRecipes.Count > 0;
        }

        private void SaveItem()
        {
            if (_editedRecipes.Count > 0)
            {
                foreach (Recipe item in _editedRecipes)
                {
                    Database db = Database.GetInstance();
                    db.queryWithValues("UPDATE recipe SET difficulty = @0, cook_time = @1, archived = @2 WHERE id = @3", new object[] { item.Difficulty, item.CookTime, item.Archived, item.Id });
                    db.close();
                }
            }
            
            if (_addedRecipes.Count > 0)
            {
                foreach (Recipe item in _addedRecipes)
                {
                    Database db = Database.GetInstance();
                    db.queryWithValues("INSERT INTO recipe (difficulty, cook_time, archived) VALUES (@0, @1, @2)", new object[] { item.Difficulty, item.CookTime, item.Archived });
                    db.close();
                }
            }
        }

        internal void AddItem(Recipe item)
        {
            Items.Add(item);
            _addedRecipes.Add(item);
        }
    }
}
