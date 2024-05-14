using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_BKStudia.Infrastructure.Interfaces;
using WPF_BKStudia.Infrastructure.Navigation;
using WPF_BKStudia.Infrastructure.Services;
using WPF_BKStudia.Model;

namespace WPF_BKStudia.ViewModel.Pages
{
    internal class TakeTestPageViewModel: ViewModel.Base.ViewModel
    {
        private IFileReaderService _fileReaderService { get; set; }
        public TakeTestPageViewModel(NavigationStore navigationStore, IFileReaderService fileReaderService) 
        {
            _fileReaderService = fileReaderService;
            TestModel test = navigationStore.Param as TestModel;
            test.QuestionCollection = _fileReaderService.GetQuestionCollection(test.Name);
        }
    }
}
