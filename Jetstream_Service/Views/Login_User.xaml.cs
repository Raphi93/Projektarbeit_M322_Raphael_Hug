using JetStream_Service.ViewModels;
using System;
using System.Windows;

namespace JetStream_Service.View
{
    /// <summary>
    /// Interaction logic for Login_User.xaml
    /// </summary>
    public partial class Login_User : Window
    {
        public Login_User()
        {
            InitializeComponent();
            LoginViewModel ovm = new LoginViewModel();
            this.DataContext = ovm;
            if (ovm.CloseAction == null)
                ovm.CloseAction = new Action(() => this.Close());
        }
    }
}
