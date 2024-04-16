using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_BKStudia.Infrastructure.Interfaces;

namespace WPF_BKStudia.Infrastructure.Services.DataType
{
    internal class TextQuestion : IQuestionAnswer
    {
        public int Id { get; set; }
        public string Text { get ; set ; }
        public QuestionEnum Type { get; set; }
        public ObservableCollection<Answer>? ListAnswer { get; set; }

    }
}
