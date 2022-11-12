using BookLib;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Library
{
    public partial class MainWindow : Window
    {
        public Action<string> ChangeVisibilityAdd { get; }
        public Action<AbstractItem> ChangeVisibilityProp { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            ChangeVisibilityAdd = UpdateAddNewVisibility;
            ChangeVisibilityProp = UpdateVisibilityProp;
            Messenger.Default.Register<string>(this, ChangeVisibilityAdd);
            Messenger.Default.Register<AbstractItem>(this, ChangeVisibilityProp);
        }

        public void UpdateVisibilityProp(AbstractItem selectedItem)
        {
            if (selectedItem is Book)
            {
                BookPropView.Visibility = Visibility.Visible;
                JournalPropView.Visibility = Visibility.Collapsed;
            }
            else 
            {
                BookPropView.Visibility = Visibility.Collapsed;
                JournalPropView.Visibility = Visibility.Visible;
            }
            
        }
        public void UpdateAddNewVisibility(string s)
        {
            if (s == "Book")
            {
                BookAddView.Visibility = Visibility.Visible;
                JournalAddView.Visibility = Visibility.Collapsed;
            }
            else 
            {
                BookAddView.Visibility = Visibility.Collapsed;
                JournalAddView.Visibility = Visibility.Visible;
            }
        }
    }
}
