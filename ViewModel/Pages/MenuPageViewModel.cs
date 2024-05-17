using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF_BKStudia.Infrastructure.Commands;
using WPF_BKStudia.Infrastructure.Interfaces;
using WPF_BKStudia.Infrastructure.Navigation;

namespace WPF_BKStudia.ViewModel.Pages
{
    internal class MenuPageViewModel: ViewModel.Base.ViewModel
    {
        //Поля
        private string _path = "Tests";
        private INavigationStoreService _navigationStoreService { get; set; }
        private IFileReaderService _fileReaderService { get; set; }
        private IFileWriterService _fileWriterService { get; set; }

        //Навигационные команды
        public ICommand NavigateGetTesttedMenuCommand { get; }
        private bool CanNavigateGetTesttedMenuCommandExecuted(object p) => true;
        private void OnNavigateGetTesttedMenuCommandExecuted(object p)
        {
            IsNotNullDirectory();            
        }

        public ICommand NavigateCreateTestCommand { get; }
        private bool CanNavigateCreateTestCommandExecuted(object p) => true;
        private void OnNavigateCreateTestCommandExecuted(object p)
        {
            _navigationStoreService.CurrentViewModel = new CreateTestViewModel(_navigationStoreService, _fileReaderService, _fileWriterService);
        }

        //Функциональные команды
        public ICommand CloseAppCommand { get;  }
        private bool CanCCloseAppExecuted(object p) => true;
        private void OnCCloseAppExecuted(object p)
        { 
            Application.Current.Shutdown();
        }





        public MenuPageViewModel(INavigationStoreService navigationStoreService, IFileReaderService fileReaderService, IFileWriterService fileWriterService)  
        {
            _navigationStoreService = navigationStoreService;
            _fileReaderService = fileReaderService;
            _fileWriterService = fileWriterService;

            NavigateGetTesttedMenuCommand = new LamdaCommand(OnNavigateGetTesttedMenuCommandExecuted, CanNavigateGetTesttedMenuCommandExecuted); 
            NavigateCreateTestCommand = new LamdaCommand(OnNavigateCreateTestCommandExecuted, CanNavigateCreateTestCommandExecuted);

            CloseAppCommand = new LamdaCommand(OnCCloseAppExecuted, CanCCloseAppExecuted);          
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
                _navigationStoreService.CurrentViewModel = new TakeTestPageViewModel(_navigationStoreService, _fileReaderService, _fileWriterService);
            }
        }
    }
}
