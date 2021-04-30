using System;
using System.Collections;
using System.Collections.Generic;

namespace labCollection
{
    public class CollectionType<T> : IEnumerable<T> // реализация интерфейса IEnumerable
    {
        private T[] collection = new T[0];

        public int Count
        {
            get
            {
                return collection.Length;
            }
        }

        public CollectionType() // конструктор
        {

        }

        public CollectionType(IEnumerable<T> collection)
        {
            this.collection = (T[])collection;
        }

        ~CollectionType() // деструктор
        {
            Console.WriteLine("Объект уничтожен.");
        }

        public T this[int i] // получаем доступ к экземпляру как массив
        {
            get
            {
                return collection[i];
            }
            set
            {
                collection[i] = value;
            }
        }

        public void Add(T item) // метод добавления
        {
            T[] buffer = new T[collection.Length + 1];

            for (int i = 0; i < collection.Length; i++)
            {
                buffer[i] = collection[i];
            }

            buffer[buffer.Length - 1] = item;

            collection = buffer;
        }

        public void Remove(T item) // метод удаления
        {
            int collectionIndex = 0;

            try
            {
                T[] buffer = new T[collection.Length - 1];

                for (int i = 0; i < buffer.Length; i++)
                {
                    if (collection[collectionIndex].Equals(item))
                    {
                        collectionIndex++;
                        buffer[i] = collection[collectionIndex];
                        collectionIndex++;

                        continue;
                    }

                    buffer[i] = collection[collectionIndex];
                    collectionIndex++;
                }

                collection = buffer;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Невозможно удалить элемент из пустой коллекции!");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < collection.Length; i++) // какие значения будут возвращаться при проходе foreach
                yield return collection[i]; // Оператор yield return возвращает элемент коллекции в итераторе и перемещает текущую позицию на следующий элемент.
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
