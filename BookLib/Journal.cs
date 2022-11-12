using System;

namespace BookLib
{
    public class Journal : AbstractItem
    {
        public Months PublishedAtMonths { get; set; }
        public Journal(string title) : base(title) { }
    }
}
