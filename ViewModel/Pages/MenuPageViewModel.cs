using System.IO;
using System.Windows;
using System.Windows.Input;
using WPF_BKStudia.Infrastructure.Commands;
using WPF_BKStudia.Infrastructure.Interfaces;

namespace WPF_BKStudia.ViewModel.Pages
{
    internal class MenuPageViewModel : Base.ViewModel
    {
        //Поля
        private const string TestsPath = "Tests";
        private readonly INavigationStoreService _navigationStoreService;
        private readonly IFileReaderService _fileReaderService;
        private readonly IFileWriterService _fileWriterService;

        //Навигационные команды
        public ICommand NavigateGetTesttedMenuCommand { get; }
        private bool CanNavigateGetTesttedMenuCommandExecuted(object p) => true;
        private void OnNavigateGetTesttedMenuCommandExecuted(object p)
        {
            IsDirectoryNotNull();
        }

        public ICommand NavigateCreateTestCommand { get; }
        private bool CanNavigateCreateTestCommandExecuted(object p) => true;
        private void OnNavigateCreateTestCommandExecuted(object p)
        {
            _navigationStoreService.CurrentViewModel = new CreateTestViewModel(_navigationStoreService, _fileReaderService, _fileWriterService);
        }

        //Функциональные команды
        public ICommand CloseAppCommand { get; }
        private bool CanCloseAppExecuted(object p) => true;
        private void OnCloseAppExecuted(object p)
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

            CloseAppCommand = new LamdaCommand(OnCloseAppExecuted, CanCloseAppExecuted);
        }

        //Проверяет пуста ли пака Tests
        private void IsDirectoryNotNull()
        {
            if (Directory.GetFileSystemEntries(TestsPath).ToList().Count == 0)
            {
                MessageBoxResult result = MessageBox.Show("В папке Tests нет тестов. Хотите создать тест ? (нажмите Да)", "Information", MessageBoxButton.YesNo, MessageBoxImage.Information);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        NavigateCreateTestCommand.Execute(1);
                        break;
                    case MessageBoxResult.No:
                    default:
                        break;
                }
            }
            else
            {
                _navigationStoreService.CurrentViewModel = new SelectTestMenuViewModel(_navigationStoreService, _fileReaderService, _fileWriterService);
            }
        }
    }
}
