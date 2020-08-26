using System;
using Algorithms.CTCI;
using Algorithms.DailyInterviewPro;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.DailyInterviewPro
{
    [TestClass]
    public class AddNumberByLinkedListTests
    {
        [TestMethod]
        public void AddNumberByLinkedList()
        {
            var ex = new AddNumberByLinkedList();
            SingleLinkedList<int> l1 = new SingleLinkedList<int>()
            {
                Head = new Node<int>()
                {
                    Value = 1,
                    Next = new Node<int>()
                    {
                        Value = 2,
                        Next = new Node<int>()
                        {
                            Value = 3
                        }
                    }
                }
            };
            SingleLinkedList<int> l2 = new SingleLinkedList<int>()
            {
                Head = new Node<int>()
                {
                    Value = 4,
                    Next = new Node<int>()
                    {
                        Value = 5,
                        Next = new Node<int>()
                        {
                            Value = 6
                        }
                    }
                }
            };
            var res = ex.Add(l1, l2);
            Assert.AreEqual(5, res.Head.Value);
            Assert.AreEqual(7, res.Head.Next.Value);
            Assert.AreEqual(9, res.Head.Next.Next.Value);
        }
    }
}
