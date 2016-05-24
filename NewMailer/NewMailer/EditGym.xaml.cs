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
        public EditGym()
        {
            InitializeComponent();
            Gym planetGym = new Gym();
            Gyms = planetGym.GetGyms();
            foreach (Gym gym in Gyms)
            {
                ListOfGyms.Items.Add(gym);
            }
        }
        private void ListOfGyms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedGym = (Gym)ListOfGyms.SelectedItem;
            if (selectedGym != null)
            {
                editGymName.SelectedText = selectedGym.Name;
                editGymAddress.SelectedText = selectedGym.Address;
                editGymCityZip.SelectedText = selectedGym.CityZip;
                editGymPhone.SelectedText = selectedGym.Phone;
                editGymManager.SelectedText = selectedGym.ManagerName;
                editGymTrainer.SelectedText = selectedGym.TrainerName;
            }
        }
        private void SaveChanges(object sender, RoutedEventArgs e)

        {
            StringBuilder csv = new StringBuilder();
            foreach(Gym gym in Gyms)
            {
                if(gym.Name == editGymName.SelectedText)
                {
                    gym.Name = editGymName.SelectedText;
                    gym.Phone = editGymPhone.Text;
                    gym.ManagerName = editGymManager.SelectedText;
                    gym.TrainerName = editGymTrainer.SelectedText;
                    gym.Address = editGymAddress.SelectedText;
                    gym.CityZip = editGymCityZip.SelectedText; 
                }
                csv.AppendLine(gym.Name + "," + gym.Address + "," + gym.CityZip + "," + gym.Phone + "," + gym.ManagerName + "," + gym.ManagerPicture + "," + gym.TrainerName + "," + gym.TrainerPicture);
            }
            File.WriteAllText(@"ReadFile\\GymInfo.csv", csv.ToString());
        }
    }
}
