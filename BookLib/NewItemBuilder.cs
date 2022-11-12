using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BookLib
{
    public class NewItemBuilder : INotifyPropertyChanged
    {
        public double NewCopyTax { get => newCopyTax; set { newCopyTax = value; OnPropertyChanged(); } }
        public string NewPublisher { get; set; }
        public string NewAuthor { get; set; }
        public DateTime NewPrintedDate { get; set; }
        public Months SelectedMonth { get; set; }
        private Months newMonth;
        public Months NewMonth
        {
            get { return newMonth; }
            set
            {
                newMonth = value;
                OnPropertyChanged(nameof(NewMonth));
            }
        }
        public Book NewBook { get; set; }
        public Journal NewJournal { get; set; }
        public string NewTitle { get; set; }
        public Genres NewGenre { get; set; }
        private Genres genre;
        public Genres Genre
        {
            get { return genre; }
            set
            {
                genre = value;
                OnPropertyChanged(nameof(Genre));
            }
        }
        ItemsCollection Stock { get; set; }
        public NewItemBuilder()
        {
            NewPrintedDate = new DateTime(1997, 10, 5);
            NewPublisher = "Publisher Name";
            Stock = ItemsCollection.Instance;
            NewBook = new Book("");
            NewJournal = new Journal("");
        }
        public void AddItem(string type)
        {
            if (!string.IsNullOrEmpty(NewTitle) && !string.IsNullOrWhiteSpace(NewTitle))
            {
                if (type == "Book")
                {
                    NewBook.Title = NewTitle;
                    NewBook.Genre = Genre;
                    NewBook.PrintedDate = NewPrintedDate;
                    NewBook.Publisher = NewPublisher;
                    NewBook.CopyTax = NewCopyTax;
                    NewBook.Author = NewAuthor;
                    Stock.AddNew(NewBook);
                    NewBook = new Book("");
                }
                else if (type == "Journal")
                {
                    NewJournal.Title = NewTitle;
                    NewJournal.Genre = Genre;
                    NewJournal.PublishedAtMonths = NewMonth;
                    NewJournal.PrintedDate = NewPrintedDate;
                    NewJournal.Publisher = NewPublisher;
                    NewJournal.CopyTax = NewCopyTax;
                    Stock.AddNew(NewJournal);
                    NewJournal = new Journal("");
                }
                Genre = default;
            }
        }
        public void InitiateEditing()
        {
            if (Stock.SelectedAbstractItem is Book b)
            {
                NewTitle = b.Title;
                Genre = b.Genre;
                NewPrintedDate = b.PrintedDate;
                NewPublisher = b.Publisher;
                NewCopyTax = b.CopyTax;
                NewAuthor = b.Author;
            }
            else if (Stock.SelectedAbstractItem is Journal j)
            {
                NewTitle = j.Title;
                Genre = j.Genre;
                NewMonth = j.PublishedAtMonths;
                NewPrintedDate = j.PrintedDate;
                NewPublisher = j.Publisher;
                NewCopyTax = j.CopyTax;
            }
        }
        public void RemoveMonth() { if (NewMonth.HasFlag(SelectedMonth)) NewMonth -= SelectedMonth; }
        public void AddMonth() { if (!NewMonth.HasFlag(SelectedMonth)) NewMonth |= SelectedMonth; }
        public void RemoveGenre() { if (Genre.HasFlag(NewGenre)) Genre -= NewGenre; }
        public void AddGenre() { if (!Genre.HasFlag(NewGenre)) Genre |= NewGenre; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private static NewItemBuilder instance;
        private double newCopyTax;

        public static NewItemBuilder Instance => instance ?? (instance = new NewItemBuilder());

    }
}
