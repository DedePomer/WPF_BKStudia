using System.Collections.ObjectModel;
using System.ComponentModel;
using WPF_BKStudia.Model.Abstaracts;
using WPF_BKStudia.Model.DataType;

namespace WPF_BKStudia.Model
{
    public class Test : AbstractNotifyModel
    {
        //Модель где "содержаться" название теста и коллекция вопросов
        private int? _id;
        public int? Id
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
        public string? Name { get; set; }
        public ObservableCollection<TextQuestion>? QuestionCollection { get; set; }
        public int? QuestionCount { get; set; }
    }
}
