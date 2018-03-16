using MedlemRegisterUppgift3.Entities;
using MedlemRegisterUppgift3.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MedlemRegisterUppgift3
{
    class Runtime
    {
        public List<Member> Members { get; set; }

        public Runtime()
        {
            var repo = new MemberRepository();
            Members = repo.Members;
        }

        internal void Start()
        {
            PrintList(Members);
            do
            {
                //Console.Clear();
                Gui.StartMenu();        
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
            var members = Members.ToArray();
            QuickSort(members, 0, members.Length - 1, p => p.LastName);
            PrintList(members.ToList());
        }

        private void SortByAge()
        {
            var members = Members.ToArray();
            QuickSort(members, 0, members.Length - 1, p => p.SocialSecurityNumber);
            PrintList(members.ToList());
        }
        internal void QuickSort<T, TProperty>(T[] members, int left, int right, Func<T, TProperty> selector)
        {
            if (Comparer<int>.Default.Compare(left, right) < 0)
            {
                int index = Partition(members, left, right, selector);

                QuickSort(members, left, index - 1, selector);
                QuickSort(members, index + 1, right, selector);
            }
        }

        private int Partition<T, TProperty>(T[] members, int left, int right, Func<T, TProperty> selector)
        {
           var pivot = members[right];
            T temp;

            int i = left;
            for (int j = left; j < right; j++)
            {
                if (Comparer<TProperty>.Default.Compare(selector(members[j]), selector(pivot)) <= 0)
                {
                    temp = members[j];
                    members[j] = members[i];
                    members[i] = temp;
                    i++;
                }
            }

            members[right] = members[i];
            members[i] = pivot;

            return i;
        }
        private void PrintList(List<Member> members)
        {
            foreach (var member in members)
            {
                var paid = (member.MemberShipPaid == true) ? "Betald" : "Inte betald";
                Console.WriteLine("Personnr:  {0} , Förnamn: {1}    , Efternamn: {2}     , Betalat medlemskapet: {3}", member.SocialSecurityNumber, member.FirstName, member.LastName, paid);
            }
        }
    }
}
