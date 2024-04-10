using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF_BKStudia.Infrastructure.Commands;
using WPF_BKStudia.Infrastructure.Navigation;

namespace WPF_BKStudia.ViewModel.Pages
{
    internal class MenuPageViewModel: ViewModel.Base.ViewModel
    {
        public ICommand CCloseApp { get;  }
        private bool CanCCloseAppExecuted(object p) => true;
        private void OnCCloseAppExecuted(object p)
        { 
            Application.Current.Shutdown();
        }


        public MenuPageViewModel(NavigationStore navigationStore)  
        {
            //CNavigateGetTesttedMenuPage = new NavigationCommand<>
            CCloseApp = new LamdaCommand(OnCCloseAppExecuted, CanCCloseAppExecuted);
        }
    }
}
