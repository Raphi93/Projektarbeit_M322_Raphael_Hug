using JetStream_Service.Utility;
using System;

namespace JetStream_Service.ViewModels
{
    internal class NewViewModel : ViewModelBase
    {

        public Action CloseAction { get; set; }
        private RelayCommand _cmdSendenNew;
        private RelayCommand _cmdExitNew;

        public NewViewModel()
        {

            _cmdSendenNew = new RelayCommand(param => Execute_Senden(), param => CanExecute_Senden());
            _cmdExitNew = new RelayCommand(param => Execute_Exit(), param => CanExecute_Exit());
        }

        public RelayCommand CmdSendenNew
        {
            get { return _cmdSendenNew; }
            set { _cmdSendenNew = value; }
        }

        public RelayCommand CmdExitNew
        {
            get { return _cmdExitNew; }
            set { _cmdExitNew = value; }
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
