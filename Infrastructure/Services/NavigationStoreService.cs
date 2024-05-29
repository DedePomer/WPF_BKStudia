using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_BKStudia.Infrastructure.Interfaces;
using WPF_BKStudia.ViewModel.Base;


namespace WPF_BKStudia.Infrastructure.Services
{
    internal class NavigationStoreService : INavigationStoreService
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
        public object Param { get; set; }

        //?
        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
