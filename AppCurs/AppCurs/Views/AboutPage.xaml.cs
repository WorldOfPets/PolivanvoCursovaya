using AppCurs.Models;
using AppCurs.Services;
using AppCurs.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCurs.Views
{
    public partial class AboutPage : ContentPage
    {
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();
        public AboutPage()
        {
            InitializeComponent();
            BindingContext = new AboutViewModel();
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var newStep = Math.Round(e.NewValue / 1);
            var slider = sender as Slider;
            slider.Value = newStep * 1;
            LSilderValue.Text = slider.Value.ToString();
        }

        private void BtnEveryDay_Clicked(object sender, EventArgs e)
        {
            BtnEveryDay.IsEnabled = false;
            BtnOnlyOne.IsEnabled = true;
            FrmDatePicker.IsVisible = false;
        }

        private void BtnOnlyOne_Clicked(object sender, EventArgs e)
        {
            BtnEveryDay.IsEnabled = true;
            BtnOnlyOne.IsEnabled = false;
            FrmDatePicker.IsVisible = true;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Text = ELogin.Text,
                Description = Descript.Text
            };

            await DataStore.AddItemAsync(newItem);
            await Navigation.PushAsync(new ItemsPage());
        }
    }
}