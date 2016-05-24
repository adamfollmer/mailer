﻿using Microsoft.Win32;
using System;
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
    /// Interaction logic for CreateGym.xaml
    /// </summary>
    public partial class CreateGym : Window
    {
        List<Gym> Gyms;
        Gym newGym;
        public CreateGym(string GymName)
        {
            InitializeComponent();
            get_GymName.Text = GymName;
            Gyms = new List<Gym>();
            newGym = new Gym() { Name = GymName };
            Gym planetGym = new Gym();
            Gyms = planetGym.GetGyms();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            newGym.Name = get_GymName.Text.Replace(',', ' ');
            newGym.Phone = get_GymPhone.Text.Replace(',', ' ');
            newGym.ManagerName = get_GymMN.Text.Replace(',', ' ');
            newGym.TrainerName = get_GymTN.Text.Replace(',', ' ');
            newGym.Address = get_GymAdd.Text.Replace(',', ' ');
            newGym.CityZip = get_GymCSZ.Text.Replace(',',' ');

            Gyms.Add(newGym);

            StringBuilder csv = new StringBuilder();
            foreach (Gym gym in Gyms)
            {
                csv.AppendLine(gym.Name + "," + gym.Address + "," + gym.CityZip + "," + gym.Phone + "," + gym.ManagerName + "," + gym.ManagerPicture + "," + gym.TrainerName + "," + gym.TrainerPicture);
            }
            File.WriteAllText(@"ReadFile\\GymInfo.csv", csv.ToString());
            System.Windows.MessageBox.Show("{0}: Gym Details Successfully Created!", get_GymName.Text);
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
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
                string destFile = string.Format(@"Images//{0}//ManagerPic.jpg", newGym.Name);
                string destFolder = string.Format(@"Images//{0}", newGym.Name);
                if (!Directory.Exists(destFolder))
                {
                    Directory.CreateDirectory(destFolder);
                }
                File.Copy(sourceFile, destFile, true);
                newGym.ManagerPicture = destFile;
            }
        }

        private void Trainer_Photo_Upload_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string sourceFile = openFileDialog.FileName;
                string destFile = string.Format(@"Images//{0}//TrainerPic.jpg", newGym.Name);
                string destFolder = string.Format(@"Images//{0}", newGym.Name);
                if (!Directory.Exists(destFolder))
                {
                    Directory.CreateDirectory(destFolder);
                }
                File.Copy(sourceFile, destFile, true);
                newGym.TrainerPicture = destFile;
            }
        }
    }
}
