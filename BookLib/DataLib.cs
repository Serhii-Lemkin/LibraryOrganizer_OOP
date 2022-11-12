using System;
using System.Collections.Generic;
using System.Linq;

namespace BookLib
{
    public class DataLib
    {
        public string[] ComboboxTypeNames { get; set; }
        public List<string> BookProps { get; set; }
        public List<string> JournalProps { get; set; }
        public List<string> AbstractProps { get; set; }
        public List<Genres> GenresList { get; set; }
        public List<Months> MonthsList { get; set; }
        public DataLib()
        {
            BookProps = new List<string>();
            foreach (var item in typeof(Book).GetProperties()) BookProps.Add(item.Name);
            JournalProps = new List<string>();
            foreach (var item in typeof(Journal).GetProperties()) JournalProps.Add(item.Name);
            AbstractProps = new List<string>();
            foreach (var item in typeof(AbstractItem).GetProperties()) AbstractProps.Add(item.Name);
            ComboboxTypeNames = new string[3] { "Book", "Journal", "Book Or Journal" };
            GenresList = Enum.GetValues(typeof(Genres)).Cast<Genres>().ToList();
            MonthsList = Enum.GetValues(typeof(Months)).Cast<Months>().ToList();
        }
    }
}