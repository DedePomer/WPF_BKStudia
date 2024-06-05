
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using WPF_BKStudia.Infrastructure.Commands;
using WPF_BKStudia.Infrastructure.Interfaces;
using WPF_BKStudia.Model;

namespace WPF_BKStudia.ViewModel.Pages
{
    internal class SelectTestMenuViewModel: ViewModel.Base.ViewModel
    {
        // Поля
        private string _path = "Tests";
        private int _testId = 0;
        public ObservableCollection<Test> Tests {  get; set; }
        private INavigationStoreService _navigationStoreService { get; set; }
        private IFileReaderService _fileReaderService { get; set; }
        private IFileWriterService _fileWriterService { get; set; }

        //Навигационные команды
        public ICommand NavigateMenuPageViewModelCommand { get; }
        private bool CanNavigateMenuPageViewModelCommandExecuted(object p) => true;
        private void OnNavigateMenuPageViewModelCommandExecuted(object p)
        {
            _navigationStoreService.CurrentViewModel = new MenuPageViewModel(_navigationStoreService, _fileReaderService, _fileWriterService);
        }

        public ICommand NavigateCreateTestViewModelCommand { get; }
        private bool CanNavigateCreateTestViewModelCommandExecuted(object p) => true;
        private void OnNavigateCreateTestViewModelCommandExecuted(object p)
        {
            _navigationStoreService.CurrentViewModel = new CreateTestViewModel(_navigationStoreService, _fileReaderService, _fileWriterService);
        }

        public ICommand NavigateTakeTestPageViewModelCommand { get; }
        private bool CanNavigateTakeTestPageViewModelCommandExecuted(object p) => true;
        private void OnNavigateTakeTestPageViewModelCommandExecuted(object p)
        {
            _navigationStoreService.Param = p;
            _navigationStoreService.CurrentViewModel = new TestingViewModel(_navigationStoreService, _fileReaderService, _fileWriterService);    
        }

        //Функциональные команды
        public ICommand ChoiseTestCommand { get; }
        private bool CanChoiseTestCommandExecuted(object p) => true;
        private void OnChoiseTestCommandExecuted(object p)
        {
            Test test = p as Test;
            NavigateTakeTestPageViewModelCommand.Execute(test);       
        }

        public ICommand RemoveTestCommand { get; }
        private bool CanRemoveTestCommandExecuted(object p) => true;
        private void OnRemoveTestCommandExecuted(object p)
        {
            Test test = p as Test;
            if (File.Exists(test.Name))
            { 
                File.Delete(test.Name);
                Tests.Remove(test);
                foreach (Test Test in Tests)
                {
                    if (Test.Id > Test.Id)
                    {
                        Test.Id--;
                    }
                }
                _testId--;
            }
        }

        //Конструктор
        public SelectTestMenuViewModel(INavigationStoreService navigationStoreService, IFileReaderService fileReaderService, IFileWriterService fileWriterService)
        {
            _navigationStoreService = navigationStoreService;
            _fileReaderService = fileReaderService;
            _fileWriterService = fileWriterService;
            Tests = new ObservableCollection<Test>();
            FillTestsList();

            NavigateMenuPageViewModelCommand = new LamdaCommand(OnNavigateMenuPageViewModelCommandExecuted, CanNavigateMenuPageViewModelCommandExecuted);
            NavigateCreateTestViewModelCommand = new LamdaCommand(OnNavigateCreateTestViewModelCommandExecuted, CanNavigateCreateTestViewModelCommandExecuted);
            NavigateTakeTestPageViewModelCommand = new LamdaCommand(OnNavigateTakeTestPageViewModelCommandExecuted, CanNavigateTakeTestPageViewModelCommandExecuted);

            ChoiseTestCommand = new LamdaCommand(OnChoiseTestCommandExecuted, CanChoiseTestCommandExecuted);
            RemoveTestCommand = new LamdaCommand(OnRemoveTestCommandExecuted, CanRemoveTestCommandExecuted);
        }

        private void FillTestsList()
        {
            List<string> OurTests = Directory.GetFileSystemEntries(_path).ToList();
            if (OurTests.Count != 0)
            {
                for (int i = 0; i < OurTests.Count; i++)
                {
                    if (IsTestFile(OurTests[i]))
                    {
                        Tests.Add(new Test()
                        {
                            Id = _testId + 1,
                            Name = OurTests[i],
                            QuestionCount = _fileReaderService.GetCountQuestions(OurTests[i])
                        });                       
                        _testId++;
                    }
                }
            }
            else 
            {
                MessageBox.Show("Как ты сюда зашёл ?", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public bool IsTestFile(string path)
        {
            string nameOfTest = path.Replace("\\", "").Replace("Tests", "").Replace(".txt", "");
            if (File.ReadLines(path).First() == nameOfTest)
            {
                return true;
            }
            return false;
        }
    }

    
}
