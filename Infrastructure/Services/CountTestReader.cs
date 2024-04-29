using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_BKStudia.Infrastructure.Services
{
    public class CountTestReader
    {
        public int Count(string path)
        {
            string testText = File.ReadAllText(path);
            return (testText.Length - testText.Replace("\n\n\n","").Length)/ "\n\n\n".Length;
        }
    }

}
