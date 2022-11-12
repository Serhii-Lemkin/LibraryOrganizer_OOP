using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace BookLib
{
    public class ItemsCollection : INotifyPropertyChanged
    {
        public ObservableCollection<AbstractItem> Collection { get; set; }
        private string selectedItemType;
        public string SelectedItemType
        {
            get => selectedItemType; 
            set
            {
                selectedItemType = value;
                OnSelectedPropertyChanged();
            }
        }
        private Journal selectedJournal;
        public Journal SelectedJournal
        {
            get { return selectedJournal; }
            set
            {
                selectedJournal = value;
                OnPropertyChanged();
            }
        }
        private Book selectedBook;
        public Book SelectedBook
        {
            get { return selectedBook; }
            set
            {
                selectedBook = value;
                OnPropertyChanged();
            }
        }
        private AbstractItem selectedAbstractItem;
        public AbstractItem SelectedAbstractItem
        {
            get => selectedAbstractItem;
            set
            {
                selectedAbstractItem = value;
                SelectedItemType = selectedAbstractItem?.GetType().Name;
                OnPropertyChanged();
            }
        }
        public AbstractItem this[string code]
        {
            get
            {
                var tmp = Collection.Single(x => x.ISBN == code);
                if (tmp == null) throw new Exception("Index was not found");
                return tmp;
            }
        }
        ItemsCollection()
        {
            Collection = new ObservableCollection<AbstractItem>();
            AddRandomItems();
        }
        public void AddNew(AbstractItem newItem) => Collection.Add(newItem);
        public void DeleteItem() => Collection.Remove(SelectedAbstractItem);
        private static ItemsCollection instance;
        public static ItemsCollection Instance => instance ?? (instance = new ItemsCollection());
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        private void OnSelectedPropertyChanged()
        {
            if (SelectedAbstractItem is Book)
            {
                foreach (var item in Collection)
                    if (SelectedAbstractItem != null)
                        if (SelectedAbstractItem.ISBN == item.ISBN)
                            if (SelectedAbstractItem is Book)
                                SelectedBook = (Book)SelectedAbstractItem;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedBook)));
            }
            else
            {
                foreach (var item in Collection)
                    if (SelectedAbstractItem != null)
                        if (SelectedAbstractItem.ISBN == item.ISBN)
                            if (selectedAbstractItem is Journal)
                                SelectedJournal = (Journal)SelectedAbstractItem;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedJournal)));
            }
        }
        void AddRandomItems()
        {
            Collection.Add(new Book("Harry Putter") { Author = "Rolling", Genre = Genres.Fantasy, Publisher = "RotWood", CopyTax = 12.3 });
            Collection.Add(new Book("The Ring of the Lords") { Author = "Talkin", Genre = Genres.Fantasy | Genres.Horror, Publisher = "RotWood", CopyTax = 15.2 });
            Collection.Add(new Book("12 rules for death") { Author = "Peter&Son", Genre = Genres.Horror | Genres.Informative, Publisher = "BlackWood", CopyTax = 54.5 });
            Collection.Add(new Journal("PlayGirl") { PublishedAtMonths = Months.April | Months.July, Genre = Genres.Science | Genres.Tragedy, Publisher = "WargCop", CopyTax = 132.3 });
            Collection.Add(new Journal("Science Yesterday") { PublishedAtMonths = Months.March, Genre = Genres.Comedy | Genres.Science, Publisher = "RomanWise", CopyTax = 8.7 });
            Collection.Add(new Journal("Victoria's rumour") { PublishedAtMonths = Months.February, Genre = Genres.Tragedy | Genres.Horror, Publisher = "Ababahalamaga", CopyTax = 37.3 });
            Collection.Add(new Journal("As you see I dont have much imagination") { PublishedAtMonths = Months.December, Genre = Genres.Fantasy, Publisher = "Ya'll see", CopyTax = 85.6 });
        }
    }
}


