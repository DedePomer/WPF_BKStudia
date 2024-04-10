using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_BKStudia.Infrastructure.Navigation;


namespace WPF_BKStudia.ViewModel.Windows
{
    internal class MainWindowViewModel : ViewModel.Base.ViewModel
    {
        NavigationStore navigationStore = new NavigationStore();
        public ViewModel.Base.ViewModel? CurrentViewModel => navigationStore.CurrentViewModel;

        public MainWindowViewModel()
        {
            //navigationStore.CurrentViewModel = new MenuPageViewModel(navigationStore);
            navigationStore.CurrentViewModelChanged += () => OnCurrentViewChanged();
        }

        private void OnCurrentViewChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
