using System.Collections.ObjectModel;
using WPF_BKStudia.Model.DataType;

namespace WPF_BKStudia.Infrastructure.Interfaces
{
    public interface IFileReaderService
    {
        public int GetCountQuestions(string path);
        public bool GetAnswerVisibilityCheck(string path);
        public ObservableCollection<TextQuestion> GetAnsweredQuestionCollection(string path);
        public ObservableCollection<TextQuestion> GetUnansweredQuestionCollection(string path);
    }
}
