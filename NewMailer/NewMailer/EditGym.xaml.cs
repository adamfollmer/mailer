using System;
using System.Collections;
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

namespace NewMailer
{
    /// <summary>
    /// Interaction logic for EditGym.xaml
    /// </summary>
    public partial class EditGym : Window
    {
        public EditGym()
        {
            InitializeComponent();
            listBox.ItemsSource = LoadGymList();
        }

        private ArrayList LoadGymList()
        {
            ArrayList gyms = new ArrayList();
            //Code foreach based on CSV
            return gyms;
        }
    }
}
