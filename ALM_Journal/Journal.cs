using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALM_Journal
{
    internal class Journal
    {
        public int Count
        {
            get
            {
                int count = 0;
                JournalEntry? current = FirstEntry;
                while (current != null)
                {
                    count++;
                    current = current.Next;
                }
                return count;
            }
        }
        public JournalEntry? FirstEntry { get; private set; }
        public JournalEntry? LastEntry { get; private set; }

        public void AddAfter(JournalEntry newEntry, JournalEntry? existingEntry)
        {
            if (existingEntry == null)
            {
                if (FirstEntry == null)
                {
                    FirstEntry = newEntry;
                    LastEntry = newEntry;
                }
                else
                {
                    newEntry.Previous = LastEntry;
                    LastEntry!.Next = newEntry;
                    LastEntry = newEntry;
                }
            }
            else
            {
                newEntry.Next = existingEntry.Next;
                newEntry.Previous = existingEntry;
                if (existingEntry.Next == null)
                {
                    LastEntry = newEntry;
                }
                else
                {
                    existingEntry.Next.Previous = newEntry;
                }
                existingEntry.Next = newEntry;
            }
        }

        public void AddBefore(JournalEntry newEntry, JournalEntry? existingEntry)
        {
            if (existingEntry == null)
            {
                if (FirstEntry == null)
                {
                    FirstEntry = newEntry;
                    LastEntry = newEntry;
                }
                else
                {
                    newEntry.Next = FirstEntry;
                    FirstEntry!.Previous = newEntry;
                    FirstEntry = newEntry;
                }
            }
            else
            {
                newEntry.Previous = existingEntry.Previous;
                newEntry.Next = existingEntry;
                if (existingEntry.Previous == null)
                {
                    FirstEntry = newEntry;
                }
                else
                {
                    existingEntry.Previous.Next = newEntry;
                }
                existingEntry.Previous = newEntry;
            }
        }

        public void AddFirst(JournalEntry newEntry)
        {
            AddBefore(newEntry, FirstEntry);
        }

        public void AddLast(JournalEntry newEntry)
        {
            AddAfter(newEntry, LastEntry);
        }

        public void Remove(JournalEntry entry)
        {
            if (entry.Previous == null)
            {
                FirstEntry = entry.Next;
            }
            else
            {
                entry.Previous.Next = entry.Next;
            }
            if (entry.Next == null)
            {
                LastEntry = entry.Previous;
            }
            else
            {
                entry.Next.Previous = entry.Previous;
            }
            entry = null;
        }

        public void RemoveFirst()
        {
            if (FirstEntry != null)
            {
                Remove(FirstEntry);
            }
        }

        public void RemoveLast()
        {
            if (LastEntry != null)
            {
                Remove(LastEntry);
            }
        }
    }
}
