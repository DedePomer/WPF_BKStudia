﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_BKStudia.ViewModel.Base;


namespace WPF_BKStudia.Infrastructure.Navigation
{
    internal class NavigationStore
    {
        //?
        public event Action CurrentViewModelChanged;

        //Здесь хранится текущаяя ViewModel
        private ViewModel.Base.ViewModel? _currentViewModel;
        public ViewModel.Base.ViewModel? CurrentViewModel 
        {             
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        //?
        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}