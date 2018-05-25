using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab15
{
    class Gorod : Oblast, ICloneable, IComparable
    {
        public int CompareTo(object obj)
        {
            Gorod ob = obj as Gorod;
            if (ob != null)
            {
                string str = Country + Obl + City;
                string str1 = ob.Country + ob.Obl + ob.City;
                return str.CompareTo(str1);
            }
            return 0;
        }
        public override bool Equals(object obj)
        {
            Gorod temp = new Gorod();
            temp = obj as Gorod;
            if (temp != null)
                return (this.Country.Equals(temp.Country) && (this.Obl.Equals(temp.Obl) && (this.City.Equals(temp.City))));
            else return false;
        }
        public override void Generate()
        {
            base.Generate();
            City = cities[rnd.Next(0, cities.Length)];
        }
        private string city;
        new public Object Clone()
        {
            return new Gorod(this.Country, this.Obl, this.City);
        }
        public string City
        {
            get
            {
                if (city == null || city == "" || city == " ")
                    return "Область не указана!";
                else return city;
            }
            set
            {
                if (value.Length > 1) city = value;
                else Console.WriteLine("Некорректное название области!");
            }
        }


        public Gorod(string state = "Страна отсутствует", string obl = "Область отсутствует", string city1 = "Город отсутствует") : base(state, obl)
        {
            City = city1;
            Code += city1.Length * 1000;
        }
        public override void Show()
        {
            Console.WriteLine("Страна " + Country + " Область " + Obl + " город " + City + " Население " + Population + " чел.");
        }
        public override void Input()
        {
            do
            {
                Console.WriteLine("Введите название страны");
                Country = Console.ReadLine();
            } while (Country == null);
            do
            {
                Console.WriteLine("Введите название области");
                Obl = Console.ReadLine();
            } while (Obl == null);
            do
            {
                Console.WriteLine("Введите название города ");
                City = Console.ReadLine();
            } while (City == null);
            Code = City.Length * 1000 + Country.Length * 10000000 + Obl.Length * 100000;
        }
        public override string ToString()
        {
            return Country + " " + Obl + " " + City + " Население " + Population + " чел.";
        }

        public override int GetHashCode()
        {
            var hashCode = 2025378804;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(city);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(City);
            return hashCode;
        }
    }
}
