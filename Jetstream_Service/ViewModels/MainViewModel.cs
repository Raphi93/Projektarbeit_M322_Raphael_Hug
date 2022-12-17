using JetStream_Service.Models;
using JetStream_Service.Utility;
using JetStream_Service.View;
using JetStream_Service.Views;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        private string _SearchContent;
        private bool _IsIndeterminate = new bool();

        public string keyJwt { get; set; }
        public string RegistrationURL { get; set; }

        public Action CloseAction { get; set; }
        private RelayCommand _cmdNew;
        private RelayCommand _cmdLogin;
        private RelayCommand _cmdUpdate;
        private RelayCommand _cmdDetail;
        private RelayCommand _cmdDelete;
        private RelayCommand _cmdRefresh;
        private RelayCommand _cmdExit;
        private RelayCommand _cmdSearch;


        public MainViewModel()
        {
            _cmdNew = new RelayCommand(param => Execute_New(), param => CanExecute_New());
            _cmdUpdate = new RelayCommand(param => Execute_Update(), param => CanExecute_Update());
            _cmdDetail = new RelayCommand(param => Execute_Detail(), param => CanExecute_Detail());
            _cmdDelete = new RelayCommand(param => Execute_Delete(), param => CanExecute_Delete());
            _cmdRefresh = new RelayCommand(param => Execute_Refresh(), param => CanExecute_Refresh());
            _cmdLogin = new RelayCommand(param => Execute_Login(), param => CanExecute_Login());
            _cmdExit = new RelayCommand(param => Execute_Exit(), param => CanExecute_Exit());
            _cmdSearch = new RelayCommand(param => Execute_Search(), param => CanExecute_Search());

            keyJwt = Properties.Settings.Default.JWTToken;
            string baseURL = Properties.Settings.Default.APILink;
            string regi = Properties.Settings.Default.registrationLink;
            RegistrationURL = baseURL + regi;
            Content.IsIndeterminate = false;
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

        public string SearchContent
        {
            get { return _SearchContent; }
            set
            {
                if (value != _SearchContent)
                {
                    SetProperty(ref _SearchContent, value);
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

        private void Execute_New()
        {
            New_User new_User = new New_User();
            new_User.Show();
            Execute_Refresh();
        }

        private bool CanExecute_New()
        {
            return true;

        }
        private void Execute_Search()
        {
            Content.IsIndeterminate = true;
            try
            {
                Execute_Refresh();
                IEnumerable<RegistrationModel> filteredOrder;
                filteredOrder = Registrations.Where
                    (x => x.Name.Contains(SearchContent, StringComparison.OrdinalIgnoreCase) ||
                    x.Id.ToString().Contains(SearchContent, StringComparison.OrdinalIgnoreCase) ||
                    x.Phone.Contains(SearchContent, StringComparison.OrdinalIgnoreCase) ||
                    x.EMail.Contains(SearchContent, StringComparison.OrdinalIgnoreCase) ||
                    x.Priority.Contains(SearchContent, StringComparison.OrdinalIgnoreCase) ||
                    x.Service.Contains(SearchContent, StringComparison.OrdinalIgnoreCase) ||
                    x.Status.Contains(SearchContent, StringComparison.OrdinalIgnoreCase));
                var filteredOrderCollection = new ObservableCollection<RegistrationModel>(filteredOrder);
                Registrations = filteredOrderCollection;
            }
            catch (Exception ex)
            {
                Content.Status = "Error: " + ex.Message;
            }
            finally
            {
                SearchContent = "";
            }
        }

        private bool CanExecute_Search()
        {
            if (Registrations.Count == 0)
                return false;
            else
                return SearchContent != null && SearchContent != "";
        }

        private void Execute_Update()
        {
            Content.IsIndeterminate = true;
            try
            {
                RegistrationModel regi = new RegistrationModel();
                regi = SelectedRegistartion;
                string id = SelectedRegistartion.Id.ToString();

                Edit_User edit_User = new Edit_User(regi);
                edit_User.ShowDialog();

                if (edit_User.DialogResult == true)
                {
                    string json = JsonSerializer.Serialize<RegistrationModel>(regi);

                    var options = new RestClientOptions($"{RegistrationURL}/{id}")
                    {
                        MaxTimeout = 10000,
                        ThrowOnAnyError = true
                    };
                    var client = new RestClient(options);

                    var request = new RestRequest()
                        .AddHeader("Authorization", $"Bearer " + keyJwt)
                        .AddJsonBody(json);

                    var response = client.Put(request);
                    Content.Status = "Status Code: " + response.StatusCode;
                }
                else if (edit_User.DialogResult == false)
                {
                    Content.Status = "Canceled changes";
                }
            }
            catch (Exception ex)
            {
                Content.Status = "Error: " + ex.Message;
            }
            finally
            {
                Content.IsIndeterminate = false;
            }
        }

        private bool CanExecute_Update()
        {
            if (SelectedRegistartion == null)
                return false;
            else
                return SelectedRegistartion.Id != null;
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
            if (SelectedRegistartion == null)
                return false;
            else
                return SelectedRegistartion.Id != null;
        }

        private void Execute_Delete()
        {
            Content.IsIndeterminate = true;
            try
            {
                RegistrationModel regi = new RegistrationModel();
                regi = SelectedRegistartion;
                string id = SelectedRegistartion.Id.ToString();
                var options = new RestClientOptions($"{RegistrationURL}/{id}")
                {
                    MaxTimeout = 10000,
                    ThrowOnAnyError = true
                };
                var client = new RestClient(options);

                var request = new RestRequest()
                    .AddHeader("Authorization", $"Bearer " + keyJwt);

                var response = client.Delete(request);

                Content.Status = "Status Code: " + response.StatusCode;
                Execute_Refresh();
            }
            catch (Exception ex)
            {
                Content.Status = "Error: " + ex.Message;
            }
            finally
            {
                Content.IsIndeterminate = false;
            }
        }

        private bool CanExecute_Delete()
        {
            if (SelectedRegistartion == null)
                return false;
            else
                return SelectedRegistartion.Id != null;
        }

        public void Execute_Refresh()
        {
            Content.IsIndeterminate = true;
            try
            {
                var options = new RestClientOptions(RegistrationURL)
                {
                    MaxTimeout = 10000,
                    ThrowOnAnyError = true
                };
                var client = new RestClient(options);

                var request = new RestRequest()
                    .AddHeader("Authorization", $"Bearer " + keyJwt);

                var response = client.Get(request);
                var statusCode = "Status Code: " + response.StatusCode;

                Registrations = JsonSerializer.Deserialize<ObservableCollection<RegistrationModel>>(response.Content);
                Content.Status = statusCode;
            }
            catch (Exception ex)
            {
                Content.Status = "Error: " + ex.Message;
            }
            finally
            {
                Content.IsIndeterminate = false;
            }
        }

        public bool CanExecute_Refresh()
        {
            return true;
        }

        private void Execute_Login()
        {
            Login_User login_User = new Login_User();
            login_User.ShowDialog();
            Execute_Refresh();
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

        public RelayCommand CmdSearch
        {
            get { return _cmdSearch; }
            set { _cmdSearch = value; }
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
        public Content Content
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

    }
}
