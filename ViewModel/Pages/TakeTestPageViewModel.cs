using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_BKStudia.Infrastructure.Navigation;
using WPF_BKStudia.Infrastructure.Services;
using WPF_BKStudia.Model;

namespace WPF_BKStudia.ViewModel.Pages
{
    internal class TakeTestPageViewModel: ViewModel.Base.ViewModel
    {
        public TakeTestPageViewModel(NavigationStore navigationStore) 
        {
            //TestModel test = navigationStore.Param as TestModel;
            //FileReader fileReader = new FileReader();
            //test = fileReader.ReadFile(test.Name);
        }
    }
}
