using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_BKStudia.Infrastructure.Commands;
using WPF_BKStudia.Infrastructure.Navigation;

namespace WPF_BKStudia.ViewModel.Pages
{
    internal class GetTesttedMenuViewModel: ViewModel.Base.ViewModel
    {
        //Навигационные команды
        public ICommand CNavigateMenuPageViewModel { get; }

        public GetTesttedMenuViewModel(NavigationStore navigationStore)
        {
            CNavigateMenuPageViewModel = new NavigationCommand<MenuPageViewModel>(navigationStore, () => new MenuPageViewModel(navigationStore));

        }
    }
}
