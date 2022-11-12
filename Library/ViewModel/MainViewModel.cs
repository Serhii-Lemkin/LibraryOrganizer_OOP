using BookLib;
using GalaSoft.MvvmLight;
using System.Windows;

namespace Library.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private Visibility bookVis;
        private Visibility journalVis;
        NewItemBuilder NIB;
        public ItemsCollection Stock { get; set; }
        public Visibility BookVis { get => bookVis; set => Set(ref bookVis, value); }
        public Visibility JournalVis { get => journalVis; set => Set(ref journalVis, value); }
        public MainViewModel()
        {
            JournalVis = Visibility.Collapsed;
            Stock = ItemsCollection.Instance;
            NIB = NewItemBuilder.Instance;
        }
        public void VisibilityChanged()
        {
            if (Stock.SelectedAbstractItem.GetType().Name == "Book")
            {
                BookVis = Visibility.Visible;
                JournalVis = Visibility.Hidden;
            }
            else
            {
                BookVis = Visibility.Hidden;
                JournalVis = Visibility.Visible;
            }
        }

    }
}