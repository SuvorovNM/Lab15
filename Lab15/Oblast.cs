using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab15
{
    class Oblast : Mesto, ICloneable
    {
        private string oblast;
        public override bool Equals(object obj)
        {
            Oblast ob = (Oblast)obj;
            return (this.Country.Equals(ob.Country) && (this.Obl.Equals(ob.Obl)));
        }
        public Oblast(string s = "Страна отсутствует", string c = "Область отсутствует") : base(s)
        {
            Obl = c;
            Code += c.Length * 100000;
        }
        public override void Generate()
        {
            Country = countries[rnd.Next(0, countries.Length)];
            Obl = Obls[rnd.Next(0, Obls.Length)];
            Population = rnd.Next(10000, 2000000);
        }

        public Object Clone()
        {
            return new Oblast("Клон " + this.Country, this.Obl);
        }
        public string Obl
        {
            get
            {
                if (oblast == null || oblast == "" || oblast == " ")
                    return "Область не указана!";
                else return oblast;
            }
            set
            {
                if (value.Length > 1) oblast = value;
                else Console.WriteLine("Некорректное название области!");
            }
        }

        public override void Show()
        {
            Console.WriteLine("Страна " + base.Country + " Область " + Obl+" Население "+Population+" чел.");
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
            Code = Country.Length * 10000000 + Obl.Length * 100000;
        }
        public override string ToString()
        {
            return Country + " " + Obl + " Население " + Population + " чел.";
        }

        public override int GetHashCode()
        {
            var hashCode = 1351520924;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(oblast);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Obl);
            return hashCode;
        }
    }
}
