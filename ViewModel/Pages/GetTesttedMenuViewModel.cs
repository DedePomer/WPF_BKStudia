using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;
using WPF_BKStudia.Infrastructure.Commands;
using WPF_BKStudia.Infrastructure.Navigation;
using WPF_BKStudia.Model.DataType;
using static System.Net.Mime.MediaTypeNames;

namespace WPF_BKStudia.ViewModel.Pages
{
    internal class GetTesttedMenuViewModel: ViewModel.Base.ViewModel
    {
        //Поля
        private string _path = "Tests";
        public ObservableCollection<TestType> MyTests {  get; set; }
        public int NumberOfQuestion {  get; set; }

        //Навигационные команды
        public ICommand NavigateMenuPageViewModelCommand { get; }
        public ICommand NavigateCreateTestViewModelCommand { get; }

        //Функциональные команды
        public ICommand ChoiseTestCommand { get; }
        private bool CanChoiseTestCommandExecuted(object p) => true;
        private void OnChoiseTestCommandExecuted(object p)
        {
            
        }

        public ICommand RemoveTestCommand { get; }
        private bool CanRemoveTestCommandExecuted(object p) => true;
        private void OnRemoveTestCommandExecuted(object p)
        {

        }

        //Конструктор
        public GetTesttedMenuViewModel(NavigationStore navigationStore)
        {         
            MyTests = new ObservableCollection<TestType>();
            FillTestsList();

            NavigateMenuPageViewModelCommand = new NavigationCommand<MenuPageViewModel>(navigationStore, () => new MenuPageViewModel(navigationStore));
            NavigateCreateTestViewModelCommand = new NavigationCommand<CreateTestViewModel>(navigationStore, () => new CreateTestViewModel(navigationStore));

            ChoiseTestCommand = new LamdaCommand(OnChoiseTestCommandExecuted, CanChoiseTestCommandExecuted);
            RemoveTestCommand = new LamdaCommand(OnRemoveTestCommandExecuted, CanRemoveTestCommandExecuted);
        }

        private void FillTestsList()
        {
            if (Directory.GetFileSystemEntries(_path).ToList().Count != 0)
            {
                for (int i = 0; i < Directory.GetFileSystemEntries(_path).ToList().Count; i++)
                {
                    MyTests.Add(new TestType()
                    {
                        Id = i+1,
                        Name = Directory.GetFileSystemEntries(_path).ToList()[i]
                    });
                }
            }
            else 
            {
                MessageBox.Show("Как ты сюда зашёл", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }

    
}
