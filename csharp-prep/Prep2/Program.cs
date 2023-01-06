using System;

class Program
{
    static void Main(string[] args)
    {
       Console.Write("What was your grade percent in the class?: ") ;
       string grade = Console.ReadLine();
       int gradeInt = int.Parse(grade);

       string letter = "";

       if (gradeInt >= 90 )
       {
            letter = "A";
       }
        else if (gradeInt >= 80)
        {
            letter = "B";
        }
        else if (gradeInt >= 70)
        {
             letter = "C";
            
        }
        else if (gradeInt >= 60)
        {
            letter = "D";
            
        }
        else
        {
             letter = "F";
            
        }

        Console.WriteLine($"You got a {letter}");
    
        if (gradeInt >= 70)
        {
            Console.WriteLine("You passed the class.");
        }
        else
        {
            Console.WriteLine("You failed the class.");
        }
    }
}