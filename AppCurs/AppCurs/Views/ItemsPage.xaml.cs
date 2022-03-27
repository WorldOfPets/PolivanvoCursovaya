using AppCurs.Models;
using AppCurs.ViewModels;
using AppCurs.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCurs.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
            ComplateList.Command.Execute(BindingContext);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
        private int _count = 3;
        private async void Button_Clicked(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var grid = btn.Parent as Grid;
            //var star1 = grid.Children[0] as Image;
            var star2 = grid.Children[1] as Image;
            var star3 = grid.Children[2] as Image;
            if (star2.IsVisible == true && star3.IsVisible == true)
            {
                star2.IsVisible = false;
                star3.IsVisible = false;
                _count = 1;
            }
            else if (star2.IsVisible == false && star3.IsVisible == false)
            {
                star2.IsVisible = true;
                _count = 2;
            }
            else if (star2.IsVisible == true && star3.IsVisible == false)
            {
                star3.IsVisible = true;
                _count = 3;
            }
        }
    }
}