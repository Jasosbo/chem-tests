using System;
using System.Globalization;

namespace ChemicalTests
{
    class Program
    {



        static void Main(string[] args)
        {
            Console.WriteLine("---------------------------------------------------------------\n" +
                "Welcome to chemical testing!\n" +
                "You enter a sample of germs and each chemical.\n" +
                "The tests will show an efficency rating for each sample you enter.\n" +
                "---------------------------------------------------------------\n\n" 
                );


            TestChemical();


        }

        static void TestChemical()
        {

            Console.WriteLine("\nPlease select the chemical being tested:\n\n" +
                   "1. Chlorine\n" +
                   "2. Formaldehyde\n" +
                   "3. Hydrogen Peroxide\n" +
                   "4. Ethanol\n" +
                   "5. Peracetic Acid\n"
                   );

            int chemchoice = Convert.ToInt32(Console.ReadLine());
 
            for (int i = 1; i < 6; i++) 
            {

                //first live germ sample

                Console.WriteLine($"\nEnter amount of live germs in sample : Test {i}\n");
                float liveGerm = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture.NumberFormat);

                Console.WriteLine("-------------------------------------------------------------------------------\n"+
                    "~~~~ Please wait 30 minutes before checking remaining live germs in sample ~~~\n" +
                    "-------------------------------------------------------------------------------");

                //follow up live germ sample
                Console.WriteLine("\nPlease enter remaining live germs in sample");

                float remGerms = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture.NumberFormat);

                //efficency rating
                float efficRate = (liveGerm - remGerms) / 30;


                Console.WriteLine($"\nThe efficency rating for ---- is {efficRate} ");

            }

           


        }




    }



}
