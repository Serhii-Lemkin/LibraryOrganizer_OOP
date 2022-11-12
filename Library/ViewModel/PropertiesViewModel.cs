using BookLib;
using GalaSoft.MvvmLight;

namespace Library.ViewModel
{
    public class PropertiesViewModel : ViewModelBase
    {
        NewItemBuilder NIB = new NewItemBuilder();
        public MyCommand DeleteItemCommand { get; set; }
        public ItemsCollection Stock { get; set; }
        public MyCommand EditItemCommand { get; set; }
        public string SelectedItemType { get; set; }
        public PropertiesViewModel()
        {
            Stock = ItemsCollection.Instance;
            DeleteItemCommand = new MyCommand(DeleteItem);
            EditItemCommand = new MyCommand(EditItem);
        }
        void EditItem() => NIB.InitiateEditing();
        void DeleteItem()
        {
            Stock.DeleteItem();
            MessengerInstance.Send(true);
        }
    }
}
