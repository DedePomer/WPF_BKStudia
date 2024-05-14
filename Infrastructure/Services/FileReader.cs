using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_BKStudia.Infrastructure.Interfaces;
using WPF_BKStudia.Infrastructure.Services.Enums;
using WPF_BKStudia.Model;
using WPF_BKStudia.Model.DataType;
using static System.Net.Mime.MediaTypeNames;

namespace WPF_BKStudia.Infrastructure.Services
{
    public class FileReader: IFileReaderService
    {
        public int GetCountQuestions(string path)
        {
            List<string> fileStr = File.ReadLines(path).ToList();
            return int.Parse(fileStr[1]);
        }
        public ObservableCollection<TextQuestion> GetQuestionCollection(string path)
        {
            string[] file = GetQuestionMas(path);
            ObservableCollection<TextQuestion> questions = new ObservableCollection<TextQuestion>();
            for (int i = 0; i < file.Length; i++)
            {
                string[] mas = file[i].Split('\n');
                questions.Add(new TextQuestion()
                {
                    Id = Int32.Parse(mas[0]),
                    Type = (QuestionEnum)Int32.Parse(mas[1]),
                    Text = mas[2]
                });
                switch (questions[i].Type)
                {
                    case QuestionEnum.TextQuestion:
                        questions[i].ListAnswer = new ObservableCollection<Answer>();
                        questions[i].ListAnswer.Add(new Answer()
                        {
                            Text = mas[3],
                            IsTrue = true
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
        private string[] GetQuestionMas(string path)
        {
            string fileStr = File.ReadAllText(path);

            fileStr = fileStr.Replace(path.Replace(".txt", "").Replace("Tests", "").Replace("\\", "") + "\n" + GetCountQuestions(path), "");
            fileStr = fileStr.Substring(3);

            string[] fileMas = fileStr.Split("\n\n\n");
            return fileMas;
        }
    }
}
