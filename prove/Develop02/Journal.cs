public class Journal
{
    Random random = new Random ();
    private Prompt _prompt = new Prompt();
    public List<Entry> Entries = new List<Entry>();
   
    public void addEntry(){
        
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

    public void displayEntry(){
        for (int i = 0; i<Entries.Count; i++){
            Entry entry = Entries[i];
            Console.WriteLine(entry.Date);
            Console.WriteLine(entry.Prompt);
            Console.WriteLine(entry.Text);
            Console.WriteLine();
        }
        
    }
    

    public void saveEntry(){
        using (StreamWriter sw = File.CreateText("file.txt"));
         for (int i = 0; i<Entries.Count; i++){
            Entry entry = Entries[i];
            Console.WriteLine();
            Console.WriteLine(entry.Date);
            Console.WriteLine(entry.Prompt);
            Console.WriteLine(entry.Text);
            Console.WriteLine();
         }
    }
}

