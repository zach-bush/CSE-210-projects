using System;
using System.IO;

public static class Program
{

    public static Journal _journal = new Journal();


    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Journal Program!");

        while (true)
        {
            Console.WriteLine(" Please choose an option: ");
            Console.WriteLine("1. Add an Entry.");
            Console.WriteLine("2. Display Entry.");
            Console.WriteLine("3. Load.");
            Console.WriteLine("4. Save.");
            Console.WriteLine("5. Quit ");
            string option = Console.ReadLine();

            if (option == "1")
                {
                    _journal.addEntry();
                    //Console.WriteLine("Please type a file name: ");
                    //string filename = Console.ReadLine();
                }

            else if (option == "2")
                {
                    _journal.displayEntry();
                }    
            else if (option == "5"){
                break;
            }

        } 



        
        

        // if statement portion
        




    }
}