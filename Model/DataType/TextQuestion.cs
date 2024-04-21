using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WPF_BKStudia.Infrastructure.Interfaces;
using WPF_BKStudia.Infrastructure.Services;

namespace WPF_BKStudia.Model.DataType
{
    internal class TextQuestion : ViewModel.Base.ViewModel , IQuestionAnswer
    {
        private int _id;
        public int Id 
        {
            get 
            { return _id; }
            set 
            { Set(ref _id, value); }
        }
        public string Text { get; set; }
        public QuestionEnum Type { get; set; }
        public ObservableCollection<Answer>? ListAnswer { get; set; }
        public SolidColorBrush QuestionColor { get; set; }
    }
}
