using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_BKStudia.Model;

namespace WPF_BKStudia.Infrastructure.Services
{
    public class FileWriter
    {
        public void SaveFile(TestModel test)
        {
            string path = "Tests" + "\\" + test.Name + ".txt";
            
            File.AppendAllText(path, test.Name);
            File.AppendAllText(path, "\n\n");

            foreach (var question in test.QuestionCollection)
            {
                File.AppendAllText(path, question.Id.ToString());
                File.AppendAllText(path, question.Type.ToString());
                File.AppendAllText(path,question.Text.ToString());

                switch (question.Type)
                { 
                    case QuestionEnum.TextQuestion:
                        File.AppendAllText(path, question.ListAnswer[0].Id.ToString());
                        File.AppendAllText(path, question.ListAnswer[0].Text.ToString());
                        break;
                    case QuestionEnum.SingleChoiceQuestion:

                        break;
                    case QuestionEnum.MultiChoiceQuestion:
                        break;
                    default:
                        MessageBox.Show("Тип вопроса " + question.Id + " неопределён", "Save error", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                }
            }

        }

    }
}
