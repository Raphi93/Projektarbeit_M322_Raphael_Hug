using JetStream_Service.ViewModels;
using System;
using System.Windows;

namespace JetStream_Service.View
{
    /// <summary>
    /// Interaction logic for new_user.xaml
    /// </summary>
    public partial class New_User : Window
    {
        public New_User()
        {
            InitializeComponent();
            NewViewModel ovm = new NewViewModel();
            this.DataContext = ovm;
            if (ovm.CloseAction == null)
                ovm.CloseAction = new Action(() => this.Close());
        }
    }
}
