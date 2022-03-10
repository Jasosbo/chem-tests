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
            //first live germ sample
            Console.WriteLine("Entering live germ sample:\n" +
                "To enter manualy enter 1 or to randonmly generate enter 2"
                );


            float germNum = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture.NumberFormat);



            if (germNum == 1)
            {
                Console.WriteLine("Enter amount of live germs in sample\n");
                float liveGerm = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture.NumberFormat);

            }
            else
            {
                Random rnd = new Random();
                float liveGerm = rnd.Next();
                Console.WriteLine($"{liveGerm}");
            }


            Console.WriteLine("\nPlease select the chemical being tested:\n\n" +
                "1. Chlorine\n" +
                "2. Formaldehyde\n" +
                "3. Hydrogen Peroxide\n" +
                "4. Ethanol\n" +
                "5. Peracetic Acid\n"
                );

            int chemchoice = Convert.ToInt32(Console.ReadLine());

            
            //follow up live germ sample
            Console.WriteLine("\nPlease enter remaining live germs in sample");

            float remGerms = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture.NumberFormat);




        }




    }



}
