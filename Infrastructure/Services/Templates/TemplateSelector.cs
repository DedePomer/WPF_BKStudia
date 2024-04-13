using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WPF_BKStudia.Infrastructure.Interfaces;

namespace WPF_BKStudia.Infrastructure.Services.Templates
{
    internal class TemplateSelector: DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;

            if (element != null && item != null && item is IQuestion)
            {
                IQuestion question = item as IQuestion;

                if (question.Enum.Equals(QuestionEnum.TextQuestion))
                    return element.FindResource("TextQuestionTemplate") as DataTemplate;
                else if (question.Enum.Equals(QuestionEnum.SingleChoiceQuestion))
                    return element.FindResource("SingleChoiceTemplate") as DataTemplate;
                else if (question.Enum.Equals(QuestionEnum.MultiChoiceQuestion))
                    return element.FindResource("MultiChoiceTemplate") as DataTemplate;

                return element.FindResource("TextQuestionTemplate") as DataTemplate;
            }

            return null;

        }
    }
}
