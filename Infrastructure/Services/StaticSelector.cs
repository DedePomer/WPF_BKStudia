using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WPF_BKStudia.Infrastructure.Interfaces;

namespace WPF_BKStudia.Infrastructure.Services
{
    internal class StaticSelector: DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;

            if (element != null && item != null && item is IQuestionAnswer)
            {
                IQuestionAnswer question = item as IQuestionAnswer;

                if (question.Type.Equals(QuestionEnum.TextQuestion))
                    return element.FindResource("TextQuestionTemplate") as DataTemplate;
                else if (question.Type.Equals(QuestionEnum.SingleChoiceQuestion))
                    return element.FindResource("SingleChoiceQuestionTemplate") as DataTemplate;
                else if (question.Type.Equals(QuestionEnum.MultiChoiceQuestion))
                    return element.FindResource("MultiChoiceQuestionTemplate") as DataTemplate;

                return element.FindResource("TextQuestionTemplate") as DataTemplate;
            }

            return null;

        }
    }

}
