using JetStream_Service.Models;
using JetStream_Service.Utility;
using JetStream_Service.View;
using JetStream_Service.Views;
using RestSharp;
using System;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace JetStream_Service.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<RegistrationModel> _registration = new ObservableCollection<RegistrationModel>();
        private RegistrationModel _selectedRegistartion = new RegistrationModel();
        private Content _content = new Content();
        private bool _IsIndeterminate = new bool();


        public string jwtKey { get; set; }
        public string registrationURL { get; set; }


        //private RegistrationModel _selectRegistration = new RegistrationModel();

        public Action CloseAction { get; set; }
        private RelayCommand _cmdNew;
        private RelayCommand _cmdLogin;
        private RelayCommand _cmdUpdate;
        private RelayCommand _cmdDetail;
        private RelayCommand _cmdDelete;
        private RelayCommand _cmdRefresh;
        private RelayCommand _cmdExit;
        private RelayCommand _cmdExitDetail;

        public MainViewModel()
        {
            _cmdNew = new RelayCommand(param => Execute_New(), param => CanExecute_New());
            _cmdUpdate = new RelayCommand(param => Execute_Update(), param => CanExecute_Update());
            _cmdDetail = new RelayCommand(param => Execute_Detail(), param => CanExecute_Detail());
            _cmdDelete = new RelayCommand(param => Execute_Delete(), param => CanExecute_Delete());
            _cmdRefresh = new RelayCommand(param => Execute_Refresh(), param => CanExecute_Refresh());
            _cmdLogin = new RelayCommand(param => Execute_Login(), param => CanExecute_Login());
            _cmdExit = new RelayCommand(param => Execute_Exit(), param => CanExecute_Exit());
            _cmdExitDetail = new RelayCommand(param => Execute_ExitDetail(), param => CanExecute_ExitDetail());

            jwtKey = Properties.Settings.Default.JWTToken;
            string baseURL = Properties.Settings.Default.APILink;
            string regi = Properties.Settings.Default.registrationLink;
            registrationURL = baseURL + regi;
        }

        public ObservableCollection<RegistrationModel> Registrations
        {
            get { return _registration; }
            set
            {
                if (value != _registration)
                {
                    SetProperty<ObservableCollection<RegistrationModel>>(ref _registration, value);
                }
            }
        }

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

        

        public Content content
        {
            get { return _content; }
            set
            {
                if (value != _content)
                {
                    SetProperty<Content>(ref _content, value);
                }
            }
        }

        private void Execute_New()
        {
            New_User new_User = new New_User();
            new_User.Show();
        }

        private bool CanExecute_New()
        {
            return true;

        }

        private void Execute_Update()
        {
            Edit_User edit_User = new Edit_User();
            edit_User.Show();
        }

        private bool CanExecute_Update()
        {
            return true;
        }

        private void Execute_Detail()
        {
            RegistrationModel regi = new RegistrationModel();
            regi = SelectedRegistartion;
            Detail_User detail_User = new Detail_User(regi);
            detail_User.Show();
        }

        private bool CanExecute_Detail()
        {
            return true;
        }

        private void Execute_Delete()
        {

        }

        private bool CanExecute_Delete()
        {
            return true;
        }

        public void Execute_Refresh()
        {
            var options = new RestClientOptions(registrationURL)
            {
                MaxTimeout = 10000,
                ThrowOnAnyError = true
            };
            var client = new RestClient(options);

            var request = new RestRequest()
                .AddHeader("Authorization", $"Bearer " + jwtKey);

            var response = client.Get(request);
            var statusCode = "Status Code: " + response.StatusCode;

            Registrations = JsonSerializer.Deserialize<ObservableCollection<RegistrationModel>>(response.Content);
            //content.status = statusCode;
        }

        public bool CanExecute_Refresh()
        {
            return true;
        }

        private void Execute_Login()
        {
            Login_User login_User = new Login_User();
            login_User.Show();
        }

        private bool CanExecute_Login()
        {
            return true;
        }

        private void Execute_Exit()
        {

            MessageBoxResult result = MessageBox.Show($" Wollen Sie wirklich beenden?",
               "Begrüssung",
               MessageBoxButton.YesNo,
               MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
                CloseAction();
        }

        private bool CanExecute_Exit()
        {
            return true;
        }


        public RelayCommand CmdNew
        {
            get { return _cmdNew; }
            set { _cmdNew = value; }
        }

        public RelayCommand CmdLogin
        {
            get { return _cmdLogin; }
            set { _cmdLogin = value; }
        }

        public RelayCommand CmdDelete
        {
            get { return _cmdDelete; }
            set { _cmdDelete = value; }
        }

        public RelayCommand CmdUpdate
        {
            get { return _cmdUpdate; }
            set { _cmdUpdate = value; }
        }

        public RelayCommand CmdRefresh
        {
            get { return _cmdRefresh; }
            set { _cmdRefresh = value; }
        }

        public RelayCommand CmdDetail
        {
            get { return _cmdDetail; }
            set { _cmdDetail = value; }
        }

        public RelayCommand CmdExit
        {
            get { return _cmdExit; }
            set { _cmdExit = value; }
        }

        public RelayCommand CmdExitEdit
        {
            get { return _cmdExitDetail; }
            set { _cmdExitDetail = value; }
        }

        private void Execute_ExitDetail()
        {
            CloseAction();
        }

        private bool CanExecute_ExitDetail()
        {
            return true;
        }

    }
}
