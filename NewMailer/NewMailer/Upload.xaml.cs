using System;
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

namespace NewMailer
{
    /// <summary>
    /// Interaction logic for Upload.xaml
    /// </summary>
    public partial class Upload : Window
    {
        public Upload()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                txtEditor.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }
        private void SendEmail(object sender, RoutedEventArgs e) //eventually can pass string server, to, from, subject, body
        {
            string to = "adam_2131@hotmail.com";
            string from = "follmeradam@gmail.com";
            string subject = "Welcome friend!";
            string body = "test 1234";
            MailMessage message = new MailMessage(from, to, subject, body);
            SmtpClient client = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                UseDefaultCredentials = false,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential("follmeradam@gmail.com", "M3i5l4l6!"),
                Timeout = 20000


            };
            //client.Timeout = 100;
            //client.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;

            try
            {
                client.Send(message);
                txtEditor.Text = "You did it!";
            }
            catch (Exception ex)
            {
                txtEditor.Text = ex.ToString();
                Console.WriteLine("Exception caught in CreateTimeoutTestMessage(): {0}", ex.ToString());
            }
        }


        private void CSVParse(object sender, RoutedEventArgs e)
        {
            CreateGymMember memberMaker = new CreateGymMember();
            //var reader = File.ReadAllLines();
            List<GymMember> EmailList = new List<GymMember>();
            foreach (string line in File.ReadLines(@"C:\\Users\\Derek Scheller\\Documents\\Visual Studio 2015\\Projects\\EmailTools\\mailer\\NewMailer\\NewMailer\\test.csv"))
            {
                if (line.Contains("@"))
                {
                    if (line.Contains("Planet Fitness"))
                    {
                        GymMember ValidMember = memberMaker.Create(line);
                        EmailList.Add(ValidMember);
                    }
                }
            }
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

    }
}
