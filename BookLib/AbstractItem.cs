using System;

namespace BookLib
{
    public abstract class AbstractItem
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public Genres Genre { get; set; }
        public DateTime PrintedDate { get; set; }
        public string Publisher { get; set; }
        public double CopyTax { get; set; }

        public AbstractItem(string title)
        {
            Title = title;
            ISBN = Guid.NewGuid().ToString();
            PrintedDate = new DateTime(1997, 05, 12);
        }
    }
}
