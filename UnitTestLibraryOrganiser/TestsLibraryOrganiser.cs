using BookLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestLibraryOrganiser
{
    [TestClass]
    public class TestItemsCollection
    {
        readonly ItemsCollection stock = ItemsCollection.Instance;
        [TestMethod]
        public void TestAddNew_AddsNewBook_CollectionCountEqualsPlusOne()
        {
            int count = stock.Collection.Count;
            stock.AddNew(new Book("bla"));
            Assert.AreEqual(stock.Collection.Count, count + 1);
        }
        [TestMethod]
        public void TestRemove_RemovesElement_CollectionCountEqualsMinisOne()
        {
            int count = stock.Collection.Count;
            stock.SelectedAbstractItem =  stock.Collection[0];
            stock.DeleteItem();
            Assert.AreEqual(stock.Collection.Count, count - 1);
        }
        [TestMethod]
        public void TestRemoveSpecific_ChecksForISBNOfRemovedItemInCollection_ReturnsTrue()
        {
            stock.SelectedAbstractItem = stock.Collection[0];
            stock.DeleteItem();
            bool wasDeleted = true;
            foreach (var item in stock.Collection) if(item.ISBN == stock.SelectedAbstractItem.ISBN) { wasDeleted = false; break; }
            Assert.IsTrue(wasDeleted); 
        }
    }
}
