using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;

namespace Library.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<AddNewViewModel>();
            SimpleIoc.Default.Register<PropertiesViewModel>();
            SimpleIoc.Default.Register<PropertiesJournalViewModel>();
            SimpleIoc.Default.Register<SearchPageViewModel>();
            SimpleIoc.Default.Register<AddNewJournalViewModel>();
        }
        public MainViewModel Main =>
            ServiceLocator.Current.GetInstance<MainViewModel>();
        public AddNewViewModel AddNewItem =>
            ServiceLocator.Current.GetInstance<AddNewViewModel>();
        public AddNewJournalViewModel AddJournal =>
            ServiceLocator.Current.GetInstance<AddNewJournalViewModel>();
        public PropertiesViewModel Properties =>
            ServiceLocator.Current.GetInstance<PropertiesViewModel>();
        public PropertiesViewModel PropertiesJournal =>
            ServiceLocator.Current.GetInstance<PropertiesViewModel>();
        public SearchPageViewModel SearchPage =>
            ServiceLocator.Current.GetInstance<SearchPageViewModel>();

        public static void Cleanup()
        {

        }
    }
}