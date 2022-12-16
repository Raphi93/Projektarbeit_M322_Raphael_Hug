using JetStream_Service.Utility;
using JetStream_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JetStream_Service.ViewModels
{
    public class DetailViewModel : ViewModelBase
    {
        public Action CloseAction { get; set; }
        private RelayCommand _cmdExitDetail;
        private RegistrationModel _selectedRegistartion = new RegistrationModel();

        public RegistrationModel SelectedRegistartion
        {
            get { return _selectedRegistartion; }
            set
            {
                if (value != _selectedRegistartion)
                {
                    SetProperty<RegistrationModel>(ref _selectedRegistartion, value);
                }
            }
        }

        public DetailViewModel(RegistrationModel regi)
        {
            _selectedRegistartion = regi;
            _cmdExitDetail = new RelayCommand(param => Execute_Exit(), param => CanExecute_Exit());
        }

        public RelayCommand CmdExitEdit
        {
            get { return _cmdExitDetail; }
            set { _cmdExitDetail = value; }
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
