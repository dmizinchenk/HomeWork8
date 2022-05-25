using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork8
{
    //Задание 2
    class Point2D<T> 
    {
        public T X { get; set; }
        public T Y { get; set; }
        public Point2D(T x, T y)
        {
            X = x;
            Y = y;
        }
        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
    class Point3D : Point2D<int>
    {
        public int Z { get; set; }
        public Point3D(int x, int y, int z) : base(x, y)
        {
            Z = z;
        }
        public override string ToString()
        {
            string temp = base.ToString().Remove(base.ToString().Length - 1);
            temp += $", {Z})";
            return temp;
        }
    }
    //Задание 3
    class Line<T>
    {
        Point2D<T> p1;
        Point2D<T> p2;

        public Line(Point2D<T> p1, Point2D<T> p2)
        {
            this.p1 = new Point2D<T>(p1.X, p1.Y);
            this.p2 = new Point2D<T>(p2.X, p2.Y);
        }
        public Line(T x1, T y1, T x2, T y2)
        {
            p1 = new Point2D<T>(x1, y1);
            p2 = new Point2D<T>(x2, y2);
        }
        public override string ToString()
        {
            return $"Прямая, проходящая через точки {p1} и {p2}";
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            //Задание 1
            /*Dictionary<string, string> countries = new Dictionary<string, string>()
            {
                { "Russia", "Россия" },
                { "Spain", "Испания" },
                { "France", "Франция" },
                { "Germany", "Германия" },
                { "Portugal", "Португалия" },
                { "Brazil", "Бразилия" },
                { "Argentina", "Аргентина" },
                { "Sweden", "Швеция" },
                { "China", "Китай" },
                { "Japan", "Япония" }
            };

            while (true)
            {
                Console.WriteLine("С каким словарём работаем:\n" +
                "1 - Английский -> Русский\n2 - Русский -> Английский\n0 - Выход");
                int choise = Console.Read();
                Console.Write("Введите название страны: ");
                string word = Console.ReadLine();
                string translate = "";
                if (choise == 0)
                    break;
                else if (choise == 1 && countries.TryGetValue(word, out translate))
                {
                    Console.WriteLine(translate);
                }
                else if (choise == 1 && !countries.TryGetValue(word, out translate))
                    Console.WriteLine("Такого слова нет в словаре");
                else if (choise == 2)
                {
                    foreach (var country in countries)
                    {
                        if (word.ToLower() == country.Value.ToLower())
                        {
                            translate = country.Value;
                            break;
                        }
                    }
                    if (translate == "")
                        Console.WriteLine("Такого слова нет в словаре");
                    else
                        Console.WriteLine(translate);
                }
                else
                    continue;
            }*/

            //Задание 4
            Console.WriteLine("Введите текст:");
            string text = Console.ReadLine();
            //string text = "Привет, мир. Солнце светит ярко. Я люблю когда светит солнце!";
            char[] separators = { ' ', ',', '.', '!', '?' };
            var result = from word in text.ToLower().Split(separators, StringSplitOptions.RemoveEmptyEntries)
                         orderby word
                         group word by word into newCollection
                         select new
                         {
                             Key = newCollection.Key,
                             Value = newCollection.Count()
                         };
            foreach (var item in result)
            {
                Console.WriteLine($"В данном тексте слово \"{item.Key}\" встречается {item.Value} раз");
            }
        }
    }
}
