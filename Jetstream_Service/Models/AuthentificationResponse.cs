using JetStream_Service.ViewModels;
using System.Text.Json.Serialization;

namespace JetStream_Service.Models
{

    public class AuthentificationResponse : ViewModelBase
    {
        private string _jwt;
        [JsonPropertyName("token")]
        public string jwt
        {
            get { return _jwt; }
            set
            {
                if (_jwt != value)
                {
                    SetProperty(ref _jwt, value);
                }
            }
        }
    }
}
