using System;
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
using WPF_BKStudia.Infrastructure.Services.DataType;
using WPF_BKStudia.Model;



namespace WPF_BKStudia.ViewModel.Pages
{
    

    internal class CreateTestViewModel: ViewModel.Base.ViewModel
    {
        //--Поля
        private int _questionId = 0;
        public SolidColorBrush AquaColor { get { return new SolidColorBrush(Colors.Aqua); } }
        public TestModel CurrentQuestion { get; set; }

        //Функциональные команды
        public ICommand CRemoveQuestion { get; }
        private bool CanCRemoveQuestionExecuted(object p) => true;
        private void OnCRemoveQuestionExecuted(object p)
        { 
            TextQuestion question = p as TextQuestion;
            CurrentQuestion.QuestionCollection.Remove(question);
        }

        public ICommand CAddQuestion { get; }
        private bool CanCAddQuestionExecuted(object p) => true;
        private void OnCAddQuestionExecuted(object p)
        {
            _questionId++;
            CurrentQuestion.QuestionCollection.Add(new TextQuestion
            {
                QuestionColor = AquaColor,
                Id = _questionId,
                Text = "",
                Type = QuestionEnum.TextQuestion,
                ListAnswer = new ObservableCollection<Answer> 
                { new Answer()
                { 
                    Id = 1, 
                    Text="Popa",
                    IsTrue = true
                } 
                }
            });
        }

        //Навигационные команды
        public ICommand CNavigateMenuPageViewModel { get; }

        public CreateTestViewModel(NavigationStore navigationStore)
        {            
            CurrentQuestion = new TestModel();
            CurrentQuestion.QuestionCollection = new ObservableCollection<TextQuestion>();


           
            CNavigateMenuPageViewModel = new NavigationCommand<MenuPageViewModel>(navigationStore, () => new MenuPageViewModel(navigationStore));

            CAddQuestion = new LamdaCommand(OnCAddQuestionExecuted, CanCAddQuestionExecuted);
            CRemoveQuestion = new LamdaCommand(OnCRemoveQuestionExecuted, CanCRemoveQuestionExecuted);
        }
    }
}
