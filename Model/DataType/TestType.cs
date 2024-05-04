using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_BKStudia.Model.DataType
{
    //Номер и название теста
    class TestType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public int GetCountQuantity()
        {
            string testText;
            if (Name != null)
            {
                testText = File.ReadAllText(Name);
                return (testText.Length - testText.Replace("\n\n\n", "").Length) / "\n\n\n".Length;
            }
            return -1;
        }
    }
}
