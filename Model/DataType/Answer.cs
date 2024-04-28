using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_BKStudia.Infrastructure.Interfaces;

namespace WPF_BKStudia.Model.DataType
{
    //Номер, текст ответа и поле указывающее верный вопрос или нет 
    public class Answer : IQuestionAnswer
    {
        public int Id { get; set; }
        public string Text { get; set; }
        /// <summary>
        /// <typeparam name="IsTrue">true - verny otvet, false - ne verny otvet</typeparam>
        /// </summary>
        public bool IsTrue { get; set; }
    }
}
