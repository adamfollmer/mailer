using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NewMailer
{
    public class Gym
    {
        public string Name;
        public string Address;
        public string CityZip;
        public string Phone;
        public string ManagerName;
        public string ManagerPicture;
        public string TrainerName;
        public string TrainerPicture;
        public List<Gym> GetGyms()
        {
            List<Gym> gyms = new List<Gym>();
            string csvLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "NewMemberMailer\\Information\\GymInfo.csv");
            //string csvLocation = Path.Combine(Environment.CurrentDirectory, @"Dependencies\\GymInfo.csv");
            var reader = new StreamReader(File.OpenRead(csvLocation));
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                var validGym = new Gym()
                {
                    Name = values[0],
                    Address = values[1],
                    CityZip = values[2],
                    Phone = values[3],
                    ManagerName = values[4],
                    ManagerPicture = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\NewMemberMailer\\" + values[5]),
                    TrainerName = values[6],
                    TrainerPicture = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\NewMemberMailer\\" + values[7]),
                };
                gyms.Add(validGym);
                string destFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), string.Format("NewMemberMailer\\GymPictures\\{0}", validGym.Name));
                if (!Directory.Exists(destFolder))
                {
                    Directory.CreateDirectory(destFolder);
                }
            }
            reader.Close();
            return gyms;
        }
        public Gym SelectGym(Upload.GymMember member)
        {
            List<Gym> gyms = GetGyms();
            foreach (Gym gym in gyms)
            {
                if (member.GymId.Contains(gym.Name))
                    return gym;
            }
            return gyms[0];
        }
        public override string ToString()
        {

            return Name;
        }
    }
}