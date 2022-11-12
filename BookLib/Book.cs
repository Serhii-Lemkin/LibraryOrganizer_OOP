namespace BookLib
{
    public class Book : AbstractItem
    {
        public string Author { get; set; }
        public Book(string title) : base(title) {}

    }
}
