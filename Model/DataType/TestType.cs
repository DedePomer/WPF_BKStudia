using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPF_BKStudia.Model.DataType
{
    //Номер и название теста + методы подсчёта количесва вопросов  в тесте и проверки
    class TestType :INotifyPropertyChanged
    {
        //Приватные поля
        private int _id;

        //Свойства
        public int Id
        {
            get 
            { 
                return _id;
            }
            set 
            {
                _id = value;
                NotifyPropertyChanged();
            }
        }
        public string Name { get; set; }
        public int Quantity { get; set; }

        //Методы
        public int GetCountQuantity()
        {
            string testText;
            if (Name != null)
            {
                testText = File.ReadAllText(Name);
                return (testText.Length - testText.Replace("\n\n\n", "").Length) / "\n\n\n".Length;
            }
            return -1;
        }
        public bool IsTest()
        {
            string nameOfTest = Name.Replace("\\", "").Replace("Tests", "").Replace(".txt", "");
            if (File.ReadLines(Name).First() == nameOfTest)
            { 
                return true;
            }
            return false;
        }


        //Реализация интерфейса INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
