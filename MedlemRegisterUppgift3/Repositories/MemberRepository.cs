using MedlemRegisterUppgift3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedlemRegisterUppgift3.Repositories
{
     class MemberRepository
    {
        public List<Member> Members { get; set; }

       public MemberRepository()
        {
            Members = new List<Member>
            {
                new Member{SocialSecurityNumber=198406232725, FirstName = "Tommy", LastName="Fors", MemberShipPaid = false },
                new Member{SocialSecurityNumber=198502236412, FirstName = "Klara", LastName="Olsson", MemberShipPaid = true },
                new Member{SocialSecurityNumber=199612231213, FirstName = "Kurt", LastName="Larsson", MemberShipPaid = false },
                new Member{SocialSecurityNumber=199012237314, FirstName = "Sven", LastName="Sven", MemberShipPaid = true },
                new Member{SocialSecurityNumber=198911232515, FirstName = "Doris", LastName="Fibonacchi", MemberShipPaid = true },
                new Member{SocialSecurityNumber=198111237416, FirstName = "Harry", LastName="Ladox", MemberShipPaid = true },
                new Member{SocialSecurityNumber=198111232517, FirstName = "Mary", LastName="Riven", MemberShipPaid = true },
                new Member{SocialSecurityNumber=193408234418, FirstName = "Tommy", LastName="River", MemberShipPaid = false },
                new Member{SocialSecurityNumber=194301233313, FirstName = "Housame", LastName="Straw", MemberShipPaid = true },
                new Member{SocialSecurityNumber=191205232214, FirstName = "Gregory", LastName="Fibonacchi", MemberShipPaid = true },
                new Member{SocialSecurityNumber=201201232316, FirstName = "Jack", LastName="Klarx", MemberShipPaid = false },
                new Member{SocialSecurityNumber=201302235517, FirstName = "Petra", LastName="Fibonacchi", MemberShipPaid = true },
                new Member{SocialSecurityNumber=200303234517, FirstName = "Petra", LastName="Kviverb", MemberShipPaid = true },
                new Member{SocialSecurityNumber=196404234517, FirstName = "Filip", LastName="Olsson", MemberShipPaid = true },
                new Member{SocialSecurityNumber=196305237617, FirstName = "Björn", LastName="Barry", MemberShipPaid = true },
                new Member{SocialSecurityNumber=192906233418, FirstName = "Göran", LastName="Isberg", MemberShipPaid = true },
                new Member{SocialSecurityNumber=195707235617, FirstName = "Sailor", LastName="Olsson", MemberShipPaid = false },
                new Member{SocialSecurityNumber=196708235618, FirstName = "Sven", LastName="Hast", MemberShipPaid = true },
                new Member{SocialSecurityNumber=198709237317, FirstName = "Tor", LastName="Olsson", MemberShipPaid = false },
                new Member{SocialSecurityNumber=198901237416, FirstName = "Gunnel", LastName="Sven", MemberShipPaid = true },
            };
        }
    }
}
