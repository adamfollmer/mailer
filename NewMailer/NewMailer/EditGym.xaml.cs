using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
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
    /// Interaction logic for EditGym.xaml
    /// </summary>
    public partial class EditGym : Window
    {
        List<Gym> Gyms = new List<Gym>();
        public EditGym(Gym edittedGym)
        {
            InitializeComponent();
            Gym planetGym = new Gym();
            Gyms = planetGym.GetGyms();
            get_GymName.Text = edittedGym.Name;
            get_GymAdd.Text = edittedGym.Address;
            get_GymCSZ.Text = edittedGym.CityZip;
            get_GymPhone.Text = edittedGym.Phone;
            get_GymMN.Text = edittedGym.ManagerName;
            get_GymTN.Text = edittedGym.TrainerName;
        }
        private void SaveChanges(object sender, RoutedEventArgs e)
        {
            StringBuilder csv = new StringBuilder();
            foreach (Gym gym in Gyms)
            {
                if (gym.Name == get_GymName.Text)
                {
                    gym.Phone = get_GymPhone.Text.Replace(',', ' ');
                    gym.ManagerName = get_GymMN.Text.Replace(',', ' ');
                    gym.TrainerName = get_GymTN.Text.Replace(',', ' ');
                    gym.Address = get_GymAdd.Text.Replace(',', ' ');
                    gym.CityZip = get_GymCSZ.Text.Replace(',', ' ');
                }
                csv.AppendLine(gym.Name + "," + gym.Address + "," + gym.CityZip + "," + gym.Phone + "," + gym.ManagerName + "," + gym.ManagerPicture + "," + gym.TrainerName + "," + gym.TrainerPicture);
            }
            File.WriteAllText(@"ReadFile\\GymInfo.csv", csv.ToString());
            MainWindow main = new MainWindow();
            System.Windows.MessageBox.Show("{0}: Gym Details Successfully Updated!",get_GymName.Text);
            main.Show();
            this.Close();
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Manager_Photo_Upload_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string sourceFile = openFileDialog.FileName;
                string destFile = string.Format(@"Images//{0}//ManagerPic.jpg", get_GymName.Text);
                string destFolder = string.Format(@"Images//{0}", get_GymName.Text);
                if (!Directory.Exists(destFolder))
                {
                    Directory.CreateDirectory(destFolder);
                }
                File.Copy(sourceFile, destFile, true);
            }
        }
        private void Trainer_Photo_Upload_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string sourceFile = openFileDialog.FileName;
                string destFile = string.Format(@"Images//{0}//TrainerPic.jpg", get_GymName.Text);
                string destFolder = string.Format(@"Images//{0}", get_GymName.Text);
                if (!Directory.Exists(destFolder))
                {
                    Directory.CreateDirectory(destFolder);
                }
                File.Copy(sourceFile, destFile, true);
            }
        }
    }
}
