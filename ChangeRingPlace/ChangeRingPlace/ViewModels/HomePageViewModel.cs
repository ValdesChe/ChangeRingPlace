using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prism.Mvvm;
using ChangeRingPlace.ViewModels.Base;
using Prism.Navigation;
using ChangeRingPlace.Services.Abstractions;

namespace ChangeRingPlace.ViewModels
{
    public class HomePageViewModel: BaseViewModel, INavigatedAware
    {

        public HomePageViewModel(INavigationService navigationService): base(navigationService)
        {
        }

        #region Navigation

        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {

        }
        #endregion

        #region Properties


        #endregion
    }
}
