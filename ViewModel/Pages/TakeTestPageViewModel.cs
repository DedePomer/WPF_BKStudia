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
        private INavigationStoreService _navigationStoreService { get; set; }
        private IFileReaderService _fileReaderService { get; set; }
        private IFileWriterService _fileWriterService { get; set; }


        public TakeTestPageViewModel(INavigationStoreService navigationStoreService, IFileReaderService fileReaderService, IFileWriterService fileWriterService) 
        {
            _navigationStoreService = navigationStoreService;
            _fileReaderService = fileReaderService;
            _fileWriterService = fileWriterService;

            TestModel test = _navigationStoreService.Param as TestModel;
            test.QuestionCollection = _fileReaderService.GetQuestionCollection(test.Name);
        }
    }
}
