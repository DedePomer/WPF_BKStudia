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
        private TestModel GetModel(string file, string path)
        {
            TestModel model = new TestModel();
            model.Name = path.Replace(".txt", "").Replace("Tests", "").Replace("\\", "");
            model.Quanty = GetCountQuestions(path);
            file = file.Replace(model.Name + "\n" + model.Quanty, "");
            file = file.Substring(3);

            string[] proxyMas = file.Split("\n\n\n");
            ObservableCollection < TextQuestion > = new ObservableCollection<TextQuestion>();

            for (int i = 0; i < proxyMas.Length; i++)
            {
                string [] mas = proxyMas[i].Split("\n");
                model.Id = Int32.Parse(mas[0]);
                model.Name = mas[1];

            }
            return model;
        }
        public TestModel ReadFile(string path)
        {
            string fileStr = File.ReadAllText(path);
            test.Name = path.Replace(".txt", "").Replace("Tests", "").Replace("\\", "");
            test.Quanty = GetCountQuestions(path);
            string[] fileMas = fileStr.Split("\n\n\n");
            
            for (int i = 1; i < fileMas.Length; i++)
            {
                test.QuestionCollection = 
                    new ObservableCollection<TextQuestion> 
                    {
                        
                    }
            }
        }


    }
}
