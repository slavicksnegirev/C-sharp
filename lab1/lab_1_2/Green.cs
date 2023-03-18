using System;
namespace lab_1_2
{
    public class Green : Tea
    {
        private string _taste;

        public string Taste
        {
            get => _taste;
            set => _taste = value;
        }

        public Green(string name = "Green", string countryProducer = null, bool bergamot = false, double volume = 0, int seconds = 0, int minutes = 0, int hours = 0, int day = 0, int month = 0, int year = 0, int choice = 0, string taste = "Сладкий") : base(name, countryProducer, bergamot, volume, seconds, minutes, hours, day, month, year, choice)
        {
            _taste = taste;
        }

        public override string ToString()
        {
            return $"\nСтрана-производитель: {CountryProducer}\nСодержание бергамота: {Bergamot}\nОбъем: {Volume}\nВкус: {Taste}\nВремя изготовления: {Hours}:{Minutes}:{Seconds}\nДата изготовления: {Day}.{Month}.{Year} г.";
        }

        public void ChangeTaste()
        {
            Console.WriteLine("\nКажется что-то произошло с напитком. Попробуйте его еще раз и напишите новый вкус чая: ");
            _taste = Console.ReadLine();
        }

        public new static void ShowClassName()
        {
            Console.WriteLine("\nИмя класса: 'Green'.");
            Tea.ShowClassName();
        }

        public override void FiveOClock()
        {
            Console.WriteLine("\nВремя пить зеленый чай!");
        }

        public override void InputData()
        {
            base.InputData();
            Console.WriteLine("Введите вкус: ");
            _taste = Console.ReadLine();
            Console.WriteLine("------------------------------------------------");
        }
    }
}