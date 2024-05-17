using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_BKStudia.Infrastructure.Interfaces;
using WPF_BKStudia.Infrastructure.Navigation;
using WPF_BKStudia.ViewModel.Pages;


namespace WPF_BKStudia.ViewModel.Windows
{
    internal class MainWindowViewModel : ViewModel.Base.ViewModel
    {
        private INavigationStoreService _navigationStoreService { get; set; }
        private IFileReaderService _fileReaderService { get; set; }
        private IFileWriterService _fileWriterService { get; set; }

        public ViewModel.Base.ViewModel? CurrentViewModel => _navigationStoreService.CurrentViewModel;

        public MainWindowViewModel(INavigationStoreService navigationStoreService, IFileReaderService fileReaderService, IFileWriterService fileWriterService)
        {
            _navigationStoreService = navigationStoreService;
            _fileReaderService = fileReaderService;
            _fileWriterService = fileWriterService;

            if (!Directory.Exists("Tests")) Directory.CreateDirectory("Tests");

            _navigationStoreService.CurrentViewModel = new MenuPageViewModel(_navigationStoreService, _fileReaderService, _fileWriterService);
            //navigationStore.CurrentViewModel = new GetTesttedMenuViewModel(_navigationStoreService);
            _navigationStoreService.CurrentViewModelChanged += () => OnCurrentViewChanged();
        }

        private void OnCurrentViewChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
