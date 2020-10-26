using ChangeRingPlace.ViewModels.Base;
using Prism.Navigation;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ChangeRingPlace.ViewModels.Welcome
{
    public class WelcomePageViewModel: BaseViewModel
    {
        public WelcomePageViewModel(INavigationService navigationService = null): base(navigationService)
        {
            Title = "Welcome Page";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://xamarin.com"));
        }

        public ICommand OpenWebCommand { get; }
    }
}