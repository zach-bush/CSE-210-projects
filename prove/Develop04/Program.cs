using System;
using System.Threading;

public class Program
{
    public static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to Mindfulness Activities!");
            Console.WriteLine("Please choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");

            int choice = ReadIntInput("Enter your choice:");

            switch (choice)
            {
                case 1:
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.Start();
                    break;

                case 2:
                    ReflectionActivity reflectionActivity = new ReflectionActivity();
                    reflectionActivity.Start();
                    break;

                case 3:
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.Start();
                    break;

                case 4:
                    Console.WriteLine("Thank you for using Mindfulness Activities. Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                    break;
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    public static int ReadIntInput(string message)
    {
        int input;

        while (true)
        {
            Console.Write(message);

            if (int.TryParse(Console.ReadLine(), out input))
            {
                return input;
            }

            Console.WriteLine("Invalid input. Please enter an integer value.");
        }
    }
}

public abstract class MindfulnessActivity
{
    protected int duration;

    public virtual void Start()
    {
        Console.Clear();
        Console.WriteLine("Starting " + this.GetType().Name + " activity...");
        Console.WriteLine(this.GetDescription());
        this.SetDuration();
        Console.WriteLine("Get ready to begin in 5 seconds...");
        this.ShowCountdown(5);
        this.PerformActivity();
        this.ShowSummary();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public virtual string GetDescription()
    {
        return "No description available.";
    }

    public virtual void SetDuration()
    {
        this.duration = Program.ReadIntInput("Enter the duration of the activity in seconds:");
    }

    public virtual void PerformActivity()
    {
        Console.WriteLine("No activity available.");
    }

    public virtual void ShowSummary()
    {
        Console.WriteLine("No summary available.");
    }

    public void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i + " ");
            Thread.Sleep(1000);
        }

        Console.WriteLine();
    }

    public void ShowSpinner(int seconds)
    {
        int counter = 0;
        int delay = 100;

        while (seconds > 0)
        {
            counter = (counter + 1) % 4;
            Console.Write("\rProcessing" + new string('.', counter));
            Thread.Sleep(delay);
            seconds--;
        }

        Console.WriteLine();
    }
}

public class BreathingActivity : MindfulnessActivity
{
    public override string GetDescription()
    {
        return "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public override void PerformActivity()
    {
        Console.WriteLine("Breathe in...");
        this.ShowCountdown(3);
        Console.WriteLine("Breathe out...");
        this.ShowCountdown(3);

        int remainingSeconds = this.duration - 6;

    }
}
        
