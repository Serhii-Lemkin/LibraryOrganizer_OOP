using System;
using System.Collections.Generic;
using System.Linq;

namespace BookLib
{
    public class SearchServise
    {
        public List<AbstractItem> SearchByName(List<AbstractItem> filtered, string searchBy) 
            => new List<AbstractItem>(filtered.Where(x 
                =>x.Title.IndexOf(searchBy, StringComparison.OrdinalIgnoreCase) >= 0));
        public List<AbstractItem> SearchByType(List<AbstractItem> filtered, string searchBy) 
            => new List<AbstractItem>(filtered.Where(x => x.GetType().Name == searchBy));
        public List<AbstractItem> SearchByISBN(List<AbstractItem> filtered, string searchBy) 
            => new List<AbstractItem>(filtered.Where(x 
                =>x.ISBN.IndexOf(searchBy, StringComparison.OrdinalIgnoreCase) >= 0));
        public List<AbstractItem> SearchByGenre(List<AbstractItem> filtered, string searchBy) 
            => new List<AbstractItem>(filtered.Where(x 
                => x.Genre.ToString().IndexOf(searchBy, StringComparison.OrdinalIgnoreCase) >= 0));
        public List<AbstractItem> SearchByDate(List<AbstractItem> filtered, string searchBy) 
            => new List<AbstractItem>(filtered.Where(x 
                => x.PrintedDate.ToString().IndexOf(searchBy, StringComparison.OrdinalIgnoreCase) >= 0));

        public List<AbstractItem> SearchByPublisher(List<AbstractItem> filtered, string searchBy) 
            => new List<AbstractItem>(filtered.Where(x 
                    => x.Publisher.IndexOf(searchBy, StringComparison.OrdinalIgnoreCase) >= 0));

        public List<AbstractItem> SearchByCopyTax(List<AbstractItem> filtered, string searchBy)
        {
            if (double.TryParse(searchBy, out double num))
            {
                var tmp = new List<AbstractItem>
                    (filtered.Where(x => x.CopyTax == num));
                if (tmp.Count == 0)
                    tmp = new List<AbstractItem>
                            (filtered.Where(x => x.CopyTax < num + 5 && x.CopyTax > num - 5));
                return tmp;
            }
            else return filtered;
        }

        public List<AbstractItem> SearchByMonths(List<AbstractItem> filtered, string searchBy)
        {
            var tmp = new List<AbstractItem>();
            foreach (var item in filtered) 
                if (item is Journal j)
                    if (j.PublishedAtMonths.ToString().IndexOf(searchBy, StringComparison.OrdinalIgnoreCase) >= 0)
                        tmp.Add(j);
            return tmp;
        }

        public List<AbstractItem> SearchByAuthor(List<AbstractItem> filtered, string searchBy)
        {
            var tmp = new List<AbstractItem>();
            foreach (var item in filtered)
                if (item is Book j)
                    if (j.Author.IndexOf(searchBy, StringComparison.OrdinalIgnoreCase) >= 0)
                        tmp.Add(j);
            return tmp;
        }
    }

}
