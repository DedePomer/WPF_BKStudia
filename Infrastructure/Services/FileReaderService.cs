
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Media;
using WPF_BKStudia.Infrastructure.Enums;
using WPF_BKStudia.Infrastructure.Interfaces;
using WPF_BKStudia.Model.DataType;


namespace WPF_BKStudia.Infrastructure.Services
{
    public class FileReaderService: IFileReaderService
    {
        private const string FileDataSplitter = "\n\n\n";
        private const string QuestionDataSplitter = "\n";
        private const int FirstQuestionLineNumber = 1;

        public int GetCountQuestions(string path)
        {
            List<string> fileStr = File.ReadLines(path).ToList();
            return int.Parse(fileStr[1]);
        }
        public ObservableCollection<TextQuestion> GetQuestionCollection(string path)
        {
            string[] fileLines = File.ReadAllText(path).Split(FileDataSplitter);
            ObservableCollection<TextQuestion> questions = new ObservableCollection<TextQuestion>();
            for (int i = FirstQuestionLineNumber; i < fileLines.Length; i++)
            {
                string[] questionData = fileLines[i].Split(QuestionDataSplitter);
                questions.Add(new TextQuestion()
                {
                    Id = Int32.Parse(questionData[0]),
                    Type = (QuestionEnum)Int32.Parse(questionData[1]),
                    Text = questionData[2],
                    Answer = new ObservableCollection<Answer>(),
                    ListAnswer = new ObservableCollection<Answer>(),
                    QuestionColor  = new SolidColorBrush(Colors.LightBlue)
                });

                var currentQuestion = questions[i - 1];
                switch (currentQuestion.Type)
                {
                    case QuestionEnum.TextQuestion:
                        currentQuestion.ListAnswer.Add(new Answer()
                        {
                            Text = questionData[3],
                            IsCorrect = true
                        });
                        currentQuestion.Answer.Add(new Answer()
                        {
                            Text = string.Empty
                        });
                        break;
                    case QuestionEnum.SingleChoiceQuestion:

                        break;
                    case QuestionEnum.MultiChoiceQuestion:

                        break;
                    default:
                        break;
                }
            }
            return questions;
        }
    }
}
