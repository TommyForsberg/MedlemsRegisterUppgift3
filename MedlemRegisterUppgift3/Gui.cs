using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedlemRegisterUppgift3
{
    class Gui
    {
        public static void StartMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("       * ***************************************************************************************************************");
            Console.WriteLine("         **************************************************************************************************************");
            Console.WriteLine("        **                                                                                                            **");
            Console.WriteLine("        **                                                                                                            **");
            Console.WriteLine("        **                                 Vänligen välj en av alternativen                                           **");
            Console.WriteLine("        **                                                                                                            **");
            Console.WriteLine("        **                                                                                                            **");
            Console.WriteLine("        **                                     1. Sort by age                                                         **");
            Console.WriteLine("        **                                                                                                            **");
            Console.WriteLine("        **                                     2. Sort by Lastname                                                    **");
            Console.WriteLine("        **                                                                                                            **");
            Console.WriteLine("        **                                     3. Membersship not paid                                                **");
            Console.WriteLine("        **                                                                                                            **");
            Console.WriteLine("        **                                     4. Search by Lastname/Socialnumber (Membersship not paid )             **");
            Console.WriteLine("        **                                                                                                            **");
            Console.WriteLine("        **                                     5. Init list  and clear the app                                        **");
            Console.WriteLine("        **                                                                                                            **");
            Console.WriteLine("        **                                     0. Exit                                                                **");
            Console.WriteLine("        **                                                                                                            **");
            Console.WriteLine("        **                            ****------- To quit the app Press C -----****                                   **");
            Console.WriteLine("         **************************************************************************************************************");
            Console.WriteLine("        ****************************************************************************************************************");
            Console.Write("\n");
            Console.ResetColor();
        }

        public static void Topic(string topic)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("     ************ {0} : ***********", topic);
            Console.ResetColor();
        }
    }
}
