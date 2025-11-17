namespace ALM_Journal
{
    internal class Program
    {
        static Journal journal = new Journal();
        static JournalEntry? toShow = null;

        static void Main(string[] args)
        {
            bool run = true;

            while (run)
            {
                ShowMenu();
                ShowEntry(toShow);

                
                Console.Write("Zadej příkaz: ");
                string prikaz = Console.ReadLine()!;
                switch (prikaz)
                {
                    case "predchozi":
                        MovePrevious();
                        break;
                    case "dalsi":
                        MoveNext();
                        break;
                    case "zacatek":
                        MoveFirst();
                        break;
                    case "konec":
                        MoveLast();
                        break;
                    case "novy":
                        CreateNewEntry();
                        break;
                    case "smaz":
                        DeleteCurrentEntry(toShow);
                        break;
                    case "zavri":
                        run = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Neplatný příkaz. Zkuste to znovu.");
                        Console.ReadKey();
                        break;
                }
            }

            Environment.Exit(0);
        }

        private static void ShowEntry(JournalEntry? entry)
        {
            if (entry == null) return;

            Console.WriteLine("Datum: " + entry.Date.ToString("dd.MM.yyyy") + '\n');
            Console.WriteLine(entry.Text);
            Console.WriteLine(new string('-', 30) + '\n');
        }

        private static void MovePrevious()
        {
            if (toShow != null && toShow.Previous != null) toShow = toShow.Previous;
        }

        private static void MoveNext()
        {
            if (toShow != null && toShow.Next != null) toShow = toShow.Next;
        }

        private static void MoveFirst()
        {
            if (journal.FirstEntry != null) toShow = journal.FirstEntry;
        }

        private static void MoveLast()
        {
            if (journal.LastEntry != null) toShow = journal.LastEntry;
        }

        private static void CreateNewEntry()
        {
            DateTime date;
            
            ShowMenu();
            Console.Write("Datum: ");

            while (!DateTime.TryParse(Console.ReadLine(), out date))
            {
                ShowMenu();
                Console.Write("Špatný formát, zkus to znovu: ");
            }

            ShowMenu();
            Console.WriteLine("Datum: " + date.ToString("dd.MM.yyyy") + '\n');

            string text = "";

            Console.WriteLine("Text:");
            string line = null;
            while (line != "uloz")
            {
                line = Console.ReadLine()!;
                if (line == "uloz") break;
                text += line + '\n';
            }

            SaveCurrentEntry(date, text);
            return;
        }

        private static void SaveCurrentEntry(DateTime date, string text)
        {
            JournalEntry newEntry = new JournalEntry(date, text);
            journal.AddLast(newEntry);
            toShow = newEntry;
        }

        private static void DeleteCurrentEntry(JournalEntry? entry)
        {
            if (entry == null) return;

            Console.Clear();
            ShowEntry(entry);

            Console.WriteLine("Pro odstranění tohoto záznamu stiskni 'a', pro zrušení jiný znak.");
            char key = Console.ReadKey().KeyChar;
            if (key == 'a')
            {
                journal.Remove(entry);
                toShow = journal.FirstEntry;
            }

            return;
        }

        public static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine(new string('-', 30));
            Console.WriteLine("Deník se ovládá následujícími příkazy:");
            Console.WriteLine("- predchozi: Přesunutí na předchozí záznam");
            Console.WriteLine("- dalsi: Přesunutí na další záznam");
            Console.WriteLine("- zacatek: Přesunutí na první záznam");
            Console.WriteLine("- konec: Přesunutí na poslední záznam");
            Console.WriteLine("- novy: Vytvoření nového záznamu");
            Console.WriteLine("- uloz: Uložení vytvořeného záznamu");
            Console.WriteLine("- smaz: Odstranění záznamu");
            Console.WriteLine("- zavri: Zavření deníku");
            Console.WriteLine(new string('-', 30) + '\n');
            Console.WriteLine("Počet záznamů: " + journal.Count + '\n');
        }
    }
}
