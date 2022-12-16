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
