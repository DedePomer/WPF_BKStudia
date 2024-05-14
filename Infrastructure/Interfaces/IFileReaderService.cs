using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_BKStudia.Model.DataType;

namespace WPF_BKStudia.Infrastructure.Interfaces
{
    public interface IFileReaderService
    {
        int GetCountQuestions(string path);
        public ObservableCollection<TextQuestion> GetQuestionCollection(string path);
    }
}
