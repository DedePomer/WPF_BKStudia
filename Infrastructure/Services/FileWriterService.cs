using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using WPF_BKStudia.Infrastructure.Enums;
using WPF_BKStudia.Infrastructure.Interfaces;
using WPF_BKStudia.Model;
using WPF_BKStudia.Model.DataType;

namespace WPF_BKStudia.Infrastructure.Services
{
    public class FileWriterService: IFileWriterService
    {
        private const string FirstDataSplitter = "\n\n\n";
        private const string SecindDataSplitter = "\n";


        private void WriteFile(Test test, string path)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.Write(test.Name);
                writer.Write("\n" + test.QuestionCount);

                foreach (TextQuestion question in test.QuestionCollection)
                {
                    writer.Write(FirstDataSplitter + question.Id);
                    writer.Write(SecindDataSplitter + (int)question.Type);
                    writer.Write(SecindDataSplitter + question.Text);

                    switch (question.Type)
                    {
                        case QuestionEnum.TextQuestion:
                            if (question.ListAnswer[0].IsCorrect)
                            {
                                if (question.ListAnswer[0].Text == "")
                                    writer.Write(SecindDataSplitter + " ");
                                else
                                    writer.Write(SecindDataSplitter + question.ListAnswer[0].Text);
                            }
                            break;
                        case QuestionEnum.SingleChoiceQuestion:

                            break;
                        case QuestionEnum.MultiChoiceQuestion:

                            break;
                        default:                            
                            break;
                    }
                }

                writer.Close();
            }
        }

        public bool SaveFile(Test test)
        {
            string path = $"Tests\\{test.Name}.txt";
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
