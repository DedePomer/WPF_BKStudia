﻿namespace WPF_BKStudia.Infrastructure.Interfaces
{
    public interface IQuestionAnswer
    {
        /// <summary>
        /// <typeparam name = "Id">Индификатор вопроса (ответа)</typeparam>
        /// </summary>
        public int Id { get ; set ; }
        /// <summary>
        /// <typeparam name = "Text">Текст вопроса (ответа)</typeparam>
        /// </summary>
        public string Text { get; set; }
    }
}
