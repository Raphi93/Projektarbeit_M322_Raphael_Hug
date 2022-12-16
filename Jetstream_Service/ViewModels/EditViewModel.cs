using JetStream_Service.Utility;
using System;

namespace JetStream_Service.ViewModels
{
    public class EditViewModel : ViewModelBase
    {
        public Action CloseAction { get; set; }
        private RelayCommand _cmdSendenEdit;
        private RelayCommand _cmdExitEdit;

        public EditViewModel()
        {

            _cmdSendenEdit = new RelayCommand(param => Execute_Senden(), param => CanExecute_Senden());
            _cmdExitEdit = new RelayCommand(param => Execute_Exit(), param => CanExecute_Exit());
        }

        public RelayCommand CmdSendenEdit
        {
            get { return _cmdSendenEdit; }
            set { _cmdSendenEdit = value; }
        }

        public RelayCommand CmdExitEdit
        {
            get { return _cmdExitEdit; }
            set { _cmdExitEdit = value; }
        }

        private void Execute_Senden()
        {

        }

        private bool CanExecute_Senden()
        {
            return true;
        }

        private void Execute_Exit()
        {
            CloseAction();
        }

        private bool CanExecute_Exit()
        {
            return true;
        }
    }
}
