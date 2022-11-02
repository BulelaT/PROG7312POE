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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PROG7312_POE_ST10119567_Bulela_Tyelela
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtBlock.Text = "Welcome " + Player.Name + "\n" +
                "Please select the game you would like to play";
        }

        private void btnRB_Click(object sender, RoutedEventArgs e)
        {
            ReplacingBooks rb = new ReplacingBooks();
            rb.Show();
            this.Close();
        }

        private void btnIA_Click(object sender, RoutedEventArgs e)
        {
            ColumnMatching cm = new ColumnMatching();
            cm.Show();
            this.Close();
        }

        private void btnFCN_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This mode isn't available yet");
        }
    }
}
