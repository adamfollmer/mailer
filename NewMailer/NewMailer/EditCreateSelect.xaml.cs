using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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

        private void Gym_List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var ListBox = sender as ListBox;
            Gym selectedGym = (Gym)ListBox.SelectedItem;
            get_GymName.Text = selectedGym.Name;
            get_GymAdd.Text = selectedGym.Address;
            get_GymCSZ.Text = selectedGym.CityZip;
            get_GymPhone.Text = selectedGym.Phone;
            get_GymMN.Text = selectedGym.ManagerName;
            get_GymTN.Text = selectedGym.TrainerName;
            if(ListBox.SelectedIndex != -1)
            {
                string fileManager = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), string.Format("GymPictures\\{0}\\manager.jpg", get_GymName.Text));
                string fileTrainer = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), string.Format("GymPictures\\{0}\\trainer.jpg", get_GymName.Text));
                if (File.Exists(fileManager))
                {
                    BitmapImage b = new BitmapImage();
                    b.BeginInit();
                    b.UriSource = new Uri(fileManager,UriKind.RelativeOrAbsolute);
                    b.EndInit();
                    get_MPic.Stretch = Stretch.Fill;
                    get_MPic.Source = b;
                }
                if (File.Exists(fileTrainer))
                {
                    BitmapImage b = new BitmapImage();
                    b.BeginInit();
                    b.UriSource = new Uri(fileTrainer,UriKind.RelativeOrAbsolute);
                    b.EndInit();
                    get_TPic.Stretch = Stretch.Fill;
                    get_TPic.Source = b;
                }
            }
        }
    }
}
