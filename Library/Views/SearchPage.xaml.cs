using BookLib;
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

namespace Library.Views
{
    /// <summary>
    /// Interaction logic for SearchPage.xaml
    /// </summary>
    public partial class SearchPage : UserControl
    {
        DataLib dataLib;
        public SearchPage()
        {
            InitializeComponent();
            dataLib = new DataLib();
            Props.ItemsSource = dataLib.AbstractProps;
        }

        private void UpdateSource(object sender, SelectionChangedEventArgs e)
        {
            if (Types.SelectedItem.ToString() == "Book Or Journal") if(Props!= null) Props.ItemsSource = dataLib.AbstractProps;
            if (Types.SelectedItem.ToString() == "Book") if (Props != null) Props.ItemsSource = dataLib.BookProps;
            if (Types.SelectedItem.ToString() == "Journal") if (Props != null) Props.ItemsSource = dataLib.JournalProps;
            
        }
    }
}
