using JetStream_Service.ViewModels;
using System.Text.Json.Serialization;

namespace JetStream_Service.Models
{
    public class Authentification : ViewModelBase
    {

        private string _user;
        [JsonPropertyName("user_name")]
        public string User
        {
            get { return _user; }
            set
            {
                if (_user != value)
                {
                    SetProperty(ref _user, value);
                }
            }
        }
        private string _password;
        [JsonPropertyName("password")]
        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    SetProperty(ref _password, value);
                }
            }
        }
    }
}
