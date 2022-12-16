using JetStream_Service.Models;
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
        private RegistrationModel _regi = new RegistrationModel();

        public Edit_User()
        {
            InitializeComponent();

            DataContext = _regi;
        }

        private void btClose(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
