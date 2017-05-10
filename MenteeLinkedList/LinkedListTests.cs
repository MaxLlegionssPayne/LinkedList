using System;
using NUnit.Framework;

namespace MenteeLinkedList
{
    [TestFixture]
    public class LinkedListTests
    {
        #region EnumerableTests

        [Test]
        public void GetEnumeartor_ReturnsAllCollectionItems()
        {
            var originList = new LinkedList<int>().Add(5).Add(125).Add(502).Add(152);
            var newList = new LinkedList<int>();

            foreach (var value in originList)
                newList.Add(value);

            CollectionAssert.AreEqual(originList, newList);
        }
        
        #endregion

        #region RemoveAtTests

        [Test]
        [TestCase(-1)]
        [TestCase(5)]
        public void RemoveAt_WithIncorrectIndex_ThroughsException(int index)
        {
            Assert.Throws<IndexOutOfRangeException>(() => new LinkedList<int>().AddAt(123, index));
        }

        #endregion

        #region RemoveTests

        [Test]
        public void Remove_ForListWithOneElement_RemovesValue()
        {
            const int value = 100;
            var list = new LinkedList<int>().Add(value);

            Assert.That(list.Remove(value).Length, Is.EqualTo(0));
        }

            #endregion

        #region AddAtTests

        [Test]
        [TestCase(0, 12)]
        [TestCase(2,7)]
        [TestCase(1, 3)]
        public void AddAt_Element_AddNewNode(int position, int value)
        {
            var list = new LinkedList<int>().Add(1).Add(5);

            list.AddAt(value, position);

            Assert.That(list.ElementAt(position), Is.EqualTo(value));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(5)]
        public void AddAt_WithIncorrectIndex_ThroughsException(int index)
        {
            Assert.Throws<IndexOutOfRangeException>(() => new LinkedList<int>().AddAt(123, index));
        }

        [Test]
        public void AddAt_ToEmpty_AddNewNode()
        {
            const int value = 12;
            var list = new LinkedList<int>();

            list.AddAt(value, 0);

            Assert.That(list.ElementAt(0), Is.EqualTo(value));
        }

        #endregion

        #region AddTests

        [Test]
        public void Add_ToNotEmpty_AddNewNode()
        {
            const int value = 12;

            var list = new LinkedList<int>().Add(1).Add(5);

            Assert.That(list.Add(value).ElementAt(list.Length - 1), Is.EqualTo(value));
        }

        [Test]
        public void Add_ToEmpty_AddNewNode()
        {
            const int value = 12;

            var list = new LinkedList<int>();

            Assert.That(list.Add(value).ElementAt(list.Length - 1), Is.EqualTo(value));
        }

        #endregion

        #region LengthTests
        [Test]
        public void Length_ForNewList_ReturnsZero()
        {
            Assert.That(new LinkedList<int>().Length, Is.EqualTo(0));
        }

        [Test]
        public void Length_AfterAdd_ReturnsElementsCount()
        {
            var list = new LinkedList<int>();
            var initCount = list.Length;

            list.Add(1);

            Assert.That(list.Length, Is.EqualTo(initCount + 1));
        }

        [Test]
        public void Length_AfterAddAtAsFirst_ReturnsElementsCount()
        {
            var list = new LinkedList<int>();
            var initCount = list.Length;

            list.AddAt(1, 0);

            Assert.That(list.Length, Is.EqualTo(initCount + 1));
        }


        [Test]
        public void Length_AfterAddAt_ReturnsElementsCount()
        {
            var list = new LinkedList<int>();
            var initCount = list.Length;

            list.AddAt(12, 0);

            Assert.That(list.Length, Is.EqualTo(initCount + 1));
        }

        [Test]
        public void Length_AfterAddAtEnd_ReturnsElementsCount()
        {
            var list = new LinkedList<int>().Add(1);
            var initCount = list.Length;

            list.AddAt(12, 1);

            Assert.That(list.Length, Is.EqualTo(initCount + 1));
        }

        [Test]
        public void Length_AfterRemoveOneExistingElementAtEnd_ReturnsElementsCount()
        {
            var list = new LinkedList<int>().Add(1).Add(17).Add(7);
            var initCount = list.Length;

            list.Remove(7);

            Assert.That(list.Length, Is.EqualTo(initCount - 1));
        }

        [Test]
        public void Length_AfterRemoveOneExistingElementAtStartEnd_ReturnsElementsCount()
        {
            var list = new LinkedList<int>().Add(7).Add(4).Add(17);
            var initCount = list.Length;

            list.Remove(7);

            Assert.That(list.Length, Is.EqualTo(initCount - 1));
        }

        [Test]
        public void Length_AfterRemoveFewExistingElements_ReturnsElementsCount()
        {
            var list = new LinkedList<int>().Add(1).Add(7).Add(7).Add(8);
            var initCount = list.Length;

            list.Remove(7);

            Assert.That(list.Length, Is.EqualTo(initCount - 2));
        }

        [Test]
        public void Length_AfterRemoveFewExistingElementsAtStartAndEnd_ReturnsElementsCount()
        {
            var list = new LinkedList<int>().Add(7).Add(2).Add(3).Add(7);
            var initCount = list.Length;
            list.Remove(7);

            Assert.That(list.Length, Is.EqualTo(initCount - 2));
        }

        [Test]
        public void Lenght_RemoveAtStart_DecreaseCount()
        {
            var list = new LinkedList<int>().Add(7).Add(2).Add(3).Add(7);
            var initCount = list.Length;

            list.RemoveAt(0);

            Assert.That(list.Length, Is.EqualTo(initCount - 1));

        }
        #endregion

    }
}
