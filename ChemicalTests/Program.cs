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
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------\n" +
                "Welcome to chemical testing for HI - Jean Cleaning!\n" +
                "Enter a sample of germs and choose a chemical.\n" +
                "The tests will show an efficency rating for each chemical sample you enter.\n" +
                "At the end of the program the system will generate and display lists of the worst and best chemicals tested.\n" +
                "--------------------------------------------------------------------------------------------------------------\n\n"
                );

            //test menu
            while (flag)
            {
                menuPick = CheckInt(
                    "~~~~~~~~~~~~~~\n"+
                    "Menu: \n" +
                    "1. Continue\n" +
                    "2. Stop\n"+
                    "~~~~~~~~~~~~~~\n", 1, 2);
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

            //sorting chemRating and CHEMICALS lists in order

            for (int leftPointer = 0; leftPointer < chemRating.Count - 1; leftPointer++)
            {
                for (int rightPointer = leftPointer + 1; rightPointer < chemRating.Count; rightPointer++)
                {
                    //Swopping logic
                    if (chemRating[leftPointer] < chemRating[rightPointer])
                    {
                        float tempRATE = chemRating[leftPointer];
                        chemRating[leftPointer] = chemRating[rightPointer];
                        chemRating[rightPointer] = tempRATE;
                        int tempCHEM = chosenChemicals[leftPointer];
                        chosenChemicals[leftPointer] = chosenChemicals[rightPointer];
                        chosenChemicals[rightPointer] = tempCHEM;

                    }
                }
            }

            //Ordered List top chems


            string top3Chem = "----- Top Rated Chemicals -----\n";

            int numLoop;

            if (chosenChemicals.Count >= 3)
            {
                numLoop = 3;
            }
            else
            {
                numLoop = chosenChemicals.Count;
            }

            for(int chemIndex = 0; chemIndex < numLoop; chemIndex++)
            {
                top3Chem+= chemIndex + 1 + "." + " " + CHEMICALS[chosenChemicals[chemIndex]] + "  " + chemRating[chemIndex] +"\n";
                
            }

            Console.WriteLine(top3Chem);

            //worst chems list

            string worst3Chem = "----- Worst Rated Chemicals -----\n";

            int numbLoop;
            int worstChemIndex = chosenChemicals.Count - 1;

            if (chosenChemicals.Count >= 3)
            {
                numbLoop = 3;
            }
            else
            {
                numbLoop = chosenChemicals.Count;
            }

            for (int loop = 0; loop < numbLoop; loop++)
            {
                worst3Chem += worstChemIndex + 1 + "." + " " + CHEMICALS[chosenChemicals[worstChemIndex]] + "  " + chemRating[worstChemIndex] + "\n";
                worstChemIndex--;
            }
            Console.WriteLine(worst3Chem);
        }  



            //additonal methods

            //check to see chemical has not been tested before
            //chemical choice
            static int CheckChemical()
            {
                while (true)
                {

                    int chemChoice = CheckInt("\nPlease select the chemical being tested:\n\n" +
                       $"1. {CHEMICALS[0]}\n" +
                       $"2. {CHEMICALS[1]}\n" +
                       $"3. {CHEMICALS[2]}\n" +
                       $"4. {CHEMICALS[3]}\n" +
                       $"5. {CHEMICALS[4]}\n", 1, 5);

                    //error message for chosen chem
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

                    float liveGerm = CheckInt($"\nEnter amount of live germs in sample (30-300): Test {i}\n", 30, 300);
                    
                    Console.WriteLine("-------------------------------------------------------------------------------\n" +
                        "~~~~ Please wait 30 minutes before checking remaining live germs in sample ~~~\n" +
                        "-------------------------------------------------------------------------------");

                    //follow up live germ sample
                 
                    float remGerms = CheckInt("\nPlease enter remaining live germs in sample;", 0, 300);
                    
                    //efficency rating
                    float efficRate = (liveGerm - remGerms) / 30;

                    sumEffic += efficRate;

                    Console.WriteLine($"\nThe efficency rating for {CHEMICALS[chosenChemicals[chosenChemicals.Count - 1] - 1]} is {efficRate} \n");



                }
                //final efficency rating
                float finalEfficRate = (float)Math.Round(sumEffic / 5, 2);


                chemRating.Add(finalEfficRate);

                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine($"\n The final efficency rating of {CHEMICALS[chosenChemicals[chosenChemicals.Count - 1] - 1]} is {finalEfficRate}\n");
                Console.WriteLine("-------------------------------------------------------------------------------");







            }
                //error messages
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
