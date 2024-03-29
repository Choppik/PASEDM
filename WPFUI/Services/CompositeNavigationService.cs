﻿using System.Collections.Generic;

namespace PASEDM.Services
{
    public class CompositeNavigationService : INavigationService
    {
        private readonly IEnumerable<INavigationService> _navigationService;

        public CompositeNavigationService(params INavigationService[] navigationService)
        {
            _navigationService = navigationService;
        }

        public void Navigate()
        {
            foreach (INavigationService navigationService in _navigationService)
            {
                navigationService.Navigate();
            }
        }
    }
}