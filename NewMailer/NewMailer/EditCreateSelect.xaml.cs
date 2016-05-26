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

namespace NewMailer
{
    /// <summary>
    /// Interaction logic for EditCreateSelect.xaml
    /// </summary>
    public partial class EditCreateSelect : Window
    {
        List<Gym> Gyms = new List<Gym>();
        public EditCreateSelect()
        {
            InitializeComponent();
            Gym planetGym = new Gym();
            Gyms = planetGym.GetGyms();
            foreach (Gym gym in Gyms)
            {
                Gym_List.Items.Add(gym);
            }
        }

        private void Gym_List_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Gym_List.SelectedItem != null)
            {
                EditGym edit = new EditGym((Gym)Gym_List.SelectedItem);
                edit.Show();
                this.Close();
            }
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Create_Button_Click(object sender, RoutedEventArgs e)
        {
            NameNewGym create = new NameNewGym();
            create.Show();
            this.Close();
        }
    }
}
