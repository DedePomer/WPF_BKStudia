﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    internal class CreateTestViewModel: ViewModel.Base.ViewModel
    {
        //Поля
        private int _questionId = 0;
        private SolidColorBrush _aquaColor = new SolidColorBrush(Colors.Aqua);
        public QuestionComboBox QuestionComboBox { get; set; }
        public TestModel CurrentQuestion { get; set; }       


        //Функциональные команды
        public ICommand RemoveQuestionCommand { get; }
        private bool CanCRemoveQuestionExecuted(object p) => true;
        private void OnCRemoveQuestionExecuted(object p)
        { 
            TextQuestion question = p as TextQuestion;
            RemoveCheck(question);
        }

        public ICommand AddQuestionCommand { get; }
        private bool CanCAddQuestionExecuted(object p) => true;
        private void OnCAddQuestionExecuted(object p)
        {
            _questionId++;
            CurrentQuestion.QuestionCollection.Add(new TextQuestion
            {
                QuestionColor = _aquaColor,
                Id = _questionId,
                Text = "",
                Type = QuestionEnum.TextQuestion,
                ListAnswer = new ObservableCollection<Answer> 
                { new Answer()
                { 
                    Id = 1, 
                    Text="",
                    IsTrue = true
                } 
                }
            });
        }

        //Навигационные команды
        public ICommand NavigateMenuPageViewModelCommand { get; }

        public CreateTestViewModel(NavigationStore navigationStore)
        {            
            CurrentQuestion = new TestModel();
            CurrentQuestion.QuestionCollection = new ObservableCollection<TextQuestion>();


            NavigateMenuPageViewModelCommand = new NavigationCommand<MenuPageViewModel>(navigationStore, () => new MenuPageViewModel(navigationStore));

            AddQuestionCommand = new LamdaCommand(OnCAddQuestionExecuted, CanCAddQuestionExecuted);
            RemoveQuestionCommand = new LamdaCommand(OnCRemoveQuestionExecuted, CanCRemoveQuestionExecuted);
        }

        //Сдвигает значение Id, после удаления элемента коллекции
        private void RemoveCheck(TextQuestion question)
        { 
            if (CurrentQuestion.QuestionCollection != null)
            {
                foreach (TextQuestion q in CurrentQuestion.QuestionCollection)
                {
                    if (q.Id > question.Id)
                    {
                        q.Id -= 1;
                    }
                }
                CurrentQuestion.QuestionCollection.Remove(question);
                _questionId--;
            }
        }

        //Проверка полей
        private bool FieldsNotNULL()
        {
            string nameOfTest = CurrentQuestion.Name;
            if (!string.IsNullOrEmpty(nameOfTest) && nameOfTest.Count(x => x == ' ') < nameOfTest.Length)
            {
                //Проверка на программные символы
                int count = 0;
                foreach (char c in nameOfTest)
                {
                    if (Char.IsLetterOrDigit(c))
                    {
                        count += 1;
                    }
                }
                if (count == nameOfTest.Length) 
                {
                    return true;
                }
                return false;
            }
            return false;
        }



    }
}
