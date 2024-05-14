using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_BKStudia.Model;

namespace WPF_BKStudia.Infrastructure.Interfaces
{
    public interface IFileWriterService
    {
        bool SaveFile(TestModel test);
    }
}
