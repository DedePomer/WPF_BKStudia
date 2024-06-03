﻿using System.Collections.ObjectModel;
using WPF_BKStudia.Model.DataType;

namespace WPF_BKStudia.Infrastructure.Interfaces
{
    public interface IFileReaderService
    {
        int GetCountQuestions(string path);
        public ObservableCollection<TextQuestion> GetQuestionCollection(string path);
    }
}
