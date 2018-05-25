using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab15
{
    class Address : Gorod, ICloneable, IComparable
    {
        private int number;
        private string street;
        new public Object Clone()
        {
            return new Address(this.Country, this.Obl, this.City, this.street, this.number);
        }
        public override void Generate()
        {
            base.Generate();
            Street = str[rnd.Next(0, str.Length)];
            number = rnd.Next(0, 129);
            Population = rnd.Next(1, 10);
        }
        public override bool Equals(object obj)
        {
            Address temp = obj as Address;
            if (temp == null) return false;
            return (this.Country.Equals(temp.Country) && (this.Obl.Equals(temp.Obl) && (this.City.Equals(temp.City)) && (this.Street.Equals(temp.Street)) && (this.Number.Equals(temp.Number))));
        }
        public Gorod BaseGorod
        {
            get
            {
                return new Gorod(Country, Obl, City);
            }
        }
        public string Street
        {
            get
            {
                if (street != null) return street;
                else return "Улица не обозначена";
            }
            set
            {
                if (value != "" && value != " ")
                    street = value;
            }
        }

        public int Number
        {
            get
            {
                if (number > 0) return number;
                else return 0;
            }
            set
            {
                if (value > 0) number = value;
                else if (value < 0) Console.WriteLine("Номер дома не может быть отрицательным!");
            }
        }


        public Address(string state = "Страна отсутствует", string obl = "Область отсутствует", string city1 = "Город отсутствует", string str = "Улица отсутствует", int num = 0) : base(state, obl, city1)
        {
            Number = num;
            Street = str;
            Code += str.Length * 10 + num / 10;
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
            do
            {
                Console.WriteLine("Введите улицу: ");
                Street = Console.ReadLine();
            } while (Street == null);
            do
            {
                Console.WriteLine("Введите номер дома ");
                int n;
                Int32.TryParse(Console.ReadLine(), out n);
                Number = n;
            } while (City == null);
            Code = City.Length * 1000 + Country.Length * 10000000 + Obl.Length * 100000 + Street.Length * 10 + Number / 10;

        }
        public override void Show()
        {
            Console.WriteLine("Страна " + Country + " Область " + Obl + " город " + City + " улица " + Street + " дом " + Number + " Население " + Population + " чел.");
        }
        public override string ToString()
        {
            return Country + " " + Obl + " " + City + " " + Street + " " + Number + " Население " + Population + " чел.";
        }

        public override int GetHashCode()
        {
            var hashCode = 1827137059;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + number.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(street);
            hashCode = hashCode * -1521134295 + EqualityComparer<Gorod>.Default.GetHashCode(BaseGorod);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Street);
            hashCode = hashCode * -1521134295 + Number.GetHashCode();
            return hashCode;
        }
    }
}
