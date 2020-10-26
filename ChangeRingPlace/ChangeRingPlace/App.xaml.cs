using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ChangeRingPlace.Services;
using ChangeRingPlace.Views;
using Prism.Unity;
using Prism.Ioc;
using Prism;
using ChangeRingPlace.ViewModels;
using ChangeRingPlace.Views.Welcome;
using ChangeRingPlace.ViewModels.Welcome;
using ChangeRingPlace.Services.Abstractions;
using Prism.Navigation;
using System.Threading.Tasks;

namespace ChangeRingPlace
{
    public partial class App: PrismApplication
    {
        IStorageService _PreferencesService;
        public App() : base(null) { }
        public App(IPlatformInitializer initializer = null) : base(initializer, setFormsDependencyResolver: true)
        {
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register Services
            containerRegistry.RegisterSingleton<IStorageService, PreferencesService>();

            // Register Navigation Pages + ViewModels
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<WelcomePage, WelcomePageViewModel>();

        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            
            await SetMainPageAsync();
        }
        
        private async Task SetMainPageAsync()
        {
            _PreferencesService = Container.Resolve<IStorageService>();
            var isFirstTimeLaunched = await _PreferencesService.GetAsync<bool>(AppSettings.IsFirstTimeAppLaunched, AppSettings.IsFirstTimeAppLaunchedDefaultValue);
            
            INavigationResult result = null;
            if (isFirstTimeLaunched)
            {
                await _PreferencesService.SaveAsync(AppSettings.IsFirstTimeAppLaunched, false);
                result = await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(WelcomePage)}");
            }
            else
            {
                result = await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(HomePage)}");
            }

            if (!result.Success)
            {
                SetMainPageFromException(result.Exception);
            }
        }
        

        private void SetMainPageFromException(Exception ex)
        {
            var layout = new StackLayout
            {
                Padding = new Thickness(40)
            };
            layout.Children.Add(new Label
            {
                Text = ex?.GetType()?.Name ?? "Unknown Error encountered",
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            });

            layout.Children.Add(new ScrollView
            {
                Content = new Label
                {
                    Text = $"{ex}",
                    LineBreakMode = LineBreakMode.WordWrap
                }
            });

            MainPage = new ContentPage
            {
                Content = layout
            };
        }
    }
}

