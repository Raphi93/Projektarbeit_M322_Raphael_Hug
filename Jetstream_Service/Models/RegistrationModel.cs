using JetStream_Service.ViewModels;
using System;
using System.Text.Json.Serialization;

namespace JetStream_Service.Models
{
    public class RegistrationModel : ViewModelBase
    {
        private int _Id;
        [JsonPropertyName("id")]
        public int Id
        {
            get { return (int)_Id; }
            set
            {
                if (_Id != value)
                {
                    SetProperty(ref _Id, value);
                }
            }
        }

        private string _Name;
        [JsonPropertyName("name")]
        public string? Name
        {
            get { return _Name; }
            set
            {
                if (_Name != value)
                {
                    SetProperty(ref _Name, value);
                }
            }
        }

        private string? _Email;
        [JsonPropertyName("email")]
        public string? EMail
        {
            get { return _Email; }
            set
            {
                if (_Email != value)
                {
                    SetProperty(ref _Email, value);
                }
            }
        }

        private string _Phone;
        [JsonPropertyName("phone")]
        public string? Phone
        {
            get { return _Phone; }
            set
            {
                if (_Phone != value)
                {
                    SetProperty(ref _Phone, value);
                }
            }
        }

        private string _Priority;
        [JsonPropertyName("priority")]
        public string? Priority
        {
            get { return _Priority; }
            set
            {
                if (_Priority != value)
                {
                    SetProperty(ref _Priority, value);
                }
            }
        }

        private string _Service;
        [JsonPropertyName("service")]
        public string? Service
        {
            get { return _Service; }
            set
            {
                if (_Service != value)
                {
                    SetProperty(ref _Service, value);
                }
            }
        }

        private string _Status;
        [JsonPropertyName("status")]
        public string? Status
        {
            get { return _Status; }
            set
            {
                if (_Status != value)
                {
                    SetProperty(ref _Status, value);
                }
            }
        }

        private string _Comment;
        [JsonPropertyName("kommentar")]
        public string? Kommentar
        {
            get { return _Comment; }
            set
            {
                if (_Comment != value)
                {
                    SetProperty(ref _Comment, value);
                }
            }
        }

        private DateTime _CreateDate;
        [JsonPropertyName("create_date")]
        public DateTime CreateDate
        {
            get { return _CreateDate; }
            set
            {
                if (_CreateDate != value)
                {
                    SetProperty(ref _CreateDate, value);
                }
            }
        }

        private DateTime _PickupDate;
        [JsonPropertyName("pickup_date")]
        public DateTime PickupDate
        {
            get { return _PickupDate; }
            set
            {
                if (_PickupDate != value)
                {
                    SetProperty(ref _PickupDate, value);
                }
            }
        }
    }
}
