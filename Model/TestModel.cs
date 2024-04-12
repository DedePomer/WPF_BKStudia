﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_BKStudia.Infrastructure.Services.DataType;

namespace WPF_BKStudia.Model
{
    internal class TestModel
    {
        //Модель где "содержаться" название теста и коллекция вопросов
        public string Name { get; set; }
        public ObservableCollection<Question>? Questions { get; set; }
    }
}
