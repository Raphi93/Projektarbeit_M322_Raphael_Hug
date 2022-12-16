using JetStream_Service.ViewModels;
using System;
using System.Windows;

namespace JetStream_Service
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainViewModel ovm = new MainViewModel();
            this.DataContext = ovm;
            if (ovm.CloseAction == null)
                ovm.CloseAction = new Action(() => this.Close());
        }

    }
}
