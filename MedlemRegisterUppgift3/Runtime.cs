using MedlemRegisterUppgift3.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedlemRegisterUppgift3
{
    class Runtime
    {
        public void Init()
        {
            var repo = new MemberRepository();
        }
    }
}
