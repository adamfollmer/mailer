using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewMailer
{
    class GymMember
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int GymId { get; set; }
        public static GymMember GetGymMember()
        {
            var gMem = new GymMember()
            {
                Name = "Derek",
                Email = "derekscheller23@gmail.com",
                GymId = 1
            };
            return gMem;
        }
    }
}
