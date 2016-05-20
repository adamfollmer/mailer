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

namespace NewMailer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void GoToUpload(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
            Upload up = new Upload();
            up.ShowDialog();
            Close();
=======
            Upload upload = new NewMailer.Upload();
            upload.Show();
            this.Close();
>>>>>>> 62acc138e72c22d23ac205837c5bdf098672071f
        }
    }
}
