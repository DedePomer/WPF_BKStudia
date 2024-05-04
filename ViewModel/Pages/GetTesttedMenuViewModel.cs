﻿using System;
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
using System.Xml.Linq;
using WPF_BKStudia.Infrastructure.Commands;
using WPF_BKStudia.Infrastructure.Navigation;
using WPF_BKStudia.Infrastructure.Services;
using WPF_BKStudia.Model;
using static System.Net.Mime.MediaTypeNames;

namespace WPF_BKStudia.ViewModel.Pages
{
    internal class GetTesttedMenuViewModel: ViewModel.Base.ViewModel
    {
        //Поля
        private string _path = "Tests";
        private int _testId = 0;
        public ObservableCollection<TestModel> MyTests {  get; set; }
        public int NumberOfQuestion {  get; set; }

        //Навигационные команды
        public ICommand NavigateMenuPageViewModelCommand { get; }
        public ICommand NavigateCreateTestViewModelCommand { get; }
        public ICommand NavigateTakeTestPageViewModelCommand { get; }

        //Функциональные команды
        public ICommand ChoiseTestCommand { get; }
        private bool CanChoiseTestCommandExecuted(object p) => true;
        private void OnChoiseTestCommandExecuted(object p)
        {
            TestModel test = p as TestModel;
            NavigateTakeTestPageViewModelCommand.Execute(test);       
        }

        public ICommand RemoveTestCommand { get; }
        private bool CanRemoveTestCommandExecuted(object p) => true;
        private void OnRemoveTestCommandExecuted(object p)
        {
            TestModel test = p as TestModel;
            if (File.Exists(test.Name))
            { 
                File.Delete(test.Name);
                MyTests.Remove(test);
                foreach (TestModel t in MyTests)
                {
                    if (t.Id > test.Id)
                    {
                        t.Id--;
                    }
                }
                _testId--;
            }
        }

        //Конструктор
        public GetTesttedMenuViewModel(NavigationStore navigationStore)
        {         
            MyTests = new ObservableCollection<TestModel>();
            FillTestsList();

            NavigateMenuPageViewModelCommand = new NavigationCommand<MenuPageViewModel>(navigationStore, () => new MenuPageViewModel(navigationStore));
            NavigateCreateTestViewModelCommand = new NavigationCommand<CreateTestViewModel>(navigationStore, () => new CreateTestViewModel(navigationStore));
            NavigateTakeTestPageViewModelCommand = new NavigationCommand<TakeTestPageViewModel>(navigationStore, () => new TakeTestPageViewModel(navigationStore));

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
                    if (IsTest(OurTests[i]))
                    {
                        MyTests.Add(new TestModel()
                        {
                            Id = _testId + 1,
                            Name = OurTests[i]
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

        public bool IsTest(string path)
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
