using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_BKStudia.Infrastructure.Commands;
using WPF_BKStudia.Infrastructure.Navigation;
using WPF_BKStudia.Infrastructure.Services;
using WPF_BKStudia.Infrastructure.Services.DataType;
using WPF_BKStudia.Model;


namespace WPF_BKStudia.ViewModel.Pages
{
    

    internal class CreateTestViewModel: ViewModel.Base.ViewModel
    {
        ////Очень важно
        //internal class Person
        //{
        //    public string name { get; set; }
        //    public int age { get; set; }
        //    public Person(string Name, int Age)
        //    {
        //        name = Name;
        //        age = Age;
        //    }
        //}
        //private ObservableCollection<Person> _tetsPerson = new ObservableCollection<Person> { new Person("GG", 19) };
        //public ObservableCollection<Person> TetsPerson
        //{
        //    set { Set(ref _tetsPerson, value); }
        //    get { return _tetsPerson; }
        //}

        //public ICommand CTest { get; }
        //private bool CanCCTestExecuted(object p) => true;
        //private void OnCCTestExecuted(object p)
        //{
        //    TetsPerson.Add(new Person("DDdsgsg", 19));
        //}
        ////Очень важно

        //--Поля
        //private int _questionId = 0;
        ////public TextQuestion teste = new TextQuestion();
        //public TestModel Model { get; set; }

        ////Функциональные команды
        //public  ICommand CAddQuestionCommand { get; }
        //private bool CanCAddQuestionCommandExecuted(object p) => true;
        //private void OnCAddQuestionCommandExecuted(object p)
        //{
        //    _questionId++;
        //    Model.Questions.Add(new TextQuestion
        //    {
        //        Id = _questionId,
        //        NameQuestion = "Gopa",
        //        Type = QuestionEnum.TextQuestion,

        //        Answer = "Попа"
        //    });
        //}

        //Навигационные команды
        public ICommand CNavigateMenuPageViewModel { get; }

        public CreateTestViewModel(NavigationStore navigationStore)
        {
            CNavigateMenuPageViewModel = new NavigationCommand<MenuPageViewModel>(navigationStore, () => new MenuPageViewModel(navigationStore));

            //CAddQuestionCommand = new LamdaCommand(OnCAddQuestionCommandExecuted, CanCAddQuestionCommandExecuted);
            //CTest = new LamdaCommand(OnCCTestExecuted, CanCCTestExecuted);
        }
    }
}
