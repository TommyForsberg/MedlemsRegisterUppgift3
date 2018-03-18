using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VGUppgift
{
    class Gui
    {
        public static void StartMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("       * ***************************************************************************************************************");
            Console.WriteLine("         **************************************************************************************************************");
            Console.WriteLine("        **                                      ----  VG Uppgift   ----                                               **");
            Console.WriteLine("        **                                                                                                            **");
            Console.WriteLine("        **                                 Vänligen välj en av alternativen                                           **");
            Console.WriteLine("        **                                                                                                            **");
            Console.WriteLine("        **                                                                                                            **");
            Console.WriteLine("        **                                     1. Sort 10 000 random numbers                                          **");
            Console.WriteLine("        **                                                                                                            **");
            Console.WriteLine("        **                                     2. Sort 20 000 random numbers                                          **");
            Console.WriteLine("        **                                                                                                            **");
            Console.WriteLine("        **                                     3. Sort 40 000 random numbers                                          **");
            Console.WriteLine("        **                                                                                                            **"); Console.WriteLine("        **                                                                                                            **");
            Console.WriteLine("        **                                     0. Exit                                                                **");
            Console.WriteLine("        **                                                                                                            **");
            Console.WriteLine("        **                            ****------- To quit the app Press 0 -----****                                   **");
            Console.WriteLine("         **************************************************************************************************************");
            Console.WriteLine("        ****************************************************************************************************************");
            Console.Write("\n");
            Console.ResetColor();
        }
    }
}
