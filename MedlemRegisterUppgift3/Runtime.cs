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
            Console.Clear();
            Gui.Topic("The raw list");
            PrintList(Members);
            Gui.StartMenu();

            do
            {
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
                    Search();
                    break;
                case ConsoleKey.NumPad5:
                case ConsoleKey.D5:
                    Start();
                    break;
            }
        }

        private void Search()
        {
            Gui.Topic("Search by lastname");
            var members = GetNotPaidMembers();

            Search(members);
        }

        private void Search(List<Member> members)
        {
            bool validSocialNr = false;
            string output = String.Empty;
            long result = 0;
            var searchList = new List<Member>();

            Console.Write("Your input (Lastname or Socialnumber):  ");
            var input = Console.ReadLine();

            validSocialNr = long.TryParse(input, out result);

            if (validSocialNr && result.ToString().Length == 12)
            {
                searchList = Find<Member,long>(members.ToArray(), p => p.SocialSecurityNumber, result);
            }
            else
            {
                searchList = BinaryFind<Member, string>(members.ToArray(), p => p.LastName, input);
            }
            if (searchList.Count == 0)
            {
                Console.WriteLine("Användare du söker finns inte!!!");
                Search();
            }
            else
            {
                Gui.Topic($"Search results by input  - {input} - ");
                PrintList(searchList);
            }

        }

        private void PrintNotPaidMembers()
        {
            Gui.Topic("Members that didnt paid");

            var membersRepo = GetNotPaidMembers();

            foreach (var member in membersRepo)
            {
                var paid = (member.MemberShipPaid == true) ? "Betald" : "Inte betald";
                Console.WriteLine("Personnr:  {0} , Förnamn: {1}    , Efternamn: {2}     , Betalat medlemskapet: {3}", member.SocialSecurityNumber, member.FirstName, member.LastName, paid);
            }
            Console.ReadKey();
        }

        List<Member> GetNotPaidMembers()
        {
            var members = Members.ToList();
            var notPaidMembers = new List<Member>();
            foreach (var member in members)
            {
                if (!member.MemberShipPaid)
                {
                    notPaidMembers.Add(member);
                }
            }
            return notPaidMembers;
        }

        private void SortByLastName()
        {
            Gui.Topic("List sorted by lastname");
            var members = Members.ToArray();
            QuickSort(members, 0, members.Length - 1, p => p.LastName);
            PrintList(members.ToList());
        }

        private void SortByAge()
        {
            Gui.Topic("List sorted by social number");

            var members = Members.ToArray();
            QuickSort(members, 0, members.Length - 1, p => p.SocialSecurityNumber);
            PrintList(members.ToList());
        }
        public List<T> Find<T,TProperty>(T[] members, Func<T,TProperty> selector, TProperty searchTerm)
        {
            var results = new List<T>();
           // bool found = false;
            foreach (var entity in members)
            {
                if(Comparer<TProperty>.Default.Compare(selector(entity), searchTerm) == 0)
                {
                    results.Add(entity);
                }
            }
            return results;

        }

        public List<T> BinaryFind<T, TProperty>(T[] members, Func<T, TProperty> selector, TProperty searchTerm)
        {
            QuickSort(members, 0, members.Length - 1, selector);
            var results = new List<T>();
            int mid;
            var first = 0;
            var last = members.Length - 1;
            while (first <= last)
            {
                mid = (first + last) / 2;

                if (Comparer<TProperty>.Default.Compare(selector(members[mid]), searchTerm) == 0)
                {
                    bool leftCheck = true;
                    bool rightCheck = true;
                    int i = 1;
                    results.Add(members[mid]);
                    if (rightCheck)
                    {
                        try
                        {
                            if (Comparer<TProperty>.Default.Compare(selector(members[mid + i]), searchTerm) == 0)
                            {
                                results.Add(members[mid + i]);
                                i++;
                            }
                            else
                            {
                                rightCheck = false;
                            }
                        }
                        catch
                        {
                            rightCheck = false;
                        }
                        
                    }
                    if (leftCheck)
                    {
                        try
                        {
                            if (Comparer<TProperty>.Default.Compare(selector(members[mid - i]), searchTerm) == 0)
                            {
                                results.Add(members[mid - i]);
                                i--;
                            }
                            else
                            {
                                leftCheck = false;
                            }
                        }
                        catch
                        {
                            leftCheck = false;
                        }
                        
                    }
                                                            
                    break;
                }
                    
                else if (Comparer<TProperty>.Default.Compare(selector(members[mid]), searchTerm) < 0)
                    first = mid + 1;           
                else if(Comparer<TProperty>.Default.Compare(selector(members[mid]), searchTerm) > 0)
                    last = mid - 1;

            }
           
            return results;

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
