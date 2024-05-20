﻿using System;
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
using WPF_BKStudia.Infrastructure.Services.Enums;

namespace WPF_BKStudia.ViewModel.Pages
{
    internal class TakeTestPageViewModel: ViewModel.Base.ViewModel
    {
        // Поля
        private INavigationStoreService _navigationStoreService { get; set; }
        private IFileReaderService _fileReaderService { get; set; }
        private IFileWriterService _fileWriterService { get; set; }


        public ObservableCollection<TextQuestion> Questions { get; set; }
        public int CountTrueQuestion { get; set; }
        public int CountQuestion { get; set; }
        public Visibility HidenObject { get; set; }
        public TestModel MyModel { get; set; }

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
            foreach (TextQuestion question in Questions)
            {
                switch (question.Type) 
                {
                    case QuestionEnum.TextQuestion:
                        if (CorrectStringQuestionCheker(question.Answer[0].Text, question.ListAnswer[0].Text))
                        { 
                            
                        }
                        break;
                    case QuestionEnum.SingleChoiceQuestion:
                        break;
                    case QuestionEnum.MultiChoiceQuestion:
                        break;
                }

            }
        }



        public TakeTestPageViewModel(INavigationStoreService navigationStoreService, IFileReaderService fileReaderService, IFileWriterService fileWriterService) 
        {
            _navigationStoreService = navigationStoreService;
            _fileReaderService = fileReaderService;
            _fileWriterService = fileWriterService;

            MyModel = _navigationStoreService.Param as TestModel;
            Questions = _fileReaderService.GetQuestionCollection(MyModel.Name);
            HidenObject = Visibility.Collapsed;
            CountQuestion = fileReaderService.GetCountQuestions(MyModel.Name);

            NavigateGetTesttedMenuViewModelCommand = new LamdaCommand(OnNavigateGetTesttedMenuViewModelCommandExecuted, CanNavigateGetTesttedMenuViewModelCommandExecuted);

            TakeResultCommand = new LamdaCommand(OnTakeResultCommandExecuted, CanTakeResultCommandExecuted);
        }

        //Проверяет ответ текстового вопроса с множеством правильных ответов
        private bool CorrectStringQuestionCheker(string firstStr, string secondStr)
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
