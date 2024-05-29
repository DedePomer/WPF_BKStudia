using WPF_BKStudia.Infrastructure.Interfaces;

namespace WPF_BKStudia.Model.DataType
{
    //Номер, текст ответа и поле указывающее верный вопрос или нет 
    public class Answer : IQuestionAnswer
    {
        public int Id { get; set; }

        public string Text { get; set; } = default!;

        public bool IsCorrect { get; set; }
    }
}
