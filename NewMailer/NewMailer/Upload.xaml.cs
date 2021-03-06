﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Net.Mail;
using System.Net;
using System.Net.Mime;

namespace NewMailer
{
    /// <summary>
    /// Interaction logic for Upload.xaml
    /// </summary>
    public partial class Upload : Window
    {
        List<GymMember> invalidMembers;
        public Upload()
        {
            InitializeComponent();
            invalidMembers = new List<GymMember>();
        }
        private string btnOpenFile_Click()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                return openFileDialog.FileName;
            }
            return null;
        }
        private AlternateView GetEmbeddedImage(Gym gym, GymMember member)
        {
            LinkedResource managerPicture = new LinkedResource(gym.ManagerPicture);
            LinkedResource trainerPicture = new LinkedResource(gym.TrainerPicture);
            LinkedResource logo = new LinkedResource(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "NewMemberMailer\\PlanetFitnessLogo.jpg"));
            LinkedResource banner = new LinkedResource(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "NewMemberMailer\\PlanetFitnessBanner.jpg"));
            LinkedResource header = new LinkedResource(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "NewMemberMailer\\header.jpg"));
            LinkedResource footer = new LinkedResource(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "NewMemberMailer\\footer.jpg"));
            LinkedResource pot = new LinkedResource(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "NewMemberMailer\\PoT.jpg"));
            managerPicture.ContentId = Guid.NewGuid().ToString();
            trainerPicture.ContentId = Guid.NewGuid().ToString();
            logo.ContentId = Guid.NewGuid().ToString();
            banner.ContentId = Guid.NewGuid().ToString();
            header.ContentId = Guid.NewGuid().ToString();
            footer.ContentId = Guid.NewGuid().ToString();
            pot.ContentId = Guid.NewGuid().ToString();
            StreamReader reader = new StreamReader(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "NewMemberMailer\\Information\\EmailBody.txt"));
            string emailText = reader.ReadToEnd();
            string htmlBody = string.Format(emailText.ToString(), gym.Name, member.Name, gym.Address, gym.CityZip,
                    gym.ManagerName, managerPicture.ContentId, gym.TrainerName, trainerPicture.ContentId, header.ContentId, footer.ContentId, logo.ContentId, pot.ContentId, banner.ContentId, gym.Website);
            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
            alternateView.LinkedResources.Add(managerPicture);
            alternateView.LinkedResources.Add(trainerPicture);
            alternateView.LinkedResources.Add(logo);
            alternateView.LinkedResources.Add(banner);
            alternateView.LinkedResources.Add(header);
            alternateView.LinkedResources.Add(footer);
            alternateView.LinkedResources.Add(pot);
            return alternateView;
        }
        private void MassEmail(object sender, RoutedEventArgs e)
        {
            int counter = 0;
            Gym gymData = new Gym();
            string CSV = btnOpenFile_Click();
            if (CSV == null)
            {
                return;
            }
            List<GymMember> EmailList = CSVParse(CSV);
            foreach (GymMember member in EmailList)
            {
                Gym localGym = gymData.SelectGym(member);
                MailMessage message = new MailMessage();
                message.IsBodyHtml = true;
                message.AlternateViews.Add(GetEmbeddedImage(localGym, member));
                message.To.Add(member.Email);
                message.From = new MailAddress("follmeradam@gmail.com");
                message.Subject = "Welcome to Planet Fitness " + localGym.Name;

                SmtpClient client = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    UseDefaultCredentials = false,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential("follmeradam@gmail.com", "M3i5l4l6!"), //Comment in password
                    Timeout = 20000
                };
                try
                {
                    client.Send(message);
                    counter++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("Exception caught in CreateTimeoutTestMessage(): {0}", ex.ToString()));
                }
            }
            System.Windows.MessageBox.Show(string.Format("Successfully Sent {0} Emails!", counter.ToString()));
        }
        private List<GymMember> CSVParse(string csv)
        {
            CreateGymMember memberMaker = new CreateGymMember();
            List<GymMember> EmailList = new List<GymMember>();
            foreach (string line in File.ReadLines(csv))
            {
                if (line.Contains("Planet Fitness"))
                {
                    if (line.Contains("@"))
                    {
                        GymMember ValidMember = memberMaker.Create(line);
                        EmailList.Add(ValidMember);
                    }else
                    {
                        GymMember InvalidMember = memberMaker.Create(line);
                        invalidMembers.Add(InvalidMember);
                    }
                }
            }
            return EmailList;
        }
        public class GymMember
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string GymId { get; set; }
        }
        private class CreateGymMember
        {
            public GymMember Create(string MemberInfo)
            {
                string[] colData = MemberInfo.Split(',');
                GymMember Member = new GymMember()
                {
                    GymId = colData[0],
                    Name = colData[3].Trim(new char[] { '"' }) + " " + colData[2].Trim(new char[] { '"' }),
                    Email = colData[4]
                };
                return Member;
            }
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
