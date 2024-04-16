using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_BKStudia.Infrastructure.Services;

namespace WPF_BKStudia.Infrastructure.Interfaces
{
    public interface IQuestion
    {
        /// <summary>
        /// <typeparam name = "Id">Номер вопроса в тесте</typeparam>
        /// </summary>
        public int? Id { get ; set ; }
        /// <summary>
        /// <typeparam name = "NameQuestion">Вопрос, на который нужно ответить</typeparam>
        /// </summary>
        public string? NameQuestion { get; set; }
        /// <summary>
        /// <typeparam name = "Type">Тип вопроса</typeparam>
        /// </summary>
        public QuestionEnum? Type { get; set; }
    }
}
