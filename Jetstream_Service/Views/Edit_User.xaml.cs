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

        public Edit_User(RegistrationModel regi)
        {
            InitializeComponent();
            _regi = regi;
            DataContext = _regi;
        }

        private void btClose(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void btSenden(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
