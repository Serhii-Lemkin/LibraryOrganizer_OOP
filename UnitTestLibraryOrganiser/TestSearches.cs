using BookLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace UnitTestLibraryOrganiser
{
    [TestClass]
    public class TestSearches
    {
        readonly ItemsCollection stock = ItemsCollection.Instance;
        readonly SearchServise ss = new SearchServise();
        [TestMethod]
        public void TestSearchByTypeBook()
        {
            var filtered = ss.SearchByType(stock.Collection.ToList(), "Book");
            bool correctType = false;
            foreach (var item in filtered) if (item is Book) correctType = true;
                else
                {
                    correctType = false;
                    break;
                }
            Assert.IsTrue(correctType);
        }
        [TestMethod]
        public void TestSearchByTypeJournal()
        {            
            var filtered = ss.SearchByType(stock.Collection.ToList(), "Journal");
            bool correctType = false;
            foreach (var item in filtered) 
                if (item is Journal) correctType = true;
                else
                {
                    correctType = false;
                    break;
                }
            Assert.IsTrue(correctType);
        }
        [TestMethod]
        public void TestSearchByName()
        {

            var filtered = ss.SearchByName(stock.Collection.ToList(), "Lord");
            bool correctType = false;
            foreach (var item in filtered) 
                if (item.Title.IndexOf("Lord", StringComparison.OrdinalIgnoreCase) >= 0) 
                    correctType = true;
                else
                {
                    correctType = false;
                    break;
                }
            Assert.IsTrue(correctType);
        }
    }
}
