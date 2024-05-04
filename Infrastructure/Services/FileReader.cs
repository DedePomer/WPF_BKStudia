using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_BKStudia.Model.DataType;

namespace WPF_BKStudia.Infrastructure.Services
{
    public class FileReader
    {
        public int GetCountQuestions(string path)
        {
            List<string> fileStr = File.ReadLines(path).ToList();
            return int.Parse(fileStr[1]);
        }
    }
}
