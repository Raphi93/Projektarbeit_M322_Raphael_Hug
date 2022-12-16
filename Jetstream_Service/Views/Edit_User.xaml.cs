using JetStream_Service.ViewModels;
using System;
using System.Windows;

namespace JetStream_Service.View
{
    /// <summary>
    /// Interaction logic for Edit_User.xaml
    /// </summary>
    public partial class Edit_User : Window
    {
        public Edit_User()
        {
            InitializeComponent();
            EditViewModel ovm = new EditViewModel();
            this.DataContext = ovm;
            if (ovm.CloseAction == null)
                ovm.CloseAction = new Action(() => this.Close());
        }
    }
}
