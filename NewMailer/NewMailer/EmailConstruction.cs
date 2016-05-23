using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewMailer
{
    class EmailConstruction
    {
        public class Gym
        {
            public string Name;
            public string Address;
            public string CityZip;
            public string Phone;
            public string Email;
            public string ManagerName;
            public string ManagerPicture;
            public string TrainerName;
            public string TrainerPicture;
        }
        
        public Gym SelectGym (Upload.GymMember Member)
        {
            switch (Member.GymId)
            {
                case ("Planet Fitness Addison IL"):
                    return new Gym()
                    {
                        Name = "Addison, Illinois",
                        Address = "1445 W Lake St.",
                        CityZip = "Addison, IL 60101",
                        Phone = "(630) 953-4961",
                        Email = "test",
                        ManagerName = "John Doe",
                        ManagerPicture = "C:\\Pics\\gym-manager.jpg",
                        TrainerName = "Jared Doe",
                        TrainerPicture = "C:\\Pics\\gym-trainer.jpg"
                    };
                case ("Naperville IL"):
                    return new Gym()
                    {
                        Name = "test",
                        Address = "test",
                        CityZip = "test",
                        Phone = "test",
                        Email = "test",
                        ManagerName = "test",
                        ManagerPicture = "test",
                        TrainerName = "test",
                        TrainerPicture = "test"
                    };
                case ("Horseheads"):
                    return new Gym()
                    {
                        Name = "test",
                        Address = "test",
                        CityZip = "test",
                        Phone = "test",
                        Email = "test",
                        ManagerName = "test",
                        ManagerPicture = "test",
                        TrainerName = "test",
                        TrainerPicture = "test"
                    };
                case ("Milwaukee Southgate"):
                    return new Gym()
                    {
                        Name = "test",
                        Address = "test",
                        CityZip = "test",
                        Phone = "test",
                        Email = "test",
                        ManagerName = "test",
                        ManagerPicture = "test",
                        TrainerName = "test",
                        TrainerPicture = "test"
                    };
                case ("Sheboygan"):
                    return new Gym()
                    {
                        Name = "test",
                        Address = "test",
                        CityZip = "test",
                        Phone = "test",
                        Email = "test",
                        ManagerName = "test",
                        ManagerPicture = "test",
                        TrainerName = "test",
                        TrainerPicture = "test"
                    };
                case ("Franklin Milwaukee"):
                    return new Gym()
                    {
                        Name = "test",
                        Address = "test",
                        CityZip = "test",
                        Phone = "test",
                        Email = "test",
                        ManagerName = "test",
                        ManagerPicture = "test",
                        TrainerName = "test",
                        TrainerPicture = "test"
                    };
                case ("West Bend"):
                    return new Gym()
                    {
                        Name = "test",
                        Address = "test",
                        CityZip = "test",
                        Phone = "test",
                        Email = "test",
                        ManagerName = "test",
                        ManagerPicture = "test",
                        TrainerName = "test",
                        TrainerPicture = "test"
                    };
                case ("Champaign"):
                    return new Gym()
                    {
                        Name = "test",
                        Address = "test",
                        CityZip = "test",
                        Phone = "test",
                        Email = "test",
                        ManagerName = "test",
                        ManagerPicture = "test",
                        TrainerName = "test",
                        TrainerPicture = "test"
                    };
                case ("Madison West Broadway"):
                    return new Gym()
                    {
                        Name = "test",
                        Address = "test",
                        CityZip = "test",
                        Phone = "test",
                        Email = "test",
                        ManagerName = "test",
                        ManagerPicture = "test",
                        TrainerName = "test",
                        TrainerPicture = "test"
                    };
                case ("Fond du Lac"):
                    return new Gym()
                    {
                        Name = "test",
                        Address = "test",
                        CityZip = "test",
                        Phone = "test",
                        Email = "test",
                        ManagerName = "test",
                        ManagerPicture = "test",
                        TrainerName = "test",
                        TrainerPicture = "test"
                    };
                case ("Rockford"):
                    return new Gym()
                    {
                        Name = "test",
                        Address = "test",
                        CityZip = "test",
                        Phone = "test",
                        Email = "test",
                        ManagerName = "test",
                        ManagerPicture = "test",
                        TrainerName = "test",
                        TrainerPicture = "test"
                    };
                case ("Madison Mineral Point"):
                    return new Gym()
                    {
                        Name = "test",
                        Address = "test",
                        CityZip = "test",
                        Phone = "test",
                        Email = "test",
                        ManagerName = "test",
                        ManagerPicture = "test",
                        TrainerName = "test",
                        TrainerPicture = "test"
                    };
                case ("Loves Park"):
                    return new Gym()
                    {
                        Name = "test",
                        Address = "test",
                        CityZip = "test",
                        Phone = "test",
                        Email = "test",
                        ManagerName = "test",
                        ManagerPicture = "test",
                        TrainerName = "test",
                        TrainerPicture = "test"
                    };
                case ("East Peoria"):
                    return new Gym()
                    {
                        Name = "test",
                        Address = "test",
                        CityZip = "test",
                        Phone = "test",
                        Email = "test",
                        ManagerName = "test",
                        ManagerPicture = "test",
                        TrainerName = "test",
                        TrainerPicture = "test"
                    };
                case ("Eau Claire"):
                    return new Gym()
                    {
                        Name = "test",
                        Address = "test",
                        CityZip = "test",
                        Phone = "test",
                        Email = "test",
                        ManagerName = "test",
                        ManagerPicture = "test",
                        TrainerName = "test",
                        TrainerPicture = "test"
                    };
                case ("South Milwaukee"):
                    return new Gym()
                    {
                        Name = "test",
                        Address = "test",
                        CityZip = "test",
                        Phone = "test",
                        Email = "test",
                        ManagerName = "test",
                        ManagerPicture = "test",
                        TrainerName = "test",
                        TrainerPicture = "test"
                    };
                case ("Milwaukee East Capitol WI"):
                    return new Gym()
                    {
                        Name = "test",
                        Address = "test",
                        CityZip = "test",
                        Phone = "test",
                        Email = "test",
                        ManagerName = "test",
                        ManagerPicture = "test",
                        TrainerName = "test",
                        TrainerPicture = "test"
                    };
                case ("Springfield Wabash Ave"):
                    return new Gym()
                    {
                        Name = "test",
                        Address = "test",
                        CityZip = "test",
                        Phone = "test",
                        Email = "test",
                        ManagerName = "test",
                        ManagerPicture = "test",
                        TrainerName = "test",
                        TrainerPicture = "test"
                    };
                case ("Peoria IL"):
                    return new Gym()
                    {
                        Name = "test",
                        Address = "test",
                        CityZip = "test",
                        Phone = "test",
                        Email = "test",
                        ManagerName = "test",
                        ManagerPicture = "test",
                        TrainerName = "test",
                        TrainerPicture = "test"
                    };
                case ("Manitowoc"):
                    return new Gym()
                    {
                        Name = "test",
                        Address = "test",
                        CityZip = "test",
                        Phone = "test",
                        Email = "test",
                        ManagerName = "test",
                        ManagerPicture = "test",
                        TrainerName = "test",
                        TrainerPicture = "test"
                    };
                case ("Oconomowoc Wi"):
                    return new Gym()
                    {
                        Name = "test",
                        Address = "test",
                        CityZip = "test",
                        Phone = "test",
                        Email = "test",
                        ManagerName = "test",
                        ManagerPicture = "test",
                        TrainerName = "test",
                        TrainerPicture = "test"
                    };
                case ("Appleton"):
                    return new Gym()
                    {
                        Name = "test",
                        Address = "test",
                        CityZip = "test",
                        Phone = "test",
                        Email = "test",
                        ManagerName = "test",
                        ManagerPicture = "test",
                        TrainerName = "test",
                        TrainerPicture = "test"
                    };
                case ("East Appleton WI"):
                    return new Gym()
                    {
                        Name = "test",
                        Address = "test",
                        CityZip = "test",
                        Phone = "test",
                        Email = "test",
                        ManagerName = "test",
                        ManagerPicture = "test",
                        TrainerName = "test",
                        TrainerPicture = "test"
                    };
                case ("Brookfield WI"):
                    return new Gym()
                    {
                        Name = "test",
                        Address = "test",
                        CityZip = "test",
                        Phone = "test",
                        Email = "test",
                        ManagerName = "test",
                        ManagerPicture = "test",
                        TrainerName = "test",
                        TrainerPicture = "test"
                    };
                case ("Green Bay West"):
                    return new Gym()
                    {
                        Name = "test",
                        Address = "test",
                        CityZip = "test",
                        Phone = "test",
                        Email = "test",
                        ManagerName = "test",
                        ManagerPicture = "test",
                        TrainerName = "test",
                        TrainerPicture = "test"
                    };
                case ("Milwaukee Midtown"):
                    return new Gym()
                    {
                        Name = "test",
                        Address = "test",
                        CityZip = "test",
                        Phone = "test",
                        Email = "test",
                        ManagerName = "test",
                        ManagerPicture = "test",
                        TrainerName = "test",
                        TrainerPicture = "test"
                    };
                case ("Roths Child WI"):
                    return new Gym()
                    {
                        Name = "test",
                        Address = "test",
                        CityZip = "test",
                        Phone = "test",
                        Email = "test",
                        ManagerName = "test",
                        ManagerPicture = "test",
                        TrainerName = "test",
                        TrainerPicture = "test"
                    };
                case ("Oshkosh"):
                    return new Gym()
                    {
                        Name = "test",
                        Address = "test",
                        CityZip = "test",
                        Phone = "test",
                        Email = "test",
                        ManagerName = "test",
                        ManagerPicture = "test",
                        TrainerName = "test",
                        TrainerPicture = "test"
                    };
                case ("Green Bay East"):
                    return new Gym()
                    {
                        Name = "test",
                        Address = "test",
                        CityZip = "test",
                        Phone = "test",
                        Email = "test",
                        ManagerName = "test",
                        ManagerPicture = "test",
                        TrainerName = "test",
                        TrainerPicture = "test"
                    };
                case ("Milwaukee Downtown"):
                    return new Gym()
                    {
                        Name = "test",
                        Address = "test",
                        CityZip = "test",
                        Phone = "test",
                        Email = "test",
                        ManagerName = "test",
                        ManagerPicture = "test",
                        TrainerName = "test",
                        TrainerPicture = "test"
                    };
                case ("Janesville"):
                    return new Gym()
                    {
                        Name = "test",
                        Address = "test",
                        CityZip = "test",
                        Phone = "test",
                        Email = "test",
                        ManagerName = "test",
                        ManagerPicture = "test",
                        TrainerName = "test",
                        TrainerPicture = "test"
                    };
                case ("Menomonee Falls"):
                    return new Gym()
                    {
                        Name = "test",
                        Address = "test",
                        CityZip = "test",
                        Phone = "test",
                        Email = "test",
                        ManagerName = "test",
                        ManagerPicture = "test",
                        TrainerName = "test",
                        TrainerPicture = "test"
                    };
                case ("Beloit"):
                    return new Gym()
                    {
                        Name = "test",
                        Address = "test",
                        CityZip = "test",
                        Phone = "test",
                        Email = "test",
                        ManagerName = "test",
                        ManagerPicture = "test",
                        TrainerName = "test",
                        TrainerPicture = "test"
                    };
                default:
                    return new Gym()
                    {
                        Name = "test",
                        Address = "test",
                        CityZip = "test",
                        Phone = "test",
                        Email = "test",
                        ManagerName = "test",
                        ManagerPicture = "test",
                        TrainerName = "test",
                        TrainerPicture = "test"
                    };
            }


        }
    }
}
