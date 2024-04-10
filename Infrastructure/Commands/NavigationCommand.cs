using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_BKStudia.Infrastructure.Commands.Base;
using WPF_BKStudia.Infrastructure.Navigation;
using WPF_BKStudia.ViewModel.Base;


namespace WPF_BKStudia.Infrastructure.Commands
{
    internal class NavigationCommand<VM> : Command where VM : ViewModel.Base.ViewModel
    {
        private NavigationStore _navigationStore;
        private readonly Func<VM> _createViewModel;

        public NavigationCommand(NavigationStore navigationStore, Func<VM> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}

