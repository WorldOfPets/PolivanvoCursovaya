using AppCurs.Models;
using AppCurs.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppCurs.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private Item _selectedItem;

        public ObservableCollection<Item> Items { get; }
        public ObservableCollection<Item> ItemsComplate { get; }
        public ObservableCollection<Item> ItemsJustDoIt { get; }
        public Command LoadItemsCommand { get; }
        public Command LoadItemsCommandUnComplate { get; }
        public Command LoadItemsCommandJustDoIt { get; }
        public Command AddItemCommand { get; }
        public Command<Item> ItemTapped { get; }

        public ItemsViewModel()
        {
            Items = new ObservableCollection<Item>();
            ItemsComplate = new ObservableCollection<Item>();
            ItemsJustDoIt = new ObservableCollection<Item>();

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            LoadItemsCommandUnComplate = new Command(async () => await ExecuteLoadItemsCommandUnComplate());
            LoadItemsCommandJustDoIt = new Command(async () => await ExecuteLoadItemsCommandJustDoIt());
            
            ItemTapped = new Command<Item>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        async Task ExecuteLoadItemsCommandUnComplate()
        {
            IsBusy = true;

            try
            {
                ItemsComplate.Clear();
                var items = await DataStore.GetItemComlateAsync(true);
                foreach (var item in items)
                {
                    ItemsComplate.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        async Task ExecuteLoadItemsCommandJustDoIt()
        {
            IsBusy = true;

            try
            {
                ItemsJustDoIt.Clear();
                var items = await DataStore.GetItemJustDoItAsync(true);
                foreach (var item in items)
                {
                    ItemsJustDoIt.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Item SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnItemSelected(Item item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }
    }
}