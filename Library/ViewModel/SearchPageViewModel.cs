using BookLib;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Library.ViewModel
{
    public class SearchPageViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private AbstractItem selectedItem;
        public AbstractItem SelectedItem
        {
            get { return selectedItem; }
            set
            {
                Set(ref selectedItem, value);
                Stock.SelectedAbstractItem = SelectedItem;
                MessengerInstance.Send(Stock.SelectedAbstractItem);
            }
        }
        public ItemsCollection Stock { get; set; }
        public DataLib Dlib { get; set; }
        SearchServise search;
        public string SelectedProp { get; set; }
        //Full Properties

        #region ObservableCollection
        private ObservableCollection<AbstractItem> collectionFiltered;
        public ObservableCollection<AbstractItem> CollectionFiltered
        {
            get => collectionFiltered;
            set
            {
                Set(ref collectionFiltered, value);
                OnListPropertyChanged();
            }
        }
        #endregion
        #region searchbyName
        private string searchBy;
        public string SearchBy
        {
            get { return searchBy; }
            set
            {
                searchBy = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region searchByType
        private string searchByType;
        public string SearchByType
        {
            get => searchByType;
            set
            {
                Set(ref searchByType, value);
                OnPropertyChanged();
            }
        }
        #endregion
        #region searchByISBN
        public string SearchByISBN { get; set; }
        #endregion
        Action<bool> AddedToListAction;
        public SearchPageViewModel()
        {
            Stock = ItemsCollection.Instance;
            Dlib = new DataLib();
            CollectionFiltered = new ObservableCollection<AbstractItem>(Stock.Collection);
            search = new SearchServise();
            AddedToListAction = AddedToList;
            MessengerInstance.Register<bool>(this, AddedToList);
        }
        void AddedToList(bool IsChanged)
        {
            CollectionFiltered = Stock.Collection;
            OnPropertyChanged();
        }
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //CollectionFiltered = Stock.Collection;
            var tmp = Stock.Collection.ToList();
            if (SearchByType != "Book Or Journal")
                tmp = new List<AbstractItem>(search.SearchByType(tmp, searchByType));
            if (!string.IsNullOrEmpty(SearchBy) && !string.IsNullOrWhiteSpace(SearchBy))
            {
                switch (SelectedProp)
                {
                    case "Title": tmp = search.SearchByName(tmp, SearchBy); break;
                    case "ISBN": tmp = search.SearchByISBN(tmp, SearchBy); break;
                    case "Genre": tmp = search.SearchByGenre(tmp, SearchBy); break;
                    case "PrintedDate": tmp = search.SearchByDate(tmp, SearchBy); break;
                    case "Publisher": tmp = search.SearchByPublisher(tmp, SearchBy); break;
                    case "CopyTax": tmp = search.SearchByCopyTax(tmp, SearchBy); break;
                    case "PublishedAtMonths": tmp = search.SearchByMonths(tmp, SearchBy); break;
                    case "Author": tmp = search.SearchByAuthor(tmp, SearchBy); break;
                    default: break;
                }
            }
            CollectionFiltered = new ObservableCollection<AbstractItem>(tmp);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void OnListPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
