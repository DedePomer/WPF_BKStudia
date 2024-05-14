using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_BKStudia.Infrastructure.Interfaces
{
    public interface INavigationStoreService
    {
        ViewModel.Base.ViewModel? CurrentViewModel { get; set; }
        object Param { get; set; }
        event Action CurrentViewModelChanged;
    }
}
