﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismUnityApp1.ViewModels
{
    public class PrismNavigationPageViewModel : BindableBase, INavigationAware
    {
        private INavigationService _navigationService;
        public PrismNavigationPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {            
        }
    }
}
