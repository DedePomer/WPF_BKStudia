using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_BKStudia.Infrastructure.Navigation;
using WPF_BKStudia.ViewModel.Pages;


namespace WPF_BKStudia.ViewModel.Windows
{
    internal class MainWindowViewModel : ViewModel.Base.ViewModel
    {
        NavigationStore navigationStore = new NavigationStore();
        public ViewModel.Base.ViewModel? CurrentViewModel => navigationStore.CurrentViewModel;

        public MainWindowViewModel()
        {
            if (!Directory.Exists("Tests")) Directory.CreateDirectory("Tests");

            navigationStore.CurrentViewModel = new MenuPageViewModel(navigationStore);
            //navigationStore.CurrentViewModel = new CreateTestViewModel(navigationStore);
            navigationStore.CurrentViewModelChanged += () => OnCurrentViewChanged();
        }

        private void OnCurrentViewChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
