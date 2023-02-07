public class Journal
{
    Random random = new Random ();
    private Prompt _prompt = new Prompt();
    public List<Entry> Entries = new List<Entry>();
   
    public void AddEntry(){
        
        string prompt = _prompt.prompts[ random.Next(0,4)];
        Console.WriteLine(prompt);
        string userInput = Console.ReadLine();
        //File.CreateText(userInput);

        Entry entry = new Entry();
        entry.Date = DateTime.Now.ToShortDateString();
        entry.Prompt = prompt;
        entry.Text = userInput;
        Entries.Add(entry);
        
    }

    public void DisplayEntry(){
        for (int i = 0; i<Entries.Count; i++){
            Entry entry = Entries[i];
            Console.WriteLine(entry.Date);
            Console.WriteLine(entry.Prompt);
            Console.WriteLine(entry.Text);
            Console.WriteLine();
        }
        
    }
    

    public void SaveEntry(){
        using (StreamWriter sw = File.CreateText("file.txt"))
        {
            for (int i = 0; i<Entries.Count; i++)
            {
                Entry entry = Entries[i];
                sw.Write(entry.Date);
                sw.Write("|");
                sw.Write(entry.Prompt);
                sw.Write("|");
                sw.Write(entry.Text);
                sw.Write("\n");
                
               
            }
        }


       
    }


    public void LoadEntry()
    {
        Entries.Clear();
        string filename = "file.txt";
        string[] lines = System.IO.File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split("|");
            Entry entry = new Entry();
            entry.Date = parts[0];
            entry.Prompt = parts[1];
            entry.Text = parts[2];
            Entries.Add(entry);
        }

    }


}

