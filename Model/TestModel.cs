﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WPF_BKStudia.Infrastructure.Interfaces;
using WPF_BKStudia.Model.Abstaracts;
using WPF_BKStudia.Model.DataType;

namespace WPF_BKStudia.Model
{
    public class TestModel : AbstractINotifyProperty, INotifyPropertyChanged
    {
        //Модель где "содержаться" название теста и коллекция вопросов
        private int? _id;
        public int? Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                NotifyPropertyChanged();
            }
        }
        public string? Name { get; set; }
        public ObservableCollection<TextQuestion>? QuestionCollection { get; set; }
        public int? Quanty { get; set; }
    }
}
