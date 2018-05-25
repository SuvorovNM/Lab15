using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab15
{
    abstract class Mesto
    {
        private string information;
        double code;
        private int population;
        protected string[] countries = new string[] { "Россия","США","Франция","Германия","Норвегия", "Финляндия", "Швеция", "Швейцария", "Дания"
        ,"Нидерланды","Люксембург","Беларусь","Казахстан","Оман","Украина","ОАЭ","Саудовская Аравия","Узбекистан","Таджикистан",
            "Афганистан","Азербайджан","Армения","Грузия","Литва","Латвия","Эстония","Египет","Ливия","Зимбабве"};
        protected string[] cities = new string[] { "Пермь", "Москва", "Нью-Йорк", "Вашингтон", "Париж", "Берлин", "Дюссельдорф", "Гамбург", "Осло",
            "Хельсинки", "Маскат", "Стокгольм", "Цюрих", "Женева", "Берн", "Минск", "Киев", "Харьков", "Одесса", "Донецк", "Луганск", "Ялта" };
        protected string[] Obls = new string[] { "Пермский край", "Свердловская область", "Краснодарский край", "Республика Саха", "Тюменская область",
            "Штат Вашингтон","Штат Луизина","Киевская область","Донецкая область","Луганская область","Московская область","Ивановская область" };
        protected string[] str = new string[] { "Мира", "Ленина", "9-го Мая", "Декабристов", "Советская","Свободы","Моторостроителей","Победы","Мейн-стрит",
        "Хай-стрит","Нефтянников","Комбайнеров","Гагарина","Чайковского","Куйбышева","Чкалова","Свиязева","Студенческая","Баумана","Беляева"};
        protected static Random rnd = new Random();
        public string Country
        {
            get
            {
                if (information == null || information == "" || information == " ")
                    return "Страна не указана!";
                else return information;
            }
            set
            {
                if (value.Length > 1) information = value;
                else Console.WriteLine("Некорректное название страны!");
            }
        }

        public double Code { get { return code; } set { code = value; } }

        public int Population { get { return population; } set { population = value; } }

        public Mesto(string s = "Страна отсутствует")
        {
            Country = s;
            Code = s.Length * 10000000;
        }
        public virtual void Show()
        {
        }
        public abstract void Input();
        public override string ToString()
        {
            return information;
        }
        public virtual void Generate()
        {
        }
    }
}
