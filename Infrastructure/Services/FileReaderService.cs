
using System.Collections.ObjectModel;
using System.IO;
using WPF_BKStudia.Infrastructure.Enums;
using WPF_BKStudia.Infrastructure.Interfaces;
using WPF_BKStudia.Model.DataType;


namespace WPF_BKStudia.Infrastructure.Services
{
    public class FileReaderService : IFileReaderService
    {
        private const string FileDataSplitter = "\n\n\n";
        private const string QuestionDataSplitter = "\n";
        private const int FirstQuestionLineNumber = 1;

        private TextQuestion ReadFile(string[] questionData)
        {
            TextQuestion question = new TextQuestion()
            {
                Id = Int32.Parse(questionData[0]),
                Type = (QuestionEnum)Int32.Parse(questionData[1]),
                Text = questionData[2],
                ListAnswer = new ObservableCollection<Answer>(),
            };

            switch (question.Type)
            {
                case QuestionEnum.TextQuestion:
                    question.ListAnswer.Add(new Answer()
                    {
                        Text = questionData[3],
                        IsCorrect = true
                    });
                    break;
                case QuestionEnum.SingleChoiceQuestion:

                    break;
                case QuestionEnum.MultiChoiceQuestion:

                    break;
                default:
                    break;
            }
            return question;
        }

        public int GetCountQuestions(string path)
        {
            List<string> fileStr = File.ReadLines(path).ToList();
            return int.Parse(fileStr[1]);
        }
        public ObservableCollection<TextQuestion>? GetQuestionCollection(string path)
        {
            string[] fileLines = File.ReadAllText(path).Split(FileDataSplitter);
            ObservableCollection<TextQuestion>? questions = new ObservableCollection<TextQuestion>();
            for (int i = FirstQuestionLineNumber; i < fileLines.Length; i++)
            {
                string[] questionData = fileLines[i].Split(QuestionDataSplitter);
                questions.Add(ReadFile(questionData));
            }
            return questions;
        }
    }
}


