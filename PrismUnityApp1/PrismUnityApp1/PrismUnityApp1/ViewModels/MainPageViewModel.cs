using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PrismUnityApp1.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        private INavigationService _navigationService;

        public DelegateCommand Esegui { get; set; }

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Esegui = new DelegateCommand(Navigate);
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            //_navigationService.NavigateAsync("PrismMasterDetailPage");            
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";           
        }

        void Navigate()
        {
            _navigationService.NavigateAsync("PrismMasterDetailPage");
        }
    }
}
