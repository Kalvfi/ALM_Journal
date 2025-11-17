using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALM_Journal
{
    internal class JournalEntry
    {
        public JournalEntry? Next;
        public JournalEntry? Previous;
        public DateTime Date { get; private set; }
        public string? Text { get; private set; }

        public JournalEntry(DateTime date, string? text)
        {
            Date = date;
            Text = text;
        }

    }
}
