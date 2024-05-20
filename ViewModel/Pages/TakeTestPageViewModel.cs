using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using WPF_BKStudia.Infrastructure.Commands;
using WPF_BKStudia.Infrastructure.Interfaces;
using WPF_BKStudia.Infrastructure.Navigation;
using WPF_BKStudia.Infrastructure.Services;
using WPF_BKStudia.Model;
using WPF_BKStudia.Model.DataType;

namespace WPF_BKStudia.ViewModel.Pages
{
    internal class TakeTestPageViewModel: ViewModel.Base.ViewModel
    {
        // Поля
        private INavigationStoreService _navigationStoreService { get; set; }
        private IFileReaderService _fileReaderService { get; set; }
        private IFileWriterService _fileWriterService { get; set; }

        private SolidColorBrush _aquaColor = new SolidColorBrush(Colors.LightBlue);

        public ObservableCollection<TextQuestion> Questions { get; set; } 
        public Visibility HidenObject { get; set; }

        //Навигационные команды
        public ICommand NavigateGetTesttedMenuViewModelCommand { get; }
        private bool CanNavigateGetTesttedMenuViewModelCommandExecuted(object p) => true;
        private void OnNavigateGetTesttedMenuViewModelCommandExecuted(object p)
        {
            _navigationStoreService.CurrentViewModel = new GetTesttedMenuViewModel(_navigationStoreService, _fileReaderService, _fileWriterService);
        }

        //Функциональные команды
        public ICommand TakeResultCommand { get; }
        private bool CanTakeResultCommandExecuted(object p) => true;
        private void OnTakeResultCommandExecuted(object p)
        {
            
        }



        public TakeTestPageViewModel(INavigationStoreService navigationStoreService, IFileReaderService fileReaderService, IFileWriterService fileWriterService) 
        {
            _navigationStoreService = navigationStoreService;
            _fileReaderService = fileReaderService;
            _fileWriterService = fileWriterService;

            TestModel test = _navigationStoreService.Param as TestModel;
            Questions = _fileReaderService.GetQuestionCollection(test.Name);
            HidenObject = Visibility.Collapsed;

            NavigateGetTesttedMenuViewModelCommand = new LamdaCommand(OnNavigateGetTesttedMenuViewModelCommandExecuted, CanNavigateGetTesttedMenuViewModelCommandExecuted);

            TakeResultCommand = new LamdaCommand(OnTakeResultCommandExecuted, CanTakeResultCommandExecuted);
        }
    }
}
