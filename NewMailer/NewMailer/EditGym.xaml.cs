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
            Gym planetGym = new Gym();
            List<Gym> Gyms = planetGym.GetGyms();
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

        }
    }
}
