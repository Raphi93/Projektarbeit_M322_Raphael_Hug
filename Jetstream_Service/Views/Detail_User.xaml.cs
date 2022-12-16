using JetStream_Service.Models;
using JetStream_Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace JetStream_Service.Views
{
    /// <summary>
    /// Interaction logic for Detail_User.xaml
    /// </summary>
    public partial class Detail_User : Window
    {
        private RegistrationModel _regi = new RegistrationModel();
        public Detail_User(RegistrationModel regi)
        { 
            InitializeComponent();
            _regi = regi;
            DataContext = _regi;
        }

        private void btClose(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
