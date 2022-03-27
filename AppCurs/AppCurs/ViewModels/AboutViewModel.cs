using AppCurs.Models;
using AppCurs.Views;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppCurs.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        private string text;
        private string description;
        public AboutViewModel()
        {
            Title = "About";
            //OpenWebCommand = new Command(OnSave);
        }

        public ICommand OpenWebCommand { get; }
        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }
        private async void OnSave()
        {
            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Text = Text,
                Description = Description
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemsPage)}");
        }
    }
}