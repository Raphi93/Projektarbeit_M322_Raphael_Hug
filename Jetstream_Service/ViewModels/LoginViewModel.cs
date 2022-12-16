using JetStream_Service.Models;
using JetStream_Service.Utility;
using JetStream_Service.View;
using RestSharp;
using System;
using System.Text.Json;
using System.Windows;

namespace JetStream_Service.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {

        public string JwtKey { get; set; }
        public string RegistrationURL { get; set; }

        public Action CloseAction { get; set; }
        private RelayCommand _cmdSendenlogin;
        private RelayCommand _cmdExitLogin;

        private Authentification _authentification = new Authentification();

        private bool _IsIndeterminate = new bool();

        public string ApiLink { get; set; }


        public Authentification Authentifications
        {
            get { return _authentification; }
            set
            {
                if (value != _authentification)
                {
                    SetProperty<Authentification>(ref _authentification, value);
                }
            }
        }

        public bool IsIndeterminate
        {
            get { return _IsIndeterminate; }
            set
            {
                if (value != _IsIndeterminate)
                {
                    SetProperty(ref _IsIndeterminate, value);
                }
            }
        }

        public LoginViewModel()
        {

            _cmdSendenlogin = new RelayCommand(param => Execute_Senden(), param => CanExecute_Senden());
            _cmdExitLogin = new RelayCommand(param => Execute_Exit(), param => CanExecute_Exit());
            ApiLink = Properties.Settings.Default.APILink;
            JwtKey = Properties.Settings.Default.JWTToken;
            string baseURL = Properties.Settings.Default.APILink;
            string regi = Properties.Settings.Default.registrationLink;
            RegistrationURL = baseURL + regi;
        }

        public RelayCommand CmdSendenLogin
        {
            get { return _cmdSendenlogin; }
            set { _cmdSendenlogin = value; }
        }

        public RelayCommand CmdExitLogin
        {
            get { return _cmdExitLogin; }
            set { _cmdExitLogin = value; }
        }

        private void Execute_Senden()
        {
            string json = JsonSerializer.Serialize<Authentification>(Authentifications);

            var options = new RestClientOptions(ApiLink + "/UserToken/login")
            {
                MaxTimeout = 10000,
                ThrowOnAnyError = true
            };
            var client = new RestClient(options);

            var request = new RestRequest()
                .AddJsonBody(json);

            var response = client.Post(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                AuthentificationResponse authResponse = new AuthentificationResponse();
                authResponse = JsonSerializer.Deserialize<AuthentificationResponse>(response.Content);
                Properties.Settings.Default.JWTToken = authResponse.jwt;
                Properties.Settings.Default.Save();
                CloseAction();
            }
            else
            {
                MessageBox.Show($"{response.StatusCode}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            CloseAction();
        }

        private bool CanExecute_Senden()
        {
            if (Authentifications == null)
                return false;
            else
                return Authentifications.User != null && Authentifications.Password != null && Authentifications.User != "" && Authentifications.Password != "";
        }

        private void Execute_Exit()
        {
            Login_User loginView = new Login_User();
            loginView.DialogResult = false;
            CloseAction();
        }

        private bool CanExecute_Exit()
        {
            return true;
        }

    }
}
