using JetStream_Service.ViewModels;

namespace JetStream_Service.Models
{
    public class Content : ViewModelBase
    {
        private string _status;
        public string status
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    SetProperty(ref _status, value);
                }
            }
        }
    }
}
