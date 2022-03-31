//imports
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ChemicalTests
{

    class Program
    {

        //global variables

        static readonly List<string> CHEMICALS = new List<string>() { "Chlorine", "Formaldehyde", "Hydrogen Peroxide", "Ethanol", "Peracetic Acid" };
        static List<float> chemRating = new List<float>();
        static List<int> chosenChemicals = new List<int>();

        //methods

        //main process/when run

        static void Main(string[] args)
        {
            int menuPick;
            bool flag = true;


            //welcome message
            Console.WriteLine("---------------------------------------------------------------\n" +
                "Welcome to chemical testing for HI - Jean Cleaning!\n" +
                "You enter a sample of germs and each chemical.\n" +
                "The tests will show an efficency rating for each sample you enter.\n" +
                "---------------------------------------------------------------\n\n"
                );

            //test menu
            while (flag)
            {
                menuPick = CheckInt("Menu: \n" +
                    "1. Continue\n" +
                    "2. Stop", 1, 2);
                if (menuPick == 1)
                {
                    TestChemical();
                }
                else if (menuPick == 2)
                {
                    Console.WriteLine("Thank you for trying HI-Jean Cleaning\n");
                    flag = false;
                }
                else
                {
                    Console.WriteLine("Error: Input must be 1 or 2\n");
                }



            }


        }

        //additonal methods

        //check to see chemical has not been tested before
        static int CheckChemical()
        {
            while (true)
            {

                Console.WriteLine("\nPlease select the chemical being tested:\n\n" +
                       $"1. {CHEMICALS[0]}\n" +
                       $"2. {CHEMICALS[1]}\n" +
                       $"3. {CHEMICALS[2]}\n" +
                       $"4. {CHEMICALS[3]}\n" +
                       $"5. {CHEMICALS[4]}\n"
                       );

                int chemChoice = Convert.ToInt32(Console.ReadLine());


                if (chosenChemicals.Contains(chemChoice))
                {
                    Console.WriteLine("ERROR: chemical has already been tested");

                }
                else
                {
                    return chemChoice;
                }
            }

        }



        //calculates the efficency of chemical

        static void TestChemical()
        {

            chosenChemicals.Add(CheckChemical());

            float sumEffic = 0;

            for (int i = 1; i < 6; i++)
            {

                //first live germ sample

                Console.WriteLine($"\nEnter amount of live germs in sample : Test {i}\n");
                float liveGerm = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture.NumberFormat);

                Console.WriteLine("-------------------------------------------------------------------------------\n" +
                    "~~~~ Please wait 30 minutes before checking remaining live germs in sample ~~~\n" +
                    "-------------------------------------------------------------------------------");

                //follow up live germ sample
                Console.WriteLine("\nPlease enter remaining live germs in sample");

                float remGerms = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture.NumberFormat);

                //efficency rating
                float efficRate = (liveGerm - remGerms) / 30;

                sumEffic += efficRate;

                Console.WriteLine($"\nThe efficency rating for {CHEMICALS[chosenChemicals[chosenChemicals.Count - 1]]} is {efficRate} \n");



            }

            float finalEfficRate = (float)Math.Round(sumEffic / 5, 2);


            chemRating.Add(finalEfficRate);

            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine($"\n The final efficency rating of {CHEMICALS[chosenChemicals[chosenChemicals.Count - 1]]} is {finalEfficRate}\n");
            Console.WriteLine("-------------------------------------------------------------------------------");

                
            




        }

        static int CheckInt(string question, int min, int max)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine(question);
                    int user_choice = Convert.ToInt32(Console.ReadLine());



                    if (user_choice >= min && user_choice <= max)
                    {
                        return user_choice;
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: Please enter a number between {min} and {max}\n");
                    }
                }
                catch
                {
                    Console.WriteLine($"ERROR: Please enter a number between {min} and {max}\n");
                }




            }

        }
    }

}
