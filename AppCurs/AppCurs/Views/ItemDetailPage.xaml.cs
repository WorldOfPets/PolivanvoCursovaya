using AppCurs.Models;
using AppCurs.Services;
using AppCurs.ViewModels;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace AppCurs.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();
        public ObservableCollection<Item> Items { get; }
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
            
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            var items = await DataStore.GetItemsAsync(true);
            string delete = "";
            foreach (var item in items)
            {
                if (item.Text == NameLabel.Text && item.Description == DescriptionLabel.Text)
                {
                    await DataStore.AddItemComplateAsync(item);
                    delete = item.Id;
                    //await DataStore.DeleteItemAsync(item.Id);
                    //await Navigation.PushAsync(new AboutPage());
                }
                //Items.Add(item);
            }
            await DataStore.DeleteItemAsync(delete);
            await Navigation.PushAsync(new ItemsPage());
            //await DisplayAlert($"{(sender as Button)}", "", "asdf");
        }
    }
}