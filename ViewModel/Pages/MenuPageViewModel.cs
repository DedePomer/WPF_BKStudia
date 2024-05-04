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
        //Поля
        private string _path = "Tests";
        

        //Навигационные команды
        public ICommand NavigateGetTesttedMenuCommand { get; }
        public ICommand NavigateCreateTestCommand { get; }

        //Функциональные команды
        public ICommand CloseAppCommand { get;  }
        private bool CanCCloseAppExecuted(object p) => true;
        private void OnCCloseAppExecuted(object p)
        { 
            Application.Current.Shutdown();
        }

        public ICommand GetTesttedMenuCommand { get; }
        private bool CanGetTesttedMenuCommandExecuted(object p) => true;
        private void OnGetTesttedMenuCommandExecuted(object p)
        {
            IsNotNullDirectory();
        }




        public MenuPageViewModel(NavigationStore navigationStore)  
        {
            NavigateGetTesttedMenuCommand = new NavigationCommand<GetTesttedMenuViewModel>(navigationStore, () => new GetTesttedMenuViewModel(navigationStore));
            NavigateCreateTestCommand = new NavigationCommand<CreateTestViewModel>(navigationStore, () => new CreateTestViewModel(navigationStore));
            
            CloseAppCommand = new LamdaCommand(OnCCloseAppExecuted, CanCCloseAppExecuted);

            //Спросить про это
            GetTesttedMenuCommand = new LamdaCommand(OnGetTesttedMenuCommandExecuted, CanGetTesttedMenuCommandExecuted);
        }

        //Проверяет пуста ли пака Tests
        private void IsNotNullDirectory()
        {
            if (Directory.GetFileSystemEntries(_path).ToList().Count == 0)
            {
                MessageBoxResult result = MessageBox.Show("В папке Tests нет тестов. Хотите создать тест ? (нажмите Да)", "Information", MessageBoxButton.YesNo, MessageBoxImage.Information);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        NavigateCreateTestCommand.Execute(1);
                        break;
                    case MessageBoxResult.No:default:                        
                        break;
                }
            }
            else
            {
                NavigateGetTesttedMenuCommand.Execute(1);
            }
        }
    }
}
