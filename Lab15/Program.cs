using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab15
{    
    class Program
    {
        static Random rnd = new Random();
        public static void CitiesinRussia(List<List<Mesto>> ListOfElements)
        {
            for (int i = 0; i < ListOfElements.Count; i++)
            {
                var res1 = from p in ListOfElements[i]
                           where (p.Country == "Россия" && p is Megapolis)
                           select p;
                foreach (Megapolis t in res1)
                {
                    Console.WriteLine(t.City);
                }
            }
        }
        public static void CitiesinRussia1(List<List<Mesto>> ListOfElements)
        {
            Func<Mesto, bool> searchFilter = delegate (Mesto place) { return (place is Megapolis && place.Country == "Россия"); };
            Func<Mesto, string> itemToProcess = delegate (Mesto t) { Megapolis m = t as Megapolis; return m.City; };
            for (int i = 0; i < ListOfElements.Count; i++)
            {
                var res1 = ListOfElements[i].Where(searchFilter).Select(itemToProcess);
                           
                foreach (string t in res1)
                {
                    Console.WriteLine(t);
                }
            }
        }
        public static void PopinGermany(List<List<Mesto>> ListOfElements)
        {
            double summ=0;
            for (int i = 0; i < ListOfElements.Count; i++)
            {
                var res1 = (from p in ListOfElements[i]
                            where (p.Country == "Германия")
                            select p.Population).Sum();
                summ += res1;
                
            }
            Console.WriteLine("Население Германии = "+ summ);
        }
        public static void PopinGermany1(List<List<Mesto>> ListOfElements)
        {
            Func<Mesto, bool> searchFilter = delegate (Mesto place) { return (place.Country == "Германия"); };
            double summ = 0;
            for (int i = 0; i < ListOfElements.Count; i++)
            {
                var res1 = ListOfElements[i].Where(searchFilter).Select(x => x.Population).Sum();
                summ += res1;

            }
            Console.WriteLine("Население Германии = " + summ);
        }
        public static void Uniting1(List<List<Mesto>> ListOfElements)
        {
            Func<Mesto, bool> searchFilter = delegate (Mesto place) { return (place.Country == "Таджикистан"); };
            List<Mesto> temp = new List<Mesto>();
            for (int i = 0; i < ListOfElements.Count; i++)
            {
                var result = ListOfElements[i].Where(searchFilter).Union(temp);
                temp = result.ToList<Mesto>();
            }
            foreach(Mesto t in temp)
            {
                t.Show();
            }
        }
        public static void Uniting(List<List<Mesto>> ListOfElements)
        {
            List<Mesto> temp = new List<Mesto>();
            for (int i = 0; i < ListOfElements.Count; i++)
            {
                var result = (from p in ListOfElements[i] where p.Country == "Таджикистан" select p).Union(temp);
                temp = result.ToList<Mesto>();
            }
            foreach (Mesto t in temp)
            {
                t.Show();
            }
        }
        public static void PopinRussia(List<List<Mesto>> ListOfElements)
        {
            List<double> pop = new List<double>();
            for (int i = 0; i < ListOfElements.Count; i++)
            {
                var res = (from p in ListOfElements[i] where (p.Country == "Россия" && (p is Gorod || p is Megapolis)) select p.Population);
                if (res.Count()>0)
                {
                    var res1 = res.Average();
                    pop.Add(res1);
                }

            }
            Console.WriteLine("Среднее население городов России = " + pop.Average());
        }
        public static void MaxPopCity(List<List<Mesto>> ListOfElements)
        {
            List<int> max = new List<int>();
            for (int i = 0; i < ListOfElements.Count; i++)
            {
                var res = (from p in ListOfElements[i] where (p is Gorod || p is Megapolis) select p.Population).Max();
                max.Add(res);
            }

            Console.WriteLine("Максимальное население из всех городов = " + max.Max());
        }
        public static void MaxPopCity1(List<List<Mesto>> ListOfElements)
        {
            Func<Mesto, bool> searchFilter = delegate (Mesto place) { return place is Gorod || place is Megapolis; };
            List<int> max = new List<int>();
            for (int i = 0; i < ListOfElements.Count; i++)
            {
                var res = (ListOfElements[i].Where(searchFilter).Select(x => x.Population)).Max();
                max.Add(res);
            }

            Console.WriteLine("Максимальное население из всех городов = " + max.Max());
        }
        public static void PopinRussia1(List<List<Mesto>> ListOfElements)
        {
            Func<Mesto, bool> searchFilter = delegate (Mesto place) { return (place.Country == "Россия" && (place is Gorod || place is Megapolis)); };
            List<double> pop = new List<double>();
            for (int i = 0; i < ListOfElements.Count; i++)
            {
                var res = ListOfElements[i].Where(searchFilter).Select(x => x.Population);
                if (res.Count() > 0)
                {
                    var res1 = res.Average();
                    pop.Add(res1);
                }

            }
            Console.WriteLine("Среднее население городов России = " + pop.Average());
        }
        public static List<Mesto> Generate(int size, List<Mesto> listofelem)
        //Заполенение коллекции длины size случайными элементами
        {
            listofelem = new List<Mesto>();
            for (int i = 0; i < size; i++)
            {
                int option = rnd.Next(0, 4);//Случайное значение - номер класса элемента который добавляется
                switch (option)
                {
                    case 0:
                        Megapolis mp = new Megapolis();
                        mp.Generate();
                        Console.WriteLine(mp.ToString());
                        listofelem.Add(mp);
                        break;
                    case 1:
                        Oblast ob = new Oblast();
                        ob.Generate();
                        Console.WriteLine(ob.ToString());
                        listofelem.Add(ob);
                        break;
                    case 2:
                        Gorod ct = new Gorod();
                        ct.Generate();
                        Console.WriteLine(ct.ToString());
                        listofelem.Add(ct);
                        break;
                    case 3:
                        Address adr = new Address();
                        adr.Generate();
                        Console.WriteLine(adr.ToString());
                        listofelem.Add(adr);
                        break;
                }
            }
            return listofelem;
        }
        static void Main(string[] args)
        {
            int size = 15;
            List<List<Mesto>> ListOfElements = new List<List<Mesto>>(size);
            for (int i = 0; i < size; i++)
            {
                ListOfElements.Add(new List<Mesto>());
                ListOfElements[i] = Generate(size, ListOfElements[i]);
            }
            Console.WriteLine("Вывод мегаполисов России: ");
            Console.WriteLine("LINQ");
            CitiesinRussia(ListOfElements);
            Console.WriteLine("Расширенный метод");
            CitiesinRussia1(ListOfElements);
            Console.WriteLine("Количество жителей Германии");
            Console.WriteLine("LINQ");
            PopinGermany(ListOfElements);
            Console.WriteLine("Расширенный метод");
            PopinGermany1(ListOfElements);
            Console.WriteLine("Объединение всех элементов иерархии со страной Таджикистан");
            Console.WriteLine("LINQ");
            Uniting(ListOfElements);
            Console.WriteLine("Расширенный метод");
            Uniting1(ListOfElements);
            
            Console.WriteLine("Среднее население городов России");
            Console.WriteLine("LINQ");
            PopinRussia(ListOfElements);
            Console.WriteLine("Расширенный метод");
            PopinRussia1(ListOfElements);
            Console.WriteLine("Максимальное население в городе");
            Console.WriteLine("LINQ");
            MaxPopCity(ListOfElements);
            Console.WriteLine("Расширенный метод");
            MaxPopCity1(ListOfElements);
            Console.Read();
        }
    }
}
