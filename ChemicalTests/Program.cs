﻿using System;
using System.Globalization;

namespace ChemicalTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------------------------------------------------\n" +
                "welcome to chemical testing\n" +
                "You enter a sample of germs and each chemical.\n" +
                "the tests will show an efficency rating for each sample you enter\n" +
                "---------------------------------------------------------------\n\n\n" +
                "Entering live germ sample:\n" +
                "To enter manualy enter 1 or to randonmly generate enter 2"
                );


            TestChemical();


        }

        static void TestChemical()
        {
            float germNum = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture.NumberFormat);



            if (germNum == 1)
            {
                Console.WriteLine("Enter amount of live germs in sample\n");
            }
            else
            {
                Random rnd = new Random();
                float randflo = rnd.Next();
                Console.WriteLine($"{randflo}");
            }
        }





    }



}
