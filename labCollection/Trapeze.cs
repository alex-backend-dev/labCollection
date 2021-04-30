using System;

namespace labCollection 
{
    public class Trapeze : IComparable<Trapeze> // класс трапеция 
    {
        private double a, b, c, h;

        public Trapeze()
        {

        }

        public Trapeze(double a, double b, double c, double h)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.h = h;
        }

        public double A
        {
            get => a;
            set => a = value;
        }

        public double B
        {
            get => b;
            set => b = value;
        }

        public double C
        {
            get => c;
            set => c = value;
        }

        public double H
        {
            get => h;
            set => h = value;
        }

        public bool ExistanceTrapeze()
        {
            bool result = false;

            if (a < b + 2 * c && (b < a + b + 2 * c) && (2 * c < a + b + c))
            {
                result = true;
            }

            return result;
        }

        public double P()
        {
            double p = a + b + 2 * c; // периметр по четырем сторонам
            return p;
        }

        public double S()
        {
            double s = 0.5 * (a + b) * h; // площадь
            return s;
        }

        public void OutTrapeze() // вывод результата для существующей равнобедренной трапеции
        {
            Console.WriteLine("Периметр равнобедренной трапеции: {0}", P());
            Console.WriteLine("Площадь равнобедренной трапеции: {0}", S());
        }

        public int CompareTo(Trapeze other) // Метод CompareTo предназначен для сравнения текущего объекта с объектом, который передается в качестве параметра object o
        {
            return P().CompareTo(other.P());
        }
    }
}
