using AppCurs.Models;
using AppCurs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCurs.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SkillUpPage : ContentPage
    {
        ItemsViewModel _viewModel;
        public SkillUpPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ItemsViewModel();
            JustDoItList.Command.Execute(BindingContext);
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            //var collectionView = sender as CollectionView;
            var s = sender as StackLayout;
            var f = s.Children.First() as Frame;
            var g = f.Children.First() as Grid;
            var l = g.Children.First() as Label;
            //await DisplayAlert($"{l.Text}", "StackLayout", "asdf");

            await Navigation.PushAsync(new ArticlePage(l.Text));
        }
    }
}