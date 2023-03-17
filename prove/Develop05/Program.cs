using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public abstract class Goal
{
    public string Name { get; set; }
    public int PointsPerCompletion { get; set; }
    public int CompletedCount { get; protected set; }

    public abstract bool IsCompleted();
    public abstract int RecordCompletion();
}

[Serializable]
public class SimpleGoal : Goal
{
    public override bool IsCompleted()
    {
        return CompletedCount > 0;
    }

    public override int RecordCompletion()
    {
        CompletedCount++;
        return PointsPerCompletion;
    }
}

[Serializable]
public class EternalGoal : Goal
{
    public override bool IsCompleted()
    {
        return false;
    }

    public override int RecordCompletion()
    {
        CompletedCount++;
        return PointsPerCompletion;
    }
}

[Serializable]
public class ChecklistGoal : Goal
{
    public int RequiredCompletions { get; set; }
    public int BonusPoints { get; set; }

    public override bool IsCompleted()
    {
        return CompletedCount >= RequiredCompletions;
    }

    public override int RecordCompletion()
    {
        CompletedCount++;

        if (IsCompleted())
            return PointsPerCompletion + BonusPoints;

        return PointsPerCompletion;
    }
}

public class GoalTracker
{
    public List<Goal> Goals { get; set; } = new List<Goal>();
    public int Score { get; set; }

    public void AddGoal(Goal goal)
    {
        Goals.Add(goal);
    }

    public int RecordGoalCompletion(int index)
    {
        int points = Goals[index].RecordCompletion();
        Score += points;
        return points;
    }

    public void SaveGoals(string filename)
    {
        IFormatter formatter = new BinaryFormatter();
        using (Stream stream = new FileStream(filename, FileMode.Create, FileAccess.Write))
        {
            formatter.Serialize(stream, Goals);
        }
    }

    public void LoadGoals(string filename)
    {
        IFormatter formatter = new BinaryFormatter();
        using (Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read))
        {
            Goals = (List<Goal>)formatter.Deserialize(stream);
        }
    }
}

class Program
{
   class Program
{
    static void Main(string[] args)
    {
        GoalTracker goalTracker = new GoalTracker();
        string input;
        int option;

        while (true)
        {
            Console.WriteLine("1. Create a new goal");
            Console.WriteLine("2. Record an event");
            Console.WriteLine("3. Show goals");
            Console.WriteLine("4. Display score");
            Console.WriteLine("5. Save goals");
            Console.WriteLine("6. Load goals");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option: ");
            input = Console.ReadLine();
            int.TryParse(input, out option);

            switch (option)
            {
                case 1:
                    CreateGoal(goalTracker);
                    break;
                case 2:
                    RecordEvent(goalTracker);
                    break;
                case 3:
                    ShowGoals(goalTracker);
                    break;
                case 4:
                    Console.WriteLine($"Current score: {goalTracker.Score}");
                    break;
                case 5:
                    goalTracker.SaveGoals("goals.bin");
                    Console.WriteLine("Goals saved.");
                    break;
                case 6:
                    goalTracker.LoadGoals("goals.bin");
                    Console.WriteLine("Goals loaded.");
                    break;
                case 7:
                    return;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void CreateGoal(GoalTracker goalTracker)
    {
        Console.WriteLine("Goal types:");
        Console.WriteLine("1. Simple goal");
        Console.WriteLine("2. Eternal goal");
        Console.WriteLine("3. Checklist goal");
        Console.Write("Choose a goal type: ");
        int type = int.Parse(Console.ReadLine());
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter points per completion: ");
        int points = int.Parse(Console.ReadLine());

        Goal goal;

        switch (type)
        {
            case 1:
                goal = new SimpleGoal { Name = name, PointsPerCompletion = points };
                break;
            case 2:
                goal = new EternalGoal { Name = name, PointsPerCompletion = points };
                break;
            case 3:
                Console.Write("Enter required completions: ");
                int requiredCompletions = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonusPoints = int.Parse(Console.ReadLine());
                goal = new ChecklistGoal { Name = name, PointsPerCompletion = points, RequiredCompletions = requiredCompletions, BonusPoints = bonusPoints };
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                return;
        }

        goalTracker.AddGoal(goal);
        Console.WriteLine("Goal created.");
    }

    static void RecordEvent(GoalTracker goalTracker)
    {
        ShowGoals(goalTracker);
        Console.Write("Enter the index of the goal you want to record: ");
        int index = int.Parse(Console.ReadLine());
        int points = goalTracker.RecordGoalCompletion(index);
        Console.WriteLine($"Event recorded. {points} points added.");
    }

    static void ShowGoals(GoalTracker goalTracker)
    {
        Console.WriteLine("Goals:");
        for (int i = 0; i < goalTracker.Goals.Count; i++)
        {
            Goal goal = goalTracker.Goals[i];
            string completionStatus = goal.IsCompleted() ? "[X]" : "[ ]";
            string checklistProgress = goal is ChecklistGoal ? $" Completed {goal.CompletedCount}/{((ChecklistGoal)goal).RequiredCompletions
            }
        
}
