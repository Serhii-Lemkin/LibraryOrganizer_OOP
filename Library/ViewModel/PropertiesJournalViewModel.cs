using BookLib;
using GalaSoft.MvvmLight;

namespace Library.ViewModel
{
    public class PropertiesJournalViewModel : ViewModelBase
    {
        public MyCommand DeleteItemCommand { get; set; }
        public ItemsCollection Stock { get; set; }
        public MyCommand EditItemCommand { get; set; }
        public string SelectedItemType { get; set; }
        public PropertiesJournalViewModel()
        {
            Stock = ItemsCollection.Instance;
            DeleteItemCommand = new MyCommand(DeleteItem);
        }

        void DeleteItem()
        {
            Stock.DeleteItem();
            MessengerInstance.Send(true);
        }
    }
}
