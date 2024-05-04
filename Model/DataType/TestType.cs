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
    //Номер и название теста
    class TestType :INotifyPropertyChanged
    {
        private int _id;
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

        public event PropertyChangedEventHandler? PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
