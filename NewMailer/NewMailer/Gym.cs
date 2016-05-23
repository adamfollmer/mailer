using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var reader = new StreamReader(File.OpenRead(@"ReadFile\\GymInfo.csv"));
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
                    ManagerPicture = values[5],
                    TrainerName = values[6],
                    TrainerPicture = values[7],
                };
                gyms.Add(validGym);
            }
            return gyms;
        }
        public Gym SelectGym(Upload.GymMember member)
        {
            List<Gym> gyms = GetGyms();
            foreach (Gym gym in gyms)
            {
                if (member.GymId == gym.Name)
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