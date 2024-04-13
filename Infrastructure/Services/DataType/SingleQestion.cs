using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_BKStudia.Infrastructure.Interfaces;

namespace WPF_BKStudia.Infrastructure.Services.DataType
{
    internal class SingleQestion : IQuestion
    {
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string NameQuestion { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public QuestionEnum Enum { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
