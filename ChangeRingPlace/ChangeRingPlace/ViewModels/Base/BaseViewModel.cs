using Prism.Mvvm;
using Prism.Navigation;

namespace ChangeRingPlace.ViewModels.Base
{
    public abstract class BaseViewModel: BindableBase
    {
        protected INavigationService _NavigationService { get; private set; }

        bool isBusy = false;
        string title = string.Empty;

        public BaseViewModel(INavigationService navigationService = null)
        {
            _NavigationService = navigationService;
        }


        #region Properties
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
        #endregion

    }
}
