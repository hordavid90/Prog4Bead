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

namespace BikeShop.WpfClient
{
    /// <summary>
    /// Interaction logic for ServiceMenuWindow.xaml
    /// </summary>
    public partial class ServiceMenuWindow : Window
    {
        public ServiceMenuWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menuWindow = new MenuWindow();
            this.Close();
            menuWindow.ShowDialog();
        }
    }
}
