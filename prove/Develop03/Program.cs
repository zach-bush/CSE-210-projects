using System;

class Program
{
    private static Reference _ref = new Reference();
    static void Main(string[] args)
    {
        Database database = new Database();

        Console.WriteLine("What scriputure would you like to memorize?");
        string option = "";
        while (option != "6")
        {
            Console.WriteLine("What scripture would you like to memorize?");
            Console.WriteLine("1. 1 Nephi 10:19");
            Console.WriteLine("2. Helamen  5:12");
            Console.WriteLine("3. Ether 12:12");
            Console.WriteLine("4. Ether 12:27");
            Console.WriteLine("5. 2 Nephi 1:23");
            option = Console.ReadLine();

            if (option == "1")
            {
                Scripture scripture = database.GetScripture();
                Console.WriteLine(scripture.AsString());
            }
        }
    }
}