using System;

public static class ProgramFormatted
{
    public static Journal _journal = new Journal();

    static void Main2(string[] args)
    {
        Console.WriteLine("Welcome to the Journal Program!");

        string option = "";
        while (option != "5")
        {
            Console.WriteLine(" Please choose an option: ");
            Console.WriteLine("1. Add an Entry.");
            Console.WriteLine("2. Display Entry.");
            Console.WriteLine("3. Load.");
            Console.WriteLine("4. Save.");
            Console.WriteLine("5. Quit ");

            option = Console.ReadLine();

            if (option == "1")
            {
                _journal.AddEntry();
            }
            else if (option == "2")
            {
                _journal.DisplayEntry();
            }    
            else if (option == "3")
            {
                _journal.LoadEntry();
            }
            else if (option == "4")
            {
                _journal.SaveEntry();
            }
        } 
    }
}