using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using WPF_BKStudia.Infrastructure.Interfaces;
using WPF_BKStudia.Infrastructure.Services;

namespace WPF_BKStudia 
{ 

    public class TestTemplateselector : DataTemplateSelector
    {
            public override DataTemplate SelectTemplate(object item, DependencyObject container)
            {
                FrameworkElement element = container as FrameworkElement;

                if (element != null && item != null && item is IQuestion)
                {
                    IQuestion question = item as IQuestion;

                    if (question.Type.Equals(QuestionEnum.TextQuestion))
                        return element.FindResource("TextQuestionTemplate") as DataTemplate;
                    else if (question.Type.Equals(QuestionEnum.SingleChoiceQuestion))
                        return element.FindResource("SingleChoiceTemplate") as DataTemplate;
                    else if (question.Type.Equals(QuestionEnum.MultiChoiceQuestion))
                        return element.FindResource("MultiChoiceTemplate") as DataTemplate;

                    return element.FindResource("TextQuestionTemplate") as DataTemplate;
                }

                return null;

            }     
    }
}
