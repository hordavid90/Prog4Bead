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
    /// Interaction logic for BrandMenuWindow.xaml
    /// </summary>
    public partial class BrandMenuWindow : Window
    {
        public BrandMenuWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow mw = new MenuWindow();
            this.Close();
            mw.ShowDialog();
        }
    }
}
