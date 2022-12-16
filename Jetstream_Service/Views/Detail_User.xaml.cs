using JetStream_Service.ViewModels;
using System;
using System.Windows;

namespace JetStream_Service.View
{
    /// <summary>
    /// Interaction logic for Detail_User.xaml
    /// </summary>
    public partial class Detail_User : Window
    {
        public Detail_User()
        {
            InitializeComponent();
            MainViewModel ovm = new MainViewModel();
            this.DataContext = ovm;
            if (ovm.CloseAction == null)
                ovm.CloseAction = new Action(() => this.Close());
        }
    }
}
