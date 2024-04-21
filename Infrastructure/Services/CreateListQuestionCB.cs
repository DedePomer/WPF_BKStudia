using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_BKStudia.Model.DataType;

namespace WPF_BKStudia.Infrastructure.Services
{
    //Получаем список, заполненный типами вопросов 
    internal class CreateListQuestionCB
    {
        public ObservableCollection<QuestionComboBox> CreateList(ObservableCollection<QuestionComboBox>? boxes)
        {
            if (boxes == null) boxes = new ObservableCollection<QuestionComboBox>();
            boxes.Add(new QuestionComboBox()
            {
                Text = "Строка",
                Type = QuestionEnum.TextQuestion
            });
            boxes.Add(new QuestionComboBox()
            {
                Text = "Одиночный выбор",
                Type = QuestionEnum.SingleChoiceQuestion
            });
            boxes.Add(new QuestionComboBox()
            {
                Text = "Множественный выбор",
                Type = QuestionEnum.MultiChoiceQuestion
            });
            return boxes;
        }
    }
}
