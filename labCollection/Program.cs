using System;
using System.IO;
using System.Linq;
using System.Text;

namespace labCollection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CollectionType<Trapeze>[] collections = new CollectionType<Trapeze>[4];

            for (int i = 0; i < collections.Length; i++)
            {
                collections[i] = new CollectionType<Trapeze>();
            }

            collections[0].Add(new Trapeze(20, 10, 7, 7));
            collections[0].Add(new Trapeze(15, 10, 5, 5));

            collections[1].Add(new Trapeze(10, 5, 3, 3));
            collections[1].Add(new Trapeze(28, 13, 15, 17));
            collections[1].Add(new Trapeze(23, 9, 12, 14));
            collections[1].Add(new Trapeze(34, 10, 15, 13));

            collections[2].Add(new Trapeze(43, 24, 16, 7));
            collections[2].Add(new Trapeze(29, 10, 8, 8));

            collections[3].Add(new Trapeze(20, 10, 7, 7));
            collections[3].Add(new Trapeze(20, 10, 7, 7));
            collections[3].Add(new Trapeze(20, 10, 7, 7));

            foreach (var collection in collections) // сортировка
            {
                Trapeze temp;

                for (int i = 0; i < collection.Count; i++)
                {
                    for (int j = i + 1; j < collection.Count; j++)
                    {
                        if (collection[i].CompareTo(collection[j]) > 0)
                        {
                            temp = collection[i];
                            collection[i] = collection[j];
                            collection[j] = temp;
                        }
                    }
                }
            }

            var twoElementsCollections = collections.Where(c => c.Count == 2).ToList(); // LINQ запросы

            Console.WriteLine("Коллекции с 2-мя элементами: ");

            foreach (var collection in twoElementsCollections)
            {
                foreach (var trapeze in collection)
                {
                    Console.Write("Длины сторон трапеций: "
                        + trapeze.A + " " + trapeze.B + " " + trapeze.C + " " + trapeze.H);

                    Console.WriteLine();
                }

                Console.WriteLine();
            }

            var maxCollection = collections // LINQ запросы
                .First(c => c.Contains(collections.SelectMany(x => x)
                .First(t => t.A == collections.SelectMany(x => x).Max(y => y.A))));

            var minCollection = collections // LINQ запросы
                .First(c => c.Contains(collections.SelectMany(x => x)
                .First(t => t.A == collections.SelectMany(x => x).Min(y => y.A))));

            Console.WriteLine();

            StreamWriter writer = new StreamWriter("Inlet.in.txt", true, Encoding.Default); // запись в файл

            for (int i = 0; i < collections.Length; i++) // запись информации о коллекции в файл
            {
                writer.WriteLine($"Элементы {i + 1} коллекции: ");
                writer.WriteLine();

                for (int j = 0; j < collections[i].Count; j++)
                {
                    writer.WriteLine($"\tХарактеристики {j + 1} трапеции: ");
                    writer.WriteLine("\t\tНижнее основание: " + collections[i][j].A);
                    writer.WriteLine("\t\tВерхнее основание: " + collections[i][j].B);
                    writer.WriteLine("\t\tБоковые стороны: " + collections[i][j].C);
                    writer.WriteLine("\t\tВысота: " + collections[i][j].H);
                    writer.WriteLine("\t\tПериметр: " + collections[i][j].P());
                    writer.WriteLine("\t\tПлощадь: " + collections[i][j].S());
                    writer.WriteLine();
                }

                writer.WriteLine();
            }

            writer.Close();

            Console.ReadLine();
        }
    }
}

