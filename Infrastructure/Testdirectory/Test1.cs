using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_BKStudia.Infrastructure.Interfaces;
using WPF_BKStudia.Model.DataType;

namespace WPF_BKStudia.Infrastructure.Testdirectory
{
    public class Test1 : IFileReaderService
    {
        public int GetCountQuestions(string path)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<TextQuestion> GetQuestionCollection(string path)
        {
            throw new NotImplementedException();
        }
    }
}
