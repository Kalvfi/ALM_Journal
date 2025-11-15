namespace ALM_Journal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();
            bool run = true;

            while (run)
            {
                
            }

            Environment.Exit(0);
        }

        public void GenerateMenu()
        {
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
        }
    }
}
