﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO.Packaging;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WPF_BKStudia.Infrastructure.Interfaces;
using WPF_BKStudia.Infrastructure.Services;
using WPF_BKStudia.ViewModel.Pages;

namespace WPF_BKStudia.Model.DataType
{
    //Номер, тектс вопроса, тип вопроса, список ответов, Цвет вопроса + реализация метода INotifyPropertyChanged

    //ВАЖНО!!! Попробуй использовать делегат для INotifyPropertyChanged
    //ВАЖНО!!! Попробуй использовать делегат для INotifyPropertyChanged
    //ВАЖНО!!! Попробуй использовать делегат для INotifyPropertyChanged
    public class TextQuestion :  INotifyPropertyChanged, IQuestionAnswer
    {
        //Приватные поля
        private int _id;
        private QuestionEnum _type;

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
        public ObservableCollection<Answer>? ListAnswer { get; set; }
        public SolidColorBrush QuestionColor { get; set; }

        //Реализация интерфейса INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
