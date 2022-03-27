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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            var sw = sender as Switch;
            if (sw.IsToggled == false)
            {
                EPass.IsPassword = true;
            }
            else
            {
                EPass.IsPassword = false;
            }
        }
    }
}