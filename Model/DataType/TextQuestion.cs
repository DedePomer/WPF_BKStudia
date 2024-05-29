﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media;
using WPF_BKStudia.Infrastructure.Enums;
using WPF_BKStudia.Infrastructure.Interfaces;
using WPF_BKStudia.Model.Abstaracts;

namespace WPF_BKStudia.Model.DataType
{
    //Номер, тектс вопроса, тип вопроса, список ответов, Цвет вопроса

    public class TextQuestion : AbstractNotifyModel,  INotifyPropertyChanged, IQuestionAnswer
    {
        //Приватные поля
        private int _id;
        private QuestionEnum _type;
        private SolidColorBrush _questionColor;
        private ObservableCollection<Answer>? _answer;

        //Свойства
        public int Id 
        {
            get 
            { return _id; }
            set 
            { 
                _id = value;
                NotifyPropertyChanged();
            }
        }
        public string Text { get; set; }
        public QuestionEnum Type
        {
            get
            { return _type; }
            set
            { 
                _type = value;
                NotifyPropertyChanged();
            }
        }
        public ObservableCollection<Answer>? Answer
        {
            get
            { return _answer; }
            set
            {
                _answer = value;
                NotifyPropertyChanged();
            }
        }
        public ObservableCollection<Answer>? ListAnswer { get; set; }
        public SolidColorBrush QuestionColor
        {
            get
            { return _questionColor; }
            set
            {
                _questionColor = value;
                NotifyPropertyChanged();
            }
        }
    }
}
