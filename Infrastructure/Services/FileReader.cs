using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_BKStudia.Model;
using WPF_BKStudia.Model.DataType;
using static System.Net.Mime.MediaTypeNames;

namespace WPF_BKStudia.Infrastructure.Services
{
    public class FileReader
    {
        public int GetCountQuestions(string path)
        {
            List<string> fileStr = File.ReadLines(path).ToList();
            return int.Parse(fileStr[1]);
        }
        private ObservableCollection<TextQuestion> GetQuestionCollection(string[] file, string path)
        {
            ObservableCollection<TextQuestion> questions = new ObservableCollection<TextQuestion>();
            for (int i = 0; i < file.Length; i++)
            { 
                string[] mas = file[i].Split('\n');
                questions.Add(new TextQuestion()
                {
                    Id = Int32.Parse(mas[0]),
                    Type = (QuestionEnum)1,
                });
            }
            return questions;
        }
        public TestModel ReadFile(string path)
        {
            TestModel test = new TestModel();
            string fileStr = File.ReadAllText(path);
            test.Name = path.Replace(".txt", "").Replace("Tests", "").Replace("\\", "");
            test.Quanty = GetCountQuestions(path);
            fileStr = fileStr.Replace(test.Name + "\n" + test.Quanty, "");
            string[] fileMas = fileStr.Split("\n\n\n");
            
           
        }


    }
}
