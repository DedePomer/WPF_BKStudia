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
            if (!File.Exists(path))
            {
                File.AppendAllText(path, test.Name);
                File.AppendAllText(path, "\n" + test.Quanty.ToString());

                foreach (var question in test.QuestionCollection)
                {
                    File.AppendAllText(path, "\n\n");
                    File.AppendAllText(path, "\n" + question.Id.ToString());
                    File.AppendAllText(path, "\n" + question.Type.ToString());
                    File.AppendAllText(path, "\n" + question.Text.ToString());

                    switch (question.Type)
                    {
                        case QuestionEnum.TextQuestion:
                            if (question.ListAnswer[0].IsTrue)
                            {
                                if (question.ListAnswer[0].Text == "")
                                    File.AppendAllText(path, "\n ");                               
                                else
                                    File.AppendAllText(path, "\n" + question.ListAnswer[0].Text.ToString());
                            }                          
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
            else 
            {
                var result = MessageBox.Show("Файл с таким именем существует. Если нажмёте \"Да\", то файл перезапишется. Если нажмёте \"Нет\" вернётесь к созданию теста",
                        "Save error", MessageBoxButton.YesNo, MessageBoxImage.Error);
                if (result == MessageBoxResult.Yes)
                {
                    File.Delete(path);
                    SaveFile(test);
                }
            }
        }

    }
}
