using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.CTCI
{
    public class Animal
    {
        public Types Type { get; set; }
        public enum Types
        {
            Dog, Cat
        }
    }
    // animal shelter
    public class ex_3_6
    {
        public SingleLinkedList<Animal> Storage { get; set; } = new SingleLinkedList<Animal>();
        public bool Enqueue(Animal value)
        {
            this.Storage.InsertTail(new Node<Animal>()
            {
                Value = value
            });
            return true;
        }

        public Animal DequeueAny()
        {
            var node = Storage.RemoveHead();
            return node == null ? null : node.Value;
        }

        public Animal DequeueDog()
        {
            return Dequeue(Animal.Types.Dog);
        }

        public Animal DequeueCat()
        {
            return Dequeue(Animal.Types.Cat);
        }

        public void Print()
        {
            Node<Animal> iterator = this.Storage.Head;
            Console.Out.WriteLine("");
            while (iterator != null)
            {
                Console.Out.Write($"{iterator.Value.Type.ToString()}");
                if (iterator.Next != null)
                {
                    Console.Out.Write("->");
                }

                iterator = iterator.Next;
            }
        }
        private Animal Dequeue(Animal.Types type)
        {
            Node<Animal> iterator = this.Storage.Head;
            while (iterator != null)
            {
                if (iterator.Value.Type == type)
                {
                    break;
                }
                else
                {
                    iterator = iterator.Next;
                }
            }

            if (iterator != null)
            {
                this.Storage.Remove(iterator);
                return iterator.Value;
            }

            return null;
        }
    }
}
