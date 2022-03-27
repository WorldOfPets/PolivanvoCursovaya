using AppCurs.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppCurs.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public Command RegistrPageCommand { get; }
        public Command ShowPassword { get; }
        private string _password;
        private string _login;
        public string Password {
            get { return _password; }
            set { _password = value; OnPropertyChanged(); }
        }

        public string Login
        {
            get { return _login; }
            set { _login = value; OnPropertyChanged(); }
        }
        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            RegistrPageCommand = new Command(OnLinkClicked);
        }

        private async void ShowPassClicked(object obj)
        {
            var entry = obj as Entry;
            if (entry.IsPassword == true)
            {
                entry.IsPassword = false;
            }
            else{
                entry.IsPassword = true;
            }
        }

        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }

        private async void OnLinkClicked(object obj) 
        {
            await Shell.Current.GoToAsync($"//{nameof(RegistrationPage)}");
        }

    }
}
