using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_BKStudia.Infrastructure.Services;

namespace WPF_BKStudia.Infrastructure.Interfaces
{
    public interface IQuestion
    {
        public int Id { get; set; }
        public string NameQuestion { get; set; }
        public QuestionEnum Enum { get; set; }
    }
}
