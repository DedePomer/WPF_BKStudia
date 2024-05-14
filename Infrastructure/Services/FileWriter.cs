using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using WPF_BKStudia.Infrastructure.Services.Enums;
using WPF_BKStudia.Model;

namespace WPF_BKStudia.Infrastructure.Services
{
    public class FileWriter
    {
        private void WriteFile(TestModel test, string path)
        {
            File.AppendAllText(path, test.Name);
            File.AppendAllText(path, "\n" + test.Quanty.ToString());

            foreach (var question in test.QuestionCollection)
            {
                File.AppendAllText(path, "\n\n");
                File.AppendAllText(path, "\n" + question.Id.ToString());
                File.AppendAllText(path, "\n" + (int)question.Type);
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
        public bool SaveFile(TestModel test)
        {
            string path = "Tests" + "\\" + test.Name + ".txt";
            if (!File.Exists(path))
            {
                WriteFile(test, path);
                return true;
            }
            else 
            {
                var result = MessageBox.Show("Файл с таким именем существует. Если нажмёте \"Да\", то файл перезапишется. Если нажмёте \"Нет\" вернётесь к созданию теста",
                        "Save error", MessageBoxButton.YesNo, MessageBoxImage.Error);
                if (result == MessageBoxResult.Yes)
                {
                    File.Delete(path);
                    WriteFile(test, path);
                    return true;
                }
                return false;
            }
        }

    }
}
