using System;
using System.Collections.Generic;
using System.IO;

namespace solid
{
    public class Journal
    {
        private readonly List<string> entries = new List<string>();
        private static int count = 0;
        public int AddEntry(string text)
        {
        entries.Add($"{++count}: {text}");
        return count; // memento pattern!
        }

        public void RemoveEntry(int index)
        {
        entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }
    }
    public class Persistence
    {
        public void SaveToFile(Journal journal, string filename, bool overwrite = false)
        {
            if(overwrite || !File.Exists(filename))
                File.WriteAllText(filename, journal.ToString());
        }
    }
}