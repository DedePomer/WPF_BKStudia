using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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
        public TestModel Model { get; set; }

        //Функциональные команды
        public ICommand CAddQuestionCommand { get; }
        private bool CanCAddQuestionCommandExecuted(object p) => true;
        private void OnCAddQuestionCommandExecuted(object p)
        {
            //_questionId++;
            //Model.QuestionCollection.Add(new TextQuestion
            //{
            //    Id = _questionId,
            //    Text = "Gopa",
            //    Type = QuestionEnum.TextQuestion,
            //    Answer = "Попа"
            //});
        }

        //Навигационные команды
        public ICommand CNavigateMenuPageViewModel { get; }

        public CreateTestViewModel(NavigationStore navigationStore)
        {            
            Model = new TestModel();
            Model.QuestionCollection = new ObservableCollection<TextQuestion>();
 
            CNavigateMenuPageViewModel = new NavigationCommand<MenuPageViewModel>(navigationStore, () => new MenuPageViewModel(navigationStore));
            CAddQuestionCommand = new LamdaCommand(OnCAddQuestionCommandExecuted, CanCAddQuestionCommandExecuted);
        }
    }
}
