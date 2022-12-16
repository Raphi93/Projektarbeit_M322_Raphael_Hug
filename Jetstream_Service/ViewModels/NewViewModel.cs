using JetStream_Service.Models;
using JetStream_Service.Properties;
using JetStream_Service.Utility;
using RestSharp;
using System;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows.Controls;

namespace JetStream_Service.ViewModels
{
    public class NewViewModel : ViewModelBase
    {
        private RegistrationModel _registration = new RegistrationModel();
        public string RegistrationURL { get; set; }
        public Action CloseAction { get; set; }
        private RelayCommand _cmdSendenNew;
        private RelayCommand _cmdExitNew;

        public NewViewModel()
        {

            _cmdSendenNew = new RelayCommand(param => Execute_Senden(), param => CanExecute_Senden());
            _cmdExitNew = new RelayCommand(param => Execute_Exit(), param => CanExecute_Exit());

            Registration.Status = "Offen";
            Registration.CreateDate = DateTime.Now;
            RegistrationURL = Settings.Default.APILink + Settings.Default.registrationLink;
        }

        public RegistrationModel Registration
        {
            get { return _registration; }
            set
            {
                if (value != _registration)
                {
                    SetProperty<RegistrationModel>(ref _registration, value);
                }
            }
        }

        private string _priority;
        public string Priority
        {
            get { return _priority; }
            set
            {
                if (value != _priority)
                {
                    SetProperty(ref _priority, value);
                }
                if (_priority == "Express")
                {
                    Registration.PickupDate = Registration.CreateDate.AddDays(5);

                }
                else if (_priority == "Tief")
                {
                    Registration.PickupDate = Registration.CreateDate.AddDays(12);
                }
                else
                {
                    Registration.PickupDate = Registration.CreateDate.AddDays(7);
                }
            }
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
            if (Registration.Kommentar == null)
                Registration.Kommentar = "";

            string json = JsonSerializer.Serialize<RegistrationModel>(Registration);

            var options = new RestClientOptions(RegistrationURL)
            {
                MaxTimeout = 10000,
                ThrowOnAnyError = true
            };
            var client = new RestClient(options);

            var request = new RestRequest()
                .AddJsonBody(json);

            var response = client.Post(request);
            CloseAction();
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
