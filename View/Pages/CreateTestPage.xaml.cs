using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_BKStudia.Infrastructure.Interfaces;
using WPF_BKStudia.Infrastructure.Services;
using WPF_BKStudia.Infrastructure.Services.DataType;
using WPF_BKStudia.Model;

namespace WPF_BKStudia.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для CreateTestPage.xaml
    /// </summary>
    public partial class CreateTestPage : UserControl
    {
        public CreateTestPage()
        {
            InitializeComponent();
            //TextQuestion textQuestion = new TextQuestion 
            //{ 
            //    Id = 1,
            //    NameQuestion ="as",
            //    Type = QuestionEnum.TextQuestion,
            //    Answer = "as"
            //};
            ////Попробуй создать абстрактный класс
            //ObservableCollection<TextQuestion> bb = new ObservableCollection<TextQuestion>(); 
            //bb.Add(textQuestion);
            //bb.Add(textQuestion);
            //TestModel<TextQuestion> model = new TestModel<TextQuestion>
            //{
            //    Name = "Hiz",
            //    Questions = bb
            //};
            //ItemS.ItemsSource = bb;



        }
    }
}
