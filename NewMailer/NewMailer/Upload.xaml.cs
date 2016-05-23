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
using System.Net.Mime;

namespace NewMailer
{
    /// <summary>
    /// Interaction logic for Upload.xaml
    /// </summary>
    public partial class Upload : Window
    {
       EmailConstruction GymSelection = new EmailConstruction();

        public Upload()
        {
            InitializeComponent();
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
        private void MassEmail(object sender, RoutedEventArgs e)
        {
            string CSV = btnOpenFile_Click();
            List<GymMember> EmailList = CSVParse(CSV);
            foreach (GymMember member in EmailList)
            {
                EmailConstruction.Gym localGym = GymSelection.SelectGym(member);
                StreamReader reader = new StreamReader("C:\\VisualStudio\\mailer\\NewMailer\\NewMailer\\EmailBody.txt");
                string emailText = reader.ReadToEnd();
                string to = member.Email;
                string from = "follmeradam@gmail.com";
                string subject = "Welcome to Planet Fitness" + localGym.Name;
                string body = reader.ToString(); 
                MailMessage message = new MailMessage(from, to, subject, body);
                message.IsBodyHtml = true;
                Attachment manager = new Attachment(localGym.ManagerPicture);
                Attachment trainer = new Attachment(localGym.TrainerPicture);
                message.Attachments.Add(manager);
                message.Attachments.Add(trainer);
                string ContentID = "Image";
                manager.ContentId = ContentID;
                trainer.ContentId = ContentID;

                manager.ContentDisposition.Inline = true;
                manager.ContentDisposition.DispositionType = DispositionTypeNames.Inline;
                trainer.ContentDisposition.Inline = true;
                trainer.ContentDisposition.DispositionType = DispositionTypeNames.Inline;

                //replace with message.Body =
                string test = string.Format(emailText.ToString(), localGym.Name, member.Name, localGym.Address, localGym.CityZip,
                    localGym.ManagerName, localGym.ManagerPicture, localGym.TrainerName, localGym.TrainerPicture);

                SmtpClient client = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    UseDefaultCredentials = false,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential("follmeradam@gmail.com", "PASSWORD!"), //Comment in password
                    Timeout = 20000
                };

                try
                {
                    txtEditor.Text = test.ToString();
                    //client.Send(message);
                    //txtEditor.Text = "You did it!";
                }
                catch (Exception ex)
                {
                    txtEditor.Text = ex.ToString();
                    Console.WriteLine("Exception caught in CreateTimeoutTestMessage(): {0}", ex.ToString());
                }
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
                Credentials = new NetworkCredential("follmeradam@gmail.com", "PASSWORD!"), //Comment in password
                Timeout = 20000
            };

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


        private List<GymMember> CSVParse(string csv)
        {
            CreateGymMember memberMaker = new CreateGymMember();
            List<GymMember> EmailList = new List<GymMember>();
            foreach (string line in File.ReadLines(csv))
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

    }
}
