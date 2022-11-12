using BookLib;
using GalaSoft.MvvmLight;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Library.ViewModel
{
    public partial class AddNewViewModel : ViewModelBase, INotifyPropertyChanged
    {


        public ItemsCollection Stock { get; set; }
        private NewItemBuilder nIB;
        public NewItemBuilder NIB
        {
            get => nIB;
            set => Set(ref nIB, value);
        }
        public DataLib DLib { get; set; }
        public string BtnContext { get; set; }
        public MyCommand AddItemCommand { get; set; }
        public MyCommand UpdateBookCommand { get; set; }
        public MyCommand ChangeTypeCommand { get; set; }
        public MyCommand AddGenreCommand { get; set; }
        public MyCommand RemoveGenreCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public AddNewViewModel()
        {
            NIB = new NewItemBuilder();
            DLib = new DataLib();
            BtnContext = "Book";

            Stock = ItemsCollection.Instance;
            ChangeTypeCommand = new MyCommand(ChangeType);
            AddItemCommand = new MyCommand(AddNewitem);
            AddGenreCommand = new MyCommand(AddGenre);
            RemoveGenreCommand = new MyCommand(RemoveGenre);
        }
        public void AddGenre() => NIB.AddGenre();
        public void RemoveGenre() => NIB.RemoveGenre();
        void AddNewitem()
        {
            NIB.AddItem(BtnContext);
            MessengerInstance.Send(true);
        }

        void ChangeType()
        {
            if (BtnContext == "Book")
            {
                BtnContext = "Journal";
            }
            else
            {
                BtnContext = "Book";
            }
            MessengerInstance.Send(BtnContext);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BtnContext)));
        }
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}
