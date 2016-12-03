using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismUnityApp1.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace PrismUnityApp1.ViewModels
{
    public class PrismMasterDetailPageViewModel : BindableBase, INavigationAware
    {
        INavigationService _navigationService;
        //public BindableBase CurrentViewModel { get; set; }
        public DelegateCommand<string> NavigateCommand { get; set; }
        public ContentPage CurrentPage { get; set; }
        public PrismMasterDetailPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;            
            NavigateCommand = new DelegateCommand<string>(Navigate);
                        
        }
        private void Navigate(string name)
        {
            _navigationService.NavigateAsync(name);
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }
    }
}
