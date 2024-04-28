using System;
using System.Collections.Generic;
using System.IO;
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
        //Навигационные команды
        public ICommand NavigateGetTesttedMenuCommand { get; }
        public ICommand NavigateDeleteTestCommand { get; }
        public ICommand NavigateCreateTestCommand { get; }

        //Функциональные команды
        public ICommand CCloseApp { get;  }
        private bool CanCCloseAppExecuted(object p) => true;
        private void OnCCloseAppExecuted(object p)
        { 
            Application.Current.Shutdown();
        }


        public MenuPageViewModel(NavigationStore navigationStore)  
        {
            NavigateGetTesttedMenuCommand = new NavigationCommand<GetTesttedMenuViewModel>(navigationStore, () => new GetTesttedMenuViewModel(navigationStore));
            NavigateDeleteTestCommand = new NavigationCommand<DeleteTestViewModel>(navigationStore, () => new DeleteTestViewModel(navigationStore));
            NavigateCreateTestCommand = new NavigationCommand<CreateTestViewModel>(navigationStore, () => new CreateTestViewModel(navigationStore));

            CCloseApp = new LamdaCommand(OnCCloseAppExecuted, CanCCloseAppExecuted);
        }

        //Проверяет пуста ли пака Tests
        private void IsNotNullDirectory(string path)
        {
            if (Directory.GetFileSystemEntries(path).ToList().Count == 0)
            {
                MessageBoxResult result = MessageBox.Show("В папке Tests нет тестов. Хотите создать тест ? (нажмите Да)", "Information", MessageBoxButton.YesNo, MessageBoxImage.Information);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        NavigateCreateTestViewModelCommand.Execute(1);
                        break;
                    case MessageBoxResult.No:
                        NavigateMenuPageViewModelCommand.Execute(1);
                        break;
                    default:
                        NavigateMenuPageViewModelCommand.Execute(1);
                        break;
                }
            }
        }
    }
}
