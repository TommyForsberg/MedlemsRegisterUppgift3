using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedlemRegisterUppgift3.Entities
{
    class Member
    {
        public long SocialSecurityNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool MemberShipPaid { get; set; }
    }
}
