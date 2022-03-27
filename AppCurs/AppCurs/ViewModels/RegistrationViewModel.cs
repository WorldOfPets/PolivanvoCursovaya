using AppCurs.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppCurs.ViewModels
{
    public class RegistrationViewModel : BaseViewModel
    {
        public Command LinkToAuthorization { get; }
        public RegistrationViewModel()
        {
            LinkToAuthorization = new Command(GoToPageClicked);
        }

        private async void GoToPageClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }

    }
}
