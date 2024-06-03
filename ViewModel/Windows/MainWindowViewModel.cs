using System.IO;
using WPF_BKStudia.Infrastructure.Interfaces;
using WPF_BKStudia.ViewModel.Pages;


namespace WPF_BKStudia.ViewModel.Windows
{
    internal class MainWindowViewModel : ViewModel.Base.ViewModel
    {
        private const string TestsDirectoryPath = "Tests";

        private INavigationStoreService _navigationStoreService { get; set; }
        private IFileReaderService _fileReaderService { get; set; }
        private IFileWriterService _fileWriterService { get; set; }

        public ViewModel.Base.ViewModel? CurrentViewModel => _navigationStoreService.CurrentViewModel;

        public MainWindowViewModel(INavigationStoreService navigationStoreService, IFileReaderService fileReaderService, IFileWriterService fileWriterService)
        {
            _navigationStoreService = navigationStoreService;
            _fileReaderService = fileReaderService;
            _fileWriterService = fileWriterService;

            if (!Directory.Exists(TestsDirectoryPath))
                Directory.CreateDirectory(TestsDirectoryPath);

            _navigationStoreService.CurrentViewModel = new MenuPageViewModel(_navigationStoreService, _fileReaderService, _fileWriterService);
            //_navigationStoreService.CurrentViewModel = new SelectTestMenuViewModel(_navigationStoreService, _fileReaderService, _fileWriterService);

            _navigationStoreService.CurrentViewModelChanged += () => OnCurrentViewChanged();
        }

        private void OnCurrentViewChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
