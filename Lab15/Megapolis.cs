using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab15
{
    class Megapolis : Mesto, ICloneable//, IComparable
    {
        public override bool Equals(object obj)
        {
            Megapolis temp = obj as Megapolis;
            if (temp == null) return false;
            return (this.Country.Equals(temp.Country) && (this.City.Equals(temp.City)));
        }
        private string city;
        public Object Clone()
        {
            return new Megapolis("Клон " + this.Country, this.City);
        }
        public override void Generate()
        {
            Country = countries[rnd.Next(0, countries.Length)];
            City = cities[rnd.Next(0, cities.Length)];
            Population = rnd.Next(10000, 2000000);
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

        public Megapolis(string state = "Страна отсутствует", string city1 = "Город отсутствует") : base(state)
        {
            City = city1;
            Code += city1.Length * 1000;
        }
        public override void Show()
        {
            Console.WriteLine("Страна " + Country + " мегаполис " + City + " Население " + Population + " чел.");
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
                Console.WriteLine("Введите название мегаполиса");
                City = Console.ReadLine();
            } while (City == null);
            Code = City.Length * 1000 + Country.Length * 10000000;
        }
        public override string ToString()
        {
            return Country + " " + City + " Население " + Population + " чел.";
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
