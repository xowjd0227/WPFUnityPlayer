using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
namespace WPFUnityPlayer.ViewModels
{
    using Prism.Commands;
    using Prism.Mvvm;
    using WPFUnityPlayer.Utils.Unity;

    public class MainWindowViewModel : BindableBase
    {
        private DelegateCommand<object> mainWIndowLoadedCommand;
        public DelegateCommand<object> MainWindowLoadedCommand => mainWIndowLoadedCommand ?? (mainWIndowLoadedCommand = new DelegateCommand<object>(ExecuteMainWindowLoaded));

        public MainWindowViewModel()
        { 
        }

        protected virtual void ExecuteMainWindowLoaded(object unityViewParent)
        {
            Border parentBorder = unityViewParent as Border;
            if (parentBorder != null)
            {
                parentBorder.Child = new UnityWindowHost(parentBorder.ActualWidth, parentBorder.ActualHeight);
            }
        }
    }
}
