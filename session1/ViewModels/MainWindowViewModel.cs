using session1.Infrastructure.Commands;
using session1.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace session1.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region Заголовок окна
        private string _Title = "Приложение с#";

        /// <summary>Заголовок окна</summary>
        public string Title
        {
            get => _Title;

            // set
            // {
            //  if (Equals(Title, value)) return;
            //  _Title = value;
            //  OnPropertyChanged();
            // }

            set => Set(ref _Title, value);

        }
        #endregion

        #region Команды


        #region CloseApplicationCommand
        public ICommand CloseApplicationCommand { get; }

        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }
        private bool CanCloseApplicationCommandExecute(object p) => true; 
        #endregion

        // Other commands
        #endregion
        public MainWindowViewModel()
        {
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
        }
    }
}
