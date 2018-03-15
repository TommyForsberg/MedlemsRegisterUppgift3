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

        internal void Start()
        {
            do
            {
                Console.Clear();
                Gui.StartMenu();
                PrintInitialList();
                GetChoice();

            } while (true);

        }

        public void GetChoice()
        {
            Console.Write("Ditt val: ");
            var input = Console.ReadKey(true).Key;
            switch (input)
            {
                case ConsoleKey.NumPad0:
                case ConsoleKey.D0:
                    Environment.Exit(0);
                    break;
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    SortByAge();
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    SortByLastName();
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    PrintNotPaidMembers();
                    break;
                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    SearchByLastName();
                    break;
                case ConsoleKey.NumPad5:
                case ConsoleKey.D5:
                    Start();
                    break;
            }
        }

        private void SearchByLastName()
        {
            throw new NotImplementedException();
        }

        private void PrintNotPaidMembers()
        {
            Console.Clear();
            Gui.StartMenu();
            var membersRepo = new MemberRepository();

            foreach (var member in membersRepo.Members)
            {
                var paid = (member.MemberShipPaid == true) ? "Betald" : "Inte betald";
                if (!member.MemberShipPaid)
                {
                    Console.WriteLine("Personnr:  {0} , Förnamn: {1}    , Efternamn: {2}     , Betalat medlemskapet: {3}", member.SocialSecurityNumber, member.FirstName, member.LastName, paid);
                }
            }
            Console.ReadKey();
        }

        private void SortByLastName()
        {
            throw new NotImplementedException();
        }

        private void SortByAge()
        {
            throw new NotImplementedException();
        }

        private void PrintInitialList()
        {
            var membersRepo = new MemberRepository();

            foreach (var member in membersRepo.Members)
            {
                var paid = (member.MemberShipPaid == true) ? "Betald" : "Inte betald";
                Console.WriteLine("Personnr:  {0} , Förnamn: {1}    , Efternamn: {2}     , Betalat medlemskapet: {3}", member.SocialSecurityNumber, member.FirstName, member.LastName, paid);
            }
        }

        public void Init()
        {
            var repo = new MemberRepository();
        }

    }
}
