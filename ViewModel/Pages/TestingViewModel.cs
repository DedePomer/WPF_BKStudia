using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using WPF_BKStudia.Infrastructure.Commands;
using WPF_BKStudia.Infrastructure.Interfaces;
using WPF_BKStudia.Model;
using WPF_BKStudia.Model.DataType;
using WPF_BKStudia.Infrastructure.Enums;

namespace WPF_BKStudia.ViewModel.Pages
{
    internal class TestingViewModel: ViewModel.Base.ViewModel
    {
        // Поля
        private INavigationStoreService _navigationStoreService { get; set; }
        private IFileReaderService _fileReaderService { get; set; }
        private IFileWriterService _fileWriterService { get; set; }

        private Visibility _hidenObject;
        private bool _enableObject;
        private int _countTrueQuestion;

        public ObservableCollection<TextQuestion> Questions { get; set; }
        public int CountTrueQuestion
        {
            get
            {
                return _countTrueQuestion;
            }
            set
            {
                Set(ref _countTrueQuestion, value);
            }
        }
        public int CountQuestion { get; set; }
        public Visibility ResultVisibility 
        {
            get
            { 
                return _hidenObject; 
            }
            set
            {
                Set(ref _hidenObject, value);
            }
        }
        public bool EnableObject
        {
            get
            {
                return _enableObject;
            }
            set
            {
                Set<bool>(ref _enableObject, value);
            }
        }
        public Test TestModel { get; set; }

        //Навигационные команды
        public ICommand NavigateGetTesttedMenuViewModelCommand { get; }
        private bool CanNavigateGetTesttedMenuViewModelCommandExecuted(object p) => true;
        private void OnNavigateGetTesttedMenuViewModelCommandExecuted(object p)
        {
            _navigationStoreService.CurrentViewModel = new SelectTestMenuViewModel(_navigationStoreService, _fileReaderService, _fileWriterService);
        }

        //Функциональные команды
        public ICommand TakeResultCommand { get; }
        private bool CanTakeResultCommandExecuted(object p) => true;
        private void OnTakeResultCommandExecuted(object p)
        {
            //ResultVisibility = Visibility.Visible;
            //EnableObject = false;
            //CountTrueQuestion = 0;
            //foreach (TextQuestion question in Questions)
            //{
            //    switch (question.Type) 
            //    {
            //        case QuestionEnum.TextQuestion:
            //            if (IsTrueStringQuestion(question.Answer[0].Text, question.ListAnswer[0].Text))
            //            {
            //                question.QuestionColor = new SolidColorBrush(Colors.LightSeaGreen);
            //                CountTrueQuestion++;
            //            }
            //            else
            //            {
            //                question.QuestionColor = new SolidColorBrush(Colors.DarkRed);
            //            }
            //            break;
            //        case QuestionEnum.SingleChoiceQuestion:
            //            break;
            //        case QuestionEnum.MultiChoiceQuestion:
            //            break;
            //    }
            //}
        }



        public TestingViewModel(INavigationStoreService navigationStoreService, IFileReaderService fileReaderService, IFileWriterService fileWriterService) 
        {
            _navigationStoreService = navigationStoreService;
            _fileReaderService = fileReaderService;
            _fileWriterService = fileWriterService;           

            TestModel = _navigationStoreService.Param as Test;
            Questions = _fileReaderService.GetQuestionCollection(TestModel.Name);
            ResultVisibility = Visibility.Collapsed;
            EnableObject = true;
            CountQuestion = fileReaderService.GetCountQuestions(TestModel.Name);

            NavigateGetTesttedMenuViewModelCommand = new LamdaCommand(OnNavigateGetTesttedMenuViewModelCommandExecuted, CanNavigateGetTesttedMenuViewModelCommandExecuted);

            TakeResultCommand = new LamdaCommand(OnTakeResultCommandExecuted, CanTakeResultCommandExecuted);
        }

        //Проверяет ответ текстового вопроса с множеством правильных ответов
        private bool IsTrueStringQuestion(string firstStr, string secondStr)
        {
            string[] secondStrMas = secondStr.Split('$');
            for (int i = 0; i < secondStrMas.Length; i++)
            {
                if (secondStrMas[i] == firstStr)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
